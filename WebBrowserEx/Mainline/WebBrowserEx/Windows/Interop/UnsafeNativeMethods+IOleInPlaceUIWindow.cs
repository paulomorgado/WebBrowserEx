//-----------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods+IOleInPlaceUIWindow.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IOleInPlaceUIWindow
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
        [Guid("00000115-0000-0000-C000-000000000046")]
        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IOleInPlaceUIWindow
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

            void SetActiveObject([In, MarshalAs(UnmanagedType.Interface)] Interop.UnsafeNativeMethods.IOleInPlaceActiveObject pActiveObject, [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjName);
        }
    }
}
