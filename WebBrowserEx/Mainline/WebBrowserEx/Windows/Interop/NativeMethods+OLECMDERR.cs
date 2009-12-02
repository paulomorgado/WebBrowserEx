//-----------------------------------------------------------------------
// <copyright file="NativeMethods+OLECMDERR.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// OLECMDERR.
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Interop Code")]
        public sealed class OLECMDERR
        {
            public const int OLECMDERR_E_NOTSUPPORTED = unchecked((int)0x80040100);
            public const int OLECMDERR_E_DISABLED = unchecked((int)0x80040101);
            public const int OLECMDERR_E_NOHELP = unchecked((int)0x80040102);
            public const int OLECMDERR_E_CANCELED = unchecked((int)0x80040103);
            public const int OLECMDERR_E_UNKNOWNGROUP = unchecked((int)0x80040104);
        }
    }
}
