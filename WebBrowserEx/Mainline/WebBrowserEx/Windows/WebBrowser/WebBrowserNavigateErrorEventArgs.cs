//-----------------------------------------------------------------------
// <copyright file="WebBrowserNavigateErrorEventArgs.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Provides data for the NavigateError event.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using System;

    /// <summary>
    /// Provides data for the <see cref="WebBrowserControl.NavigateError"/> event.
    /// </summary>
    public class WebBrowserNavigateErrorEventArgs : global::System.ComponentModel.CancelEventArgs
    {
        #region Public Instance Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserNavigateErrorEventArgs"/> class with the <see cref="WebBrowser"/>, <see cref="Url"/>, <see cref="TargetFrameName"/> and <see cref="StatusCode"/> properties set to the given values.
        /// </summary>
        /// <param name="webBrowser">
        /// The <see cref="WebBrowser"/> that represents the window or frame in which the navigation error occurred.
        /// </param>
        /// <param name="url">
        /// The URL for which navigation failed.
        /// </param>
        /// <param name="targetFrame">
        /// The name of the frame or window in which the resource is to be displayed, or a null reference (Nothing in Visual Basic) if no named frame or window was targeted for the resource. 
        /// </param>
        /// <param name="statusCode">
        /// A <see cref="NavigateErrorStatus"/> error status code.
        /// </param>
        /// <param name="cancel">
        /// <see langword="true"/> to cancel the event; otherwise, <see langword="false"/>.
        /// </param>
        public WebBrowserNavigateErrorEventArgs(WebBrowser webBrowser, Uri url, string targetFrame, WebBrowserNavigateErrorStatus statusCode, bool cancel)
            : base(cancel)
        {
            this.WebBrowser = webBrowser;
            this.Url = url;
            this.TargetFrameName = targetFrame;
            this.StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserNavigateErrorEventArgs"/> class.
        /// </summary>
        /// <param name="cancel">true to cancel the event; otherwise, false.</param>
        public WebBrowserNavigateErrorEventArgs(bool cancel)
            : base(cancel)
        {
        }
         
        #endregion

        #region Private Instance Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="T:WebBrowserNavigateErrorEventArgs"/> class from being created.
        /// </summary>
        private WebBrowserNavigateErrorEventArgs()
        {
        }

        #endregion

        #region Public Instance Properties

        /// <summary>
        /// Gets the <see cref="WebBrowser"/> that represents the window or frame in which the navigation error occurred.
        /// </summary>
        /// <value>
        /// The <see cref="WebBrowser"/> that represents the window or frame in which the navigation error occurred.
        /// </value>
        public WebBrowser WebBrowser { get; private set; }

        /// <summary>
        /// Gets the URL for which navigation failed.
        /// </summary>
        /// <value>
        /// The URL for which navigation failed.
        /// </value>
        public Uri Url { get; private set; }

        /// <summary>
        /// Gets the name of the frame or window in which the resource is to be displayed, or a null reference (Nothing in Visual Basic) if no named frame or window was targeted for the resource. 
        /// </summary>
        /// <value>
        /// The name of the frame in which or window the resource is to be displayed, or a null reference (Nothing in Visual Basic) if no named frame or window was targeted for the resource. 
        /// </value>
        public string TargetFrameName { get; private set; }

        /// <summary>
        /// Gets a <see cref="NavigateErrorStatus"/> error status code.
        /// </summary>
        /// <value>
        /// A <see cref="NavigateErrorStatus"/> error status code.
        /// </value>
        public WebBrowserNavigateErrorStatus StatusCode { get; private set; }

        #endregion
    }
}
