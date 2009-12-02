//-----------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods+IOleServiceProvider.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IServiceProvider
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
        [Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IServiceProvider
        {
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int QueryService(
                [In] IntPtr pguidService,
                [In] IntPtr priid,
                [Out] out IntPtr ppvObject);
        }
    }
}
