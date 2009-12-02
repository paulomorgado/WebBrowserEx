//-----------------------------------------------------------------------
// <copyright file="WebBrowserUIHandler.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Handles the web browser UI by implementing ICustomDoc.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    /// <summary>
    /// Handles the <see cref="WebBrowser" /> UI by implementing <see cref="ICustomDoc" />.
    /// </summary>
    public partial class WebBrowserUIHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserUIHandler"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public WebBrowserUIHandler(WebBrowserUIHandlerShim parent)
        {
            this.Parent = parent;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="WebBrowserUIHandler"/> class from being created.
        /// </summary>
        private WebBrowserUIHandler()
        {
        }

        /// <summary>
        /// Gets the parent <see cref="T:WebBrowserUIHandlerShim"/>.
        /// </summary>
        /// <value>The parent <see cref="T:WebBrowserUIHandlerShim"/>.</value>
        public WebBrowserUIHandlerShim Parent { get; private set; }
    }
}
