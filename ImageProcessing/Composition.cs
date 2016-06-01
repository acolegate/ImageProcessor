using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using AForge.Imaging;
using AForge.Imaging.Filters;

namespace ImageProcessing
{
    public static class Composition
    {
        public enum ChannelType
        {
            Red = 0,
            Green = 1,
            Blue = 2,
            Alpha = 3,
            Luminosity = 4
        }

        public enum CompositionType
        {
            Add = 0,
            Multiply = 1,
            Screen = 2
        }

        public static Bitmap ExtractChannel(Bitmap bitmap, ChannelType channel, PixelFormat pixelFormat = PixelFormat.Format8bppIndexed)
        {
            switch (channel)
            {
                case ChannelType.Luminosity:
                {
                    Bitmap bitmapChannel = new Grayscale(0.3, 0.59, 0.11).Apply(bitmap);
                    return bitmapChannel.PixelFormat != pixelFormat ? Conversion.ConvertPixelFormat(bitmapChannel, pixelFormat) : bitmapChannel;
                }
                case ChannelType.Red:
                {
                    return new ExtractChannel(RGB.R).Apply(bitmap);
                }
                case ChannelType.Green:
                {
                    return new ExtractChannel(RGB.G).Apply(bitmap);
                }
                case ChannelType.Blue:
                {
                    return new ExtractChannel(RGB.B).Apply(bitmap);
                }
                case ChannelType.Alpha:
                {
                    return new ExtractChannel(RGB.A).Apply(bitmap);
                }
            }

            throw new NotImplementedException();
        }

        public static Bitmap Merge(Bitmap bitmap1, Bitmap bitmap2, CompositionType mergeType, PixelFormat pixelFormat)
        {
            Bitmap mergedBitmap = null;

            switch (mergeType)
            {
                case CompositionType.Add:
                {
                    mergedBitmap = new Add(bitmap2).Apply(bitmap1);
                    break;
                }
                case CompositionType.Multiply:
                {
                    mergedBitmap = new Multiply(bitmap2).Apply(bitmap1);
                    break;
                }
                case CompositionType.Screen:
                {
                    mergedBitmap = new Screen(bitmap2).Apply(bitmap1);
                    break;
                }
            }

            if (mergedBitmap != null)
            {
                return mergedBitmap.PixelFormat != pixelFormat ? Conversion.ConvertPixelFormat(mergedBitmap, pixelFormat) : mergedBitmap;
            }

            throw new NotImplementedException();
        }

        public static Bitmap OverlayImage(Bitmap target, Bitmap overlay, Alignment alignment, int margin, PixelFormat pixelFormat)
        {
            using (Graphics newScaledVersion = Graphics.FromImage(target))
            {
                newScaledVersion.CompositingMode = CompositingMode.SourceOver;
                newScaledVersion.CompositingQuality = CompositingQuality.HighQuality;

                Rectangle rectangle = new Rectangle();

                int bottomEdge = target.Height - overlay.Height - margin;
                int rightEdge = target.Width - overlay.Width - margin;
                int centreHorizontal = (target.Width - overlay.Width) / 2;
                int centreVertical = (target.Height - overlay.Height) / 2;

                switch (alignment)
                {
                    case Alignment.BottomLeft:
                    {
                        rectangle = new Rectangle(margin, bottomEdge, overlay.Width, overlay.Height);
                        break;
                    }

                    case Alignment.BottomRight:
                    {
                        rectangle = new Rectangle(rightEdge, bottomEdge, overlay.Width, overlay.Height);
                        break;
                    }

                    case Alignment.TopLeft:
                    {
                        rectangle = new Rectangle(margin, margin, overlay.Width, overlay.Height);
                        break;
                    }

                    case Alignment.TopRight:
                    {
                        rectangle = new Rectangle(rightEdge, margin, overlay.Width, overlay.Height);
                        break;
                    }

                    case Alignment.Bottom:
                    {
                        rectangle = new Rectangle(centreHorizontal, bottomEdge, overlay.Width, overlay.Height);
                        break;
                    }

                    case Alignment.Top:
                    {
                        rectangle = new Rectangle(centreHorizontal, margin, overlay.Width, overlay.Height);
                        break;
                    }

                    case Alignment.Centre:
                    {
                        rectangle = new Rectangle(centreHorizontal, centreVertical, overlay.Width, overlay.Height);
                        break;
                    }

                    case Alignment.Left:
                    {
                        rectangle = new Rectangle(margin, centreVertical, overlay.Width, overlay.Height);
                        break;
                    }

                    case Alignment.Right:
                    {
                        rectangle = new Rectangle(rightEdge, centreVertical, overlay.Width, overlay.Height);
                        break;
                    }
                }

                newScaledVersion.DrawImageUnscaledAndClipped(overlay, rectangle);
            }

            return target.PixelFormat != pixelFormat ? Conversion.ConvertPixelFormat(target, pixelFormat) : target;
        }
    }
}
