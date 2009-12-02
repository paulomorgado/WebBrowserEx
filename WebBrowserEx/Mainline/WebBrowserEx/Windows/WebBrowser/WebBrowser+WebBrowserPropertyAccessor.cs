//-----------------------------------------------------------------------
// <copyright file="WebBrowser+WebBrowserPropertyAccessor.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Provides access the WebBrowser's properties.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    /// <summary>
    /// Represents a Web Browser instance.
    /// </summary>
    public partial class WebBrowser
    {
        /// <summary>
        /// Provides access the <see cref="T:WebBrowser"/>'s properties.
        /// </summary>
        public class WebBrowserPropertyAccessor
        {
            /// <summary>
            /// The related <see cref="T:WebBrowser"/>.
            /// </summary>
            private readonly WebBrowser webBrowser;

            /// <summary>
            /// Initializes a new instance of the <see cref="WebBrowserPropertyAccessor"/> class.
            /// </summary>
            /// <param name="webBrowser">The related <see cref="T:WebBrowser"/>.</param>
            internal WebBrowserPropertyAccessor(WebBrowser webBrowser)
            {
                this.webBrowser = webBrowser;
            }

            /// <summary>
            /// Prevents a default instance of the <see cref="T:WebBrowserPropertyAccessor"/> class from being created.
            /// </summary>
            private WebBrowserPropertyAccessor()
            {
            }

            /// <summary>
            /// Gets or sets the <see cref="System.Object"/> with the specified property name.
            /// </summary>
            /// <param name="propertyName">The property name.</param>
            /// <value>
            /// The <see cref="System.Object"/> with the specified property name.
            /// </value>
            public object this[string propertyName]
            {
                get
                {
                    this.webBrowser.CheckActiveXState();
                    return this.webBrowser.ActiveXWebBrowser.GetProperty(propertyName);
                }

                set
                {
                    this.webBrowser.CheckActiveXState();
                    this.webBrowser.ActiveXWebBrowser.PutProperty(propertyName, value);
                }
            }
        }
    }
}
