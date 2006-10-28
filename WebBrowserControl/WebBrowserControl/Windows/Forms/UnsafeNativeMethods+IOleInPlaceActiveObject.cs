using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;

namespace Pajocomo.Windows.Forms
{
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// Provides a direct channel of communication between an in-place object and the associated application's outer-most frame window and the document window within the application that contains the embedded object.
        /// </summary>
        [ComImport, Guid("00000117-0000-0000-C000-000000000046"), SuppressUnmanagedCodeSecurity, InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IOleInPlaceActiveObject : IOleWindow
        {
            /// <summary>
            /// Processes menu accelerator-key messages from the container's message queue.
            /// </summary>
            /// <param name="lpmsg">Pointer to the message that might need to be translated.</param>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int TranslateAccelerator([In] ref NativeMethods.MSG lpmsg);

            /// <summary>
            /// Notifies the object when the container's top-level frame window is activated or deactivated.
            /// </summary>
            /// <param name="fActivate">State of the container's top-level frame window. <see langword="true"/> if the window is activating; <see langword="false"/> if it is deactivating.</param>
            void OnFrameWindowActivate(bool fActivate);

            /// <summary>
            /// Notifies the active in-place object when the container's document window is activated or deactivated.
            /// </summary>
            /// <param name="fActivate">State of the MDI child document window. It is <see langword="true"/> if the window is in the act of activating; <see langword="false"/> if it is in the act of deactivating.</param>
            void OnDocWindowActivate(bool fActivate);

            /// <summary>
            /// Alerts the object that it needs to resize its border space.
            /// </summary>
            /// <param name="prcBorder">Pointer to a <see cref="NativeMethods._RECT"/> structure containing the new outer rectangle within which the object can request border space for its tools.</param>
            /// <param name="pUIWindow">Pointer to the frame or document window object whose border has changed.</param>
            /// <param name="fFrameWindow"><see langword="true"/> if the frame window object is calling ResizeBorder; otherwise, <see langword="false"/>.</param>
            void ResizeBorder([In] NativeMethods._RECT prcBorder, [In] UnsafeNativeMethods.IOleInPlaceUIWindow pUIWindow, bool fFrameWindow);

            /// <summary>
            /// Enables or disables modeless dialog boxes when the container creates or destroys a modal dialog box.
            /// </summary>
            /// <param name="fEnable"><see langword="true"/> to enable modeless dialog box windows; <see langword="false"/> to disable them.</param>
            void EnableModeless(int fEnable);
        }
    }
}
