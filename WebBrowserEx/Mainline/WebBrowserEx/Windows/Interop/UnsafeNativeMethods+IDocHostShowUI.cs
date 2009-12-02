//-----------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods+IDocHostShowUI.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IDocHostShowUI
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
        [Guid("C4D244B0-D43E-11CF-893B-00AA00BDCE1A")]
        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDocHostShowUI
        {
            [PreserveSig]
            uint ShowMessage(
                IntPtr hwnd,
                [MarshalAs(UnmanagedType.LPWStr)] string lpstrText,
                [MarshalAs(UnmanagedType.LPWStr)] string lpstrCaption,
                uint dwType,
                [MarshalAs(UnmanagedType.LPWStr)] string lpstrHelpFile,
                uint dwHelpContext,
                out int lpResult);

            [PreserveSig]
            uint ShowHelp(
                IntPtr hwnd,
                [MarshalAs(UnmanagedType.LPWStr)] string pszHelpFile,
                uint uCommand,
                uint dwData,
                Interop.NativeMethods.POINT ptMouse,
                [MarshalAs(UnmanagedType.IDispatch)] object pDispatchObjectHit);
        }
    }
}
