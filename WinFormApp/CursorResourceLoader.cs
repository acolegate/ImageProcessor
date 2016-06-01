using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ImageProcessor
{
    public static class CursorResourceLoader
    {
        #region Methods 

        public static Cursor LoadEmbeddedCursor(byte[] cursorResource, int imageIndex = 0)

        {
            GCHandle resourceHandle = GCHandle.Alloc(cursorResource, GCHandleType.Pinned);
            IntPtr iconImage = IntPtr.Zero;
            IntPtr cursorHandle = IntPtr.Zero;

            try

            {
                IconHeader header = (IconHeader)Marshal.PtrToStructure(resourceHandle.AddrOfPinnedObject(), typeof(IconHeader));

                if (imageIndex >= header.count)
                {
                    throw new ArgumentOutOfRangeException("imageIndex");
                }

                IntPtr iconInfoPtr = resourceHandle.AddrOfPinnedObject() + Marshal.SizeOf(typeof(IconHeader)) + imageIndex * Marshal.SizeOf(typeof(IconInfo));

                IconInfo info = (IconInfo)Marshal.PtrToStructure(iconInfoPtr, typeof(IconInfo));

                iconImage = Marshal.AllocHGlobal(info.size + 4);

                Marshal.WriteInt16(iconImage + 0, info.hotspot_x);
                Marshal.WriteInt16(iconImage + 2, info.hotspot_y);
                Marshal.Copy(cursorResource, info.offset, iconImage + 4, info.size);

                cursorHandle = NativeMethods.CreateIconFromResource(iconImage, info.size + 4, false, 0x30000);

                return new Cursor(cursorHandle);
            }
            finally
            {
                if (cursorHandle != IntPtr.Zero)
                {
                    NativeMethods.DestroyIcon(cursorHandle);
                }

                if (iconImage != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(iconImage);
                }

                if (resourceHandle.IsAllocated)
                {
                    resourceHandle.Free();
                }
            }
        }

        #endregion Methods 

        #region Native Methods 

        private static class NativeMethods

        {
            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr CreateIconFromResource(IntPtr pbIconBits, int dwResSize, bool fIcon, int dwVer);

            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool DestroyIcon(IntPtr hIcon);
        }

        #endregion Native Methods 

        #region Native Structures 

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private struct IconHeader
        {
            [FieldOffset(0)]
            public readonly short reserved;

            [FieldOffset(2)]
            public readonly short type;

            [FieldOffset(4)]
            public readonly short count;
        }

        /// <summary>Union structure for icons and cursors.</summary> 
        /// <remarks>For icons, field offset 4 is used for planes and field offset 6 for  
        /// bits-per-pixel, while for cursors field offset 4 is used for the x coordinate  
        /// of the hotspot, and field offset 6 is used for the y coordinate.</remarks> 
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private struct IconInfo
        {
            [FieldOffset(0)]
            public readonly byte width;

            [FieldOffset(1)]
            public readonly byte height;

            [FieldOffset(2)]
            public readonly byte colors;

            [FieldOffset(3)]
            public readonly byte reserved;

            [FieldOffset(4)]
            public readonly short planes;

            [FieldOffset(6)]
            public readonly short bpp;

            [FieldOffset(4)]
            public readonly short hotspot_x;

            [FieldOffset(6)]
            public readonly short hotspot_y;

            [FieldOffset(8)]
            public readonly int size;

            [FieldOffset(12)]
            public readonly int offset;
        }

        #endregion Native Structures 
    }
}
