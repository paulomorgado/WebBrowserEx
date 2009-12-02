//-----------------------------------------------------------------------
// <copyright file="SafeNativeMethods+Kernel32.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Kernel32.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    using System.Runtime.InteropServices;

    /// <content>
    /// <see cref="Kernel32"/> class.
    /// </content>
    public static partial class SafeNativeMethods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
        public sealed class Kernel32
        {
            [DllImport("kernel32.dll", EntryPoint = "GetThreadLocale", CharSet = CharSet.Auto)]
            public static extern int GetThreadLCID();
        }
    }
}
