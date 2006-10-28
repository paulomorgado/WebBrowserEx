using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// Supports simple frame controls that act as simple containers for other nested controls.
        /// </summary>
        [ComImport, Guid("742B0E01-14E6-101B-914E-00AA00300CAB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ISimpleFrameSite
        {
            /// <summary>
            /// Sends the simple frame site a message that is received by a control's own window before the control itself does any processing.
            /// </summary>
            /// <param name="hwnd">Handle of the control window receiving the message.</param>
            /// <param name="msg">Message received by the simple frame site.</param>
            /// <param name="wp">The WPARAM of the message.</param>
            /// <param name="lp">The LPARAM of the message.</param>
            /// <param name="plResult">Pointer to the result variable to receive the result of the message processing.</param>
            /// <param name="pdwCookie">Pointer to the <see langword="int"/> variable that will be passed to PostMessageFilter if it is called later.</param>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int PreMessageFilter(IntPtr hwnd, [In, MarshalAs(UnmanagedType.U4)] int msg, IntPtr wp, IntPtr lp, [In, Out] ref IntPtr plResult, [In, Out, MarshalAs(UnmanagedType.U4)] ref int pdwCookie);

            /// <summary>
            /// Sends the simple frame site a message that is received by a control's own window after the control does its own processing.
            /// </summary>
            /// <param name="hwnd">Handle of the control window receiving the message.</param>
            /// <param name="msg">Message received by the simple frame site.</param>
            /// <param name="wp">The WPARAM of the message.</param>
            /// <param name="lp">The LPARAM of the message.</param>
            /// <param name="plResult">Pointer to the variable that receives the result of the message processing.</param>
            /// <param name="dwCookie">Value that was returned by <see cref="ISimpleFrameSite.PreMessageFilter"/> through its pdwCookie parameter.</param>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int PostMessageFilter(IntPtr hwnd, [In, MarshalAs(UnmanagedType.U4)] int msg, IntPtr wp, IntPtr lp, [In, Out] ref IntPtr plResult, [In, MarshalAs(UnmanagedType.U4)] int dwCookie);
        }
    }
}
