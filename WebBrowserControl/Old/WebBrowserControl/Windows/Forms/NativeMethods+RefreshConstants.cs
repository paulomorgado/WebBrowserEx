using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Values used with the Refresh2 and IWebBrowser2::Refresh2 methods.
        /// </summary>
        public enum RefreshConstants : int
        {
            /// <summary>
            /// Refresh that does not include sending the HTTP "pragma:nocache" header to the server.
            /// </summary>
            REFRESH_NORMAL = 0,

            /// <summary>
            /// Refresh that occurs if the page has expired.
            /// </summary>
            REFRESH_IFEXPIRED = 1,

            /// <summary>
            /// Refresh that includes sending a "pragma:nocache" header to the server (HTTP URLs only).
            /// </summary>
            REFRESH_COMPLETELY = 3
        }
    }
}
