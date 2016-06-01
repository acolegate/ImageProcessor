using System.Drawing;
using System.Drawing.Imaging;

namespace ImageProcessing
{
    public static class Creation
    {
        public static Bitmap Create(int width, int height, Color backgroundColour, PixelFormat pixelFormat = PixelFormat.Format32bppArgb)
        {
            using (Bitmap bitmap = new Bitmap(width, height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(backgroundColour);
                    Bitmap newBitmap = new Bitmap(bitmap);

                    return newBitmap.PixelFormat != pixelFormat ? Conversion.ConvertPixelFormat(newBitmap, pixelFormat) : newBitmap;
                }
            }
        }
    }
}
