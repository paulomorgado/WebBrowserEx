using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Palette entry flags.
        /// </summary>
        [Flags]
        public enum PALETTEENTRYFLAGS : byte
        {
            /// <summary>
            /// Palette index used for animation.
            /// </summary>
            PC_RESERVED = 0x01,

            /// <summary>
            /// Palette index is explicit to device.
            /// </summary>
            PC_EXPLICIT = 0x02,

            /// <summary>
            /// Do not match color to system palette.
            /// </summary>
            PC_NOCOLLAPSE = 0x04

        }
    }
}
