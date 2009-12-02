//-----------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods+IOleObject.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IOleObject
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    using System.Security;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1601:PartialElementsMustBeDocumented", Justification = "Interop Code")]
    public static partial class UnsafeNativeMethods
    {
        [Guid("00000112-0000-0000-C000-000000000046")]
        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [SuppressUnmanagedCodeSecurity]
        public interface IOleObject
        {
            int SetClientSite([In, MarshalAs(UnmanagedType.Interface)] Interop.UnsafeNativeMethods.IOleClientSite pClientSite);
            
            [PreserveSig]
            int GetClientSite([Out, MarshalAs(UnmanagedType.Interface)] out object ppClientSite);
            
            [PreserveSig]
            int SetHostNames([In, MarshalAs(UnmanagedType.LPWStr)] string szContainerApp, [In, MarshalAs(UnmanagedType.LPWStr)] string szContainerObj);
            
            [PreserveSig]
            int Close(int dwSaveOption);
            
            [PreserveSig]
            int SetMoniker([In, MarshalAs(UnmanagedType.U4)] int dwWhichMoniker, [In, MarshalAs(UnmanagedType.Interface)] object pmk);
            
            [PreserveSig]
            int GetMoniker([In, MarshalAs(UnmanagedType.U4)] int dwAssign, [In, MarshalAs(UnmanagedType.U4)] int dwWhichMoniker, [MarshalAs(UnmanagedType.Interface)] out object moniker);
            
            [PreserveSig]
            int InitFromData([In, MarshalAs(UnmanagedType.Interface)] IDataObject pDataObject, int fCreation, [In, MarshalAs(UnmanagedType.U4)] int dwReserved);
            
            [PreserveSig]
            int GetClipboardData([In, MarshalAs(UnmanagedType.U4)] int dwReserved, out IDataObject data);
            
            [PreserveSig]
            int DoVerb(int iVerb, [In] IntPtr lpmsg, [In, MarshalAs(UnmanagedType.Interface)] Interop.UnsafeNativeMethods.IOleClientSite pActiveSite, int lindex, IntPtr hwndParent, [In] Interop.NativeMethods.RECT lprcPosRect);
            
            [PreserveSig]
            int EnumVerbs(out Interop.UnsafeNativeMethods.IEnumOLEVERB e);
            
            [PreserveSig]
            int OleUpdate();
            
            [PreserveSig]
            int IsUpToDate();
            
            [PreserveSig]
            int GetUserClassID([In, Out] ref Guid pClsid);
            
            [PreserveSig]
            int GetUserType([In, MarshalAs(UnmanagedType.U4)] int dwFormOfType, [MarshalAs(UnmanagedType.LPWStr)] out string userType);
            
            [PreserveSig]
            int SetExtent([In, MarshalAs(UnmanagedType.U4)] int dwDrawAspect, [In] Interop.NativeMethods.SIZEL pSizel);
            
            [PreserveSig]
            int GetExtent([In, MarshalAs(UnmanagedType.U4)] int dwDrawAspect, [Out] Interop.NativeMethods.SIZEL pSizel);
            
            [PreserveSig]
            int Advise(System.Runtime.InteropServices.ComTypes.IAdviseSink pAdvSink, out int cookie);
            
            [PreserveSig]
            int Unadvise([In, MarshalAs(UnmanagedType.U4)] int dwConnection);
            
            [PreserveSig]
            int EnumAdvise(out System.Runtime.InteropServices.ComTypes.IEnumSTATDATA e);
            
            [PreserveSig]
            int GetMiscStatus([In, MarshalAs(UnmanagedType.U4)] int dwAspect, out int misc);
            
            [PreserveSig]
            int SetColorScheme([In] Interop.NativeMethods.LOGPALETTE pLogpal);
        }
    }
}
