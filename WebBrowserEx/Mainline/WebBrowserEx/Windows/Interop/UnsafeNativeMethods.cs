//-----------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Unsafe native methods.
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
        public static readonly Guid DocHostCommandHandlerCgid = new Guid(0xf38bc242, 0xb950, 0x11d1, 0x89, 0x18, 0x00, 0xc0, 0x4f, 0xc2, 0xc8, 0x36);

        public const string WebBrowserClsid = "8856f961-340a-11d0-a96b-00c04fd705a2";

        [return: MarshalAs(UnmanagedType.Interface)]
        [DllImport("ole32.dll", ExactSpelling = true, PreserveSig = false)]
        public static extern object CoCreateInstance([In] ref Guid clsid, [MarshalAs(UnmanagedType.Interface)] object punkOuter, int context, [In] ref Guid iid);
    }
}
