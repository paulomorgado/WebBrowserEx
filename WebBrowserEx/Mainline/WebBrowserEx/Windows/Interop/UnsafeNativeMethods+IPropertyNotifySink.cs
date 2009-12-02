//-----------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods+IPropertyNotifySink.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IPropertyNotifySink
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    using System;
    using System.Runtime.InteropServices;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1601:PartialElementsMustBeDocumented", Justification = "Interop Code")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1604:ElementDocumentationMustHaveSummary", Justification = "Interop Code")]
    public static partial class UnsafeNativeMethods
    {
        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("9BFBBC02-EFF1-101A-84ED-00AA00341D07")]
        public interface IPropertyNotifySink
        {
            void OnChanged(int dispID);

            [PreserveSig]
            int OnRequestEdit(int dispID);
        }
    }
}
