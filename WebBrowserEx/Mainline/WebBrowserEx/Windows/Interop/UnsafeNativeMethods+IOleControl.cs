//-----------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods+IOleControl.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IOleControl
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <content>
    /// <see cref="IOleControl"/> interface.
    /// </content>
    public static partial class UnsafeNativeMethods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
        [ComImport]
        [SuppressUnmanagedCodeSecurity]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("B196B288-BAB4-101A-B69C-00AA00341D07")]
        public interface IOleControl
        {
            [PreserveSig]
            int GetControlInfo([Out] Interop.NativeMethods.CONTROLINFO pCI);

            [PreserveSig]
            int OnMnemonic([In] ref Interop.NativeMethods.MSG pMsg);

            [PreserveSig]
            int OnAmbientPropertyChange(int dispID);

            [PreserveSig]
            int FreezeEvents(int bFreeze);
        }
    }
}
