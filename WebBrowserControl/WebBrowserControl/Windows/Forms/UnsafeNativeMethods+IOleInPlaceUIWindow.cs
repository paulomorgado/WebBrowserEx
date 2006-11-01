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
        /// Implemented by container applications and used by object applications to negotiate border space on the document or frame window.
        /// </summary>
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000115-0000-0000-C000-000000000046")]
        public interface IOleInPlaceUIWindow //: IOleWindow
        {
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
            /// Returns a <see cref="NativeMethods._RECT"/> structure in which the object can put toolbars and similar controls while active in place.
            /// </summary>
            /// <returns>The outer <see cref="NativeMethods._RECT">rectangle</see>. The <see cref="NativeMethods._RECT"/> structure's coordinates are relative to the window being represented by the interface.</returns>
            [return: MarshalAs(UnmanagedType.LPStruct)]
            NativeMethods._RECT GetBorder();

            /// <summary>
            /// Determines if there is available space for tools to be installed around the object's window frame while the object is active in place
            /// </summary>
            /// <param name="pborderwidths">Pointer to a <see cref="NativeMethods._RECT"/> structure containing the requested widths (in pixels) needed on each side of the window for the tools.</param>
            void RequestBorderSpace(
                [In, MarshalAs(UnmanagedType.LPStruct)] NativeMethods._RECT pborderwidths);

            /// <summary>
            /// Allocates space for the border requested in the call to <see cref="IOleInPlaceUIWindow.RequestBorderSpace"/>.
            /// </summary>
            /// <param name="pborderwidths">Pointer to a <see cref="NativeMethods._RECT"/> structure containing the requested width (in pixels) of the tools. It can be <see langword="null"/>, indicating the object does not need any space.</param>
            void SetBorderSpace(
                [In, MarshalAs(UnmanagedType.LPStruct)] NativeMethods._RECT pborderwidths);

            /// <summary>
            /// Provides a direct channel of communication between the object and each of the frame and document windows.
            /// </summary>
            /// <param name="pActiveObject">Pointer to the <see cref="IOleInPlaceActiveObject"/> interface on the active in-place object</param>
            /// <param name="pszObjName">Pointer to a string containing a name that describes the object an embedding container can use in composing its window title.</param>
            void SetActiveObject(
                [In, MarshalAs(UnmanagedType.Interface)] UnsafeNativeMethods.IOleInPlaceActiveObject pActiveObject,
                [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjName);
        }
    }
}
