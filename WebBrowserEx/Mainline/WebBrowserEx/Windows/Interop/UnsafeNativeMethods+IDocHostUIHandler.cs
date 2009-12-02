//-----------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods+IDocHostUIHandler.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IDocHostUIHandler
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1601:PartialElementsMustBeDocumented", Justification = "Interop Code")]
    public static partial class UnsafeNativeMethods
    {
        [Guid("BD3F23C0-D43E-11CF-893B-00AA00BDCE1A")]
        [ComImport]
        [ComVisible(true)]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDocHostUIHandler
        {
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int ShowContextMenu(
                [In, MarshalAs(UnmanagedType.U4)] int dwID,
                [In] Interop.NativeMethods.POINT pt,
                [In, MarshalAs(UnmanagedType.Interface)] object pcmdtReserved,
                [In, MarshalAs(UnmanagedType.Interface)] object pdispReserved);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int GetHostInfo([In, Out] Interop.NativeMethods.DOCHOSTUIINFO info);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int ShowUI(
                [In, MarshalAs(UnmanagedType.I4)] int dwID,
                [In] Interop.UnsafeNativeMethods.IOleInPlaceActiveObject activeObject,
                [In] Interop.NativeMethods.IOleCommandTarget commandTarget,
                [In] Interop.UnsafeNativeMethods.IOleInPlaceFrame frame,
                [In] Interop.UnsafeNativeMethods.IOleInPlaceUIWindow doc);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int HideUI();

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int UpdateUI();

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int EnableModeless([In, MarshalAs(UnmanagedType.Bool)] bool fEnable);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int OnDocWindowActivate([In, MarshalAs(UnmanagedType.Bool)] bool fActivate);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int OnFrameWindowActivate([In, MarshalAs(UnmanagedType.Bool)] bool fActivate);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int ResizeBorder(
                [In] Interop.NativeMethods.RECT rect,
                [In] Interop.UnsafeNativeMethods.IOleInPlaceUIWindow doc,
                bool fFrameWindow);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int TranslateAccelerator(
                [In] ref Interop.NativeMethods.MSG msg,
                [In] ref Guid group,
                [In, MarshalAs(UnmanagedType.I4)] int nCmdID);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int GetOptionKeyPath(
                [Out, MarshalAs(UnmanagedType.LPArray)] string[] pbstrKey,
                [In, MarshalAs(UnmanagedType.U4)] int dw);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int GetDropTarget(
                [In, MarshalAs(UnmanagedType.Interface)] Interop.UnsafeNativeMethods.IOleDropTarget pDropTarget,
                [MarshalAs(UnmanagedType.Interface)] out Interop.UnsafeNativeMethods.IOleDropTarget ppDropTarget);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int GetExternal([MarshalAs(UnmanagedType.Interface)] out object ppDispatch);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int TranslateUrl(
                [In, MarshalAs(UnmanagedType.U4)] int dwTranslate,
                [In, MarshalAs(UnmanagedType.LPWStr)] string strURLIn,
                [MarshalAs(UnmanagedType.LPWStr)] out string pstrURLOut);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int FilterDataObject(IDataObject pDO, out IDataObject ppDORet);
        }
    }
}
