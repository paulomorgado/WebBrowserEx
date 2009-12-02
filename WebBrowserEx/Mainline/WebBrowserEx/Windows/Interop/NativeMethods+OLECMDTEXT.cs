//-----------------------------------------------------------------------
// <copyright file="NativeMethods+OLECMDTEXT.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// OLECMDTEXT.
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
        [DebuggerDisplay("cmdID={cmdID}, cmdf={cmdf}")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Interop Code")]
        public class OLECMDTEXT
        {
            public OLECMDTEXTF cmdtextf;

            [MarshalAs(UnmanagedType.U4)]
            public int cwActual;

            [MarshalAs(UnmanagedType.U4)]
            public int cwBuf;

            [MarshalAs(UnmanagedType.LPArray)]
            public char[] rgwz;
        }
    }
}
