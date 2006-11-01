using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        public enum HRESULT : int
        {
            /// <summary>
            /// OK.
            /// </summary>
            S_OK = 0,

            /// <summary>
            /// Not OK.
            /// </summary>
            S_FALSE = 1,

            /// <summary>
            /// Not implemented.
            /// </summary>
            E_NOTIMPL = unchecked((int)(0x80004001)), // -2147467263

            /// <summary>
            /// Ran out of memory.
            /// </summary>
            E_OUTOFMEMORY = unchecked((int)(0x8007000EL)),

            /// <summary>
            /// One or more arguments are invalid.
            /// </summary>
            E_INVALIDARG = unchecked((int)(0x80070057)), // -2147024809

            /// <summary>
            /// No such interface supported.
            /// </summary>
            E_NOINTERFACE = unchecked((int)(0x80004002)),

            /// <summary>
            /// Invalid pointer.
            /// </summary>
            E_POINTER = unchecked((int)(0x80004003)),

            /// <summary>
            /// Invalid handle.
            /// </summary>
            E_HANDLE = unchecked((int)(0x80070006)),

            /// <summary>
            /// Operation aborted.
            /// </summary>
            E_ABORT = unchecked((int)(0x80004004)),

            /// <summary>
            /// Unspecified error.
            /// </summary>
            E_FAIL = unchecked((int)(0x80004005)),

            /// <summary>
            /// General access denied error.
            /// </summary>
            E_ACCESSDENIED = unchecked((int)(0x80070005)),

            /// <summary>
            /// Catastrophic failure.
            /// </summary>
            E_UNEXPECTED = unchecked((int)(0x8000FFFF))
        }
    }
}
