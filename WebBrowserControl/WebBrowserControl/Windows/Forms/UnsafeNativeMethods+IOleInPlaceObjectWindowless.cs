using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// Enables a windowless object to process window messages and participate in drag and drop operations.
        /// </summary>
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("1C2056CC-5EF4-101B-8BC8-00AA003E3B29")]
        public interface IOleInPlaceObjectWindowless //: IOleInPlaceObject
        {
            #region IOleInPlaceObject

            #region IOleWindow

            /// <summary>
            /// Gets a window handle.
            /// </summary>
            /// <returns>Pointer to where to return the window handle.</returns>
            IntPtr GetWindow();

            /// <summary>
            /// Controls enabling of context-sensitive help.
            /// </summary>
            /// <param name="fEnterMode">Indicator of whether the control is entering context-sensitive help mode (<see langword="true"/>) or leaving it (<see langword="false"/>).</param>
            void ContextSensitiveHelp(
                [In, MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

            #endregion

            /// <summary>
            /// Deactivates an active in-place object and discards the object's undo state.
            /// </summary>
            void InPlaceDeactivate();

            /// <summary>
            /// Deactivate and remove UI of active object.
            /// </summary>
            void UIDeactivate();

            /// <summary>
            /// Portion of in-place object to be visible.
            /// </summary>
            /// <param name="lprcPosRect">Pointer to the rectangle containing the position of the in-place object using the client coordinates of its parent window.</param>
            /// <param name="lprcClipRect">Pointer to the outer rectangle containing the in-place object's position rectangle (PosRect).</param>
            void SetObjectRects(
                [In] NativeMethods._RECT lprcPosRect,
                [In] NativeMethods._RECT lprcClipRect);

            /// <summary>
            /// Reactivate previously deactivated object.
            /// </summary>
            void ReactivateAndUndo();

            #endregion

            /// <summary>
            /// Dispatches a message from the container to a windowless object.
            /// </summary>
            /// <param name="msg">Identifier for the window message provided to the container by Windows.</param>
            /// <param name="wParam">Parameter for the window message provided to the container by Windows.</param>
            /// <param name="lParam">Parameter for the window message provided to the container by Windows.</param>
            /// <param name="plResult">Pointer to result code for the window message as defined in the Windows API.</param>
            /// <returns><see langword="false"/> if the window message was successfully dispatched to the windowless object; otherwise <see langword="true"/>.</returns>
            [return: MarshalAs(UnmanagedType.I4)]
            bool OnWindowMessage(
                [In, MarshalAs(UnmanagedType.U4)] int msg, 
                [In, MarshalAs(UnmanagedType.U4)] int wParam, 
                [In, MarshalAs(UnmanagedType.U4)] int lParam, 
                [Out, MarshalAs(UnmanagedType.U4)] int plResult);
            
            /// <summary>
            /// Supplies the IDropTarget interface for a windowless object that supports drag and drop.
            /// </summary>
            /// <returns>The windowless object.</returns>
            [return: MarshalAs(UnmanagedType.Interface)]
            object GetDropTarget();
        }

    }
}
