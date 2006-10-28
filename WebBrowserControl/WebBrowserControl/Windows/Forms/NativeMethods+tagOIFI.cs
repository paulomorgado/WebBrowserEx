using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Contains information about the accelerators supported by a container during an in-place session.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagOIFI
        {
            /// <summary>
            /// Size in bytes of this structure.
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public int cb;

            /// <summary>
            /// Whether the container is an MDI application.
            /// </summary>
            public bool fMDIApp;

            /// <summary>
            /// Handle to the container's top-level frame window.
            /// </summary>
            public IntPtr hwndFrame;

            /// <summary>
            /// Handle to the accelerator table that the container wants to use during an in-place editing session.
            /// </summary>
            public IntPtr hAccel;

            /// <summary>
            /// Number of accelerators in haccel.
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public int cAccelEntries;

            /// <summary>
            /// Initializes a new instance of the <see cref="tagOIFI"/> class.
            /// </summary>
            public tagOIFI()
            {
            }
        }
    }
}
