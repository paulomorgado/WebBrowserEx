//-----------------------------------------------------------------------
// <copyright file="WebBrowserScriptErrorEventArgs.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// WebBrowserEx's site implementation.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using System;

    /// <summary>
    /// Provides data for the <see cref="WebBrowserControl.ScriptError"/> event.
    /// </summary>
    public class WebBrowserScriptErrorEventArgs : global::System.ComponentModel.HandledEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserScriptErrorEventArgs"/> class.
        /// </summary>
        /// <param name="document">The HTML document where the error occurred.</param>
        /// <param name="handled">The default value for the <see cref="P:System.ComponentModel.HandledEventArgs.Handled"/> property</param>
        public WebBrowserScriptErrorEventArgs(object document, bool handled)
            : base(handled)
        {
            this.Document = document;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserScriptErrorEventArgs"/> class.
        /// </summary>
        /// <param name="document">The HTML document where the error occurred.</param>
        public WebBrowserScriptErrorEventArgs(object document)
            : base()
        {
            this.Document = document;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="WebBrowserScriptErrorEventArgs"/> class from being created.
        /// </summary>
        private WebBrowserScriptErrorEventArgs()
            : base()
        {
        }

        #region Public Instance Properties

        /// <summary>
        /// Gets the document where the error occourred.
        /// </summary>
        /// <value>The document where the error occourred.</value>
        public object Document { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the execution of scripts will continue.
        /// </summary>
        /// <value><see langword="true"/> if scripts are to continue running; otherwise, <see langword="false"/>.</value>
        public bool ContinueScripts { get; set; }

        #endregion
    }
}
