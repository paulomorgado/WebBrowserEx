using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public partial class NativeMethods
    {
        /// <summary>
        /// Flags that indicate the keyboard behavior of the control.
        /// </summary>
        [Flags]
        public enum tagCTRLINFO : int
        {
            /// <summary>
            /// When the control has the focus, it will process the Return key.
            /// </summary>
            CTRLINFO_EATS_RETURN = 1,

            /// <summary>
            /// When the control has the focus, it will process the Escape key.
            /// </summary>
            CTRLINFO_EATS_ESCAPE = 2
        }
    }
}
