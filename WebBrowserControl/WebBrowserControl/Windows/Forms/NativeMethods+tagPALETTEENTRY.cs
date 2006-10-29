using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// specifies the color and usage of an entry in a logical palette. A logical palette is defined by <see cref="tagLOGPALETTE"/>.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct tagPALETTEENTRY
        {
            /// <summary>
            /// Specifies a red intensity value for the palette entry.
            /// </summary>
            byte peRed;

            /// <summary>
            /// Specifies a green intensity value for the palette entry.
            /// </summary>
            byte peGreen;

            /// <summary>
            /// Specifies a blue intensity value for the palette entry. 
            /// </summary>
            byte peBlue;

            /// <summary>
            /// Specifies how the palette entry is to be used.
            /// </summary>
            PALETTEENTRYFLAGS peFlags;
        }
    }
}
