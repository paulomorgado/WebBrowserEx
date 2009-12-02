//-----------------------------------------------------------------------
// <copyright file="WebBrowserEvents.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Handles IWebBrowser events by implementing DWebBrowserEvents2.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Handles <see cref="T:IWebBrowser"/> events by implementing <see cref="T:DWebBrowserEvents2"/>.
    /// </summary>
    public partial class WebBrowserEvents
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserEvents"/> class.
        /// </summary>
        /// <param name="parent">The parent <see cref="T:WebBrowserEventsShim"/>.</param>
        public WebBrowserEvents(WebBrowserEventsShim parent)
        {
            this.Parent = parent;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="WebBrowserEvents"/> class from being created.
        /// </summary>
        private WebBrowserEvents()
        {
        }

        /// <summary>
        /// Gets the parent <see cref="T:WebBrowserEventsShim"/>.
        /// </summary>
        /// <value>The parent <see cref="T:WebBrowserEventsShim"/>.</value>
        public WebBrowserEventsShim Parent { get; private set; }
    }
}
