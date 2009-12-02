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
        public interface IOleContainer //: IParseDisplayName
        {
            #region IParseDisplayName

            /// <summary>
            /// Parses the display name to extract a component of the string that it can convert into a moniker, using the maximum number of characters from the left side of the string.
            /// </summary>
            /// <param name="pbc">Pointer to the bind context to be used in this binding operation.</param>
            /// <param name="pszDisplayName">Pointer to a zero-terminated string containing the display name to be parsed. For Win32 applications, the LPOLESTR type indicates a wide character string (two bytes per character); otherwise, the string has one byte per character.</param>
            /// <param name="pchEaten">Pointer to the number of characters in the display name that correspond to the ppmkOut moniker.</param>
            /// <param name="ppmkOut">Address of IMoniker* pointer variable that receives the interface pointer to the resulting moniker.</param>
            void ParseDisplayName(
                [In, MarshalAs(UnmanagedType.Interface)] object pbc,
                [In, MarshalAs(UnmanagedType.BStr)] string pszDisplayName,
                [Out, MarshalAs(UnmanagedType.LPArray)] int[] pchEaten,
                [Out, MarshalAs(UnmanagedType.LPArray)] object[] ppmkOut);

            #endregion
            
            /// <summary>
            /// Enumerates objects in the current container.
            /// </summary>
            /// <param name="grfFlags">Value that specifies which objects in a container are to be enumerated, as defined in the enumeration OLECONTF.</param>
            /// <returns>The <see cref="T:UnsafeNativeMethods.IEnumUnknown">enumerator object</see>.</returns>
            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethods.IEnumUnknown EnumObjects(
                [In, MarshalAs(UnmanagedType.U4)] NativeMethods.tagOLECONTF grfFlags);

            /// <summary>
            /// Keeps an embedded object's container running.
            /// </summary>
            /// <param name="fLock">Value that specifies whether to lock (<see langword="true"/>) or unlock (<see langword="false"/>) a container.</param>
            void LockContainer([
                In, MarshalAs(UnmanagedType.Bool)] bool fLock);
        }
    }
}
