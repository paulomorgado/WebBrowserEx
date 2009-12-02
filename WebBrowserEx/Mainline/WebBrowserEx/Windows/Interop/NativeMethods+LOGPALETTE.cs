//-----------------------------------------------------------------------
// <copyright file="NativeMethods+LOGPALETTE.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// LOGPALETTE.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    /// <content>
    /// Native methods.
    /// </content>
    public static partial class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        [DebuggerDisplay("palVersion={palVersion}, palNumEntries={palNumEntries}")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Interop Code")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Interop Code")]
        public sealed class LOGPALETTE
        {
            [MarshalAs(UnmanagedType.U2)]
            public short palVersion;

            [MarshalAs(UnmanagedType.U2)]
            public short palNumEntries;
        }
    }
}
