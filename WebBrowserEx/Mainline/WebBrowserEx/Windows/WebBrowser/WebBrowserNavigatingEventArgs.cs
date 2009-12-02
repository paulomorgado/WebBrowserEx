//-----------------------------------------------------------------------
// <copyright file="WebBrowserNavigatingEventArgs.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Provides data for the Navigating event.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using System;

    /// <summary>
    /// Provides data for the <see cref="WebBrowserControl.Navigating"/> event.
    /// </summary>
    public class WebBrowserNavigatingEventArgs : global::System.Windows.Forms.WebBrowserNavigatingEventArgs
    {
        #region Internal Instance Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserNavigatingEventArgs"/> class with the <see cref="WebBrowser"/>, <see cref="Url"/>, <see cref="TargetFrameName"/>, <see cref="PostData"/> and <see cref="Headers"/> properties set to the given values.
        /// </summary>
        /// <param name="webBrowser">The <see cref="WebBrowser"/> of window or frame performing the navigation.</param>
        /// <param name="url">The URL to be navigated to.</param>
        /// <param name="targetFrameName">The name of the frame or window in which the resource is to be displayed, or a null reference (Nothing in Visual Basic) if no named frame or window was targeted for the resource.</param>
        /// <param name="postData">A <see cref="byte"/> array that contains the data to send to the server if the HTTP POST transaction is being used.</param>
        /// <param name="headers">A <see cref="string"/> that contains additional HTTP headers to send to the server (HTTPURLs only). The headers can specify things such as the action required of the server, the type of data being passed to the server, or a status code.</param>
        public WebBrowserNavigatingEventArgs(WebBrowser webBrowser, Uri url, string targetFrameName, byte[] postData, string headers)
            : base(url, targetFrameName)
        {
            this.WebBrowser = webBrowser;
            this.PostData = postData;
            this.Headers = headers;
        }

        #endregion

        #region Public Instance Properties

        /// <summary>
        /// Gets the <see cref="WebBrowser"/> of the window or frame preforming the navigation.
        /// </summary>
        /// <value>
        /// The <see cref="WebBrowser"/> of window or frame preforming the navigation.
        /// </value>
        public WebBrowser WebBrowser { get; private set; }

        /// <summary>
        /// Gets a <see cref="byte"/> array that contains the data to send to the server if the HTTP POST transaction is being used.
        /// </summary>
        /// <value>
        /// A <see cref="byte"/> array that contains the data to send to the server if the HTTP POST transaction is being used.
        /// </value>
        public byte[] PostData { get; private set; }

        /// <summary>
        /// Gets a <see cref="string"/> that contains additional HTTP headers to send to the server (HTTPURLs only). The headers can specify things such as the action required of the server, the type of data being passed to the server, or a status code. 
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that contains additional HTTP headers to send to the server (HTTPURLs only). The headers can specify things such as the action required of the server, the type of data being passed to the server, or a status code. 
        /// </value>
        public string Headers { get; private set; }

        #endregion
    }
}
