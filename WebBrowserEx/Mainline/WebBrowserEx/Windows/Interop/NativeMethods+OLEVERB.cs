//-----------------------------------------------------------------------
// <copyright file="NativeMethods+OLEVERB.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// OLEVERB.
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
        [DebuggerDisplay("lVerb={lVerb}, lpszVerbName={lpszVerbName}, fuFlags={fuFlags}, grfAttribs={grfAttribs}")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Interop Code")]
        public sealed class OLEVERB
        {
            public int lVerb;

            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszVerbName;

            [MarshalAs(UnmanagedType.U4)]
            public int fuFlags;

            [MarshalAs(UnmanagedType.U4)]
            public int grfAttribs;
        }
    }
}
