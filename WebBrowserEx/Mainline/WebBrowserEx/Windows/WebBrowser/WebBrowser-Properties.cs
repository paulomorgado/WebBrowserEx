//-----------------------------------------------------------------------
// <copyright file="WebBrowser-Properties.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// WebBrowser's Properties.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;
    using PauloMorgado.Windows.Interop;

    /// <content>
    /// <see cref="T:WebBrowser"/>'s Properties.
    /// </content>
    public partial class WebBrowser
    {
        /// <summary>
        /// Gets the <see cref="T:WebBrowser"/>'s properties.
        /// </summary>
        /// <value>The <see cref="T:WebBrowser"/>'s properties.</value>
        public WebBrowserPropertyAccessor Properties { get; private set; }

        #region Behavior

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:WebBrowser"/> is registered as a registered as a drop target for navigation.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if this <see cref="T:WebBrowser"/> is registered as a drop target; otherwise, <see langword="false"/>.
        /// </value>
        public bool RegisterAsDropTarget
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.RegisterAsDropTarget;
            }

            set
            {
                this.CheckActiveXState();
                this.ActiveXWebBrowser.RegisterAsDropTarget = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="WebBrowser"/> is engaged in a navigation or downloading operation.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if busy; otherwise, <see langword="false"/>.
        /// </value>
        public bool Busy
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.Busy;
            }
        }

        /// <summary>
        /// Gets the automation object of the active document, if any.
        /// </summary>
        /// <value>The automation object of the active document, if any.</value>
        public object Document
        {
            get { return (this.ActiveXWebBrowser == null) ? null : this.ActiveXWebBrowser.Document; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="WebBrowser"/> is is operating in offline mode.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if operating in offline mode; otherwise, <see langword="false"/>.
        /// </value>
        public bool Offline
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.Offline;
            }

            set
            {
                this.CheckActiveXState();
                this.ActiveXWebBrowser.Offline = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="WebBrowser"/> can display dialog boxes.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if dialog boxes are to be displayed; otherwise, <see langword="false"/>.
        /// </value>
        public bool Silent
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.Silent;
            }

            set
            {
                this.CheckActiveXState();
                this.ActiveXWebBrowser.Silent = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="WebBrowser"/> is registered as a top-level browser window.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if registered as a top-level browser window; otherwise, <see langword="false"/>.
        /// </value>
        public bool RegisterAsBrowser
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.RegisterAsBrowser;
            }

            set
            {
                this.CheckActiveXState();
                this.ActiveXWebBrowser.RegisterAsBrowser = value;
            }
        }

        /// <summary>
        /// Gets the text in the status bar for this <see cref="WebBrowser"/>.
        /// </summary>
        /// <value>The status text.</value>
        public string StatusText
        {
            get
            {
                try
                {
                    this.CheckActiveXState();
                    return this.ActiveXWebBrowser.StatusText;
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the ready state.
        /// </summary>
        /// <value>The ready state.</value>
        public WebBrowserReadyState ReadyState
        {
            get
            {
                ////CheckActiveXState();
                if (this.ActiveXWebBrowser != null)
                {
                    return this.ActiveXWebBrowser.ReadyState;
                }
                else
                {
                    return WebBrowserReadyState.Uninitialized;
                }
            }
        }

        /// <summary>
        /// Gets the path or title of the resource that is currently displayed.
        /// </summary>
        /// <value>The path or title of the resource that is currently displayed.</value>
        public string LocationName
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.LocationName;
            }
        }

        /// <summary>
        /// Gets the URL of the resource that is currently displayed.
        /// </summary>
        /// <value>The URL of the resource that is currently displayed.</value>
        public string LocationUrl
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.LocationURL;
            }
        }

        #endregion

        #region Appearance

        /// <summary>
        /// Gets or sets a value indicating whether address bar is visible.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if address bar is visible; otherwise, <see langword="false"/>.
        /// </value>
        public bool ShowAddressBar
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.AddressBar;
            }

            set
            {
                this.CheckActiveXState();
                this.ActiveXWebBrowser.AddressBar = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether menu bar is visible.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if menu bar is visible; otherwise, <see langword="false"/>.
        /// </value>
        public bool ShowMenuBar
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.MenuBar;
            }

            set
            {
                this.CheckActiveXState();
                this.ActiveXWebBrowser.MenuBar = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the status bar is visible.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if status bar is visible; otherwise, <see langword="false"/>.
        /// </value>
        public bool ShowStatusBar
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.StatusBar;
            }

            set
            {
                this.CheckActiveXState();
                this.ActiveXWebBrowser.StatusBar = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether toolbars are visible.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if toolbars are visible; otherwise, <see langword="false"/>.
        /// </value>
        public bool ShowToolBar
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.ToolBar != 0;
            }

            set
            {
                this.CheckActiveXState();
                this.ActiveXWebBrowser.ToolBar = value ? 1 : 0;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="WebBrowser"/> is visible.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if visible; otherwise, <see langword="false"/>.
        /// </value>
        public bool Visible
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.Visible;
            }

            set
            {
                this.CheckActiveXState();
                this.ActiveXWebBrowser.Visible = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="T:WebBrowser"/> is in full-screen mode or normal window mode.
        /// </summary>
        /// <value><see langword="true"/> if the <see cref="T:WebBrowser"/> is in full-screen mode; otherwise <see langword="false"/>.</value>
        public bool FullScreen
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.FullScreen;
            }

            set
            {
                this.CheckActiveXState();
                this.ActiveXWebBrowser.FullScreen = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="T:WebBrowser"/> is in theater mode.
        /// </summary>
        /// <value><see langword="true"/> if the <see cref="T:WebBrowser"/> is in theater mode; otherwise <see langword="false"/>.</value>
        public bool TheaterMode
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.TheaterMode;
            }

            set
            {
                this.CheckActiveXState();
                this.ActiveXWebBrowser.TheaterMode = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="T:WebBrowser"/> is in theater mode.
        /// </summary>
        /// <value><see langword="true"/> if the <see cref="T:WebBrowser"/> is in theater mode; otherwise <see langword="false"/>.</value>
        public bool Resizable
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.Resizable;
            }

            set
            {
                this.CheckActiveXState();
                this.ActiveXWebBrowser.Resizable = value;
            }
        }

        #endregion

        #region Layout

        /// <summary>
        /// Gets or sets the coordinate of the top edge of the <see cref="T:WebBrowser"/>.
        /// </summary>
        /// <value>The coordinate of the top edge of the <see cref="T:WebBrowser"/>.</value>
        public int Top
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.Top;
            }

            set
            {
                this.CheckActiveXState();
                this.ActiveXWebBrowser.Top = value;
            }
        }

        /// <summary>
        /// Gets or sets the left of the coordinate of the left edge of the <see cref="T:WebBrowser"/>.
        /// </summary>
        /// <value>The left of the coordinate of the left edge of the <see cref="T:WebBrowser"/>.</value>
        public int Left
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.Left;
            }

            set
            {
                this.CheckActiveXState();
                this.ActiveXWebBrowser.Left = value;
            }
        }

        /// <summary>
        /// Gets or sets the the coordinates of the upper-left corner of the <see cref="T:WebBrowser"/>.
        /// </summary>
        /// <value>The coordinates of the upper-left corner of the <see cref="T:WebBrowser"/>.</value>
        public System.Drawing.Point Location
        {
            get
            {
                return new System.Drawing.Point(this.Left, this.Top);
            }

            set
            {
                this.Left = value.X;
                this.Top = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets the height of the <see cref="T:WebBrowser"/>.
        /// </summary>
        /// <value>The height of the <see cref="T:WebBrowser"/>.</value>
        public int Height
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.Height;
            }

            set
            {
                this.CheckActiveXState();
                this.ActiveXWebBrowser.Height = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the <see cref="T:WebBrowser"/>.
        /// </summary>
        /// <value>The width of the <see cref="T:WebBrowser"/>.</value>
        public int Width
        {
            get
            {
                this.CheckActiveXState();
                return this.ActiveXWebBrowser.Width;
            }

            set
            {
                this.CheckActiveXState();
                this.ActiveXWebBrowser.Width = value;
            }
        }

        /// <summary>
        /// Gets or sets the size of the <see cref="T:WebBrowser"/>.
        /// </summary>
        /// <value>The size of the <see cref="T:WebBrowser"/>.</value>
        public System.Drawing.Size Size
        {
            get
            {
                return new System.Drawing.Size(this.Width, this.Height);
            }

            set
            {
                this.Width = value.Width;
                this.Height = value.Height;
            }
        }

        #endregion

        /// <summary>
        /// Gets the ActiveX Web Browser.
        /// </summary>
        /// <value>The ActiveX Web Browser.</value>
        internal UnsafeNativeMethods.IWebBrowser2 ActiveXWebBrowser { get; private set; }
    }
}
