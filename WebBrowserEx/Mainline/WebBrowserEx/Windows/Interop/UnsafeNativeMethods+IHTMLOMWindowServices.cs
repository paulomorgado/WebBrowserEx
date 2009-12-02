//-----------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods+IHTMLOMWindowServices.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IHTMLOMWindowServices
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
        [ComVisible(true), ComImport()]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("3050f5fc-98b5-11cf-bb82-00aa00bdce0b")]
        public interface IHTMLOMWindowServices
        {
            void moveTo([In] int x, [In] int y);

            void moveBy([In] int x, [In] int y);

            void resizeTo([In] int x, [In] int y);

            void resizeBy([In] int x, [In] int y);
        }
    }
}
