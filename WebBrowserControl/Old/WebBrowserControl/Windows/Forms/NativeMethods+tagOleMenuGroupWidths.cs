using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Represents the mechanism for building a shared menu.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagOleMenuGroupWidths
        {
            /// <summary>
            /// An array whose elements contain the number of menu items in each of the six menu groups of a shared in-place editing menu.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public int[] widths;

            /// <summary>
            /// Initializes a new instance of the <see cref="tagOleMenuGroupWidths"/> class.
            /// </summary>
            public tagOleMenuGroupWidths()
            {
                this.widths = new int[6];
            }
        }
    }
}
