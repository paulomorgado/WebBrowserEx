//-----------------------------------------------------------------------
// <copyright file="NativeMethods+RECT.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// RECT.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1601:PartialElementsMustBeDocumented", Justification = "Interop Code")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Interop Code")]
    public static partial class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        [DebuggerDisplay("Left={left}, Top={top}, Right={right}, Bottom={bottom}")]
        public class RECT
        {
            /// <summary>
            /// Specifies the x-coordinate of the upper-left corner of the rectangle.
            /// </summary>
            public int left;

            /// <summary>
            /// Specifies the y-coordinate of the upper-left corner of the rectangle.
            /// </summary>
            public int top;

            /// <summary>
            /// Specifies the x-coordinate of the lower-right corner of the rectangle.
            /// </summary>
            public int right;

            /// <summary>
            /// Specifies the y-coordinate of the lower-right corner of the rectangle.
            /// </summary>
            public int bottom;
        }
    }
}
