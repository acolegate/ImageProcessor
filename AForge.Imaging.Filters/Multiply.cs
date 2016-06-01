using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace AForge.Imaging.Filters
{
    public sealed class Multiply : BaseInPlaceFilter2
    {
        private readonly Dictionary<PixelFormat, PixelFormat> formatTranslations = new Dictionary<PixelFormat, PixelFormat>();

        /// <summary>Initializes a new instance of the <see cref="Multiply" /> class.</summary>
        public Multiply()
        {
            InitFormatTranslations();
        }

        /// <summary>Initializes a new instance of the <see cref="Multiply" /> class.</summary>
        /// <param name="overlayImage">Overlay image.</param>
        public Multiply(Bitmap overlayImage) : base(overlayImage)
        {
            InitFormatTranslations();
        }

        /// <summary>Initializes a new instance of the <see cref="Multiply" /> class.</summary>
        /// <param name="unmanagedOverlayImage">Unmanaged overlay image.</param>
        public Multiply(UnmanagedImage unmanagedOverlayImage) : base(unmanagedOverlayImage)
        {
            InitFormatTranslations();
        }

        /// <summary>Format translations dictionary.</summary>
        /// <remarks>
        /// <para>The dictionary defines, which pixel formats are supported for
        /// source images and which pixel format will be used for resulting image.
        /// </para>
        /// <para>See <see cref="P:AForge.Imaging.Filters.IFilterInformation.FormatTranslations" /> for more information.</para>
        /// </remarks>
        public override Dictionary<PixelFormat, PixelFormat> FormatTranslations
        {
            get
            {
                return formatTranslations;
            }
        }

        /// <summary>Process the filter on the specified image.</summary>
        /// <param name="image">Source image data.</param>
        /// <param name="overlay">Overlay image data.</param>
        /// <remarks>
        /// Overlay image size and pixel format is checked by this base class, before
        /// passing execution to inherited class.
        /// </remarks>
        protected override unsafe void ProcessFilter(UnmanagedImage image, UnmanagedImage overlay)
        {
            PixelFormat pixelFormat = image.PixelFormat;
            int width = image.Width;
            int height = image.Height;

            const double Factor = (double)1 / (double)255;

            if (pixelFormat == PixelFormat.Format8bppIndexed || pixelFormat == PixelFormat.Format24bppRgb || (pixelFormat == PixelFormat.Format32bppRgb || pixelFormat == PixelFormat.Format32bppArgb))
            {
                int num1 = pixelFormat == PixelFormat.Format8bppIndexed ? 1 : (pixelFormat == PixelFormat.Format24bppRgb ? 3 : 4);
                int num2 = width * num1;
                int num3 = image.Stride - num2;
                int num4 = overlay.Stride - num2;
                byte* numPtr1 = (byte*)image.ImageData.ToPointer();
                byte* numPtr2 = (byte*)overlay.ImageData.ToPointer();

                int num5;
                int num6;
                for (int index = 0; index < height; ++index)
                {
                    num5 = 0;
                    while (num5 < num2)
                    {
                        num6 = (int)(((*numPtr1 * Factor) * (*numPtr2 * Factor)) * 255);
                        *numPtr1 = num6 > (int)byte.MaxValue ? byte.MaxValue : (byte)num6;
                        ++num5;
                        ++numPtr1;
                        ++numPtr2;
                    }
                    numPtr1 += num3;
                    numPtr2 += num4;
                }
            }
            else
            {
                int num1 = pixelFormat == PixelFormat.Format16bppGrayScale ? 1 : (pixelFormat == PixelFormat.Format48bppRgb ? 3 : 4);
                int num2 = width * num1;
                int stride1 = image.Stride;
                int stride2 = overlay.Stride;
                byte* numPtr1 = (byte*)image.ImageData.ToPointer();
                byte* numPtr2 = (byte*)overlay.ImageData.ToPointer();

                ushort* numPtr3;
                ushort* numPtr4;
                int num3;
                int num4;

                for (int index = 0; index < height; ++index)
                {
                    numPtr3 = (ushort*)(numPtr1 + ((IntPtr)(index * stride1)).ToInt64());
                    numPtr4 = (ushort*)(numPtr2 + ((IntPtr)(index * stride2)).ToInt64());
                    num3 = 0;
                    while (num3 < num2)
                    {
                        num4 = (int)(((*numPtr3 * Factor) * (*numPtr4 * Factor)) * 255);
                        *numPtr3 = num4 > (int)ushort.MaxValue ? ushort.MaxValue : (ushort)num4;
                        ++num3;
                        ++numPtr3;
                        ++numPtr4;
                    }
                }
            }
        }

        /// <summary>Initializes the format translations.</summary>
        private void InitFormatTranslations()
        {
            formatTranslations[PixelFormat.Format8bppIndexed] = PixelFormat.Format8bppIndexed;
            formatTranslations[PixelFormat.Format24bppRgb] = PixelFormat.Format24bppRgb;
            formatTranslations[PixelFormat.Format32bppRgb] = PixelFormat.Format32bppRgb;
            formatTranslations[PixelFormat.Format32bppArgb] = PixelFormat.Format32bppArgb;
            formatTranslations[PixelFormat.Format16bppGrayScale] = PixelFormat.Format16bppGrayScale;
            formatTranslations[PixelFormat.Format48bppRgb] = PixelFormat.Format48bppRgb;
            formatTranslations[PixelFormat.Format64bppArgb] = PixelFormat.Format64bppArgb;
        }
    }
}
