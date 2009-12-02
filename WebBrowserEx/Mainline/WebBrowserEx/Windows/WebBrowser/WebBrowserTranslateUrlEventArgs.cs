//-----------------------------------------------------------------------
// <copyright file="WebBrowserTranslateUrlEventArgs.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Provides data for the WebBrowser's TranslateUrl event.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    /// <summary>
    /// Provides data for the <see cref="E:WebBrowserControl.TranslateUrl"/> event.
    /// </summary>
    public class WebBrowserTranslateUrlEventArgs : global::System.EventArgs
    {
        #region Internal Instance Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserTranslateUrlEventArgs"/> class.
        /// </summary>
        /// <param name="originalUrl">The original URL.</param>
        internal WebBrowserTranslateUrlEventArgs(string originalUrl)
            : base()
        {
            this.Url = originalUrl;
        }

        #endregion

        #region Private Instance Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="T:WebBrowserTranslateUrlEventArgs"/> class from being created.
        /// </summary>
        private WebBrowserTranslateUrlEventArgs()
        {
        }

        #endregion

        #region Public Instance Properties

        /// <summary>
        /// Gets or sets the new URL for the navigation.
        /// </summary>
        /// <value>
        /// The the new URL for the navigation.
        /// </value>
        public string Url { get; set; }

        #endregion
    }
}
