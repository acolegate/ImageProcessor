using System;

namespace ImageProcessing
{
    internal static class MoreMath
    {
        internal static int Max(int value1, int value2, int value3)
        {
            return Math.Max(Math.Max(value1, value2), value3);
        }

        internal static int Min(int value1, int value2, int value3)
        {
            return Math.Min(Math.Min(value1, value2), value3);
        }
    }
}
