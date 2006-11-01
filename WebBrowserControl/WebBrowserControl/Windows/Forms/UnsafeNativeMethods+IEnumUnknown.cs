using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// enumerates objects with the IUnknown interface.
        /// </summary>
        [ComImport, Guid("00000100-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IEnumUnknown
        {
            /// <summary>
            /// Retrieves a specified number of items in the enumeration sequence.
            /// </summary>
            /// <param name="celt">Number of elements requested.</param>
            /// <param name="rgelt">Array of size celt (or larger) of the elements of interest.</param>
            /// <param name="pceltFetched">Pointer to the number of elements supplied in rgelt.</param>
            /// <returns><see langword="false"/> if the container processed the message; otherwise <see langword="true"/>.</returns>
            [return: MarshalAs(UnmanagedType.Bool)]
            bool Next(
                [In, MarshalAs(UnmanagedType.U4)] int celt, 
                [Out] IntPtr rgelt, 
                [Out] IntPtr pceltFetched);

            /// <summary>
            /// Skips over a specified number of items in the enumeration sequence.
            /// </summary>
            /// <param name="celt">Number of elements to be skipped.</param>
            /// <returns><see langword="false"/> if the container processed the message; otherwise <see langword="true"/>.</returns>
            [return: MarshalAs(UnmanagedType.Bool)]
            bool Skip(
                [In, MarshalAs(UnmanagedType.U4)] int celt);

            /// <summary>
            /// Resets the enumeration sequence to the beginning.
            /// </summary>
            void Reset();

            /// <summary>
            /// Creates a copy of the current state of enumeration.
            /// </summary>
            /// <return>The <see cref="IEnumUnknown">enumeration object</see>.</return>
            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethods.IEnumUnknown Clone();
        }
    }
}
