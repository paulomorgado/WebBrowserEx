using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// Controls the container's top-level frame window.
        /// </summary>
        [ComImport, Guid("00000116-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IOleInPlaceFrame //: IOleInPlaceUIWindow
        {
            #region IOleInPlaceUIWindow

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

            #endregion

            /// <summary>
            /// Allows the container to insert its menu groups into the composite menu to be used during the in-place session.
            /// </summary>
            /// <param name="hmenuShared">Handle to an empty menu.</param>
            /// <returns>A <see cref="NativeMethods.tagOleMenuGroupWidths"/> array of six <see langword="int"/> values.</returns>
            [return: MarshalAs(UnmanagedType.LPStruct)]
            NativeMethods.tagOleMenuGroupWidths InsertMenus(
                [In] IntPtr hmenuShared);

            /// <summary>
            /// Installs the composite menu in the window frame containing the object being activated in place.
            /// </summary>
            /// <param name="hmenuShared">Handle to the composite menu constructed by calls to <see cref="IOleInPlaceFrame.InsertMenus"/> and the Windows InsertMenu function.</param>
            /// <param name="holemenu">Handle to the menu descriptor returned by the OleCreateMenuDescriptor function.</param>
            /// <param name="hwndActiveObject">Handle to a window owned by the object and to which menu messages, commands, and accelerators are to be sent.</param>
            void SetMenu(
                [In] IntPtr hmenuShared, 
                [In] IntPtr holemenu, 
                [In] IntPtr hwndActiveObject);

            /// <summary>
            /// Gives the container a chance to remove its menu elements from the in-place composite menu.
            /// </summary>
            /// <param name="hmenuShared">Handle to the in-place composite menu that was constructed by calls to <see cref="IOleInPlaceFrame.InsertMenus"/> and the Windows InsertMenu function.</param>
            void RemoveMenus(
                [In] IntPtr hmenuShared);

            /// <summary>
            /// Sets and displays status text about the in-place object in the container's frame window status line.
            /// </summary>
            /// <param name="pszStatusText">Pointer to a null-terminated character string containing the message to display.</param>
            void SetStatusText(
                [In, MarshalAs(UnmanagedType.LPWStr)] string pszStatusText);

            /// <summary>
            /// Enables or disables a frame's modeless dialog boxes.
            /// </summary>
            /// <param name="fEnable">Specifies whether the modeless dialog box windows are to be enabled by specifying <see langword="true"/> or disabled by specifying <see langword="false"/>.</param>
            void EnableModeless([In, MarshalAs(UnmanagedType.Bool)] bool fEnable);

            /// <summary>
            /// Translates accelerator keystrokes intended for the container's frame while an object is active in place.
            /// </summary>
            /// <param name="lpmsg">Pointer to the <see cref="NativeMethods.MSG"/> structure containing the keystroke message.</param>
            /// <param name="wID">Command identifier value corresponding to the keystroke in the container-provided accelerator table.</param>
            /// <returns><see cref="F:NativeMethods.HRESULT.S_OK"/> if the keystroke was used; <see cref="F:NativeMethods.HRESULT.S_FALSE"/> if the keystroke was not used.</returns>
            [PreserveSig]
            NativeMethods.HRESULT TranslateAccelerator(
                [In] ref NativeMethods.MSG lpmsg, 
                [In, MarshalAs(UnmanagedType.U2)] short wID);
        }
    }
}
