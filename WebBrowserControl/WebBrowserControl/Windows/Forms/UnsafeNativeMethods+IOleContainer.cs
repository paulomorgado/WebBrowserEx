using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// Used to enumerate objects in a compound document or lock a container in the running state.
        /// </summary>
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0000011B-0000-0000-C000-000000000046")]
        public interface IOleContainer : IParseDisplayName
        {
            /// <summary>
            /// Enumerates objects in the current container.
            /// </summary>
            /// <param name="grfFlags">Value that specifies which objects in a container are to be enumerated, as defined in the enumeration OLECONTF.</param>
            /// <param name="ppenum">Address of IEnumUnknown* pointer variable that receives the interface pointer to the enumerator object.</param>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int EnumObjects([In, MarshalAs(UnmanagedType.U4)] NativeMethods.tagOLECONTF grfFlags, out UnsafeNativeMethods.IEnumUnknown ppenum);

            /// <summary>
            /// Keeps an embedded object's container running.
            /// </summary>
            /// <param name="fLock">Value that specifies whether to lock (<see langword="true"/>) or unlock (<see langword="false"/>) a container.</param>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int LockContainer(bool fLock);
        }
    }
}
