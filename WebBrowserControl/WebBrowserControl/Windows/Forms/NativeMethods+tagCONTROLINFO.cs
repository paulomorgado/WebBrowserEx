using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;

namespace Pajocomo.Windows.Forms
{
    public partial class NativeMethods
    {
        /// <summary>
        /// Contains parameters that describe a control's keyboard mnemonics and keyboard behavior.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagCONTROLINFO
        {
            /// <summary>
            /// Size of the CONTROLINFO structure.
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public int cb;

            /// <summary>
            /// Handle to an array of Windows ACCEL structures, each structure describing a keyboard mnemonic.
            /// </summary>
            public IntPtr hAccel;

            /// <summary>
            /// Number of mnemonics described in the hAccel field.
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public short cAccel;

            /// <summary>
            /// Flags that indicate the keyboard behavior of the control.
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public tagCTRLINFO dwFlags;

            /// <summary>
            /// Initializes a new instance of the <see cref="tagCONTROLINFO"/> class.
            /// </summary>
            public tagCONTROLINFO()
            {
                this.cb = Marshal.SizeOf(typeof(NativeMethods.tagCONTROLINFO));
            }
        }
    }
}
