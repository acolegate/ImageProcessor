using System.Drawing;

namespace ImageProcessing
{
    public enum Alignment
    {
        Centre = 0,
        Top = 1,
        TopRight = 2,
        Right = 3,
        BottomRight = 4,
        Bottom = 5,
        BottomLeft = 6,
        Left = 7,
        TopLeft = 8
    }

    
        public class PreviewBitmap
        {
            public Bitmap Bitmap { get; internal set; }
            public long FileSize { get; internal set; }
        }
    
}
