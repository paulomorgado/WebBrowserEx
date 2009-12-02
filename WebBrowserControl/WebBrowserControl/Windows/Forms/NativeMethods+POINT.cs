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
        [StructLayout(LayoutKind.Sequential)]
        public class POINT
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
            /// Initializes a new instance of the <see cref="POINT"/> class.
            /// </summary>
            public POINT()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="POINT"/> class.
            /// </summary>
            /// <param name="x">The x.</param>
            /// <param name="y">The y.</param>
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
