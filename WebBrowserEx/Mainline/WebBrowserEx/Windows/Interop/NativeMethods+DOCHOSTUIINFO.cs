//-----------------------------------------------------------------------
// <copyright file="NativeMethods+DOCHOSTUIINFO.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// DOCHOSTUIINFO.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using PauloMorgado.Windows.WebBrowser;

    /// <content>
    /// Native methods.
    /// </content>
    public static partial class NativeMethods
    {
        [DebuggerDisplay("cbSize={cbSize}, dwFlags={dwFlags}, dwDoubleClick={dwDoubleClick}, dwReserved1={dwReserved1}, dwReserved2={dwReserved2}")]
        [StructLayout(LayoutKind.Sequential)]
        [ComVisible(true)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1601:PartialElementsMustBeDocumented", Justification = "Interop Code")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Interop Code")]
        public class DOCHOSTUIINFO
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize = Marshal.SizeOf(typeof(DOCHOSTUIINFO));

            [MarshalAs(UnmanagedType.I4)]
            public WebBrowserCapabilities dwFlags;

            [MarshalAs(UnmanagedType.I4)]
            public WebBrowserDoubleClickActions dwDoubleClick = 0;

            [MarshalAs(UnmanagedType.I4)]
            public int dwReserved1 = 0;

            [MarshalAs(UnmanagedType.I4)]
            public int dwReserved2 = 0;
        }
    }
}
