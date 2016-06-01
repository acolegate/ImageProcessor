using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace ImageProcessing
{
    public static class Save
    {
        /// <summary>Estimates the JPEG quality.</summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="fileSize">Size of the file.</param>
        /// <returns>The estimated JPEG quality</returns>
        public static int EstimateJpegQuality(Bitmap bitmap, long fileSize)
        {
            bool found = false;
            int upper = 100;
            int lower = 0;
            int value = 50;

            PreviewBitmap previewJpeg;

            while (found == false)
            {
                previewJpeg = SaveJpeg(bitmap, value);

                if (previewJpeg.FileSize > fileSize)
                {
                    upper = value;
                    value = lower + ((upper - lower) / 2);
                }
                else
                {
                    lower = value;
                    value = lower + ((upper - lower) / 2);
                }

                if (upper - lower <= 2)
                {
                    found = true;
                }
            }

            return value;
        }

        /// <summary>Save an image as a JPEG</summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="filename">Filename. If the file exists it will be overwritten</param>
        /// <param name="quality">The quality of compression (0-100)</param>
        /// <exception cref="System.ArgumentException">Quality must be between 0 and 100;quality</exception>
        public static void SaveJpeg(Bitmap bitmap, string filename, int quality)
        {
            if (quality >= 0 && quality <= 100)
            {
                using (EncoderParameters encoderParameters = new EncoderParameters(1))
                {
                    encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);
                    bitmap.Save(filename, FindCodecByMimeType("image/jpeg"), encoderParameters);
                }
            }
            else
            {
                throw new ArgumentException("Quality must be between 0 and 100", "quality");
            }
        }

        /// <summary>Saves the JPEG.</summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="quality">The quality.</param>
        /// <returns>The preview JPEG</returns>
        /// <exception cref="System.ArgumentException">Quality must be between 0 and 100;quality</exception>
        public static PreviewBitmap SaveJpeg(Bitmap bitmap, int quality)
        {
            if (quality >= 0 && quality <= 100)
            {
                using (EncoderParameters encoderParameters = new EncoderParameters(1))
                {
                    encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        bitmap.Save(memoryStream, FindCodecByMimeType("image/jpeg"), encoderParameters);

                        return new PreviewBitmap {
                                                   Bitmap = (Bitmap)Image.FromStream(memoryStream),
                                                   FileSize = memoryStream.Length
                                               };
                    }
                }
            }

            throw new ArgumentException("Quality must be between 0 and 100", "quality");
        }

        /// <summary>Find an installed Codec by it's MIME type</summary>
        /// <param name="mimeType">MIME type to find</param>
        /// <returns>ImagecodecInfo for the located MIME type</returns>
        private static ImageCodecInfo FindCodecByMimeType(string mimeType)
        {
            return ImageCodecInfo.GetImageEncoders().FirstOrDefault(t => t.MimeType == mimeType);
        }
    }
}
