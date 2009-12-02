using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// designates the type of support provided by an object for the command specified in an  <see cref="OLECMD"/> structure.
        /// </summary>
        public enum OLECMDF : int
        {
            /// <summary>
            /// The command is supported by this object.
            /// </summary>
            OLECMDF_SUPPORTED = 0x01,

            /// <summary>
            /// The command is available and enabled.
            /// </summary>
            OLECMDF_ENABLED = 0x02,

            /// <summary>
            /// The command is an on-off toggle and is currently on.
            /// </summary>
            OLECMDF_LATCHED = 0x04,

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            OLECMDF_NINCHED = 0x08,

            /// <summary>
            /// The command should not be visible at the moment.
            /// </summary>
            OLECMDF_INVISIBLE = 0x10,

            /// <summary>
            /// The command should be hidden if it appears on a context menu.
            /// </summary>
            OLECMDF_DEFHIDEONCTXTMENU = 0x20
        }
    }
}
