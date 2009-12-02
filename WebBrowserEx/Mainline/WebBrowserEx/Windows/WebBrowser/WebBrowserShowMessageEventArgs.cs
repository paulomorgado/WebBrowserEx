//-----------------------------------------------------------------------
// <copyright file="WebBrowserShowMessageEventArgs.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Provides data for the WebBrowser's ShowMessage event.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    /// <summary>
    /// Provides data for the <see cref="E:WebBrowserControl.ShowMessage"/> event.
    /// </summary>
    public class WebBrowserShowMessageEventArgs : global::System.EventArgs
    {
        #region Internal Instance Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserShowMessageEventArgs"/> class.
        /// </summary>
        /// <param name="window">The owner window.</param>
        /// <param name="text">The text for the message box.</param>
        /// <param name="caption">The caption for the message box.</param>
        /// <param name="buttons">The message box buttons.</param>
        /// <param name="icon">The message box icons.</param>
        /// <param name="helpFile">The Help file name.</param>
        /// <param name="helpContext">The Help context identifier.</param>
        internal WebBrowserShowMessageEventArgs(
            System.Windows.Forms.NativeWindow window,
            string text,
            string caption,
            System.Windows.Forms.MessageBoxButtons buttons,
            System.Windows.Forms.MessageBoxIcon icon,
            string helpFile,
            uint helpContext) : base()
        {
            this.Window = window;
            this.Text = text;
            this.Caption = caption;
            this.Buttons = buttons;
            this.Icon = icon;
            this.HelpFile = helpFile;
            this.HelpContext = helpContext;
            this.Result = System.Windows.Forms.DialogResult.None;
            this.Handled = false;
        }

        #endregion

        #region Private Instance Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="T:WebBrowserShowMessageEventArgs"/> class from being created.
        /// </summary>
        private WebBrowserShowMessageEventArgs()
        {
        }

        #endregion

        #region Public Instance Properties

        /// <summary>
        /// Gets or sets a value indicating whether the event was handled.
        /// </summary>
        /// <value><see langword="true"/> if handled; otherwise, <see langword="false"/>.</value>
        public bool Handled { get; set; }

        /// <summary>
        /// Gets the owner window.
        /// </summary>
        /// <value>The owner window.</value>
        public System.Windows.Forms.NativeWindow Window { get; private set; }

        /// <summary>
        /// Gets the text for the message box.
        /// </summary>
        /// <value>The text for the message box.</value>
        public string Text { get; private set; }

        /// <summary>
        /// Gets the caption for the message box.
        /// </summary>
        /// <value>The caption for the message box.</value>
        public string Caption { get; private set; }

        /// <summary>
        /// Gets the message box buttons.
        /// </summary>
        /// <value>The message box buttons.</value>
        public System.Windows.Forms.MessageBoxButtons Buttons { get; private set; }

        /// <summary>
        /// Gets the message box icons.
        /// </summary>
        /// <value>The message box icons.</value>
        public System.Windows.Forms.MessageBoxIcon Icon { get; private set; }

        /// <summary>
        /// Gets the Help file name.
        /// </summary>
        /// <value>The Help file name.</value>
        public string HelpFile { get; private set; }

        /// <summary>
        /// Gets the Help context identifier.
        /// </summary>
        /// <value>The Help context identifier.</value>
        public uint HelpContext { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating what button the user clicked.
        /// </summary>
        /// <value>The button the user clicked.</value>
        public System.Windows.Forms.DialogResult Result { get; set; }

        #endregion
    }
}
