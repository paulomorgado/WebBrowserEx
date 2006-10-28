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
        /// Manages the activation and deactivation of in-place objects, and determines how much of the in-place object should be visible.
        /// </summary>
        [ComImport, Guid("00000113-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), SuppressUnmanagedCodeSecurity]
        public interface IOleInPlaceObject : IOleWindow
        {
            /// <summary>
            /// Deactivates an active in-place object and discards the object's undo state.
            /// </summary>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int InPlaceDeactivate();

            /// <summary>
            /// Deactivate and remove UI of active object.
            /// </summary>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int UIDeactivate();

            /// <summary>
            /// Portion of in-place object to be visible.
            /// </summary>
            /// <param name="lprcPosRect">Pointer to the rectangle containing the position of the in-place object using the client coordinates of its parent window.</param>
            /// <param name="lprcClipRect">Pointer to the outer rectangle containing the in-place object's position rectangle (PosRect).</param>
            void SetObjectRects([In] NativeMethods._RECT lprcPosRect, [In] NativeMethods._RECT lprcClipRect);

            /// <summary>
            /// Reactivate previously deactivated object.
            /// </summary>
            void ReactivateAndUndo();
        }
    }
}
