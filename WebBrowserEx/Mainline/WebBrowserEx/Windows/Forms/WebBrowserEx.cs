//-----------------------------------------------------------------------
// <copyright file="WebBrowserEx.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// WebBrowserEx control.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Forms
{
    using System;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Permissions;
    using System.Windows.Forms;
    using PauloMorgado.ComponentModel;
    using PauloMorgado.Windows.Interop;
    using PauloMorgado.Windows.WebBrowser;
    using WebBrowser = PauloMorgado.Windows.WebBrowser.WebBrowser;
    using System.Drawing;

    /// <summary>
    /// Enables the user to navigate Web pages inside your form.
    /// </summary>
    /// <remarks>
    /// Extends the framework's <see cref="T:System.Windows.Forms.WebBrowser"/> control.
    /// </remarks>
    [ComVisible(true)]
    [DefaultEvent("DocumentCompleted")]
    [Designer("System.Windows.Forms.Design.WebBrowserDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [DefaultProperty("Url")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ToolboxBitmap(typeof(WebBrowserEx)/*, "WebBrowserEx.bmp"*/)]
    [Docking(DockingBehavior.AutoDock)]
    [ResourcesDescription("WebBrowserEx_Description")]
    [PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
    public partial class WebBrowserEx : global::System.Windows.Forms.WebBrowser
    {
        /// <summary>
        /// Initializes static members of the <see cref="WebBrowserEx"/> class.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Windows.Forms.WebBrowser"/> control is hosted inside Internet Explorer.
        /// </exception>
        static WebBrowserEx()
        {
            webBrowserStateNo3DOuterBorder = BitVector32.CreateMask();
            webBrowserStateNo3DBorder = BitVector32.CreateMask(webBrowserStateNo3DOuterBorder);
            webBrowserStateRegisterAsBrowser = BitVector32.CreateMask(webBrowserStateNo3DBorder);
            webBrowserStatePrivacyImpacted = BitVector32.CreateMask(webBrowserStateRegisterAsBrowser);
            webBrowserStateResizable = BitVector32.CreateMask(webBrowserStatePrivacyImpacted);

            encryptionLevelFieldInfo = typeof(global::System.Windows.Forms.WebBrowser).GetField("encryptionLevel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            canGoBackInternalPropertyInfo = typeof(global::System.Windows.Forms.WebBrowser).GetProperty("CanGoBackInternal", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            canGoForwardInternalPropertyInfo = typeof(global::System.Windows.Forms.WebBrowser).GetProperty("CanGoForwardInternal", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserEx"/> class.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Windows.Forms.WebBrowser"/> control is hosted inside Internet Explorer.
        /// </exception>
        public WebBrowserEx()
        {
            this.IsWebBrowserContextMenuEnabled = false;
            this.UserAgent = UserAgentDefaultValue;
            this.RegisterAsBrowser = RegisterAsBrowserDefaultValue;
            this.No3DBorder = No3DBorderDefaultValue;
            this.No3DOuterBorder = No3DOuterBorderDefaultValue;
        }

        /// <summary>
        /// Returns a reference to the unmanaged WebBrowser ActiveX control site, which you can extend to customize the managed <see cref="T:System.Windows.Forms.WebBrowser"/> control.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Windows.Forms.WebBrowser.WebBrowserSite"/> that represents the WebBrowser ActiveX control site.
        /// </returns>
        protected override WebBrowserSiteBase CreateWebBrowserSiteBase()
        {
            this.webBrowserUIHandler = new WebBrowserUIHandler(new WebBrowserExUIHandlerShim(this));
            this.webBrowserExSite = new WebBrowserExSite(this);
            return this.webBrowserExSite;
        }

        /// <summary>
        /// Called by the control when the underlying ActiveX control is created.
        /// </summary>
        /// <param name="nativeActiveXObject">An object that represents the underlying ActiveX control.</param>
        protected override void AttachInterfaces(object nativeActiveXObject)
        {
            base.AttachInterfaces(nativeActiveXObject);

            this.WebBrowser = WebBrowser.Create(nativeActiveXObject as UnsafeNativeMethods.IWebBrowser2);
        }

        /// <summary>
        /// Called by the control when the underlying ActiveX control is discarded.
        /// </summary>
        protected override void DetachInterfaces()
        {
            this.WebBrowser = null;
        }

        /// <summary>
        /// Associates the underlying ActiveX control with a client that can handle control events.
        /// </summary>
        protected override void CreateSink()
        {
            if (this.WebBrowser != null)
            {
                this.webBrowserExEvents = new WebBrowserEvents(new WebBrowserExEventsShim(this));
                this.activeXConnectionPointCookie = new AxHost.ConnectionPointCookie(this.WebBrowser.ActiveXWebBrowser, this.webBrowserExEvents, typeof(UnsafeNativeMethods.DWebBrowserEvents2));
            }
        }

        /// <summary>
        /// Releases the event-handling client attached in the <see cref="M:System.Windows.Forms.WebBrowser.CreateSink"/> method from the underlying ActiveX control.
        /// </summary>
        protected override void DetachSink()
        {
            if (this.activeXConnectionPointCookie != null)
            {
                this.activeXConnectionPointCookie.Disconnect();
                this.activeXConnectionPointCookie = null;
            }
        }

        /// <summary>
        /// Processes Windows messages.
        /// </summary>
        /// <param name="m">The windows <see cref="T:System.Windows.Forms.Message"/> to process.</param>
        protected override void WndProc(ref Message m)
        {
            try
            {
                switch (m.Msg)
                {
                    case NativeMethods.WindowsMessages.WM_PARENTNOTIFY:
                        int @event = NativeMethods.Util.LOWORD(m.LParam);

                        if (@event == NativeMethods.WindowsMessages.WM_DESTROY)
                        {
                            this.OnWindowClosed(EventArgs.Empty);
                            ////this.BeginInvoke(new MethodInvoker(this.Dispose));
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                Application.OnThreadException(ex);
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (this.webBrowserExSite != null)
            {
                this.webBrowserExSite.Dispose();
            }

            SafeNativeMethods.Ole32.CoFreeUnusedLibraries();
        }

        /// <summary>
        /// Gets the download control options.
        /// </summary>
        /// <param name="downloadControl">The initial download control options.</param>
        /// <returns>The download control options.</returns>
        protected virtual WebBrowserDownloadControlOptions GetDownloadControl(WebBrowserDownloadControlOptions downloadControl)
        {
            return downloadControl;
        }

        /// <summary>
        /// Gets the web browser capabilities.
        /// </summary>
        /// <param name="capabilities">The initial web browser capabilities.</param>
        /// <returns>The web browser capabilities.</returns>
        protected virtual WebBrowserCapabilities GetWebBrowserCapabilities(WebBrowserCapabilities capabilities)
        {
            return capabilities;
        }
    }
}
