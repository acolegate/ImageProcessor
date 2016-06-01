using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageProcessing
{
    public static class CropResize
    {
        private static readonly Color DefaultBackgroundColour = Color.Black;

        /// <summary>
        /// Crop an image to specific dimensions. The image will be centre aligned with a black background if exposed
        /// </summary>
        /// <param name="bitmap">Bitmap to crop</param>
        /// <param name="destinationWidth">Destination image width. When parger than the original image, a black background will be exposed</param>
        /// <param name="destinationHeight">Destination image height. When parger than the original image, a black background will be exposed</param>
        /// <param name="backgroundColour">The background colour.</param>
        /// <returns>Cropped image</returns>
        public static Bitmap Crop(Bitmap bitmap, int destinationWidth, int destinationHeight, Color? backgroundColour = null)
        {
            return Crop(bitmap, destinationWidth, destinationHeight, Alignment.Centre, backgroundColour ?? DefaultBackgroundColour);
        }

        /// <summary>Crop an image to specific dimensions</summary>
        /// <param name="bitmap">Bitmap to crop</param>
        /// <param name="destinationWidth">Destination image width. When parger than the original image, the background will be exposed</param>
        /// <param name="destinationHeight">Destination image height. When parger than the original image, the background will be exposed</param>
        /// <param name="alignment">Alignment of the crop area relative to the edge of the image</param>
        /// <param name="backgroundColour">Background colour of areas exposed after cropping</param>
        /// <returns>Cropped image</returns>
        public static Bitmap Crop(Bitmap bitmap, int destinationWidth, int destinationHeight, Alignment alignment, Color? backgroundColour = null)
        {
            int cropStartX;
            int cropStartY;

            switch (alignment)
            {
                case Alignment.Bottom:
                case Alignment.Top:
                case Alignment.Centre:
                    if (destinationWidth != bitmap.Width)
                    {
                        if (bitmap.Width > destinationWidth)
                        {
                            cropStartX = (bitmap.Width - destinationWidth) / 2;
                        }
                        else
                        {
                            cropStartX = -((destinationWidth - bitmap.Width) / 2);
                        }
                    }
                    else
                    {
                        cropStartX = 0;
                    }

                    break;
                case Alignment.BottomLeft:
                case Alignment.TopLeft:
                case Alignment.Left:
                    cropStartX = 0;
                    break;
                default:
                    cropStartX = bitmap.Width - destinationWidth;
                    break;
            }

            if (alignment == Alignment.Centre || alignment == Alignment.Left || alignment == Alignment.Right)
            {
                if (destinationHeight != bitmap.Height)
                {
                    if (bitmap.Height > destinationHeight)
                    {
                        cropStartY = (bitmap.Height - destinationHeight) / 2;
                    }
                    else
                    {
                        cropStartY = -(destinationHeight - bitmap.Height) / 2;
                    }
                }
                else
                {
                    cropStartY = 0;
                }
            }
            else
            {
                cropStartY = alignment == Alignment.Top || alignment == Alignment.TopLeft || alignment == Alignment.TopRight ? 0 : bitmap.Height - destinationHeight;
            }

            return Crop(bitmap, destinationWidth, destinationHeight, cropStartX, cropStartY, backgroundColour);
        }

        /// <summary>Crop an image to specific dimensions</summary>
        /// <param name="sourceBitmap">Bitmap to crop</param>
        /// <param name="destinationWidth">Destination image width. When parger than the original image, the background will be exposed</param>
        /// <param name="destinationHeight">Destination image height. When parger than the original image, the background will be exposed</param>
        /// <param name="cropStartX">Horizontal position of crop window in pixels relative to top-left of image</param>
        /// <param name="cropStartY">Vertical position of crop window in pixels relative to top-left of image</param>
        /// <param name="backgroundColour">Background colour of areas exposed after cropping</param>
        /// <returns>Cropped image</returns>
        public static Bitmap Crop(Bitmap sourceBitmap, int destinationWidth, int destinationHeight, int cropStartX, int cropStartY, Color? backgroundColour = null)
        {
            Bitmap bitmap = new Bitmap(destinationWidth, destinationHeight, PixelFormat.Format24bppRgb);
            bitmap.SetResolution(sourceBitmap.HorizontalResolution, sourceBitmap.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(backgroundColour ?? DefaultBackgroundColour);
                graphics.CompositingQuality = CompositingQuality.HighQuality;

                graphics.DrawImage(sourceBitmap, new Rectangle(0, 0, destinationWidth, destinationHeight), cropStartX, cropStartY, destinationWidth, destinationHeight, GraphicsUnit.Pixel);
            }

            return bitmap;
        }

        // - OVERLAY ----

        // - S P E C I A L   C R O P -------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>Resize image to fit destination dimensions while maintaining aspect.</summary>
        /// <param name="bitmap">The image to be made to fit the new dimensions</param>
        /// <param name="destinationWidth">Destination image width</param>
        /// <param name="destinationHeight">Destination image height</param>
        /// <param name="alignment">Alignment of the crop area relative to the edge of the image</param>
        /// <returns>Bitmap with new dimensions but same aspect</returns>
        public static Bitmap FitAndMaintainAspect(Bitmap bitmap, int destinationWidth, int destinationHeight, Alignment alignment = Alignment.Centre)
        {
            // stretch the image so it fills the destination dimensions while maintaining aspect and aligning the new resized portion of the image properly
            decimal aspect = (decimal)bitmap.Width / bitmap.Height;

            int stretchedWidth;
            int stretchedHeight;

            if (bitmap.Width >= bitmap.Height)
            {
                // LANDSCAPE

                // need to resize the image to it's stretched so that the height fits the destination height
                stretchedHeight = destinationHeight;
                stretchedWidth = (int)(destinationHeight * aspect);

                if (stretchedWidth < destinationWidth)
                {
                    // the image still doesn't fit, stretch it again so the width now matches the destinationwidth
                    stretchedWidth = destinationWidth;
                    stretchedHeight = (int)(destinationWidth / aspect);
                }
            }
            else
            {
                // PORTRAIT

                // need to resize the image so it's stretch so that the width fits the destination width
                stretchedWidth = destinationWidth;
                stretchedHeight = (int)(destinationWidth / aspect);

                if (stretchedHeight < destinationHeight)
                {
                    // the image still doesn't fit, stretch it again so the width now matches the destinationwidth
                    stretchedHeight = destinationHeight;
                    stretchedWidth = (int)(destinationHeight * aspect);
                }
            }

            bitmap = Resize(bitmap, stretchedWidth, stretchedHeight);
            bitmap = Crop(bitmap, destinationWidth, destinationHeight, alignment);

            return bitmap;
        }

        /// <summary>Resize image ignoring aspect</summary>
        /// <param name="image">The image to resize</param>
        /// <param name="destinationWidth">Destination image width</param>
        /// <param name="destinationHeight">Destination image height</param>
        /// <returns>Resized image</returns>
        public static Bitmap Resize(Bitmap image, int destinationWidth, int destinationHeight)
        {
            Bitmap bitmap = new Bitmap(destinationWidth, destinationHeight, PixelFormat.Format24bppRgb);
            bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, new Rectangle(0, 0, destinationWidth, destinationHeight), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            }

            return bitmap;
        }

        /// <summary>Resize image to a specific height while maintaining aspect</summary>
        /// <param name="bitmap">Bitmap to resize</param>
        /// <param name="destinationHeight">Destination image height</param>
        /// <returns>Resized image</returns>
        public static Bitmap ResizeToHeightMaintainAspect(Bitmap bitmap, int destinationHeight)
        {
            decimal aspect = (decimal)bitmap.Width / bitmap.Height;
            return Resize(bitmap, (int)(destinationHeight * aspect), destinationHeight);
        }

        /// <summary>Resize image to a specific width while maintaining aspect</summary>
        /// <param name="bitmap">Bitmap to resize</param>
        /// <param name="destinationWidth">Destination image width</param>
        /// <returns>Resized image</returns>
        public static Bitmap ResizeToWidthMaintainAspect(Bitmap bitmap, int destinationWidth)
        {
            decimal aspect = (decimal)bitmap.Width / bitmap.Height;
            return Resize(bitmap, destinationWidth, (int)(destinationWidth / aspect));
        }
    }
}
