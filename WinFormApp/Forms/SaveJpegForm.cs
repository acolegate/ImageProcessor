using System;
using System.Drawing;
using System.Windows.Forms;

using ImageProcessing;

namespace ImageProcessor.Forms
{
    public sealed partial class SaveJpegForm : Form
    {
        private const int DefaultJpegQuality = 8;
        private const bool DefaultShowPreview = false;
        private readonly Bitmap _bitmap;
        private int _jpegQuality;

        public SaveJpegForm(Bitmap bitmap, int jpeqQuality = DefaultJpegQuality, bool showPreview = DefaultShowPreview)
        {
            InitializeComponent();

            _bitmap = bitmap;
            _jpegQuality = jpeqQuality;
            ShowPreview = showPreview;
            _bitmap = bitmap;
        }

        public event ShowHidePreviewEventHandler ShowHidePreviewChanged;

        public int JpegQuality {
            get
            {
                return JpegQualityToPercentage(_jpegQuality);
            }

        }

        public bool ShowPreview { get; private set; }

        private static string FormatFileSize(long size)
        {
            if (size < 1024)
            {
                return (size).ToString("F0") + " bytes";
            }
            if (size < Math.Pow(1024, 2))
            {
                return (size / 1024).ToString("F0") + " KB";
            }
            if (size < Math.Pow(1024, 3))
            {
                return (size / Math.Pow(1024, 2)).ToString("F0") + " MB";
            }
            if (size < Math.Pow(1024, 4))
            {
                return (size / Math.Pow(1024, 3)).ToString("F0") + " GB";
            }
            if (size < Math.Pow(1024, 5))
            {
                return (size / Math.Pow(1024, 4)).ToString("F0") + " TB";
            }
            if (size < Math.Pow(1024, 6))
            {
                return (size / Math.Pow(1024, 5)).ToString("F0") + " PB";
            }
            return (size / Math.Pow(1024, 6)).ToString("F0") + " EB";
        }

        private static int JpegQualityToPercentage(int jpegQuality)
        {
            return (int)(((decimal)jpegQuality / 12) * 100);
        }

        private static int QualityToSelectedIndex(int qualityValue)
        {
            switch (qualityValue)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                {
                    return 0;
                }
                case 5:
                case 6:
                case 7:
                {
                    return 1;
                }
                case 8:
                case 9:
                {
                    return 2;
                }
                default:
                {
                    return 3;
                }
            }
        }

        private static int SelectedValueToQualityValue(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                {
                    return 2;
                }
                case 1:
                {
                    return 5;
                }
                case 2:
                {
                    return 8;
                }
                default:
                {
                    return 10;
                }
            }
        }

        private void DisableControlEvents()
        {
            qualityNumericUpDown.ValueChanged -= QualityNumericUpDown_ValueChanged;
            qualityComboBox.SelectedIndexChanged -= QualityComboBox_SelectedIndexChanged;
            qualityTrackBar.ValueChanged -= QualityTrackBar_ValueChanged;
            showHidePreviewCheckBox.CheckedChanged -= ShowHidePreviewCheckBox_CheckedChanged;
        }

        private void EnableControlEvents()
        {
            qualityNumericUpDown.ValueChanged += QualityNumericUpDown_ValueChanged;
            qualityComboBox.SelectedIndexChanged += QualityComboBox_SelectedIndexChanged;
            qualityTrackBar.ValueChanged += QualityTrackBar_ValueChanged;
            showHidePreviewCheckBox.CheckedChanged += ShowHidePreviewCheckBox_CheckedChanged;
        }

        private void QualityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _jpegQuality = SelectedValueToQualityValue(qualityComboBox.SelectedIndex);

            UpdateAllControls();
        }

        private void QualityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _jpegQuality = (int)qualityNumericUpDown.Value;

            UpdateAllControls();
        }

        private void QualityTrackBar_ValueChanged(object sender, EventArgs e)
        {
            _jpegQuality = qualityTrackBar.Value;

            UpdateAllControls();
        }

        private void RaiseShowHidePreviewEvent(ShowHidePreviewEventHandlerArgs args)
        {
            ShowHidePreviewEventHandler handler = ShowHidePreviewChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void ShowHidePreviewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ShowPreview = showHidePreviewCheckBox.Checked;

            UpdateAllControls();
        }

        private void UpdateAllControls()
        {
            DisableControlEvents();

            qualityNumericUpDown.Value = _jpegQuality;
            qualityComboBox.SelectedIndex = QualityToSelectedIndex(_jpegQuality);
            qualityTrackBar.Value = _jpegQuality;
            showHidePreviewCheckBox.Checked = ShowPreview;

            EnableControlEvents();

            PreviewBitmap previewJpeg = ShowPreview ? Save.SaveJpeg(_bitmap, JpegQualityToPercentage(_jpegQuality)) : null;

            RaiseShowHidePreviewEvent(new ShowHidePreviewEventHandlerArgs {
                                                                              ShowPreview = ShowPreview,
                                                                              PreviewJpeg = previewJpeg
                                                                          });

            if (ShowPreview && previewJpeg != null)
            {
                fileSizeLabel.Text = FormatFileSize(previewJpeg.FileSize);
            }
            else
            {
                fileSizeLabel.Text = string.Empty;
            }
        }

        private void SaveJpegForm_Load(object sender, EventArgs e)
        {
            UpdateAllControls();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

    public delegate void ShowHidePreviewEventHandler(object sender, ShowHidePreviewEventHandlerArgs args);

    public class ShowHidePreviewEventHandlerArgs
    {
        public PreviewBitmap PreviewJpeg { get; internal set; }
        public bool ShowPreview { get; internal set; }
    }
}
