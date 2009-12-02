//-----------------------------------------------------------------------
// <copyright file="WebBrowserEx-Fields.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// WebBrowserEx's fields.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Forms
{
    using System.Collections.Specialized;
    using System.Windows.Forms;
    using PauloMorgado.Windows.WebBrowser;

    /// <content>
    /// <see cref="T:WebBrowserEx"/>'s fields.
    /// </content>
    public partial class WebBrowserEx : global::System.Windows.Forms.WebBrowser
    {
        /// <summary>
        /// Holds the WebBrowser's AcitveX connection point cookie.
        /// </summary>
        private AxHost.ConnectionPointCookie activeXConnectionPointCookie;

        /// <summary>
        /// Holds the WebBrowser' site.
        /// </summary>
        private WebBrowserExSite webBrowserExSite;

        /// <summary>
        /// Holds the WebBrowser' event handler.
        /// </summary>
        private WebBrowserEvents webBrowserExEvents;

        /// <summary>
        /// Holds the WebBrowser's UI handler.
        /// </summary>
        private WebBrowserUIHandler webBrowserUIHandler;

        /// <summary>
        /// Holds the <see cref="WebBrowserEx"/>'s state.
        /// </summary>
        private BitVector32 webBrowserState = new BitVector32(0);

        /// <summary>
        /// Holds the value of the <see cref="P:StatusText"/> property.
        /// </summary>
        private string statusText;

        /// <summary>
        /// Holds the value of the <see cref="P:Text"/> property.
        /// </summary>
        private string text;

        /// <summary>
        /// Sets the value of the <see cref="F:System.Windows.Forms.WebBrowser.encryptionLevel"/> private field.
        /// </summary>
        /// <param name="value">The new value of the <see cref="F:System.Windows.Forms.WebBrowser.encryptionLevel"/> field.</param>
        private void SetEncryptionLevel(WebBrowserEncryptionLevel value)
        {
            encryptionLevelFieldInfo.SetValue(this, value);
        }
    }
}
