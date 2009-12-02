//-----------------------------------------------------------------------
// <copyright file="WebBrowserNewWindowEventArgs.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Provides data for the NewWindow event.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using System;

    /// <summary>
    /// Provides data for the <see cref="WebBrowserControl.NewWindow"/> event.
    /// </summary>
    public class WebBrowserNewWindowEventArgs : global::System.ComponentModel.CancelEventArgs
    {
        #region Internal Instance Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserNewWindowEventArgs"/> class with the <see cref="P:WebBrowser"/>, <see cref="P:Flags"/>, <see cref="P:UrlContext"/> and <see cref="P:Url"/> properties set to the given values.
        /// </summary>
        /// <param name="webBrowser">
        /// The <see cref="WebBrowser"/> of the new window.
        /// </param>
        /// <param name="urlContext">
        /// The URL of the page opening the new window.
        /// </param>
        /// <param name="url">
        /// The URL being opened in the new window.
        /// </param>
        /// <param name="flags">
        /// A <see cref="NewWindowFlags"/> value that pertain to the new window.
        /// </param>
        /// <param name="cancel">
        /// <see langword="true"/> to cancel the event; otherwise, <see langword="false"/>.
        /// </param>
        internal WebBrowserNewWindowEventArgs(WebBrowser webBrowser, Uri urlContext, Uri url, WebBrowserNewWindowFlags flags, bool cancel)
            : base(cancel)
        {
            this.WebBrowser = webBrowser;
            this.Flags = flags;
            this.UrlContext = urlContext;
            this.Url = url;
        }

        #endregion

        #region Private Instance Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="WebBrowserNewWindowEventArgs"/> class from being created.
        /// </summary>
        private WebBrowserNewWindowEventArgs()
        {
        }

        #endregion

        #region Public Instance Properties

        /// <summary>
        /// Gets or sets the <see cref="WebBrowser"/> of the new window.
        /// </summary>
        /// <value>
        /// The <see cref="WebBrowser"/> of the new window.
        /// </value>
        public WebBrowser WebBrowser { get; set; }

        /// <summary>
        /// Gets the URL being opened in the new window.
        /// </summary>
        /// <value>
        /// The URL being opened in the new window.
        /// </value>
        public Uri Url { get; private set; }

        /// <summary>
        /// Gets the URL of the page opening the new window.
        /// </summary>
        /// <value>
        /// The URL of the page opening the new window.
        /// </value>
        public Uri UrlContext { get; private set; }

        /// <summary>
        /// Gets a <see cref="NewWindowFlags"/> value that pertain to the new window.
        /// </summary>
        /// <value>
        /// A <see cref="NewWindowFlags"/> value that pertain to the new window.
        /// </value>
        public WebBrowserNewWindowFlags Flags { get; private set; }

        #endregion
    }
}
