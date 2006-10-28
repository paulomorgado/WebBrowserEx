using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        public static class HRESULT
        {
            /// <summary>
            /// OK.
            /// </summary>
            public const int S_OK = 0;

            /// <summary>
            /// Not OK.
            /// </summary>
            public const int S_FALSE = 1;

            /// <summary>
            /// Not implemented.
            /// </summary>
            public const int E_NOTIMPL = unchecked((int)(0x80004001)); // -2147467263

            /// <summary>
            /// Ran out of memory.
            /// </summary>
            public const int E_OUTOFMEMORY = unchecked((int)(0x8007000EL));

            /// <summary>
            /// One or more arguments are invalid.
            /// </summary>
            public const int E_INVALIDARG = unchecked((int)(0x80070057)); // -2147024809

            /// <summary>
            /// No such interface supported.
            /// </summary>
            public const int E_NOINTERFACE = unchecked((int)(0x80004002));

            /// <summary>
            /// Invalid pointer.
            /// </summary>
            public const int E_POINTER = unchecked((int)(0x80004003));

            /// <summary>
            /// Invalid handle.
            /// </summary>
            public const int E_HANDLE = unchecked((int)(0x80070006));

            /// <summary>
            /// Operation aborted.
            /// </summary>
            public const int E_ABORT = unchecked((int)(0x80004004));

            /// <summary>
            /// Unspecified error.
            /// </summary>
            public const int E_FAIL = unchecked((int)(0x80004005));

            /// <summary>
            /// General access denied error.
            /// </summary>
            public const int E_ACCESSDENIED = unchecked((int)(0x80070005));

            /// <summary>
            /// Catastrophic failure.
            /// </summary>
            public const int E_UNEXPECTED = unchecked((int)(0x8000FFFF));
        }
    }
}
