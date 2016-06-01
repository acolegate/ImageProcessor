using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageProcessing
{
    public static class Conversion
    {
        /// <summary>Converts an image to a byte array</summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="imageFormat">The image format.</param>
        /// <returns>A byte array</returns>
        public static byte[] ImageToByteArray(Bitmap bitmap, ImageFormat imageFormat)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, imageFormat);
                return memoryStream.ToArray();
            }
        }

        /// <summary>Convert an image to specified pixel format</summary>
        /// <param name="bitmap">Image to convert</param>
        /// <param name="pixelFormat">The pixel Format.</param>
        /// <returns>Converted bitmap</returns>
        public static Bitmap ConvertPixelFormat(Bitmap bitmap, PixelFormat pixelFormat)
        {
            return AForge.Imaging.Image.Clone(bitmap, pixelFormat);
        }
    }
}
