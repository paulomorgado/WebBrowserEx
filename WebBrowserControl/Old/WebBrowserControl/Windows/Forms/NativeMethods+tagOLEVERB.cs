using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Defines a verb that an object supports.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagOLEVERB
        {
            /// <summary>
            /// Integer identifier associated with this verb.
            /// </summary>
            public int lVerb;

            /// <summary>
            /// Pointer to a string that contains the verb's name.
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszVerbName;

            /// <summary>
            /// A group of flags taken from the flag constants beginning with MF_.
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public int fuFlags;

            /// <summary>
            /// Combination of the verb attributes in the <see cref="tagOLEVERBATTRIB"/> enumeration. 
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public tagOLEVERBATTRIB grfAttribs;

            /// <summary>
            /// Initializes a new instance of the <see cref="tagOLEVERB"/> class.
            /// </summary>
            public tagOLEVERB()
            {
            }
        }
    }
}
