using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

using Histogram;

using ImageProcessing;

using ImageProcessor.CustomRenderers;
using ImageProcessor.Properties;
using ImageProcessor.Underwater;

namespace ImageProcessor.Forms
{
    public partial class MainForm : Form
    {
        private readonly Cursor _grabbingHandCursor = CursorResourceLoader.LoadEmbeddedCursor(Resources.grabbinghand);
        private readonly Cursor _openHandCursor = CursorResourceLoader.LoadEmbeddedCursor(Resources.openhand);

        private Bitmap _bitmap;
        private long _bitmapFileSize;
        private bool _changesMade;
        private bool _dragging;
        private PictureBoxSizeMode _sizeMode;
        private int _xPos;
        private int _yPos;

        public MainForm()
        {
            InitializeComponent();
            toolStrip.Renderer = new MyToolStripRenderer();
        }

        private int JpegQualityQuantised
        {
            get
            {
                return (int)Math.Floor(Save.EstimateJpegQuality(_bitmap, _bitmapFileSize) * 0.12);
            }
        }

        private bool PicturePanelScrollbarsVisible
        {
            get
            {
                return picturePanel.VerticalScroll.Visible || picturePanel.HorizontalScroll.Visible;
            }
        }

        private static bool GetFilename(out string filename, DragEventArgs e)
        {
            bool returnValue = false;
            filename = String.Empty;

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = e.Data.GetData("FileName") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        string extension = Path.GetExtension(filename);

                        if (extension != null)
                        {
                            string ext = extension.ToLower();
                            if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp"))
                            {
                                returnValue = true;
                            }
                        }
                    }
                }
            }

            return returnValue;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog(this);
        }

        private void ClearTitleBar()
        {
            Text = "Image Processor";
        }

        private void CloseImage()
        {
            pictureBox.Image = null;
            _bitmap = null;
            _bitmapFileSize = 0;
            _changesMade = false;

            SetSizeModeToFit();

            ClearTitleBar();

            SetMenuAvailability();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ContinueClosingImage(string.Format("Save changes to \"{0}\" before closing?", Path.GetFileName(openFileDialog.FileName))))
            {
                CloseImage();
            }
        }

        private bool ContinueClosingImage(string message)
        {
            if (_changesMade)
            {
                DialogResult dialogResult = MessageBox.Show(this, message, "Image Processor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                    {
                        SaveChanges();
                        return true;
                    }
                    case DialogResult.No:
                    {
                        return true;
                    }
                    default:
                    {
                        // cancel
                        return false;
                    }
                }
            }
            return true;
        }

        private void ExitApp()
        {
            Close();
        }

        private void FitToolStripButton_Click(object sender, EventArgs e)
        {
            SetSizeModeToFit();
            UpdatePicture();
        }

        private void LoadAndDisplayImage(string fileName)
        {
            LoadImage(fileName);
            SetSizeModeToFit();
            UpdatePicture();

            SetTitleBar();

            SetMenuAvailability();
        }

        private void LoadImage(string filename)
        {
            _bitmapFileSize = new FileInfo(filename).Length;

            _bitmap = Conversion.ConvertPixelFormat(new Bitmap(Image.FromFile(filename)), PixelFormat.Format24bppRgb);

            _changesMade = false;

            SetTitleBar();
        }

        // HACK: Remove this 
        private void LoadTestImage()
        {
            openFileDialog.FileName = @"C:\Projects\Personal\ImageProcessor\Resources\Test Images\turtle1.jpg";

            LoadImage(openFileDialog.FileName);

            UpdatePicture();

            SetTitleBar();
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            bool showError = false;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string filename;
                if (GetFilename(out filename, e))
                {
                    openFileDialog.FileName = filename;

                    LoadAndDisplayImage(filename);
                }
                else
                {
                    // not a valid filename extension
                    showError = true;
                }
            }
            else
            {
                // not a valid data format
                showError = true;
            }

            if (showError)
            {
                MessageBox.Show(this, "Only files of type JPEG, PNG or BMP can be dropped  into this app", "ImageProcessor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string filename;
                if (GetFilename(out filename, e))
                {
                    // it has a valid file extension
                    e.Effect = DragDropEffects.Copy;
                }
            }
            else
            {
                // not a valid data format
                e.Effect = DragDropEffects.None;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // HACK: Remove this
            LoadTestImage();

            SetSizeModeToFit();
            UpdatePicture();

            SetTitleBar();

            SetMenuAvailability();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (_sizeMode == PictureBoxSizeMode.AutoSize)
            {
                RepositionPictureBox();
            }
        }

        private void OneToOneToolStripButton_Click(object sender, EventArgs e)
        {
            SetSizeModeToOneToOne();
            UpdatePicture();

            RepositionPictureBox();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ContinueClosingImage(string.Format("Save changes to '{0}' ?", Path.GetFileName(openFileDialog.FileName))))
            {
                ShowOpenFileDialogue();
            }
        }

        private void PanelOrPictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowOpenFileDialogue();
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && PicturePanelScrollbarsVisible)
            {
                _dragging = true;

                _xPos = e.X;
                _yPos = e.Y;

                Cursor = _grabbingHandCursor;
            }
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (PicturePanelScrollbarsVisible)
            {
                Cursor = _openHandCursor;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                int top = e.Y + pictureBox.Top - _yPos;
                if (top > 0 || Math.Abs(top) + picturePanel.ClientSize.Height >= pictureBox.Height)
                {
                    if (top > 0)
                    {
                        top = 0;
                    }
                    else
                    {
                        top = pictureBox.Height - picturePanel.ClientSize.Height;
                    }
                }
                else
                {
                    top = Math.Abs(top);
                }

                int left = e.X + pictureBox.Left - _xPos;
                if (left > 0 || Math.Abs(left) + picturePanel.ClientSize.Width >= pictureBox.Width)
                {
                    if (left > 0)
                    {
                        left = 0;
                    }
                    else
                    {
                        left = pictureBox.Width - picturePanel.ClientSize.Width;
                    }
                }
                else
                {
                    left = Math.Abs(left);
                }

                if (picturePanel.AutoScrollPosition.X != left || picturePanel.AutoScrollPosition.Y != top)
                {
                    picturePanel.AutoScrollPosition = new Point(Math.Abs(left), Math.Abs(top));
                }
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;

            if (PicturePanelScrollbarsVisible)
            {
                Cursor = _openHandCursor;
            }
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ContinueClosingImage(string.Format("Save changes to \"{0}\" before closing?", Path.GetFileName(openFileDialog.FileName))))
            {
                ExitApp();
            }
        }

        private void RepositionPictureBox()
        {
            pictureBox.Location = new Point(pictureBox.Parent.ClientSize.Width > pictureBox.Width ? (pictureBox.Parent.ClientSize.Width / 2) - (pictureBox.Width / 2) : 0, pictureBox.Parent.ClientSize.Height > pictureBox.Height ? (pictureBox.Parent.ClientSize.Height / 2) - (pictureBox.Height / 2) : 0);
        }

        private void RevertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ContinueClosingImage(string.Format("Save changes to '{0}' before reverting?", Path.GetFileName(openFileDialog.FileName))))
            {
                LoadImage(openFileDialog.FileName);
            }

            UpdatePicture();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(openFileDialog.FileName);
            saveFileDialog.FileName = Path.GetFileName(openFileDialog.FileName);

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                using (SaveJpegForm saveJpegForm = new SaveJpegForm(_bitmap, JpegQualityQuantised, true))
                {
                    saveJpegForm.ShowHidePreviewChanged += SaveJpegForm_ShowHidePreview;

                    Enabled = false;

                    if (saveJpegForm.ShowDialog(this) == DialogResult.OK)
                    {
                        Save.SaveJpeg(_bitmap, saveFileDialog.FileName, saveJpegForm.JpegQuality);
                        openFileDialog.FileName = saveFileDialog.FileName;

                        SetTitleBar();

                        _changesMade = false;
                    }

                    if (saveJpegForm.ShowPreview)
                    {
                        // put the image back again
                        pictureBox.Image = _bitmap;
                    }
                }
            }
        }

        private void SaveChanges()
        {
            using (SaveJpegForm saveJpegForm = new SaveJpegForm(_bitmap, JpegQualityQuantised, true))
            {
                saveJpegForm.ShowHidePreviewChanged += SaveJpegForm_ShowHidePreview;

                Enabled = false;

                if (saveJpegForm.ShowDialog(this) == DialogResult.OK)
                {
                    Save.SaveJpeg(_bitmap, openFileDialog.FileName, saveJpegForm.JpegQuality);

                    _changesMade = false;
                }

                if (saveJpegForm.ShowPreview)
                {
                    // put the image back again
                    pictureBox.Image = _bitmap;
                }
            }

            Enabled = true;
        }

        private void SaveJpegForm_ShowHidePreview(object sender, ShowHidePreviewEventHandlerArgs args)
        {
            if (args.ShowPreview && args.PreviewJpeg != null)
            {
                // show the preview
                pictureBox.Image = args.PreviewJpeg.Bitmap;
            }
            else
            {
                // show the unpreviewed image again
                pictureBox.Image = _bitmap;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveChanges();

            _changesMade = false;
        }

        private void SetMenuAvailability()
        {
            bool bitmapLoaded = _bitmap != null;

            // file menu
            closeToolStripMenuItem.Enabled = bitmapLoaded;
            saveAsToolStripMenuItem.Enabled = bitmapLoaded;
            saveToolStripMenuItem.Enabled = bitmapLoaded;
            revertToolStripMenuItem.Enabled = bitmapLoaded;

            // filters menu
            underwaterToolStripMenuItem.Enabled = bitmapLoaded;
            levelsToolStripMenuItem.Enabled = bitmapLoaded;
        }

        private void SetSizeModeButtonState()
        {
            if (_sizeMode == PictureBoxSizeMode.Zoom)
            {
                fitToolStripButton.Checked = true;
                oneToOneToolStripButton.Checked = false;
            }
            else
            {
                fitToolStripButton.Checked = false;
                oneToOneToolStripButton.Checked = true;
            }
        }

        private void SetSizeModeToFit()
        {
            pictureBox.Dock = DockStyle.Fill;
            _sizeMode = PictureBoxSizeMode.Zoom;

            SetSizeModeButtonState();
        }

        private void SetSizeModeToOneToOne()
        {
            pictureBox.Dock = DockStyle.None;
            _sizeMode = PictureBoxSizeMode.AutoSize;

            SetSizeModeButtonState();
        }

        private void SetTitleBar()
        {
            string fileName = Path.GetFileName(openFileDialog.FileName);

            Text = string.Format("Image Processor - {0}", fileName);
        }

        private void ShowOpenFileDialogue()
        {
            DialogResult dialogResult = openFileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                LoadAndDisplayImage(openFileDialog.FileName);
            }
        }

        private void UnderwaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_bitmap != null)
            {
                FilterForm filterForm = new FilterForm(_bitmap);
                DialogResult dialogResult = filterForm.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    _bitmap = filterForm.FilteredOriginal;

                    pictureBox.Image = _bitmap;

                    _changesMade = true;
                }
            }
        }

        private void UpdatePicture()
        {
            pictureBox.SizeMode = _sizeMode;
            pictureBox.Image = _bitmap;
        }

        private void LevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (LevelsForm levelsForm = new LevelsForm(_bitmap))
            {
                levelsForm.LevelsChanged += LevelsForm_LevelsChanged;

                DialogResult dialogResult = levelsForm.ShowDialog(this);

                if (dialogResult == DialogResult.OK)
                {
                    // apply the changes
                    _bitmap = levelsForm.FilteredBitmap;
                    _changesMade = true;
                    UpdatePicture();
                }
                else
                {
                    // revert the changes
                    pictureBox.Image = _bitmap;
                }

            }
        }

        void LevelsForm_LevelsChanged(object sender, LevelsForm.LevelsChangedEventHandlerArgs args)
        {
            if (args.ShowPreview)
            {
                // show the new image
                pictureBox.Image = args.Bitmap;
            }
            else
            {
                // redisplay the original again
                pictureBox.Image = _bitmap;
            }
        }
    }
}
