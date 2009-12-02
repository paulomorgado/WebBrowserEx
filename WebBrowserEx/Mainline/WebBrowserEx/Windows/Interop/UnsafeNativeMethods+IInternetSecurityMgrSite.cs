//-----------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods+IInternetSecurityMgrSite.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IInternetSecurityMgrSite
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// <see cref="IInternetSecurityMgrSite"/> interface.
    /// </content>
    public static partial class UnsafeNativeMethods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
        [Guid("79eac9ee-baf9-11ce-8c82-00aa004ba90b")]
        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IInternetSecurityMgrSite
        {
            void GetWindow(ref IntPtr phwnd);

            void EnableModeless(bool fEnable);
        }
    }
}
