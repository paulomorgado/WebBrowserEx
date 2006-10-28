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
        public interface IOleInPlaceFrame : IOleInPlaceUIWindow
        {
            /// <summary>
            /// Allows the container to insert its menu groups into the composite menu to be used during the in-place session.
            /// </summary>
            /// <param name="hmenuShared">Handle to an empty menu.</param>
            /// <param name="lpMenuWidths">Pointer to an <see cref="NativeMethods.tagOleMenuGroupWidths"/> array of six LONG values.</param>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int InsertMenus([In] IntPtr hmenuShared, [In, Out] NativeMethods.tagOleMenuGroupWidths lpMenuWidths);

            /// <summary>
            /// Installs the composite menu in the window frame containing the object being activated in place.
            /// </summary>
            /// <param name="hmenuShared">Handle to the composite menu constructed by calls to <see cref="IOleInPlaceFrame.InsertMenus"/> and the Windows InsertMenu function.</param>
            /// <param name="holemenu">Handle to the menu descriptor returned by the OleCreateMenuDescriptor function.</param>
            /// <param name="hwndActiveObject">Handle to a window owned by the object and to which menu messages, commands, and accelerators are to be sent.</param>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int SetMenu([In] IntPtr hmenuShared, [In] IntPtr holemenu, [In] IntPtr hwndActiveObject);

            /// <summary>
            /// Gives the container a chance to remove its menu elements from the in-place composite menu.
            /// </summary>
            /// <param name="hmenuShared">Handle to the in-place composite menu that was constructed by calls to <see cref="IOleInPlaceFrame.InsertMenus"/> and the Windows InsertMenu function.</param>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int RemoveMenus([In] IntPtr hmenuShared);

            /// <summary>
            /// Sets and displays status text about the in-place object in the container's frame window status line.
            /// </summary>
            /// <param name="pszStatusText">Pointer to a null-terminated character string containing the message to display.</param>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int SetStatusText([In, MarshalAs(UnmanagedType.LPWStr)] string pszStatusText);

            /// <summary>
            /// Enables or disables a frame's modeless dialog boxes.
            /// </summary>
            /// <param name="fEnable">Specifies whether the modeless dialog box windows are to be enabled by specifying <see langword="true"/> or disabled by specifying <see langword="false"/>.</param>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int EnableModeless(bool fEnable);

            /// <summary>
            /// Translates accelerator keystrokes intended for the container's frame while an object is active in place.
            /// </summary>
            /// <param name="lpmsg">Pointer to the <see cref="NativeMethods.MSG"/> structure containing the keystroke message.</param>
            /// <param name="wID">Command identifier value corresponding to the keystroke in the container-provided accelerator table.</param>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int TranslateAccelerator([In] ref NativeMethods.MSG lpmsg, [In, MarshalAs(UnmanagedType.U2)] short wID);
        }
    }
}
