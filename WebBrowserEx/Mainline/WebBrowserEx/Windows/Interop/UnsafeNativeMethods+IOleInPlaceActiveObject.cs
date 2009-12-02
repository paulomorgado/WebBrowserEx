//-----------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods+IOleInPlaceActiveObject.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IOleInPlaceActiveObject
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1601:PartialElementsMustBeDocumented", Justification = "Interop Code")]
    public static partial class UnsafeNativeMethods
    {
        [Guid("00000117-0000-0000-C000-000000000046")]
        [ComImport]
        [SuppressUnmanagedCodeSecurity]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IOleInPlaceActiveObject
        {
            [PreserveSig]
            int GetWindow(out IntPtr hwnd);

            void ContextSensitiveHelp(int fEnterMode);

            [PreserveSig]
            int TranslateAccelerator([In] ref Interop.NativeMethods.MSG lpmsg);

            void OnFrameWindowActivate(bool fActivate);

            void OnDocWindowActivate(int fActivate);

            void ResizeBorder([In] Interop.NativeMethods.RECT prcBorder, [In] Interop.UnsafeNativeMethods.IOleInPlaceUIWindow pUIWindow, bool fFrameWindow);

            void EnableModeless(int fEnable);
        }
    }
}
