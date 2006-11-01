using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Defines the width and height of a rectangle.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagSIZE
        {
            /// <summary>
            /// Specifies the rectangle's width. The units depend on which function uses this structure.
            /// </summary>
            public int cx;

            /// <summary>
            /// Specifies the rectangle's height. The units depend on which function uses this structure.
            /// </summary>
            public int cy;

            /// <summary>
            /// Initializes a new instance of the <see cref="tagSIZE"/> class.
            /// </summary>
            public tagSIZE()
            {
            }

            /// <summary>
            /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:tagSIZE"></see>.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.String"></see> that represents the current <see cref="T:tagSIZE"></see>.
            /// </returns>
            public override string ToString()
            {
                return "cx = " + this.cx + " cy " + this.cy;
            }
        }
    }
}
