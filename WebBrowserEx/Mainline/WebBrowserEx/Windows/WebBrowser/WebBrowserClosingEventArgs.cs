//-----------------------------------------------------------------------
// <copyright file="WebBrowserClosingEventArgs.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Provides data for the WindowClosing event.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    /// <summary>
    /// Provides data for the <see cref="E:WebBrowserControl.WindowClosing"/> event.
    /// </summary>
    public class WebBrowserClosingEventArgs : global::System.ComponentModel.CancelEventArgs
    {
        #region Internal Instance Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserClosingEventArgs"/> class with the <see cref="IsChildWindow"/> and <see cref="System.ComponentModel.CancelEventArgs.Cancel"/> properties set to the given values.
        /// </summary>
        /// <param name="isChildWindow"><see langword="true"/> the window was created from script; otherwise <see langword="false"/>.</param>
        internal WebBrowserClosingEventArgs(bool isChildWindow) : base()
        {
            this.IsChildWindow = isChildWindow;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserClosingEventArgs"/> class with the <see cref="IsChildWindow"/> and <see cref="System.ComponentModel.CancelEventArgs.Cancel"/> properties set to the given values.
        /// </summary>
        /// <param name="isChildWindow">
        /// <see langword="true"/> the window was created from script; otherwise <see langword="false"/>.
        /// </param>
        /// <param name="cancel">
        /// <see langword="true"/> if the event should be canceled; otherwise, <see langword="false"/>.
        /// </param>
        internal WebBrowserClosingEventArgs(bool isChildWindow, bool cancel) : base(cancel)
        {
            this.IsChildWindow = isChildWindow;
        }

        #endregion

        #region Private Instance Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="T:WebBrowserClosingEventArgs"/> class from being created.
        /// </summary>
        private WebBrowserClosingEventArgs()
        {
        }

        #endregion

        #region Public Instance Properties

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:WebBrowser"/> was created from script.
        /// </summary>
        /// <value>
        /// <see langword="true"/> the window was created from script; otherwise <see langword="false"/>.
        /// </value>
        public bool IsChildWindow { get; private set; }

        #endregion
    }
}
