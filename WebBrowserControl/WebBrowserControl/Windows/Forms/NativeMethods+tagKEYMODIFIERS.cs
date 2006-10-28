using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Flags used in calls to <see cref="IOleControlSite.TranslateAccelerator"/> to describe additional keyboard states that can modify the meaning of the keyboard messages that are also passed into <see cref="IOleControlSite.TranslateAccelerator"/>.
        /// </summary>
        [Flags]
        public enum tagKEYMODIFIERS : int
        {
            /// <summary>
            /// The Shift key is currently depressed.
            /// </summary>
            KEYMOD_SHIFT = 0x00000001,

            /// <summary>
            /// The Control key is currently depressed.
            /// </summary>
            KEYMOD_CONTROL = 0x00000002,

            /// <summary>
            /// The Alt key is currently depressed.
            /// </summary>
            KEYMOD_ALT = 0x00000004
        }
    }
}
