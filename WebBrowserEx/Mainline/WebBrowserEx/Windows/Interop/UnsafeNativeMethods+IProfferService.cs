//-----------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods+IProfferService.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IProfferService
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
        private const string IProfferServiceClsidString = "cb728b20-f786-11ce-92ad-00aa00a74cd0";

        [Guid(IProfferServiceClsidString)]
        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IProfferService
        {
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int ProfferService(ref Guid rguidService, IServiceProvider psp, ref uint pdwCookie);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int RevokeService(uint dwCookie);
        }
    }
}
