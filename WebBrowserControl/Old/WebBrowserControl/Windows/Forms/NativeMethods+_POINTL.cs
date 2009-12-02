using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Defines the x- and y-coordinates of a point.
        /// </summary>
        [StructLayout(LayoutKind.Sequential), CLSCompliant(false)]
        public sealed class _POINTL
        {
            /// <summary>
            /// Specifies the x-coordinate of the point.
            /// </summary>
            public int x;

            /// <summary>
            /// Specifies the y-coordinate of the point.
            /// </summary>
            public int y;

            /// <summary>
            /// Initializes a new instance of the <see cref="_POINTL"/> class.
            /// </summary>
            public _POINTL()
            {
            }
        }
    }
}
