//-----------------------------------------------------------------------
// <copyright file="NativeMethods+WindowsMessages.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// WindowsMessages.
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
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1601:PartialElementsMustBeDocumented", Justification = "Interop Code")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Interop Code")]
        internal static class WindowsMessages
        {
            public const int WM_DESTROY = 0x0002;
            public const int WM_PARENTNOTIFY = 0x0210;
        }
    }
}
