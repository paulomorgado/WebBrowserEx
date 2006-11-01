using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// Enumerates the different verbs available for an object in order of ascending verb number.
        /// </summary>
        [ComImport, Guid("00000104-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IEnumOLEVERB
        {
            /// <summary>
            /// Retrieves a specified number of items in the enumeration sequence.
            /// </summary>
            /// <param name="celt">Number of elements requested.</param>
            /// <param name="rgelt">Array of size celt (or larger) of the elements of interest.</param>
            /// <param name="pceltFetched">Pointer to the number of elements supplied in rgelt.</param>
            void Next(
                [In, MarshalAs(UnmanagedType.U4)] int celt, 
                [Out, MarshalAs(UnmanagedType.Interface)] NativeMethods.tagOLEVERB rgelt, 
                [Out, MarshalAs(UnmanagedType.LPArray)] int[] pceltFetched);

            /// <summary>
            /// Skips over a specified number of items in the enumeration sequence.
            /// </summary>
            /// <param name="celt">Number of elements to be skipped.</param>
            void Skip(
                [In, MarshalAs(UnmanagedType.U4)] int celt);

            /// <summary>
            /// Resets the enumeration sequence to the beginning.
            /// </summary>
            void Reset();

            /// <summary>
            /// Creates a copy of the current state of enumeration.
            /// </summary>
            /// <return>The <see cref="IEnumOLEVERB">enumeration object</see>.</return>
            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethods.IEnumOLEVERB Clone();
        }
    }
}
