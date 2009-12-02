//-----------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods+IOleInPlaceObject.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IOleInPlaceObject
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <content>
    /// <see cref="IOleInPlaceObject"/> interface.
    /// </content>
    public static partial class UnsafeNativeMethods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
        [ComImport]
        [Guid("00000113-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [SuppressUnmanagedCodeSecurity]
        public interface IOleInPlaceObject
        {
            [PreserveSig]
            int GetWindow(out IntPtr hwnd);

            void ContextSensitiveHelp(int fEnterMode);

            void InPlaceDeactivate();

            [PreserveSig]
            int UIDeactivate();

            void SetObjectRects([In] Interop.NativeMethods.RECT lprcPosRect, [In] Interop.NativeMethods.RECT lprcClipRect);

            void ReactivateAndUndo();
        }
    }
}
