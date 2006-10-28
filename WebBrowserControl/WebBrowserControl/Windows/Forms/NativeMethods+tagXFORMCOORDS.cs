using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Flags indicating the exact conversion to perform.
        /// </summary>
        [Flags]
        public enum tagXFORMCOORDS : int
        {
            /// <summary>
            /// The coordinates to convert represent a position point. Cannot be used with <see cref="XFORMCOORDS_SIZE"/>.
            /// </summary>
            XFORMCOORDS_POSITION = 0x1,

            /// <summary>
            /// The coordinates to convert represent a set of dimensions. Cannot be used with <see cref="XFORMCOORDS_POSITION"/>.

            /// </summary>
            XFORMCOORDS_SIZE = 0x2,

            /// <summary>
            /// The operation converts pptlHimetric into pptfContainer. Cannot be used with <see cref="XFORMCOORDS_CONTAINERTOHIMETRIC"/>.

            /// </summary>
            XFORMCOORDS_HIMETRICTOCONTAINER = 0x4,

            /// <summary>
            /// The operation converts pptfContainer into pptlHimetric. Cannot be used with <see cref="XFORMCOORDS_HIMETRICTOCONTAINER"/>.
            /// </summary>
            XFORMCOORDS_CONTAINERTOHIMETRIC = 0x8,

            /// <summary>
            /// ?
            /// </summary>
            XFORMCOORDS_EVENTCOMPAT = 0x10
        }
    }
}
