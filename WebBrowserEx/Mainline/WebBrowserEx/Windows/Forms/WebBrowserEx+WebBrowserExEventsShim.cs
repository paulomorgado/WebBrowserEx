//-----------------------------------------------------------------------
// <copyright file="WebBrowserEx+WebBrowserExEventsShim.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>Shims web browser events to the web browser control.</summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Forms
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using PauloMorgado.Windows.WebBrowser;
    using WebBrowser = PauloMorgado.Windows.WebBrowser.WebBrowser;
    using WebBrowserDocumentCompletedEventArgs = PauloMorgado.Windows.WebBrowser.WebBrowserDocumentCompletedEventArgs;
    using WebBrowserNavigatedEventArgs = PauloMorgado.Windows.WebBrowser.WebBrowserNavigatedEventArgs;
    using WebBrowserNavigatingEventArgs = PauloMorgado.Windows.WebBrowser.WebBrowserNavigatingEventArgs;

    /// <content>
    /// <see cref="T:WebBrowserExEventsShim"/> class.
    /// </content>
    public partial class WebBrowserEx
    {
        /// <summary>
        /// Shims web browser events to the parent web browser control.
        /// </summary>
        /// <seealso cref="T:WebBrowserEx"/>
        /// <seealso cref="T:PauloMorgado.Windows.WebBrowser.WebBrowserEvents.WebBrowserEventsShim"/>
        /// <seealso cref="T:IWebBrowser2"/>
        /// <seealso cref="T:DWebBrowserEvents2"/>
        protected class WebBrowserExEventsShim : global::PauloMorgado.Windows.WebBrowser.WebBrowserEvents.WebBrowserEventsShim
        {
            /// <summary>
            /// Indicates whether the browser has previously navigated,
            /// </summary>
            private bool hasNavigated;

            /// <summary>
            /// Initializes a new instance of the <see cref="WebBrowserExEventsShim"/> class.
            /// </summary>
            /// <param name="parent">The parent.</param>
            public WebBrowserExEventsShim(WebBrowserEx parent)
            {
                this.Parent = parent;
            }

            /// <summary>
            /// Prevents a default instance of the <see cref="WebBrowserExEventsShim"/> class from being created.
            /// </summary>
            private WebBrowserExEventsShim()
            {
            }

            /// <summary>
            /// Gets the parent <see cref="T:WebBrowserEx"/>.
            /// </summary>
            /// <value>The parent <see cref="T:WebBrowserEx"/>.</value>
            protected WebBrowserEx Parent { get; private set; }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the enable state of a toolbar button might have changed.
            /// </summary>
            public override void UpdateCommands()
            {
                this.Parent.OnUpdateCommands(EventArgs.Empty);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the enable state of the Back button has changed.
            /// </summary>
            /// <param name="enable"><see langword="true"/> the Back button should be enabled; otherwise <see langword="false"/>.</param>
            public override void SetCanGoBack(bool enable)
            {
                this.Parent.SetCanGoBackInternal(enable);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the enable state of the Forward button has changed.
            /// </summary>
            /// <param name="enable"><see langword="true"/> the Forward button should be enabled; otherwise <see langword="false"/>.</param>
            public override void SetCanGoForward(bool enable)
            {
                this.Parent.SetCanGoForwardInternal(enable);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the status bar text has changed.
            /// </summary>
            /// <param name="statusText">The status bar text.</param>
            public override void StatusTextChanged(string statusText)
            {
                this.Parent.StatusTextInternal = statusText;
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the progress of a download operation is updated.
            /// </summary>
            /// <param name="progress">The amount of total progress to show, or -1 when progress is complete.</param>
            /// <param name="progressMax">The maximum progress value.</param>
            public override void ProgressChanged(int progress, int progressMax)
            {
                WebBrowserProgressChangedEventArgs e = new WebBrowserProgressChangedEventArgs((long)progress, (long)progressMax);
                this.Parent.OnProgressChanged(e);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a navigation operation has begun.
            /// </summary>
            /// <remarks>
            /// <para>This event happens shortly after the <see cref="M:Navigating"/> event event, unless the navigation is canceled. Any animation or "busy" indication that the container must display should be connected to this event.</para>
            /// <para>Each <see cref="M:Downloading"/> event has a corresponding <see cref="M:Downloaded"/> event.</para>
            /// </remarks>
            public override void Downloading()
            {
                this.Parent.OnDownloading(EventArgs.Empty);
                this.Parent.OnFileDownload(EventArgs.Empty);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a navigation operation has finished, been halted or failed.
            /// </summary>
            /// <remarks>
            /// <para>Unlike <see cref="M:Navigated"/>, which are happens only when a URL is successfully navigated to, this event always happen after a navigation starts. Any animation or "busy" indication that the container must display should be connected to this event.</para>
            /// <para>Each <see cref="M:Downloading"/> event has a corresponding <see cref="M:Downloaded"/> event.</para>
            /// </remarks>
            public override void Downloaded()
            {
                this.Parent.OnDownloaded(EventArgs.Empty);
            }

            /// <summary>
            /// Titles the changed.
            /// </summary>
            /// <param name="titleText">The title text.</param>
            public override void TitleChanged(string titleText)
            {
                this.Parent.Text = titleText;
            }

            /// <summary>
            /// Properties the changed.
            /// </summary>
            /// <param name="propetyName">Name of the propety.</param>
            public override void PropertyChanged(string propetyName)
            {
                this.Parent.OnPropertyChanged(new PropertyChangedEventArgs(propetyName));
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a navigation is occurring.
            /// </summary>
            /// <param name="webBrowser">The top-level or frame <see cref="T:WebBrowser"/> corresponding to the navigation.</param>
            /// <param name="url">The URL to which the browser is navigating.</param>
            /// <param name="targetFrameName">The frame in which the resource will be displayed, or <see langword="null"/> if no named frame is targeted for the resource.</param>
            /// <param name="postData">Data to send to the server if the HTTP POST transaction is being used.</param>
            /// <param name="headers">Specifies the additional HTTP headers to send to the server (HTTP URLs only). The headers can specify such things as the action required of the server, the type of data being passed to the server, or a status code.</param>
            /// <returns>
            /// <see langword="true"/> to cancel the navigation operation, or to <see langword="false"/> to allow it to proceed.
            /// </returns>
            public override bool Navigating(WebBrowser webBrowser, string url, string targetFrameName, byte[] postData, string headers)
            {
                if (this.Parent.AllowNavigation || !this.hasNavigated)
                {
                    if (targetFrameName == null)
                    {
                        targetFrameName = string.Empty;
                    }

                    if (headers == null)
                    {
                        headers = string.Empty;
                    }

                    Uri uri = new Uri(url ?? string.Empty);

                    var e = new WebBrowserNavigatingEventArgs(webBrowser, uri, targetFrameName ?? string.Empty, postData, headers);

                    this.Parent.OnNavigating(e);

                    return e.Cancel;
                }
                else
                {
                    return true;
                }
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a navigation has been completed on a window or frameSet element.
            /// </summary>
            /// <param name="webBrowser">The top-level or frame <see cref="T:WebBrowser"/> corresponding to the navigation.</param>
            /// <param name="url">The URL, UNC file name, or PIDL that was navigated to.</param>
            /// <remarks>
            /// Note that the URL can be different from the URL that the browser was told to navigate to.
            /// One reason is that this URL is the canonicalized and qualified URL; for example, if an application specified a URL of "www.microsoft.com" in a call to the <see cref="M:WebBrowser.Navigate"/> method, the URL passed by Navigate2 will be "http://www.microsoft.com/".
            /// Also, if the server has redirected the browser to a different URL, the redirected URL will be reflected here.
            /// </remarks>
            public override void Navigated(WebBrowser webBrowser, string url)
            {
                Uri uri = new Uri(url ?? string.Empty);

                var e = new WebBrowserNavigatedEventArgs(webBrowser, uri);

                this.Parent.OnNavigated(e);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a document has been completely loaded and initialized.
            /// </summary>
            /// <param name="webBrowser">The top-level or frame <see cref="T:WebBrowser"/> corresponding to the loaded document.</param>
            /// <param name="url">The URL, Universal Naming Convention (UNC) file name, or pointer to an item identifier list (PIDL) of the loaded document.</param>
            public override void DocumentCompleted(WebBrowser webBrowser, string url)
            {
                this.hasNavigated = true;

                /* //TODO: Implementar carregamento inicial
                if ((this.parent.documentStreamToSetOnLoad != null) && (((string)urlObject) == "about:blank"))
                {
                    HtmlDocument document = this.parent.Document;
                    if (document != null)
                    {
                        UnsafeNativeMethods.IPersistStreamInit domDocument = document.DomDocument as UnsafeNativeMethods.IPersistStreamInit;
                        UnsafeNativeMethods.IStream pstm = new UnsafeNativeMethods.ComStreamFromDataStream(this.parent.documentStreamToSetOnLoad);
                        domDocument.Load(pstm);
                        document.Encoding = "unicode";
                    }
                    this.parent.documentStreamToSetOnLoad = null;
                }
                else
                */
                {
                    Uri uri = new Uri(url ?? string.Empty);
                    WebBrowserDocumentCompletedEventArgs e = new WebBrowserDocumentCompletedEventArgs(webBrowser, uri);
                    this.Parent.OnDocumentCompleted(e);
                }
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the Microsoft Internet Explorer application is quitting.
            /// </summary>
            /// <remarks>The WebBrowser control ignores this event.</remarks>
            public override void Quit()
            {
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the value of the <see cref="P:WebBrowser.Visible"/> property has changed.
            /// </summary>
            /// <param name="visible"><see langword="true"/> is the web browser should be visible; otherwise <see langword="false"/>.</param>
            public override void SetVisiblility(bool visible)
            {
                this.Parent.Visible = visible;
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the value of the <see cref="P:WebBrowser.ShowToolBar"/> property has changed.
            /// </summary>
            /// <param name="visible"><see langword="true"/> is the web browser's toolbar should be visible; otherwise <see langword="false"/>.</param>
            public override void SetToolBarVisiblility(bool visible)
            {
                System.Diagnostics.Debug.Assert(this.Parent.ShowToolBar == visible, "Invalid event argument.");

                this.Parent.OnShowToolBarChanged(EventArgs.Empty);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the value of the <see cref="P:WebBrowser.MenuBar"/> property has changed.
            /// </summary>
            /// <param name="visible"><see langword="true"/> is the web browser's menu bar should be visible; otherwise <see langword="false"/>.</param>
            public override void SetMenuBarVisiblility(bool visible)
            {
                System.Diagnostics.Debug.Assert(this.Parent.ShowMenuBar == visible, "Invalid event argument.");

                this.Parent.OnShowToolBarChanged(EventArgs.Empty);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the value of the <see cref="P:WebBrowser.StatusBar"/> property has changed.
            /// </summary>
            /// <param name="visible"><see langword="true"/> is the web browser's status bar should be visible; otherwise <see langword="false"/>.</param>
            public override void SetStatusBarVisiblility(bool visible)
            {
                System.Diagnostics.Debug.Assert(this.Parent.ShowToolBar == visible, "Invalid event argument.");

                this.Parent.OnShowStatusBarChanged(EventArgs.Empty);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the value of the <see cref="P:WebBrowser.FullScreen"/> property has changed.
            /// </summary>
            /// <param name="fullScreen"><see langword="true"/> is the web browser should be in full screen mode; otherwise <see langword="false"/>.</param>
            public override void SetFullScreen(bool fullScreen)
            {
                System.Diagnostics.Debug.Assert(this.Parent.FullScreenMode == fullScreen, "Invalid event argument.");

                this.Parent.OnFullScreenModeChanged(EventArgs.Empty);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the value of the <see cref="P:WebBrowser.TheaterMode"/> property has changed.
            /// </summary>
            /// <param name="theaterMode"><see langword="true"/> is the web browser should be in theater mode; otherwise <see langword="false"/>.</param>
            public override void SetTheaterMode(bool theaterMode)
            {
                System.Diagnostics.Debug.Assert(this.Parent.TheaterMode == theaterMode, "Invalid event argument.");

                this.Parent.OnTheaterModeChanged(EventArgs.Empty);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> if the host window should allow resizing.
            /// </summary>
            /// <param name="resizable"><see langword="true"/> resizing should be allowed; otherwsie <see langword="false"/>.</param>
            public override void SetResizable(bool resizable)
            {
                this.Parent.Resizable = resizable;
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that left position changes.
            /// </summary>
            /// <param name="left">The new left position.</param>
            public override void SetWindowLeft(int left)
            {
                System.Diagnostics.Debug.Assert(this.Parent.WebBrowser.Left == left, "Invalid event argument.");

                this.Parent.OnWindowLeftChanged(EventArgs.Empty);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that top position changes.
            /// </summary>
            /// <param name="top">The new top position.</param>
            public override void SetWindowTop(int top)
            {
                System.Diagnostics.Debug.Assert(this.Parent.WebBrowser.Top == top, "Invalid event argument.");

                this.Parent.OnWindowTopChanged(EventArgs.Empty);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that width changes.
            /// </summary>
            /// <param name="width">The new width.</param>
            public override void SetWindowWidth(int width)
            {
                System.Diagnostics.Debug.Assert(this.Parent.WebBrowser.Width == width, "Invalid event argument.");

                this.Parent.OnWindowWidthChanged(EventArgs.Empty);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that height changes.
            /// </summary>
            /// <param name="height">The new height.</param>
            public override void SetWindowHeight(int height)
            {
                System.Diagnostics.Debug.Assert(this.Parent.WebBrowser.Height == height, "Invalid event argument.");

                this.Parent.OnWindowHeightChanged(EventArgs.Empty);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the window is about to be closed by script.
            /// </summary>
            /// <param name="isChildWindow"><see langword="true"/> if the was created from script; otherwise <see langword="false"/>.</param>
            /// <param name="cancel"><see langword="true"/> if the window is prevented from closing; otherwise <see langword="false"/>.</param>
            /// <returns>
            /// <see langword="true"/> if the window should be prevented from closing; otherwise <see langword="false"/>.
            /// </returns>
            public override bool WindowClosing(bool isChildWindow, bool cancel)
            {
                WebBrowserClosingEventArgs e = new WebBrowserClosingEventArgs(isChildWindow, cancel);
                this.Parent.OnWindowClosing(e);
                return e.Cancel;
            }

            /// <summary>
            /// Requests the <see cref="P:Parent"/> to convert the client window size to the host window size.
            /// </summary>
            /// <param name="size">The size to convert.</param>
            /// <returns>The converted size</returns>
            public override System.Drawing.Size ClientToHostWindow(System.Drawing.Size size)
            {
                return size;
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the encryption level has changed.
            /// </summary>
            /// <param name="encryptionLevel">The <see cref="T:WebBrowserEncryptionLevel">encryption level</see>.</param>
            public override void SetEncryptionLevel(WebBrowserEncryptionLevel encryptionLevel)
            {
                this.Parent.SetEncryptionLevel(encryptionLevel);
                var e = new WebBrowserEncryptionLevelChangedEventArgs(encryptionLevel);
                this.Parent.OnEncryptionLevelChanged(e);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a file download is about to occur.
            /// </summary>
            /// <param name="activeDocument"><see langword="true"/> if the file is an Active Document; otherwise <see langword="false"/>.</param>
            /// <param name="cancel"><see langword="true"/> if the download process should be canceled; otherwise <see langword="false"/>.</param>
            /// <returns>
            /// <see langword="true"/> to cancel the download process; otherwise <see langword="false"/>.
            /// </returns>
            /// <remarks>If a file download dialog box can be displayed, this event fires prior to the appearance of the dialog box.</remarks>
            public override bool DownloadingFile(bool activeDocument, bool cancel)
            {
                var e = new WebBrowserDownloadingFileEventArgs(activeDocument, cancel);

                this.Parent.OnDownloadingFile(e);

                return e.Cancel;
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that an error occured during navigation.
            /// </summary>
            /// <param name="webBrowser">The top-level or frame <see cref="T:WebBrowser"/> corresponding to the navigation.</param>
            /// <param name="url">The URL for which navigation failed.</param>
            /// <param name="frame">The name of the frame in which to display the resource, or <see langword="null"/> if no named frame was targeted for the resource.</param>
            /// <param name="status">The <see cref="T:WebBrowserNavigateErrorStatus">error status code</see>, if available.</param>
            /// <param name="cancel"><see langword="true"/> if the navigation should be canceled; otherwise <see langword="false"/>.</param>
            /// <returns>
            /// <see langword="true"/> to cancel the navigation; otherwise <see langword="false"/>.
            /// </returns>
            public override bool NavigateError(WebBrowser webBrowser, string url, string frame, WebBrowserNavigateErrorStatus status, bool cancel)
            {
                Uri uri = new Uri(url ?? string.Empty);

                var e = new WebBrowserNavigateErrorEventArgs(webBrowser, uri, frame, status, cancel);

                this.Parent.OnNavigateError(e);

                return e.Cancel;
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a print template is being instantiated.
            /// </summary>
            /// <param name="webBrowser">The top-level or frame <see cref="T:WebBrowser"/> that represents the window or frame.</param>
            public override void PrintTemplateInstantiated(WebBrowser webBrowser)
            {
                var e = new WebBrowserPrintTemplateEventArgs(webBrowser);

                this.Parent.OnPrintTemplateCreated(e);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a print template is being destroyed.
            /// </summary>
            /// <param name="webBrowser">The top-level or frame <see cref="T:WebBrowser"/> that represents the window or frame.</param>
            public override void PrintTemplateDestroyed(WebBrowser webBrowser)
            {
                var e = new WebBrowserPrintTemplateEventArgs(webBrowser);

                this.Parent.OnPrintTemplateDestroyed(e);
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that an event occurred that impacts privacy, or when a user navigated away from a URL that has impacted privacy.
            /// </summary>
            /// <param name="impacted"><see langword="true"/> if privacy has been impacted; otherwise <see langword="false"/>.</param>
            public override void PrivacyImpactedChanged(bool impacted)
            {
                this.Parent.PrivacyImpacted = impacted;
            }

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a new window is to be created.
            /// </summary>
            /// <param name="webBrowser">The <see cref="T:WebBrowser"/> where the navigation should occur.</param>
            /// <param name="cancel"><see langword="true"/> if the navigation should be canceled; otherwise <see langword="false"/>.</param>
            /// <param name="flags">The <see cref="T:WebBrowserNewWindowFlags">flags</see> that pertain to the new window.</param>
            /// <param name="urlContext">The URL of the page that is opening the new window.</param>
            /// <param name="url">The URL that is opened in the new window.</param>
            /// <returns>
            /// <see langword="true"/> to cancel the navigation; otherwise <see langword="false"/>.
            /// </returns>
            public override bool NewWindow(ref WebBrowser webBrowser, bool cancel, WebBrowserNewWindowFlags flags, string urlContext, string url)
            {
                var uriContext = new Uri(urlContext ?? string.Empty);
                var uri = new Uri(url ?? string.Empty);
                var e = new WebBrowserNewWindowEventArgs(webBrowser, uriContext, uri, flags, cancel);

                this.Parent.OnNewWindow(e);

                webBrowser = e.WebBrowser;
                return e.Cancel;
            }
        }
    }
}