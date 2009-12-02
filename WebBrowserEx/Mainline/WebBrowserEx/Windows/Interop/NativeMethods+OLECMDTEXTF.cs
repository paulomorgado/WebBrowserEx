//-----------------------------------------------------------------------
// <copyright file="NativeMethods+OLECMDTEXTF.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// OLECMDTEXTF.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    /// <content>
    /// Native methods.
    /// </content>
    public static partial class NativeMethods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Interop Code")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Interop Code")]
        public enum OLECMDTEXTF : uint
        {
            OLECMDTEXTF_NONE = 0,
            OLECMDTEXTF_NAME = 1,
            OLECMDTEXTF_STATUS = 2
        }
    }
}
