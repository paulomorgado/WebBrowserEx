//-----------------------------------------------------------------------
// <copyright file="NativeMethods+CONTROLINFO.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// CONTROLINFO.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <content>
    /// Native methods.
    /// </content>
    public static partial class NativeMethods
    {
        [DebuggerDisplay("cAccel={cAccel}, dwFlags={dwFlags}")]
        [StructLayout(LayoutKind.Sequential)]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Interop Code")]
        public sealed class CONTROLINFO
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cb = Marshal.SizeOf(typeof(NativeMethods.CONTROLINFO));

            public IntPtr hAccel;

            [MarshalAs(UnmanagedType.U2)]
            public short cAccel;

            [MarshalAs(UnmanagedType.U4)]
            public int dwFlags;
        }
    }
}
