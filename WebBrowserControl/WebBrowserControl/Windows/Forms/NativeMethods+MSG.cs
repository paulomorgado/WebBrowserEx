using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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

            /// <summary>
            /// Explicitly converts a <see cref="T:MSG"/> instance into a <see cref="T:Message"/> instance.
            /// </summary>
            /// <param name="msg">The <see cref="T:MSG"/>.</param>
            /// <returns>The <see cref="T:Message"/>.</returns>
            public static explicit operator Message(MSG msg)
            {
                Message message = new Message();

                message.Msg = msg.message;
                message.WParam = msg.wParam;
                message.LParam = msg.lParam;
                message.HWnd = msg.hwnd;

                return message;
            }

            /// <summary>
            /// Explicitly converts a <see cref="T:Message"/> instance into a <see cref="T:MSG"/> instance.
            /// </summary>
            /// <param name="msg">The <see cref="T:Message"/>.</param>
            /// <returns>The <see cref="T:MSG"/>.</returns>
            public static explicit operator MSG(Message message)
            {
                MSG msg = new MSG();

                msg.message = message.Msg;
                msg.wParam = message.WParam;
                msg.lParam = message.LParam;
                msg.hwnd = message.HWnd;

                return msg;
            }
        }
    }
}
