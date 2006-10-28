using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Contains message information from a thread's message queue.
        /// </summary>
        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            /// <summary>
            /// Handle to the window whose window procedure receives the message.
            /// </summary>
            public IntPtr hwnd;

            /// <summary>
            /// Specifies the message identifier. Applications can only use the low word; the high word is reserved by the system.
            /// </summary>
            public int message;

            /// <summary>
            /// Specifies additional information about the message. The exact meaning depends on the value of the <see cref="message"/> member.
            /// </summary>
            public IntPtr wParam;

            /// <summary>
            /// Specifies additional information about the message. The exact meaning depends on the value of the <see cref="message"/> member.
            /// </summary>
            public IntPtr lParam;

            /// <summary>
            /// Specifies the time at which the message was posted.
            /// </summary>
            public int time;

            /// <summary>
            /// Specifies the cursor position, in screen coordinates, when the message was posted
            /// </summary>
            public _POINTL pt;
        }
    }
}
