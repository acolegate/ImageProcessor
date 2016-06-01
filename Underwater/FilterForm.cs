using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using ImageProcessing;

namespace ImageProcessor.Underwater
{
    public partial class FilterForm : Form
    {
        private const decimal DefaultGamma = (decimal)1.0;
        private const int DefaultGammaTrackbarValue = (int)(DefaultGamma * 100);
        private readonly Orientation _orientation;

        private readonly Bitmap _original;

        private decimal _blueGamma;
        private decimal _greenGamma;
        private Bitmap _originalThumbnail;
        private decimal _redGamma;
        private byte _redHighValueClip;
        private byte _redIntensity = 255;
        private Bitmap _screened;

        public FilterForm(Bitmap bitmap)
        {
            _original = bitmap;

            InitializeComponent();

            beforePictureBox.Image = bitmap;

            _orientation = _original.Width >= _original.Height ? Orientation.Landscape : Orientation.Portrait;

            SetControlDefaults();

            MakeThumbnailImage();

            beforePictureBox.Image = _originalThumbnail;

            ApplyFilterToThumbnail();
        }

        private enum Orientation
        {
            Portrait = 0,
            Landscape = 1
        }

        public Bitmap FilteredOriginal { get; private set; }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            ApplyFilterToOriginal();
        }

        private void ApplyFilterToOriginal()
        {
            _screened = null;
            FilteredOriginal = GenerateRedData(_original);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ApplyFilterToThumbnail()
        {
            afterPictureBox.Image = GenerateRedData(_originalThumbnail);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            FilteredOriginal = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void GammaTrackBar_Scroll(object sender, EventArgs e)
        {
            _redGamma = (decimal)redGammaTrackBar.Value / 100;
            _greenGamma = (decimal)greenGammaTrackBar.Value / 100;
            _blueGamma = (decimal)blueGammaTrackBar.Value / 100;

            ApplyFilterToThumbnail();
        }

        private Bitmap GenerateRedData(Bitmap sourceBitmap)
        {
            if (_screened == null)
            {
                Bitmap bitmap = sourceBitmap.Clone(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), PixelFormat.Format24bppRgb);

                Bitmap luminosity = Composition.ExtractChannel(bitmap, Composition.ChannelType.Luminosity, PixelFormat.Format24bppRgb);

                Color red = Color.FromArgb(_redIntensity, 0, 0);

                Bitmap solidRed = Creation.Create(sourceBitmap.Width, sourceBitmap.Height, red, PixelFormat.Format24bppRgb);
                Bitmap redLuminosity = Composition.Merge(luminosity, solidRed, Composition.CompositionType.Multiply, PixelFormat.Format24bppRgb);
                _screened = Composition.Merge(redLuminosity, bitmap, Composition.CompositionType.Screen, PixelFormat.Format24bppRgb);
            }

            Bitmap filtered = _screened;

            // apply the red levels
            filtered = Processing.SetRgbGamma(filtered, _redGamma, _greenGamma, _blueGamma, PixelFormat.Format24bppRgb);
            filtered = Processing.ClipRedHighValue(filtered, _redHighValueClip, PixelFormat.Format24bppRgb);

            return filtered;
        }

        private void MakeThumbnailImage()
        {
            _originalThumbnail = _orientation == Orientation.Portrait ? CropResize.ResizeToHeightMaintainAspect(_original, afterPictureBox.Height) : CropResize.ResizeToWidthMaintainAspect(_original, afterPictureBox.Height);
        }

        private void RedGenerationIntensityTrackBar_Scroll(object sender, EventArgs e)
        {
            _redIntensity = (byte)redGenerationIntensityTrackBar.Value;

            _screened = null;
            ApplyFilterToThumbnail();
        }

        private void RedHighValueClipTrackBar_Scroll(object sender, EventArgs e)
        {
            _redHighValueClip = (byte)redHighValueClipTrackBar.Value;
            ApplyFilterToThumbnail();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void ResetValues()
        {
            SetControlDefaults();

            ApplyFilterToThumbnail();
        }

        private void SetControlDefaults()
        {
            _redIntensity = 255;
            redGenerationIntensityTrackBar.Value = 255;

            _redHighValueClip = 255;
            redHighValueClipTrackBar.Value = 255;

            redGammaTrackBar.Value = DefaultGammaTrackbarValue;
            greenGammaTrackBar.Value = DefaultGammaTrackbarValue;
            blueGammaTrackBar.Value = DefaultGammaTrackbarValue;

            _redGamma = DefaultGamma;
            _greenGamma = DefaultGamma;
            _blueGamma = DefaultGamma;
        }
    }
}
