//-----------------------------------------------------------------------
// <copyright file="WebBrowserDownloadingFileEventArgs.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Provides data for the FileDownloading event.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    /// <summary>
    /// Provides data for the <see cref="E:WebBrowserControl.FileDownloading"/> event.
    /// </summary>
    public class WebBrowserDownloadingFileEventArgs : global::System.ComponentModel.CancelEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserDownloadingFileEventArgs"/> class.
        /// </summary>
        /// <param name="activeDocumentServerLoading">If set to <see langword="true"/> indicates that an Active Document server is loading in memory.</param>
        /// <param name="cancel"><see langword="true"/> true to cancel the event; otherwise, <see langword="false"/>.</param>
        public WebBrowserDownloadingFileEventArgs(bool activeDocumentServerLoading, bool cancel)
            : base(cancel)
        {
            this.ActiveDocumentServerLoading = activeDocumentServerLoading;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="T:WebBrowserDownloadingFileEventArgs"/> class from being created.
        /// </summary>
        private WebBrowserDownloadingFileEventArgs()
        {
        }

        /// <summary>
        /// Gets wheather an Active Document server is loading in memory.
        /// </summary>
        /// <value><see langword="true"/> if an Active Document server is loading in memory; otherwise, <see langword="false"/>.</value>
        public object ActiveDocumentServerLoading { get; private set; }
    }
}
