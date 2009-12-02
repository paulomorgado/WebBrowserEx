using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Used in the <see cref="IOleControlSite.TransformCoords"/> method to convert between container units, expressed in floating point, and control units, expressed in HIMETRIC.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagPOINTF
        {
            /// <summary>
            /// The x coordinates of the point in units that the container finds convenient.
            /// </summary>
            [MarshalAs(UnmanagedType.R4)]
            public float x;

            /// <summary>
            /// The y coordinates of the point in units that the container finds convenient.
            /// </summary>
            [MarshalAs(UnmanagedType.R4)]
            public float y;

            /// <summary>
            /// Initializes a new instance of the <see cref="tagPOINTF"/> class.
            /// </summary>
            public tagPOINTF()
            {
            }
        }
    }
}
