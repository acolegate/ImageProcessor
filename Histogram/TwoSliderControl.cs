using System.Drawing;
using System.Windows.Forms;

namespace Histogram
{
    public sealed partial class TwoSliderControl : UserControl
    {
        private static Size mouseOffset;
        private PictureBox _controlBeingDragged;

        private byte _highlightsValue;
        private byte _shadowsValue;

        public TwoSliderControl()
        {
            InitializeComponent();
            InitialiseControls();
        }

        public delegate void ValuesChangedEventHandler(object sender, ValuesChangedEventHandlerArgs args);

        public event ValuesChangedEventHandler ValuesChanged;

        public byte HighlightsSliderValue
        {
            get
            {
                return _highlightsValue;
            }
            set
            {
                _highlightsValue = value;
                highlightsPictureBox.Left = _highlightsValue-1;
            }
        }

        public byte ShadowsSliderValue
        {
            get
            {
                return _shadowsValue;
            }
            set
            {
                _shadowsValue = value;
                shadowsPictureBox.Left = _shadowsValue;
            }
        }

        private void RaiseValueChangedEvent(ValuesChangedEventHandlerArgs args)
        {
            ValuesChangedEventHandler handler = ValuesChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private static int CalcNewXpos(Point location, int left)
        {
            Point newLocationOffset = location - mouseOffset;

            return left + newLocationOffset.X;
        }

        private void InitialiseControls()
        {
            _shadowsValue = 0;
            _highlightsValue = 255;
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseOffset = new Size(e.Location);

            _controlBeingDragged = (PictureBox)sender;
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_controlBeingDragged != null)
            {
                Control control = (Control)sender;

                int newXpos = CalcNewXpos(e.Location, control.Left);

                switch (control.Name)
                {
                    case "shadowsPictureBox":
                    {
                        if (newXpos >= 0 && newXpos < _highlightsValue)
                        {
                            //decimal midtonesPercent = (decimal)_midTonesValue / ((decimal)_highlightsValue - (decimal)_shadowsValue);

                            control.Left = newXpos;

                            _shadowsValue = (byte)newXpos;
                        }
                        break;
                    }
                    default:
                    {
                        if (newXpos > _shadowsValue && newXpos <= 255)
                        {
                            control.Left = newXpos;
                            _highlightsValue = (byte)newXpos;
                        }
                        break;
                    }
                }

                RaiseValueChangedEvent(new ValuesChangedEventHandlerArgs {
                                                                             Shadows = _shadowsValue,
                                                                             Highlights = _highlightsValue
                                                                         });
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _controlBeingDragged = null;
        }

        public class ValuesChangedEventHandlerArgs
        {
            public byte Highlights { get; internal set; }
            public byte Shadows { get; internal set; }
        }
    }
}
