//-----------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods+IInternetSecurityManager.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IInternetSecurityManager
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// <see cref="IInternetSecurityManager"/> interface.
    /// </content>
    public static partial class UnsafeNativeMethods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
        [ComImport]
        [GuidAttribute("79EAC9EE-BAF9-11CE-8C82-00AA004BA90B")]
        [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IInternetSecurityManager
        {
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int SetSecuritySite(
                [In] IntPtr pSite);
            ////[In] Interop.UnsafeNativeMethods.IInternetSecurityMgrSite pSite);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int GetSecuritySite(
                out IntPtr pSite);
            ////out Interop.UnsafeNativeMethods.IInternetSecurityMgrSite pSite);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int MapUrlToZone(
                [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
                out uint pdwZone,
                [In] uint dwFlags);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int GetSecurityId(
                [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
                [Out] IntPtr pbSecurityId,
                [In, Out] ref uint pcbSecurityId,
                [In] uint dwReserved);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int ProcessUrlAction(
                [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
                uint dwAction,
                IntPtr pPolicy,
                uint cbPolicy,
                IntPtr pContext,
                uint cbContext,
                uint dwFlags,
                uint dwReserved);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int QueryCustomPolicy(
                [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
                ref Guid guidKey,
                out IntPtr ppPolicy,
                out uint pcbPolicy,
                IntPtr pContext,
                uint cbContext,
                uint dwReserved);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int SetZoneMapping(
                uint dwZone,
                [In, MarshalAs(UnmanagedType.LPWStr)] string lpszPattern,
                uint dwFlags);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int GetZoneMappings(
                [In] uint dwZone,
                out System.Runtime.InteropServices.ComTypes.IEnumString ppenumString,
                [In] uint dwFlags);
        }
    }
}
