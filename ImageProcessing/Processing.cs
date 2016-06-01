using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math;

namespace ImageProcessing
{
    public static class Processing
    {
        public static Bitmap ApplyCustomLevels(Bitmap sourceBitmap, byte redShadows, byte redHighlights, byte redblackClip, byte redWhiteClip, byte greenShadows, byte greenHighlights, byte greenBlackClip, byte greenWhiteClip, byte blueShadows, byte blueHighlights, byte blueBlackClip, byte blueWhiteClip)
        {
            Bitmap bitmap = new Bitmap(sourceBitmap);

            new LevelsLinear {
                                 InRed = new IntRange(redShadows, redHighlights),
                                 InGreen = new IntRange(greenShadows, greenHighlights),
                                 InBlue = new IntRange(blueShadows, blueHighlights),
                                 OutRed = new IntRange(redblackClip, redWhiteClip),
                                 OutGreen = new IntRange(greenBlackClip, greenWhiteClip),
                                 OutBlue = new IntRange(blueBlackClip, blueWhiteClip)
                             }.ApplyInPlace(bitmap);

            return bitmap;
        }

        /// <summary>Maximises dynamic range of the image while maintaining original colours</summary>
        /// <param name="sourceBitmap">Image to adjust</param>
        /// <param name="blackClipPercent">Percentage of colour volume where black clipping should end</param>
        /// <param name="whiteClipPercent">Percentage of colour volume where white clipping should end</param>
        /// <returns>Adjusted image</returns>
        public static Bitmap AutoLevelsMonochomaticContrast(Bitmap sourceBitmap, decimal blackClipPercent, decimal whiteClipPercent)
        {
            Bitmap bitmap = new Bitmap(sourceBitmap);

            ImageStatistics imageStatistics = new ImageStatistics(bitmap);
            Histogram redHistogram = imageStatistics.RedWithoutBlack;
            Histogram greenHistogram = imageStatistics.GreenWithoutBlack;
            Histogram blueHistogram = imageStatistics.BlueWithoutBlack;

            IntRange redRange = FindFirstAndLastByThreshold(redHistogram, blackClipPercent, whiteClipPercent);
            IntRange greenRange = FindFirstAndLastByThreshold(greenHistogram, blackClipPercent, whiteClipPercent);
            IntRange blueRange = FindFirstAndLastByThreshold(blueHistogram, blackClipPercent, whiteClipPercent);

            IntRange averageRange = new IntRange(MoreMath.Min(redRange.Min, greenRange.Min, blueRange.Min), MoreMath.Max(redRange.Max, greenRange.Max, blueRange.Max));

            new LevelsLinear {
                                 InRed = averageRange,
                                 InGreen = averageRange,
                                 InBlue = averageRange,
                                 Output = new IntRange(0, 255)
                             }.ApplyInPlace(bitmap);

            return bitmap;
        }

        /// <summary>Maximises dynamic range of each colour channel independently</summary>
        /// <param name="sourceBitmap">Image to adjust</param>
        /// <param name="blackClipPercent">Percentage of colour volume where black clipping should end</param>
        /// <param name="whiteClipPercent">Percentage of colour volume where white clipping should end</param>
        /// <returns>Adjusted image</returns>
        public static Bitmap AutoLevelsPerChannelContrast(Bitmap sourceBitmap, decimal blackClipPercent, decimal whiteClipPercent)
        {
            Bitmap bitmap = new Bitmap(sourceBitmap);

            ImageStatistics imageStatistics = new ImageStatistics(bitmap);
            Histogram redHistogram = imageStatistics.RedWithoutBlack;
            Histogram greenHistogram = imageStatistics.GreenWithoutBlack;
            Histogram blueHistogram = imageStatistics.BlueWithoutBlack;

            new LevelsLinear {
                                 InRed = FindFirstAndLastByThreshold(redHistogram, blackClipPercent, whiteClipPercent),
                                 InGreen = FindFirstAndLastByThreshold(greenHistogram, blackClipPercent, whiteClipPercent),
                                 InBlue = FindFirstAndLastByThreshold(blueHistogram, blackClipPercent, whiteClipPercent),
                                 Output = new IntRange(0, 255)
                             }.ApplyInPlace(bitmap);

            return bitmap;
        }

        public static Bitmap ClipRedHighValue(Bitmap sourceImage, byte redHighValueClip, PixelFormat pixelFormat)
        {
            IntRange fullRange = new IntRange(0, 255);

            Bitmap bitmap = new Bitmap(sourceImage);

            new LevelsLinear {
                                 InRed = fullRange,
                                 InGreen = fullRange,
                                 InBlue = fullRange,
                                 OutRed = new IntRange(0, redHighValueClip),
                                 OutGreen = fullRange,
                                 OutBlue = fullRange
                             }.ApplyInPlace(bitmap);

            return bitmap.PixelFormat != pixelFormat ? Conversion.ConvertPixelFormat(bitmap, pixelFormat) : bitmap;
        }

        public static Bitmap SetRgbGamma(Bitmap sourceImage, decimal redGamma, decimal greenGamma, decimal blueGamma, PixelFormat pixelFormat)
        {
            const decimal DefaultGamma = (decimal)1.0;

            Bitmap bitmap = new Bitmap(sourceImage);

            if (redGamma != DefaultGamma || greenGamma != DefaultGamma || blueGamma != DefaultGamma)
            {
                if (redGamma != DefaultGamma)
                {
                    Bitmap redChannel = Composition.ExtractChannel(bitmap, Composition.ChannelType.Red);
                    new GammaCorrection((double)redGamma).ApplyInPlace(redChannel);
                    new ReplaceChannel(RGB.R, redChannel).ApplyInPlace(bitmap);
                }

                if (greenGamma != DefaultGamma)
                {
                    Bitmap greenChannel = Composition.ExtractChannel(bitmap, Composition.ChannelType.Green);
                    new GammaCorrection((double)greenGamma).ApplyInPlace(greenChannel);
                    new ReplaceChannel(RGB.G, greenChannel).ApplyInPlace(bitmap);
                }

                if (blueGamma != DefaultGamma)
                {
                    Bitmap blueChannel = Composition.ExtractChannel(bitmap, Composition.ChannelType.Blue);
                    new GammaCorrection((double)blueGamma).ApplyInPlace(blueChannel);
                    new ReplaceChannel(RGB.B, blueChannel).ApplyInPlace(bitmap);
                }
            }

            return bitmap.PixelFormat != pixelFormat ? Conversion.ConvertPixelFormat(bitmap, pixelFormat) : bitmap;
        }

        /// <summary>Find lowest and highest volume indices from histogram using supplied threshold percentages</summary>
        /// <param name="histogram">Histogram to search</param>
        /// <param name="firstThresholdPercent">Threshold percentage used to locate lowest index (black point)</param>
        /// <param name="lastThresholdPercent">Threshold percentage used to locate lowest index (white point)</param>
        /// <returns>Populated IntRange object</returns>
        private static IntRange FindFirstAndLastByThreshold(Histogram histogram, decimal firstThresholdPercent, decimal lastThresholdPercent)
        {
            int lowerIndex = histogram.Min;
            int upperIndex = histogram.Max;

            bool foundLower = false;
            bool foundUpper = false;

            // find highest volume
            decimal maxVolume = histogram.Values.Concat(new[] { 0 }).Max();

            while ((foundLower == false || foundUpper == false) && lowerIndex < upperIndex)
            {
                if (foundLower == false)
                {
                    if ((histogram.Values[lowerIndex] / maxVolume) * 100 > firstThresholdPercent)
                    {
                        foundLower = true;
                    }
                    else
                    {
                        lowerIndex++;
                    }
                }

                if (foundUpper == false)
                {
                    if ((histogram.Values[upperIndex] / maxVolume) * 100 > lastThresholdPercent)
                    {
                        foundUpper = true;
                    }
                    else
                    {
                        upperIndex--;
                    }
                }
            }

            return new IntRange(lowerIndex, upperIndex);
        }
    }
}
