//-----------------------------------------------------------------------
// <copyright file="WebBrowserEncryptionLevelChangedEventArgs.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Provides data for the WebBrowser's Navigated event.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using System;
using System.Windows.Forms;

    /// <summary>
    /// Provides data for the <see cref="E:WebBrowserControl.Navigated"/> event.
    /// </summary>
    public class WebBrowserEncryptionLevelChangedEventArgs : global::System.EventArgs
    {
        #region Public Instance Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserEncryptionLevelChangedEventArgs"/> class with the <see cref="WebBrowser"/> and <see cref="Url"/> properties set to the given values.
        /// </summary>
        /// <param name="encryptionLevel">The encryption level.</param>
        public WebBrowserEncryptionLevelChangedEventArgs(WebBrowserEncryptionLevel encryptionLevel)
        {
            this.EncryptionLevel = encryptionLevel;
        }

        #endregion

        #region Private Instance Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="WebBrowserEncryptionLevelChangedEventArgs"/> class from being created.
        /// </summary>
        private WebBrowserEncryptionLevelChangedEventArgs()
        {
        }

        #endregion

        #region Public Instance Properties

        /// <summary>
        /// Gets the encryption level.
        /// </summary>
        /// <value>The encryption level.</value>
        public WebBrowserEncryptionLevel EncryptionLevel { get; private set; }

        #endregion
    }
}
