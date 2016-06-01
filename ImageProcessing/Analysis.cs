using System.Drawing;
using System.Linq;

using AForge.Imaging;

namespace ImageProcessing
{
    public static class Analysis
    {
        public static HistogramData GetHistogramData(Bitmap bitmap)
        {
            ImageStatistics imageStatistics = new ImageStatistics(bitmap);

            return new HistogramData {
                                         Red = imageStatistics.RedWithoutBlack.Values,
                                         MaxRed = imageStatistics.RedWithoutBlack.Values.Max(),
                                         Blue = imageStatistics.BlueWithoutBlack.Values,
                                         MaxBlue = imageStatistics.BlueWithoutBlack.Values.Max(),
                                         Green = imageStatistics.GreenWithoutBlack.Values,
                                         MaxGreen = imageStatistics.GreenWithoutBlack.Values.Max()
                                     };
        }

        public class HistogramData

        {
            public int[] Blue { get; internal set; }
            public int[] Green { get; internal set; }
            public int MaxBlue { get; internal set; }
            public int MaxGreen { get; internal set; }
            public int MaxRed { get; internal set; }
            public int[] Red { get; internal set; }
        }
    }
}
