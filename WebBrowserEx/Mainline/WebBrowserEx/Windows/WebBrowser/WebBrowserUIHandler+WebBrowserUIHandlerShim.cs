//-----------------------------------------------------------------------
// <copyright file="WebBrowserUIHandler+WebBrowserUIHandlerShim.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>Shims web browser UI to the web browser control.</summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using System;
    using PauloMorgado.Windows.Interop;

    /// <content>
    /// <see cref="T:WebBrowserExEventsShim"/> class.
    /// </content>
    public partial class WebBrowserUIHandler
    {
        /// <summary>
        /// Shims web browser UI to the web browser control.
        /// </summary>
        public abstract class WebBrowserUIHandlerShim
        {
            /// <summary>
            /// Gets a value indicating whether scroll bars are displayed in the <see cref="T:WebBrowser" />.
            /// </summary>
            /// <value><see langword="true"/> if scroll are displayed in the control; otherwise, <see langword="false"/>.</value>
            public abstract bool ScrollBarsEnabled { get; }

            /// <summary>
            /// Gets a value indicating whether a outer border is displayed in the <see cref="T:WebBrowser" />.
            /// </summary>
            /// <value><see langword="true"/> if a outer border is displayed in the control; otherwise, <see langword="false"/>.</value>
            public abstract bool No3DOuterBorder { get; }

            /// <summary>
            /// Gets a value indicating whether 3D frame borders are displayed in the <see cref="T:WebBrowser" />.
            /// </summary>
            /// <value><see langword="true"/> if 3D frame borders are displayed in the control; otherwise, <see langword="false"/>.</value>
            public abstract bool No3DBorder { get; }

            /// <summary>
            /// Gets an object that can be accessed by scripting code that is contained within a Web page displayed in the <see cref="T:WebBrowser" />.
            /// </summary>
            /// <value>The object for scripting.</value>
            public abstract object ObjectForScripting { get; }

            /// <summary>
            /// Processes a keyboard message.
            /// </summary>
            /// <param name="message">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the window message to process.</param>
            /// <returns><see langword="true" /> if the message was processed by the parent; otherwise, <see langword="false" />.</returns>
            public abstract bool TranslateAccelerator(ref System.Windows.Forms.Message message);

            /// <summary>
            /// Translates the URL.
            /// </summary>
            /// <param name="originalUrl">The original URL.</param>
            /// <returns><see langword="null"/> if no translation was performed; otherwise the translated URL.</returns>
            public abstract string TranslateUrl(string originalUrl);

            /// <summary>
            /// Gets the web browser capabilities.
            /// </summary>
            /// <param name="capabilities">The current web browser capabilities.</param>
            /// <returns>The effective web browser capabilities.</returns>
            public abstract WebBrowserCapabilities GetWebBrowserCapabilities(WebBrowserCapabilities capabilities);
        }
    }
}