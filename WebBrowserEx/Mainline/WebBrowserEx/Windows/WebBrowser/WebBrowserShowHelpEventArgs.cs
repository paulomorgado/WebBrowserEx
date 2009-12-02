//-----------------------------------------------------------------------
// <copyright file="WebBrowserShowHelpEventArgs.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Provides data for the WebBrowser's ScriptError event.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    /// <summary>
    /// Provides data for the <see cref="WebBrowserControl.ScriptError"/> event.
    /// </summary>
    public class WebBrowserShowHelpEventArgs : global::System.EventArgs
    {
        #region Internal Instance Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserShowHelpEventArgs"/> class.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="helpFile">The help file.</param>
        /// <param name="helpType">Type of the help.</param>
        /// <param name="data">The aditional help data.</param>
        /// <param name="mousePosition">The mouse position.</param>
        /// <param name="objectHit">The object hit.</param>
        internal WebBrowserShowHelpEventArgs(
            System.Windows.Forms.NativeWindow window,
            string helpFile,
            WebBrowserHelpTypes helpType,
            uint data,
            System.Drawing.Point mousePosition,
            object objectHit) : base()
        {
            this.Window = window;
            this.HelpFile = helpFile;
            this.HelpType = helpType;
            this.Data = data;
            this.MousePosition = mousePosition;
            this.ObjectHit = objectHit;
            this.Handled = false;
        }

        #endregion

        #region Private Instance Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="T:WebBrowserShowHelpEventArgs"/> class from being created.
        /// </summary>
        private WebBrowserShowHelpEventArgs()
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
        /// Gets the Help file name.
        /// </summary>
        /// <value>The Help file name.</value>
        public string HelpFile { get; private set; }

        /// <summary>
        /// Gets the type of Help.
        /// </summary>
        /// <value>The type of Help.</value>
        public WebBrowserHelpTypes HelpType { get; private set; }

        /// <summary>
        /// Gets additional Help data.
        /// </summary>
        /// <value>The additional Help data.</value>
        public uint Data { get; private set; }

        /// <summary>
        /// Gets the mouse position in screen coordinates.
        /// </summary>
        /// <value>The mouse position in screen coordinates.</value>
        public System.Drawing.Point MousePosition { get; private set; }

        /// <summary>
        /// Gets the object at the screen coordinates.
        /// </summary>
        /// <value>The object at the screen coordinates.</value>
        public object ObjectHit { get; private set; }

        #endregion
    }
}
