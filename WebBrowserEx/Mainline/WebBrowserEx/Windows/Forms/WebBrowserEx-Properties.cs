//-----------------------------------------------------------------------
// <copyright file="WebBrowserEx-Properties.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// WebBrowserEx's properties.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Forms
{
    using System;
    using System.ComponentModel;
    using System.Text;
    using PauloMorgado.ComponentModel;
    using PauloMorgado.Windows.Interop;
    using WebBrowser = PauloMorgado.Windows.WebBrowser.WebBrowser;

    /// <content>
    /// <see cref="T:WebBrowserEx"/>'s properties.
    /// </content>
    public partial class WebBrowserEx
    {
        /// <summary>
        /// Gets or sets the default user agent for this process.
        /// </summary>
        /// <value>The default user agent.</value>
        public static string DefaultUserAgent
        {
            get
            {
                try
                {
                    int length = 0;
                    var sb = new StringBuilder(1024);
                    SafeNativeMethods.Urlmon.UrlMkGetSessionOption(Interop.SafeNativeMethods.Urlmon.URLMON_OPTION_USERAGENT, sb, sb.Capacity, ref length, 0);
                    return sb.ToString();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.Application.OnThreadException(ex);
                }

                return null;
            }

            set
            {
                try
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        SafeNativeMethods.Urlmon.UrlMkSetSessionOption(Interop.SafeNativeMethods.Urlmon.URLMON_OPTION_USERAGENT_REFRESH, null, 0, 0);
                    }
                    else
                    {
                        var sb = new StringBuilder(value);
                        SafeNativeMethods.Urlmon.UrlMkSetSessionOption(Interop.SafeNativeMethods.Urlmon.URLMON_OPTION_USERAGENT, value, value.Length, 0);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.Application.OnThreadException(ex);
                }
            }
        }

        #region Behavior

        /// <summary>
        /// Gets or sets a value indicating whether 3D borders shouldn't be used on the outermost frame or frameset only.
        /// </summary>
        /// <value><see langword="true"/> if 3D borders shouldn't be used on the outermost frame or frameset only; otherwise, <see langword="false"/>.</value>
        [DefaultValue(No3DOuterBorderDefaultValue)]
        [BehaviorCategory]
        [ResourcesDescription("WebBrowserEx_PropertyDescription_No3DOuterBorder")]
        public bool No3DOuterBorder
        {
            get
            {
                return this.webBrowserState[webBrowserStateNo3DOuterBorder];
            }

            set
            {
                if (value != this.webBrowserState[webBrowserStateNo3DOuterBorder])
                {
                    this.webBrowserState[webBrowserStateNo3DOuterBorder] = value;
                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 3D borders shouldn't be used on any frames or framesets.
        /// </summary>
        /// <value><see langword="true"/> if 3D borders shouldn't be used on any frames or framesets; otherwise, <see langword="false"/>.</value>
        [DefaultValue(No3DOuterBorderDefaultValue)]
        [BehaviorCategory]
        [ResourcesDescription("WebBrowserEx_PropertyDescription_No3DBorder")]
        public bool No3DBorder
        {
            get
            {
                return this.webBrowserState[webBrowserStateNo3DBorder];
            }

            set
            {
                if (value != this.webBrowserState[webBrowserStateNo3DBorder])
                {
                    this.webBrowserState[webBrowserStateNo3DBorder] = value;
                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="WebBrowser"/> is registered as a top-level browser window.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if registered as a top-level browser window; otherwise, <see langword="false"/>.
        /// </value>
        [Browsable(true)]
        [BehaviorCategory]
        [ResourcesDescription("WebBrowserEx_PropertyDescription_RegisterAsBrowser")]
        [DefaultValue(RegisterAsBrowserDefaultValue)]
        public bool RegisterAsBrowser
        {
            get
            {
                return this.webBrowserState[webBrowserStateRegisterAsBrowser];
            }

            set
            {
                if (value != this.webBrowserState[webBrowserStateRegisterAsBrowser])
                {
                    this.webBrowserState[webBrowserStateRegisterAsBrowser] = value;
                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the user agent for the current <see cref="WebBrowserControl">WebBrowser</see> Control instance.
        /// </summary>
        /// <value>The user agent.</value>
        /// <remarks>
        /// Overrides the <see cref="DefaultUserAgent"/> for the current instance.
        /// </remarks>
        [Browsable(true)]
        [BehaviorCategory]
        [ResourcesDescription("WebBrowserEx_PropertyDescription_UserAgent")]
        [DefaultValue(UserAgentDefaultValue)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public string UserAgent { get; set; }

        #endregion

        #region Appearance

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text associated with this control.</value>
        /// <returns>The text associated with this control.</returns>
        /// <remarks>The value of this property is set by the DWebBrowserEvents2.TitleChange event handler.</remarks>
        [AppearanceCategory]
        [ResourcesDescription("WebBrowserTextDescription")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                value = value ?? string.Empty;
                if (value != this.text)
                {
                    this.text = value;
                    this.OnTextChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the address bar is visible.
        /// </summary>
        /// <value><see langword="true"/> if the address bar is visible; otherwise <see langword="false"/>.</value>
        /// <remarks>The <see cref="T:WebBrowserEx"/> control saves the value of this property, but otherwise ignores it.</remarks>
        [AppearanceCategory]
        [ResourcesDescription("WebBrowserEx_PropertyDescription_ShowAddressBar")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public bool ShowAddressBar
        {
            get
            {
                return this.WebBrowser.ShowAddressBar;
            }

            set
            {
                if (value != this.WebBrowser.ShowAddressBar)
                {
                    this.WebBrowser.ShowAddressBar = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the menu bar is visible.
        /// </summary>
        /// <value><see langword="true"/> if the menu bar is visible; otherwise <see langword="false"/>.</value>
        [AppearanceCategory]
        [ResourcesDescription("WebBrowserEx_PropertyDescription_ShowMenuBar")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public bool ShowMenuBar
        {
            get
            {
                return this.WebBrowser.ShowMenuBar;
            }

            set
            {
                if (value != this.WebBrowser.ShowMenuBar)
                {
                    this.WebBrowser.ShowMenuBar = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the status bar is visible.
        /// </summary>
        /// <value><see langword="true"/> if the status bar is visible; otherwise <see langword="false"/>.</value>
        [AppearanceCategory]
        [ResourcesDescription("WebBrowserEx_PropertyDescription_ShowStatusBar")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public bool ShowStatusBar
        {
            get
            {
                return this.WebBrowser.ShowStatusBar;
            }

            set
            {
                if (value != this.WebBrowser.ShowStatusBar)
                {
                    this.WebBrowser.ShowStatusBar = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether toolbars are visible.
        /// </summary>
        /// <value><see langword="true"/> if toolbars are visible; otherwise <see langword="false"/>.</value>
        [AppearanceCategory]
        [ResourcesDescription("WebBrowserEx_PropertyDescription_ShowToolBar")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public bool ShowToolBar
        {
            get
            {
                return this.WebBrowser.ShowToolBar;
            }

            set
            {
                if (value != this.WebBrowser.ShowToolBar)
                {
                    this.WebBrowser.ShowToolBar = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="T:WebBrowserEx"/> is in full-screen mode or normal window mode.
        /// </summary>
        /// <value><see langword="true"/> if the <see cref="T:WebBrowserEx"/> is in full-screen mode; otherwise <see langword="false"/>.</value>
        [AppearanceCategory]
        [ResourcesDescription("WebBrowserEx_PropertyDescription_FullScreenMode")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public bool FullScreenMode
        {
            get
            {
                return this.WebBrowser.FullScreen;
            }

            set
            {
                if (value != this.WebBrowser.FullScreen)
                {
                    this.WebBrowser.FullScreen = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="T:WebBrowserEx"/> is in theater mode.
        /// </summary>
        /// <value><see langword="true"/> if the <see cref="T:WebBrowserEx"/> is in theater mode; otherwise <see langword="false"/>.</value>
        /// <remarks>The <see cref="T:WebBrowserEx"/> control saves the value of this property, but otherwise ignores it.</remarks>
        [AppearanceCategory]
        [ResourcesDescription("WebBrowserEx_PropertyDescription_TheaterMode")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public bool TheaterMode
        {
            get
            {
                return this.WebBrowser.TheaterMode;
            }

            set
            {
                if (value != this.WebBrowser.TheaterMode)
                {
                    this.WebBrowser.TheaterMode = value;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:WebBrowserEx"/> is resizable.
        /// </summary>
        /// <value><see langword="true"/> if the <see cref="T:WebBrowserEx"/> is resizable; otherwise <see langword="false"/>.</value>
        /// <remarks>The <see cref="T:WebBrowserEx"/> control saves the value of this property, but otherwise ignores it.</remarks>
        [AppearanceCategory]
        [ResourcesDescription("WebBrowserEx_PropertyDescription_Resizable")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public bool Resizable
        {
            get
            {
                return this.webBrowserState[webBrowserStateResizable];
            }

            internal set
            {
                if (this.webBrowserState[webBrowserStateResizable] != value)
                {
                    this.webBrowserState[webBrowserStateResizable] = value;

                    this.OnResizableChanged(EventArgs.Empty);
                }
            }
        }

        #endregion

        /// <summary>
        /// Gets a value indicating whether the privacy state is impacted.<seealso cref="PrivacyImpactedChanged"/>
        /// </summary>
        /// <value><see langword="true" /> if the privacy state is impacted; otherwise, <see langword="false" />.</value>
        /// <returns><see langword="true" /> if the privacy state is impacted; otherwise, <see langword="false" />.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool PrivacyImpacted
        {
            get
            {
                return this.webBrowserState[webBrowserStatePrivacyImpacted];
            }

            internal set
            {
                if (this.webBrowserState[webBrowserStatePrivacyImpacted] != value)
                {
                    this.webBrowserState[webBrowserStatePrivacyImpacted] = value;

                    this.OnPrivacyImpactedChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets the status text of the <see cref="T:System.Windows.Forms.WebBrowser"/> control.
        /// </summary>
        /// <value>The status text.</value>
        /// <returns>
        /// The status text.
        /// </returns>
        /// <exception cref="T:System.ObjectDisposedException">
        /// This <see cref="T:System.Windows.Forms.WebBrowser"/> instance is no longer valid.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException">
        /// A reference to an implementation of the IWebBrowser2 interface could not be retrieved from the underlying ActiveX WebBrowser control.
        /// </exception>
        /// <PermissionSet>
        /// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
        /// <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// <IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        /// </PermissionSet>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public override string StatusText
        {
            get { return this.StatusTextInternal; }
        }

        /// <summary>
        /// Gets the <see cref="WebBrowser"/> of the <see cref="WebBrowserControl"/>.
        /// </summary>
        /// <value>
        /// The <see cref="WebBrowser"/> of the <see cref="WebBrowserControl"/>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public WebBrowser WebBrowser { get; private set; }

        /// <summary>
        /// Gets or sets the status text of the <see cref="T:System.Windows.Forms.WebBrowser"></see> control.
        /// </summary>
        /// <value>The status text.</value>
        /// <returns>
        /// The status text.
        /// </returns>
        protected virtual string StatusTextInternal
        {
            get
            {
                return this.statusText;
            }

            set
            {
                value = value ?? string.Empty;
                if (value != this.statusText)
                {
                    this.statusText = value;
                    this.OnStatusTextChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Sets the value of the <see cref="P:System.Windows.Forms.WebBrowser.GoBackInternal"/> internal property.
        /// </summary>
        /// <param name="value">The new value of the <see cref="P:System.Windows.Forms.WebBrowser.GoBackInternal"/> property.</param>
        private void SetCanGoBackInternal(bool value)
        {
            canGoBackInternalPropertyInfo.SetValue(this, value, new object[] { });
        }

        /// <summary>
        /// Sets the value of the <see cref="P:System.Windows.Forms.WebBrowser.GoForwardInternal"/> internal property.
        /// </summary>
        /// <param name="value">The new value of the <see cref="P:System.Windows.Forms.WebBrowser.GoForwardInternal"/> property.</param>
        private void SetCanGoForwardInternal(bool value)
        {
            canGoForwardInternalPropertyInfo.SetValue(this, value, new object[] { });
        }
    }
}
