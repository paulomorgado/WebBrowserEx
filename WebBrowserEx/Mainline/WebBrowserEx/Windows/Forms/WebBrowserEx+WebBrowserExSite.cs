//-----------------------------------------------------------------------
// <copyright file="WebBrowserEx+WebBrowserExSite.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// WebBrowserEx's site implementation.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Forms
{
    using System.Runtime.InteropServices;
    using PauloMorgado.Windows.WebBrowser;

    /// <content>
    /// <see cref="T:WebBrowserEx"/>'s <see cref="T:System.Windows.Forms.WebBrowser.WebBrowserSite"/> implementation.
    /// </content>
    public partial class WebBrowserEx
    {
        /// <content>
        /// <see cref="T:WebBrowserEx"/>'s <see cref="T:System.Windows.Forms.WebBrowser.WebBrowserSite"/> implementation.
        /// </content>
        protected partial class WebBrowserExSite :
            global::System.Windows.Forms.WebBrowser.WebBrowserSite
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="WebBrowserExSite"/> class.
            /// </summary>
            /// <param name="host">The host <see cref="T:WebBrowserEx"/>.</param>
            public WebBrowserExSite(WebBrowserEx host)
                : base(host)
            {
                this.Host = host;
            }

            /// <summary>
            /// Gets the host <see cref="T:WebBrowserEx"/>.
            /// </summary>
            /// <value>The host <see cref="T:WebBrowserEx"/>.</value>
            public WebBrowserEx Host { get; private set; }

            #region Ambient Control

            /// <summary>
            /// Gets the user agent.
            /// </summary>
            /// <value>The user agent.</value>
            [DispId(-5513 /* DISPID_AMBIENT_USERAGENT */)]
            public string UserAgent
            {
                get { return this.Host.UserAgent; }
            }

            /// <summary>
            /// Gets the download control options.
            /// </summary>
            /// <value>The download control options.</value>
            [DispId(-5512 /* DISPID_AMBIENT_DLCONTROL */)]
            public WebBrowserDownloadControlOptions DownloadControl
            {
                get
                {
                    var downloadControl = WebBrowserDownloadControlOptions.Default;

                    this.Host.GetDownloadControl(downloadControl);

                    return downloadControl;
                }
            }

            #endregion
        }
    }
}
