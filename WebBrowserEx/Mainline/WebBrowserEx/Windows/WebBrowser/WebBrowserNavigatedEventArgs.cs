//-----------------------------------------------------------------------
// <copyright file="WebBrowserNavigatedEventArgs.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Provides data for the WebBrowser's Navigated event.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using System;

    /// <summary>
    /// Provides data for the <see cref="E:WebBrowserControl.Navigated"/> event.
    /// </summary>
    public class WebBrowserNavigatedEventArgs : global::System.Windows.Forms.WebBrowserNavigatedEventArgs
    {
        #region Internal Instance Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserNavigatedEventArgs"/> class with the <see cref="WebBrowser"/> and <see cref="Url"/> properties set to the given values.
        /// </summary>
        /// <param name="webBrowser">
        /// The <see cref="WebBrowser"/> that represents the window or frame in which the navigation occurred.
        /// </param>
        /// <param name="url">
        /// The URL for which navigation occurred.
        /// </param>
        internal WebBrowserNavigatedEventArgs(WebBrowser webBrowser, Uri url)
            : base(url)
        {
            this.WebBrowser = webBrowser;
        }

        #endregion

        #region Public Instance Properties

        /// <summary>
        /// Gets the <see cref="WebBrowser"/> that represents the window or frame in which the navigation occurred.
        /// </summary>
        /// <value>
        /// The <see cref="WebBrowser"/> that represents the window or frame in which the navigation occurred.
        /// </value>
        public WebBrowser WebBrowser { get; private set; }

        #endregion
    }
}
