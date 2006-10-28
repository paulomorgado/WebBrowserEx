using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Specifies the window sizing and positioning flags.
        /// </summary>
        public enum SWP : int
        {
            /// <summary>
            /// Retains current size (ignores the cx and cy members). 
            /// </summary>
            SWP_NOSIZE = 0x0001,

            /// <summary>
            /// Retains current position (ignores the x and y members). 
            /// </summary>
            SWP_NOMOVE = 0x0002,

            /// <summary>
            /// Retains current ordering (ignores the hwndInsertAfter member).
            /// </summary>
            SWP_NOZORDER = 0x0004,

            /// <summary>
            /// Does not redraw changes.
            /// </summary>
            SWP_NOREDRAW = 0x0008,

            /// <summary>
            /// Does not activate the window.
            /// </summary>
            SWP_NOACTIVATE = 0x0010,

            /// <summary>
            /// Sends a WM_NCCALCSIZE message to the window, even if the window's size is not being changed.
            /// If this flag is not specified, WM_NCCALCSIZE is sent only when the window's size is being changed.
            /// </summary>
            SWP_FRAMECHANGED = 0x0020,

            /// <summary>
            /// Displays the window.
            /// </summary>
            SWP_SHOWWINDOW = 0x0040,

            /// <summary>
            /// Hides the window.
            /// </summary>
            SWP_HIDEWINDOW = 0x0080,

            /// <summary>
            /// Discards the entire contents of the client area. If this flag is not specified, the valid contents of the client area are saved and copied back into the client area after the window is sized or repositioned.
            /// </summary>
            SWP_NOCOPYBITS = 0x0100,

            /// <summary>
            /// Does not change the owner window's position in the Z-order.
            /// </summary>
            SWP_NOOWNERZORDER = 0x0200,

            /// <summary>
            /// Prevents the window from receiving the WM_WINDOWPOSCHANGING message.
            /// </summary>
            SWP_NOSENDCHANGING = 0x0400,

            /// <summary>
            /// Draws a frame (defined in the class description for the window) around the window. The window receives a WM_NCCALCSIZE message.
            /// </summary>
            SWP_DRAWFRAME = SWP_FRAMECHANGED,

            /// <summary>
            /// Same as SWP_NOOWNERZORDER.
            /// </summary>
            SWP_NOREPOSITION = SWP_NOOWNERZORDER,

            /// <summary>
            /// Prevents generation of the WM_SYNCPAINT message. 
            /// </summary>
            SWP_DEFERERASE = 0x2000,

            /// <summary>
            /// If the calling thread and the thread that owns the window are attached to different input queues, the system posts the request to the thread that owns the window.
            /// This prevents the calling thread from blocking its execution while other threads process the request.
            /// </summary>
            SWP_ASYNCWINDOWPOS = 0x4000

        }
    }
}
