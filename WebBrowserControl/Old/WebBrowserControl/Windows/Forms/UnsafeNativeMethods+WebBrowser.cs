using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;

namespace Pajocomo.Windows.Forms
{
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// This interface enables applications to implement an instance of the WebBrowser control (Microsoft ActiveX control) or control an instance of the InternetExplorer application (OLE Automation).
        /// </summary>
        /// <remarks>
        /// Note that not all of the methods listed below are supported by the WebBrowser control.
        /// </remarks>
        [
        ComImport,
        SuppressUnmanagedCodeSecurity,
        TypeLibType(TypeLibTypeFlags.FCanCreate | TypeLibTypeFlags.FControl),
        ComSourceInterfaces("DWebBrowserEvents2"),
        ClassInterface(ClassInterfaceType.None),
        Guid("8856F961-340A-11D0-A96B-00C04FD705A2")
        ]
        public abstract class WebBrowser
        {
        }
    }
}
