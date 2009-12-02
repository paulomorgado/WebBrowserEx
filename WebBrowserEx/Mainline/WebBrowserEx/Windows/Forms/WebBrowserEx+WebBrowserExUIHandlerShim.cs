//-----------------------------------------------------------------------
// <copyright file="WebBrowserEx+WebBrowserExUIHandlerShim.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// WebBrowserEx's WebBrowserUIHandlerShim.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Forms
{
    using System.Windows.Forms;
    using PauloMorgado.Windows.WebBrowser;

    /// <content>
    /// <see cref="T:PauloMorgado.Windows.WebBrowser.WebBrowserUIHandler.WebBrowserUIHandlerShim" /> implementation for the <see cref="T:WebBrowserEx" />'s <see cref="T:WebBrowserUIHandler" />.
    /// </content>
    public partial class WebBrowserEx
    {
        /// <summary>
        /// <see cref="T:PauloMorgado.Windows.WebBrowser.WebBrowserUIHandler.WebBrowserUIHandlerShim" /> implementation for the <see cref="T:WebBrowserEx" />'s <see cref="T:WebBrowserUIHandler" />.
        /// </summary>
        protected class WebBrowserExUIHandlerShim : global::PauloMorgado.Windows.WebBrowser.WebBrowserUIHandler.WebBrowserUIHandlerShim
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="WebBrowserExUIHandlerShim"/> class.
            /// </summary>
            /// <param name="parent">The parent.</param>
            public WebBrowserExUIHandlerShim(WebBrowserEx parent)
            {
                this.Parent = parent;
            }

            /// <summary>
            /// Prevents a default instance of the <see cref="WebBrowserExUIHandlerShim"/> class from being created.
            /// </summary>
            private WebBrowserExUIHandlerShim()
            {
            }

            /// <summary>
            /// Gets or sets a value indicating whether scroll bars are displayed in the <see cref="T:WebBrowser"/>.
            /// </summary>
            /// <value>
            /// <see langword="true"/> if scroll are displayed in the control; otherwise, <see langword="false"/>.
            /// </value>
            public override bool ScrollBarsEnabled
            {
                get { return this.Parent.ScrollBarsEnabled; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether a outer border is displayed in the <see cref="T:WebBrowser"/>.
            /// </summary>
            /// <value>
            /// <see langword="true"/> if a outer border is displayed in the control; otherwise, <see langword="false"/>.
            /// </value>
            public override bool No3DOuterBorder
            {
                get { return this.Parent.No3DOuterBorder; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether 3D frame borders are displayed in the <see cref="T:WebBrowser"/>.
            /// </summary>
            /// <value>
            /// <see langword="true"/> if 3D frame borders are displayed in the control; otherwise, <see langword="false"/>.
            /// </value>
            public override bool No3DBorder
            {
                get { return this.Parent.No3DBorder; }
            }

            /// <summary>
            /// Gets or sets an object that can be accessed by scripting code that is contained within a Web page displayed in the <see cref="T:WebBrowser"/>.
            /// </summary>
            /// <value>The object for scripting.</value>
            public override object ObjectForScripting
            {
                get { return this.Parent.ObjectForScripting; }
            }

            /// <summary>
            /// Gets the parent <see cref="T:WebBrowserEx"/>.
            /// </summary>
            /// <value>The parent <see cref="T:WebBrowserEx"/>.</value>
            protected WebBrowserEx Parent { get; private set; }

            /// <summary>
            /// Processes a keyboard message.
            /// </summary>
            /// <param name="message">A <see cref="T:System.Windows.Forms.Message"/>, passed by reference, that represents the window message to process.</param>
            /// <returns>
            /// <see langword="true"/> if the message was processed by the <see cref="P:Parent" />; otherwise, <see langword="false"/>.
            /// </returns>
            public override bool TranslateAccelerator(ref Message message)
            {
                return this.Parent.ProcessKeyMessage(ref message);
            }

            /// <summary>
            /// Translates the URL.
            /// </summary>
            /// <param name="originalUrl">The original URL.</param>
            /// <returns>
            /// <see langword="null"/> if no translation was performed; otherwise the translated URL.
            /// </returns>
            public override string TranslateUrl(string originalUrl)
            {
                WebBrowserTranslateUrlEventArgs translateUrlEventArgs = new WebBrowserTranslateUrlEventArgs(originalUrl);

                this.Parent.OnTranslateUrl(translateUrlEventArgs);

                return (translateUrlEventArgs.Url == originalUrl) ? null : originalUrl;
            }

            /// <summary>
            /// Gets the web browser capabilities.
            /// </summary>
            /// <param name="capabilities">The current web browser capabilities.</param>
            /// <returns>The effective web browser capabilities.</returns>
            public override WebBrowserCapabilities GetWebBrowserCapabilities(WebBrowserCapabilities capabilities)
            {
                return this.Parent.GetWebBrowserCapabilities(capabilities);
            }
        }
    }
}