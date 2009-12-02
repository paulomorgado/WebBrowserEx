//-----------------------------------------------------------------------
// <copyright file="WebBrowserPrintTemplateEventArgs.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Provides data for the WebBrowser's PrintTemplateCreated and PrintTemplateDestroyed events.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    /// <summary>
    /// Provides data for the <see cref="E:WebBrowserControl.PrintTemplateCreated"/> and <see cref="E:WebBrowserControl.PrintTemplateDestroyed"/> events.
    /// </summary>
    public class WebBrowserPrintTemplateEventArgs : global::System.EventArgs
    {
        #region Internal Instance Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserPrintTemplateEventArgs"/> class with the <see cref="WebBrowser"/> property set to the given value.
        /// </summary>
        /// <param name="webBrowser">
        /// The <see cref="WebBrowser"/> that represents the window or frame in which the navigation error occurred.
        /// </param>
        internal WebBrowserPrintTemplateEventArgs(WebBrowser webBrowser)
        {
            this.WebBrowser = webBrowser;
        }

        #endregion

        #region Private Instance Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="T:WebBrowserPrintTemplateEventArgs"/> class from being created.
        /// </summary>
        private WebBrowserPrintTemplateEventArgs()
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

        #endregion
    }
}
