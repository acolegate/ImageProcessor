using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using ImageProcessing;

namespace Histogram
{
    public partial class LevelsForm : Form
    {
        private const int HistogramHeight = 66;
        private readonly Bitmap _bitmap;

        private byte _blueBlackClip;
        private byte _blueHighlightsSliderPos;
        private byte _blueShadowsSliderPos;
        private byte _blueWhiteClip;

        private Channel _currentChannel;
        private byte _greenBlackClip;
        private byte _greenHighlightsSliderPos;
        private byte _greenShadowsSliderPos;
        private byte _greenWhiteClip;

        private Analysis.HistogramData _histogramData;
        private byte _redBlackClip;
        private byte _redHighlightsSliderPos;
        private byte _redShadowsSliderPos;
        private byte _redWhiteClip;

        private bool _showPreview;

        public LevelsForm(Bitmap bitmap)
        {
            _bitmap = bitmap;

            InitializeComponent();

            GetHistogramData();

            InitialiseControls();
        }

        public delegate void LevelsChangedEventHandler(object sender, LevelsChangedEventHandlerArgs args);

        public event LevelsChangedEventHandler LevelsChanged;

        private enum Channel
        {
            Red = 0,
            Green = 1,
            Blue = 2
        }

        public Bitmap FilteredBitmap { get; private set; }

        private static byte FirstIndexAboveThresholdPercent(IList<int> array, int max)
        {
            byte i;
            decimal decimalPercentage;
            int barHeight;

            for (i = 0; i < 255; i++)
            {
                decimalPercentage = array[i] / (decimal)max;
                barHeight = (int)(decimalPercentage * HistogramHeight);

                if (barHeight >= 1)
                {
                    break;
                }
            }

            return i;
        }

        private static byte LastIndexAboveThresholdPercent(IList<int> array, int max)
        {
            byte i;
            decimal decimalPercentage;
            int barHeight;

            for (i = 255; i > 0; i--)
            {
                decimalPercentage = array[i] / (decimal)max;
                barHeight = (int)(decimalPercentage * HistogramHeight);

                if (barHeight >= 1)
                {
                    break;
                }
            }

            return i;
        }

        private void DrawChannelHistogram(IList<int> data, int maxValue)
        {
            histogramPictureBox.Image = new Bitmap(265, HistogramHeight, PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(histogramPictureBox.Image))
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    for (int i = 0; i < 255; i++)
                    {
                        decimal decimalPercentage = data[i] / (decimal)maxValue;

                        int barHeight = (int)(decimalPercentage * HistogramHeight);

                        if (barHeight >= 1)
                        {
                            graphics.DrawLine(pen, i, HistogramHeight, i, HistogramHeight - barHeight);
                        }
                    }
                }
            }

            histogramPictureBox.Refresh();
        }

        private Bitmap ApplyLevels(Bitmap bitmap)
        {
            return Processing.ApplyCustomLevels(bitmap, _redShadowsSliderPos, _redHighlightsSliderPos, _redBlackClip, _redWhiteClip, _greenShadowsSliderPos, _greenHighlightsSliderPos, _greenBlackClip, _greenWhiteClip, _blueShadowsSliderPos, _blueHighlightsSliderPos, _blueBlackClip, _blueWhiteClip);
        }

        private void ApplyLevelsToOriginal()
        {
            FilteredBitmap = ApplyLevels(_bitmap);
        }

        private void AutoButton_Click(object sender, EventArgs e)
        {
            _redShadowsSliderPos = FirstIndexAboveThresholdPercent(_histogramData.Red, _histogramData.MaxRed);
            _greenShadowsSliderPos = FirstIndexAboveThresholdPercent(_histogramData.Green, _histogramData.MaxGreen);
            _blueShadowsSliderPos = FirstIndexAboveThresholdPercent(_histogramData.Blue, _histogramData.MaxBlue);

            _redHighlightsSliderPos = LastIndexAboveThresholdPercent(_histogramData.Red, _histogramData.MaxRed);
            _greenHighlightsSliderPos = LastIndexAboveThresholdPercent(_histogramData.Green, _histogramData.MaxGreen);
            _blueHighlightsSliderPos = LastIndexAboveThresholdPercent(_histogramData.Blue, _histogramData.MaxBlue);

            SetSliderPositions();

            if (_showPreview)
            {
                UpdatePreview();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            FilteredBitmap = null;

            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ChannelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentChannel = (Channel)channelComboBox.SelectedIndex;

            DrawHistogram();

            SetSliderPositions();
        }

        private void DrawHistogram()
        {
            switch ((Channel)channelComboBox.SelectedIndex)
            {
                case Channel.Red:
                {
                    DrawChannelHistogram(_histogramData.Red, _histogramData.MaxRed);
                    break;
                }
                case Channel.Green:
                {
                    DrawChannelHistogram(_histogramData.Green, _histogramData.MaxGreen);
                    break;
                }
                case Channel.Blue:
                {
                    DrawChannelHistogram(_histogramData.Blue, _histogramData.MaxBlue);
                    break;
                }
            }
        }

        private void GetHistogramData()
        {
            _histogramData = Analysis.GetHistogramData(_bitmap);
        }

        private void InitialiseControls()
        {
            // turn off events
            inputLevelsSlider.ValuesChanged -= Sliders_ValuesChanged;
            outputLevelsSlider.ValuesChanged -= Sliders_ValuesChanged;

            channelComboBox.SelectedIndex = 0;
            _showPreview = true;
            showPreviewCheckBox.Checked = true;

            _redShadowsSliderPos = 0;
            _redHighlightsSliderPos = 255;
            _redBlackClip = 0;
            _redWhiteClip = 255;

            _greenShadowsSliderPos = 0;
            _greenHighlightsSliderPos = 255;
            _greenBlackClip = 0;
            _greenWhiteClip = 255;

            _blueShadowsSliderPos = 0;
            _blueHighlightsSliderPos = 255;
            _blueBlackClip = 0;
            _blueWhiteClip = 255;

            inputLevelsShadowsTextBox.Text = "0";
            inputLevelsHighlightsTextBox.Text = "255";

            outputLevelsBlackClipTextBox.Text = "0";
            outputLevelsWhiteClipTextBox.Text = "255";

            SetSliderPositions();

            _currentChannel = Channel.Red;
            channelComboBox.SelectedIndex = 0;

            // turn on events
            inputLevelsSlider.ValuesChanged += Sliders_ValuesChanged;
            outputLevelsSlider.ValuesChanged += Sliders_ValuesChanged;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            ApplyLevelsToOriginal();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void RaiseShowHidePreviewEvent(LevelsChangedEventHandlerArgs args)
        {
            LevelsChangedEventHandler handler = LevelsChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            InitialiseControls();
        }

        private void SetSliderPositions()
        {
            byte shadowSliderValue = 0;
            byte highlightsSliderValue = 255;
            byte outputBlackClipSliderValue = 0;
            byte outputWhiteClipSliderValue = 255;

            switch ((Channel)channelComboBox.SelectedIndex)
            {
                case Channel.Red:
                {
                    shadowSliderValue = _redShadowsSliderPos;
                    highlightsSliderValue = _redHighlightsSliderPos;
                    outputBlackClipSliderValue = _redBlackClip;
                    outputWhiteClipSliderValue = _redWhiteClip;
                    break;
                }
                case Channel.Green:
                {
                    shadowSliderValue = _greenShadowsSliderPos;
                    highlightsSliderValue = _greenHighlightsSliderPos;
                    outputBlackClipSliderValue = _greenBlackClip;
                    outputWhiteClipSliderValue = _greenWhiteClip;
                    break;
                }
                case Channel.Blue:
                {
                    shadowSliderValue = _blueShadowsSliderPos;
                    highlightsSliderValue = _blueHighlightsSliderPos;
                    outputBlackClipSliderValue = _blueBlackClip;
                    outputWhiteClipSliderValue = _blueWhiteClip;
                    break;
                }
            }

            inputLevelsSlider.ShadowsSliderValue = shadowSliderValue;
            inputLevelsSlider.HighlightsSliderValue = highlightsSliderValue;
            outputLevelsSlider.ShadowsSliderValue = outputBlackClipSliderValue;
            outputLevelsSlider.HighlightsSliderValue = outputWhiteClipSliderValue;

            inputLevelsShadowsTextBox.Text = shadowSliderValue.ToString();
            inputLevelsHighlightsTextBox.Text = highlightsSliderValue.ToString();

            outputLevelsBlackClipTextBox.Text = outputBlackClipSliderValue.ToString();
            outputLevelsWhiteClipTextBox.Text = outputWhiteClipSliderValue.ToString();
        }

        private void ShowPreviewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _showPreview = showPreviewCheckBox.Checked;

            if (_showPreview)
            {
                UpdatePreview();
            }
            else
            {
                RaiseShowHidePreviewEvent(new LevelsChangedEventHandlerArgs(false));
            }
        }

        private void Sliders_ValuesChanged(object sender, TwoSliderControl.ValuesChangedEventHandlerArgs args)
        {
            switch (_currentChannel)
            {
                case Channel.Red:
                {
                    _redShadowsSliderPos = inputLevelsSlider.ShadowsSliderValue;
                    _redHighlightsSliderPos = inputLevelsSlider.HighlightsSliderValue;
                    _redBlackClip = outputLevelsSlider.ShadowsSliderValue;
                    _redWhiteClip = outputLevelsSlider.HighlightsSliderValue;
                    break;
                }
                case Channel.Green:
                {
                    _greenShadowsSliderPos = inputLevelsSlider.ShadowsSliderValue;
                    _greenHighlightsSliderPos = inputLevelsSlider.HighlightsSliderValue;
                    _greenBlackClip = outputLevelsSlider.ShadowsSliderValue;
                    _greenWhiteClip = outputLevelsSlider.HighlightsSliderValue;
                    break;
                }
                case Channel.Blue:
                {
                    _blueShadowsSliderPos = inputLevelsSlider.ShadowsSliderValue;
                    _blueHighlightsSliderPos = inputLevelsSlider.HighlightsSliderValue;
                    _blueBlackClip = outputLevelsSlider.ShadowsSliderValue;
                    _blueWhiteClip = outputLevelsSlider.HighlightsSliderValue;
                    break;
                }
            }

            // update text boxes
            inputLevelsShadowsTextBox.Text = inputLevelsSlider.ShadowsSliderValue.ToString();
            inputLevelsHighlightsTextBox.Text = inputLevelsSlider.HighlightsSliderValue.ToString();

            outputLevelsBlackClipTextBox.Text = outputLevelsSlider.ShadowsSliderValue.ToString();
            outputLevelsWhiteClipTextBox.Text = outputLevelsSlider.HighlightsSliderValue.ToString();

            if (_showPreview)
            {
                UpdatePreview();
            }
        }

        private void UpdatePreview()
        {
            Bitmap preview = ApplyLevels(_bitmap);

            RaiseShowHidePreviewEvent(new LevelsChangedEventHandlerArgs(true, preview));
        }

        public class LevelsChangedEventHandlerArgs
        {
            public LevelsChangedEventHandlerArgs(bool showPreview, Bitmap previewBitmap = null)
            {
                ShowPreview = showPreview;
                Bitmap = previewBitmap;
            }

            public Bitmap Bitmap { get; internal set; }
            public bool ShowPreview { get; internal set; }
        }
    }
}
