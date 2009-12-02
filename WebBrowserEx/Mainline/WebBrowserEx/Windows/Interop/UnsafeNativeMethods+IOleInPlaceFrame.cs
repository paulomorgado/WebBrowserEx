//-----------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods+IOleInPlaceFrame.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IOleInPlaceFrame
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    using System;
    using System.Runtime.InteropServices;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1601:PartialElementsMustBeDocumented", Justification = "Interop Code")]
    public static partial class UnsafeNativeMethods
    {
        [Guid("00000116-0000-0000-C000-000000000046")]
        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IOleInPlaceFrame
        {
            IntPtr GetWindow();

            [PreserveSig]
            int ContextSensitiveHelp(int fEnterMode);

            [PreserveSig]
            int GetBorder([Out] Interop.NativeMethods.RECT lprectBorder);

            [PreserveSig]
            int RequestBorderSpace([In] Interop.NativeMethods.RECT pborderwidths);

            [PreserveSig]
            int SetBorderSpace([In] Interop.NativeMethods.RECT pborderwidths);

            [PreserveSig]
            int SetActiveObject([In, MarshalAs(UnmanagedType.Interface)] Interop.UnsafeNativeMethods.IOleInPlaceActiveObject pActiveObject, [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjName);

            [PreserveSig]
            int InsertMenus([In] IntPtr hmenuShared, [In, Out] Interop.NativeMethods.OleMenuGroupWidths lpMenuWidths);

            [PreserveSig]
            int SetMenu([In] IntPtr hmenuShared, [In] IntPtr holemenu, [In] IntPtr hwndActiveObject);

            [PreserveSig]
            int RemoveMenus([In] IntPtr hmenuShared);

            [PreserveSig]
            int SetStatusText([In, MarshalAs(UnmanagedType.LPWStr)] string pszStatusText);

            [PreserveSig]
            int EnableModeless(bool fEnable);

            [PreserveSig]
            int TranslateAccelerator([In] ref Interop.NativeMethods.MSG lpmsg, [In, MarshalAs(UnmanagedType.U2)] short wID);
        }
    }
}
