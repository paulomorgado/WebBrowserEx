//-----------------------------------------------------------------------
// <copyright file="NativeMethods+Util.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Utils.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    using System;

    /// <content>
    /// Native methods.
    /// </content>
    public static partial class NativeMethods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1601:PartialElementsMustBeDocumented", Justification = "Interop Code")]
        public static class Util
        {
            public static int HIWORD(int n)
            {
                return ((n >> 16) & 0xFFFF);
            }

            public static int HIWORD(IntPtr n)
            {
                return HIWORD((int)((long)n));
            }

            public static int LOWORD(int n)
            {
                return (n & 0xFFFF);
            }

            public static int LOWORD(IntPtr n)
            {
                return LOWORD((int)((long)n));
            }

            public static int SignedHIWORD(int n)
            {
                return (short)((n >> 16) & 0xFFFF);
            }

            public static int SignedHIWORD(IntPtr n)
            {
                return SignedHIWORD((int)((long)n));
            }

            public static int SignedLOWORD(int n)
            {
                return (short)(n & 0xFFFF);
            }

            public static int SignedLOWORD(IntPtr n)
            {
                return SignedLOWORD((int)((long)n));
            }
        }
    }
}
