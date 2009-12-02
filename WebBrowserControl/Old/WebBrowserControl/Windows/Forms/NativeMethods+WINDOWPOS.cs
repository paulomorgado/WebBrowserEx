using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Contains information about the size and position of a window.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPOS
        {
            /// <summary>
            /// Identifies the window.
            /// </summary>
            public IntPtr hwnd;

            /// <summary>
            /// Identifies the window behind which this window is placed.
            /// </summary>
            public IntPtr hwndInsertAfter;

            /// <summary>
            /// Specifies the position of the left edge of the window.
            /// </summary>
            public int x;

            /// <summary>
            /// Specifies the position of the right edge of the window.
            /// </summary>
            public int y;

            /// <summary>
            /// Specifies the window width, in pixels.
            /// </summary>
            public int cx;

            /// <summary>
            /// Specifies the window height, in pixels.
            /// </summary>
            public int cy;

            /// <summary>
            /// Specifies window-positioning options.
            /// </summary>
            public SWP flags;
        }
    }
}
