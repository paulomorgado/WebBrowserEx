using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Values from the CLSCTX enumeration are used in activation calls to indicate the execution contexts in which an object is to be run.
        /// These values are also used in calls to <see cref="M:UnsafeNativeMethods.CoRegisterClassObject"/> to indicate the set of execution
        /// contexts in which a class object is to be made available for requests to construct instances.<seealso cref="http://windowssdk.msdn.microsoft.com/en-us/library/ms693716(VS.80).aspx"/>
        /// </summary>
        public enum tagCLSCTX : int
        {
            /// <summary>
            /// The code that creates and manages objects of this class is a DLL that runs in the same process as the caller of the function specifying the class context.
            /// </summary>
            CLSCTX_INPROC_SERVER = 0x1,

            /// <summary>
            /// The code that manages objects of this class is an in-process handler. This is a DLL that runs in the client process and implements client-side structures of this class when instances of the class are accessed remotely.
            /// </summary>
            CLSCTX_INPROC_HANDLER = 0x2,

            /// <summary>
            /// The EXE code that creates and manages objects of this class runs on same machine but is loaded in a separate process space.
            /// </summary>
            CLSCTX_LOCAL_SERVER = 0x4,

            /// <summary>
            /// Deprecated.
            /// </summary>
            CLSCTX_INPROC_SERVER16 = 0x8,

            /// <summary>
            /// A remote machine context. The LocalServer32 or LocalService code that creates and manages objects of this class is run on a different machine.
            /// </summary>
            CLSCTX_REMOTE_SERVER = 0x10,

            /// <summary>
            /// Deprecated.
            /// </summary>
            CLSCTX_INPROC_HANDLER16 = 0x20,

            /// <summary>
            /// Deprecated.
            /// </summary>
            CLSCTX_RESERVED1 = 0x40,

            /// <summary>
            /// Deprecated.
            /// </summary>
            CLSCTX_RESERVED2 = 0x80,

            /// <summary>
            /// Deprecated.
            /// </summary>
            CLSCTX_RESERVED3 = 0x100,

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            CLSCTX_RESERVED4 = 0x200,

            /// <summary>
            /// Disallows the downloading of code from the Directory Service or the Internet.
            /// </summary>
            CLSCTX_NO_CODE_DOWNLOAD = 0x400,

            /// <summary>
            /// Deprecated.
            /// </summary>
            CLSCTX_RESERVED5 = 0x800,

            /// <summary>
            /// Specify if you want the activation to fail if it uses custom marshalling.
            /// </summary>
            CLSCTX_NO_CUSTOM_MARSHAL = 0x1000,

            /// <summary>
            /// Allows the downloading of code from the Directory Service or the Internet. This flag cannot be set at the same time as <see cref="CLSCTX_NO_CODE_DOWNLOAD"/>
            /// </summary>
            CLSCTX_ENABLE_CODE_DOWNLOAD = 0x2000,

            /// <summary>
            /// The <see cref="CLSCTX_NO_FAILURE_LOG"/> can be used to override the logging of failures in <see cref="M:UnsafeNativeMethods.CoCreateInstanceEx"/>.
            /// </summary>
            CLSCTX_NO_FAILURE_LOG = 0x4000,

            /// <summary>
            /// Disables activate-as-activator (AAA) activations for this activation only.
            /// </summary>
            CLSCTX_DISABLE_AAA = 0x8000,

            /// <summary>
            /// Enables activate-as-activator (AAA) activations for this activation only.
            /// </summary>
            CLSCTX_ENABLE_AAA = 0x10000,

            /// <summary>
            /// Begin this activation from the default context of the current apartment.
            /// </summary>
            CLSCTX_FROM_DEFAULT_CONTEXT = 0x20000,

            /// <summary>
            /// Activate or connect to a 32-bit version of the server; fail if one is not registered.
            /// </summary>
            CLSCTX_ACTIVATE_32_BIT_SERVER = 0x40000,

            /// <summary>
            /// Activate or connect to a 64 bit version of the server; fail if one is not registered.
            /// </summary>
            CLSCTX_ACTIVATE_64_BIT_SERVER = 0x80000
        }
    }
}
