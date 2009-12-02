//-----------------------------------------------------------------------
// <copyright file="WebBrowserEx-Events.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// WebBrowserEx's events.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Forms
{
    using System;
    using System.ComponentModel;
    using PauloMorgado.ComponentModel;
    using PauloMorgado.Windows.Interop;
    using PauloMorgado.Windows.WebBrowser;

    /// <content>
    /// <see cref="T:WebBrowserEx"/>'s events.
    /// </content>
    public partial class WebBrowserEx
    {
        #region Private Constants

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:Closing"/> event handlers.
        /// </summary>
        private static readonly object WindowClosingEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:Closed"/> event handlers.
        /// </summary>
        private static readonly object WindowClosedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:DocumentCompleted"/> event handlers.
        /// </summary>
        private static readonly object DocumentCompletedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:Downloaded"/> event handlers.
        /// </summary>
        private static readonly object DownloadedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:Downloading"/> event handlers.
        /// </summary>
        private static readonly object DownloadingEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:FileDownloading"/> event handlers.
        /// </summary>
        private static readonly object DownloadingFileEvent = new object();

        /// <summary>
        /// <see cref="P:PauloMorgado.Windows.WebBrowser.WebBrowserNavigatedEventArgs"/> key for <see cref="E:Navigating"/> event handlers.
        /// </summary>
        private static readonly object NavigatedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:NavigateError"/> event handlers.
        /// </summary>
        private static readonly object NavigateErrorEvent = new object();

        /// <summary>
        /// <see cref="P:PauloMorgado.Windows.WebBrowser.WebBrowserNavigatingEventArgs"/> key for <see cref="E:Navigating"/> event handlers.
        /// </summary>
        private static readonly object NavigatingEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:NewWindow"/> event handlers.
        /// </summary>
        private static readonly object NewWindowEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:PrintTemplateDestroyed"/> event handlers.
        /// </summary>
        private static readonly object PrintTemplateDestroyedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:PrintTemplateInstantiated"/> event handlers.
        /// </summary>
        private static readonly object PrintTemplateCreatedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:PrivacyImpactedChanged"/> event handlers.
        /// </summary>
        private static readonly object PrivacyImpactedChangedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:PropertyChanged"/> event handlers.
        /// </summary>
        private static readonly object PropertyChangedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:ScriptError"/> event handlers.
        /// </summary>
        private static readonly object ScriptErrorEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:ShowHelp"/> event handlers.
        /// </summary>
        private static readonly object ShowHelpEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:ShowMenuBar"/> event handlers.
        /// </summary>
        private static readonly object ShowMenuBarChangedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:ShowMessage"/> event handlers.
        /// </summary>
        private static readonly object ShowMessageEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:ShowStatusBar"/> event handlers.
        /// </summary>
        private static readonly object ShowStatusBarChangedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:ShowToolBar"/> event handlers.
        /// </summary>
        private static readonly object ShowToolBarChangedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:FullScreenMode"/> event handlers.
        /// </summary>
        private static readonly object FullScreenModeChangedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:TheaterMode"/> event handlers.
        /// </summary>
        private static readonly object TheaterModeChangedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:Resizable"/> event handlers.
        /// </summary>
        private static readonly object ResizableChangedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:StatusTextChanged"/> event handlers.
        /// </summary>
        private static readonly object StatusTextChangedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:TextChanged"/> event handlers.
        /// </summary>
        private static readonly object TextChangedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:TranslateUrl"/> event handlers.
        /// </summary>
        private static readonly object TranslateUrlEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:UpdateCommands"/> event handlers.
        /// </summary>
        private static readonly object UpdateCommandsEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:WindowHeightChanged"/> event handlers.
        /// </summary>
        private static readonly object WindowHeightChangedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:WindowWidthChanged"/> event handlers.
        /// </summary>
        private static readonly object WindowWidthChangedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:WindowLeftChanged"/> event handlers.
        /// </summary>
        private static readonly object WindowLeftChangedEvent = new object();

        /// <summary>
        /// <see cref="P:System.ComponentModel.Component.Events"/> key for <see cref="E:WindowTopChanged"/> event handlers.
        /// </summary>
        private static readonly object WindowTopChangedEvent = new object();

        #endregion

        #region Public Instance Events

        #region Action

        /// <summary>
        /// Occurs when a navigation operation finishes, is halted, or fails.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Unlike <see cref="WebBrowserControl.Navigated"/>, which are fired only when a URL is successfully navigated to, this event is always fired after a navigation starts.
        /// Any animation or "busy" indication that the container needs to display should be connected to this event.
        /// </para>
        /// <para>
        /// Each <see cref="WebBrowserControl.Downloading"/> event will have a corresponding <see cref="WebBrowserControl.Downloaded"/> event.
        /// </para>
        /// <seealso cref="WebBrowserControl.Downloading"/>
        /// <seealso cref="M:WebBrowser.Navigate"/>
        /// <seealso cref="WebBrowserControl.ProgressChanged"/>
        /// </remarks>
        [ActionCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_Downloaded")]
        public event EventHandler Downloaded
        {
            add
            {
                this.Events.AddHandler(DownloadedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(DownloadedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when a navigation operation is beginning.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event is fired shortly after the <see cref="WebBrowserControl.Navigating"/> event, unless the navigation is canceled.
        /// Any animation or "busy" indication that the container needs to display should be connected to this event.
        /// </para>
        /// <para>
        /// Each <see cref="WebBrowserControl.Downloading"/> event will have a corresponding <see cref="WebBrowserControl.Downloaded"/> event.
        /// </para>
        /// </remarks>
        [ActionCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_Downloading")]
        public event EventHandler Downloading
        {
            add
            {
                this.Events.AddHandler(DownloadingEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(DownloadingEvent, value);
            }
        }

        /// <summary>
        /// Occurs when a file download is about to occur.
        /// If a file download dialog is to be displayed, this event is fired prior to the display of the dialog.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The processing of this download process can be modified by setting the <see cref="CancelEventArgs.Cancel"/> property to <see langword="true"/>.
        /// </para>
        /// <para>
        /// This event allows alternative action to be taken during a file download.
        /// </para>
        /// </remarks>
        [ActionCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_DownloadingFile")]
        public event EventHandler<WebBrowserDownloadingFileEventArgs> DownloadingFile
        {
            add
            {
                this.Events.AddHandler(DownloadingFileEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(DownloadingFileEvent, value);
            }
        }

        /// <summary>
        /// Occurs after a navigation to a link is completed on either a window or frame.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="NavigatedEventArgs.Url"/> property can be different from the URL that the browser was told to navigate to.
        /// One reason is that this URL is the canonized and qualified URL.
        /// Also, if the server has redirected the browser to a different URL, the redirected URL will be reflected here. 
        /// </para>
        /// <para>
        /// The document might still be downloading (and in the case of HTML, images might still be downloading), but at least part of the document has been received from the server, and the viewer for the document has been created.
        /// </para>
        /// <para>
        /// The <see cref="WebBrowserControl.Navigated"/> event fires only after the first navigation made in code.
        /// It does not fire when a user clicks a link on a Web page. 
        /// </para>
        /// <seealso cref="WebBrowserControl.Navigating"/>
        /// </remarks>
        [ActionCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_Navigated")]
        public new event EventHandler<PauloMorgado.Windows.WebBrowser.WebBrowserNavigatedEventArgs> Navigated
        {
            add
            {
                this.Events.AddHandler(NavigatedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(NavigatedEvent, value);
            }
        }

        /// <summary>
        /// Occours when an error occurs during navigation.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This event fires before Internet Explorer displays an error page due to an error in navigation.
        /// An application has a chance to stop the display of the error page by setting the <see cref="System.ComponentModel.CancelEventArgs.Cancel"/> property to <see langword="true"/>.
        /// However, if the server contacted in the original navigation supplies its own substitute page navigation, setting <see cref="System.ComponentModel.CancelEventArgs.Cancel"/> to <see langword="true"/> will have no effect and the navigation to the server's alternate page will proceed.
        /// For example, assume that a navigation to http://www.www.wingtiptoys.com/BigSale.htm causes this event to fire because the page does not exist.
        /// However, the server is set to redirect you to http://www.www.wingtiptoys.com/home.htm instead.
        /// In this case, setting <see cref="System.ComponentModel.CancelEventArgs.Cancel"/> to <see langword="true"/> has no effect and navigation will proceed to http://www.www.wingtiptoys.com/home.htm.
        /// </para>
        /// <para>
        /// The <see cref="NavigateErrorEventArgs.WebBrowser"/> property should be used to match this event with its corresponding <see cref="M:WebBrowser.Navigate"/> request.
        /// For example, multiple <see cref="NavigateError"/> events can fire for a single <see cref="M:WebBrowser.Navigate"/> request.
        /// Reasons for this include navigation to a URL with multiple frames or multiple attempts by an autosearch engine to resolve an invalid URL.
        /// In each of these cases, the URL passed into these events might not match the URL that was originally requested.
        /// However, each of these events will have the same <see cref="NavigateErrorEventArgs.WebBrowser"/>.
        /// </para>
        /// <para>
        /// A URL passed into <see cref="M:WebBrowser.Navigate"/> might not match the URL passed into this event because the URL goes through a normalization process.
        /// For example, the URL string "www.wingtiptoys.co" could be passed into <see cref="M:WebBrowser.Navigate"/>, but because of the normalization process, the URL parameter is set to "http://www.wingtiptoys.co/".
        /// </para>
        /// <para>
        /// The <see cref="NavigateError"/> event fires only after the first navigation made in code.
        /// It does not fire when a user clicks a link on a Web page.
        /// </para>
        /// </remarks>
        [ActionCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_NavigateError")]
        public event EventHandler<WebBrowserNavigateErrorEventArgs> NavigateError
        {
            add
            {
                this.Events.AddHandler(NavigateErrorEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(NavigateErrorEvent, value);
            }
        }

        /// <summary>
        /// Occurs before navigation occurs in the given object (on either a window or frameset element).
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="NavigatingEventArgs.WebBrowser"/> property contains a reference to the <see cref="WebBrowser"/> that represents the window or frame.
        /// </para>
        /// <para>
        /// The <see cref="NavigatingEventArgs.Url"/> property contains the URL to be navigated to.
        /// </para>
        /// <para>
        /// The <see cref="NavigatingEventArgs.TargetFrameName"/> property contains the name of the frame in which to display the resource, or a null reference (Nothing in Visual Basic) if no named frame is targeted for the resource.
        /// </para>
        /// <para>
        /// The <see cref="NavigatingEventArgs.PostData"/> property contains the data to send to the server if the HTTP POST transaction is being used.
        /// </para>
        /// <para>
        /// The <see cref="NavigatingEventArgs.Headers"/> property contains additional HTTP headers to send to the server (HTTPURLs only). The headers can specify things such as the action required of the server, the type of data being passed to the server, or a status code.
        /// </para>
        /// <para>
        /// Navigating to a different URL could happen as a result of external automation, internal automation from a script, or the user clicking a link.
        /// The processing of this navigation can be modified by setting the <see cref="System.ComponentModel.CancelEventArgs.Cancel"/> property to <see langword="true"/> and either ignoring or reissuing a modified navigation method to the <see cref="WebBrowser"/>.
        /// </para>
        /// <para>
        /// When reissuing a navigation for the <see cref="WebBrowser"/>, the <see cref="M:WebBrowser.Stop"/> method must first be executed for <see cref="P:NavigatingEventArgs.WebBrowser"/>.
        /// This prevents the display of a web page that declares a cancelled navigation from appearing while the new navigation is being processed.
        /// </para>
        /// <seealso cref="WebBrowserControl.Navigated"/>
        /// <seealso cref="M:WebBrowser.Navigate"/>
        /// </remarks>
        [ActionCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_Navigating")]
        public new event EventHandler<PauloMorgado.Windows.WebBrowser.WebBrowserNavigatingEventArgs> Navigating
        {
            add
            {
                this.Events.AddHandler(NavigatingEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(NavigatingEvent, value);
            }
        }

        /// <summary>
        /// Occurs when a new window is to be created (extended event arguments).
        /// </summary>
        /// <remarks>
        /// <para>
        /// <see cref="NewWindow"/> is raised before <see cref="NewWindow"/>.
        /// </para>
        /// <para>
        /// The <see cref="NewWindow"/> event is not raised when the user selects New Window from the context menu or by pressing Ctr+N.
        /// This event precedes the creation of a new window from within the <see cref="WebBrowserControl"/>.
        /// For example, <see cref="NewWindow"/> event is raised in response to a navigation targeted to a new window, or from script using the window.open() method.
        /// </para>
        /// <para>
        /// The <see cref="NewWindow"/> event is raised when a window is about to be created, such as during the following actions:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// The user clicks a link while pressing the Shift key.
        /// </item>
        /// <item>
        /// The user right-clicks a link and selects Open In New Window.
        /// </item>
        /// <item>
        /// The user selects New Window from the File menu.
        /// </item>
        /// <item>
        /// There is a targeted navigation to a frame name that does not yet exist.
        /// </item>
        /// </list>
        /// <para>
        /// Your browser application can also trigger this event by calling the <see cref="M:WebBrowser.Navigate"/> method with the <see cref="NavigateFlags.OpenInNewWindow"/> flag.
        /// The <see cref="WebBrowserControl"/> has an opportunity to handle the new window creation itself.
        /// If it does not, a top-level Internet Explorer window is created as a separate (nonhosted) process.
        /// </para>
        /// <para>
        /// The application that processes this notification can respond in one of three ways:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// Create a new, hidden, non navigated <see cref="WebBrowserControl"/> or InternetExplorer object that is returned in <see cref="NewWindowEventArgs.WebBrowser"/> property.
        /// Upon return from this event, the object that raised this event will then configure and navigate (including a <see cref="WebBrowserControl.Navigating"/> event) the new object to the target location.
        /// </item>
        /// <item>
        /// Cancel the navigation by setting <see cref="CancelEventArgs.Cancel"/> property to <see langword="true"/>.
        /// </item>
        /// </list>
        /// <seealso cref="WebBrowserControl.Navigated"/>
        /// </remarks>
        [ActionCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_NewWindow")]
        public new event EventHandler<WebBrowserNewWindowEventArgs> NewWindow
        {
            add
            {
                this.Events.AddHandler(NewWindowEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(NewWindowEvent, value);
            }
        }

        /// <summary>
        /// Occurs when a print template has been destroyed.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="PrintTemplateEventArgs.WebBrowser"/> property represents the window or frame where the print template is being destroyed.
        /// </para>
        /// <seealso cref="PrintTemplateInstantiated"/>
        /// </remarks>
        [ActionCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_PrintTemplateDestroyed")]
        public event EventHandler<WebBrowserPrintTemplateEventArgs> PrintTemplateDestroyed
        {
            add
            {
                this.Events.AddHandler(PrintTemplateDestroyedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(PrintTemplateDestroyedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when a print template has been created.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="PrintTemplateEventArgs.WebBrowser"/> property represents the window or frame where the print template is being instantiated.
        /// </para>
        /// <seealso cref="PrintTemplateDestroyed"/>
        /// </remarks>
        [ActionCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_PrintTemplateCreated")]
        public event EventHandler<WebBrowserPrintTemplateEventArgs> PrintTemplateCreated
        {
            add
            {
                this.Events.AddHandler(PrintTemplateCreatedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(PrintTemplateCreatedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when an event impacts privacy or when a user navigates away from a URL that has impacted privacy.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The firing of this event corresponds to a change in the privacy state from impacted to unimpacted and vice-versa. A change in the privacy state coincides with the displaying or clearing of the privacy-impacted icon from the status bar. Although a URL's privacy policy might not agree with the browser's privacy settings, privacy is considered impacted only if violating cookie operations are attempted. This event only fires the first time a violating cookie action is attempted for a URL.
        /// </para>
        /// <para>
        /// This event also fires when there is a user-initiated navigation away from a URL that has privacy violations. If the new URL has no record of privacy violations, the icon no longer displays and the privacy state remains as unimpacted. However, when navigating from a URL with privacy violations to revisit a URL that has a history of privacy violations (for example, the page has been retrieved from the cache), this event fires twice: once to signal that it is navigating away from the first violating URL and a second time to signal that it is navigating to a URL which has impacted privacy.
        /// </para>
        /// <para>
        /// User-initiated navigations include:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// Typing a URL in the address bar
        /// </item>
        /// <item>
        /// Navigating using "Go To" option off of the "View" menu
        /// </item>
        /// <item>
        /// Choosing a URL from the Favorites List
        /// </item>
        /// <item>
        /// Clicking on a hyperlink that does not contain a script href
        /// </item>
        /// <item>
        /// Peforming a manual top-level refresh
        /// </item>
        /// <item>
        /// Performing a top-level navigating using the Back and Forward buttons.
        /// </item>
        /// </list>
        /// <para>
        /// Privacy is considered impacted when any of the following occur:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// A cookie is suppressed when sending and HTTP request.
        /// </item>
        /// <item>
        /// A cookie is blocked from being written.
        /// </item>
        /// <item>
        /// A cached file is retrieved that has a history of privacy violations.
        /// </item>
        /// </list>
        /// </remarks>
        [ActionCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_PrivacyImpactedChanged")]
        public event EventHandler PrivacyImpactedChanged
        {
            add
            {
                this.Events.AddHandler(PrivacyImpactedChangedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(PrivacyImpactedChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when MSHTML when needs to display Help.
        /// </summary>
        [ActionCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_ShowHelp")]
        public event EventHandler<WebBrowserShowHelpEventArgs> ShowHelp
        {
            add
            {
                this.Events.AddHandler(ShowHelpEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(ShowHelpEvent, value);
            }
        }

        /// <summary>
        /// Occurs when MSHTML when needs to display a message box.
        /// </summary>
        [ActionCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_ShowMessage")]
        public event EventHandler<WebBrowserShowMessageEventArgs> ShowMessage
        {
            add
            {
                this.Events.AddHandler(ShowMessageEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(ShowMessageEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the policy for the specified action is being determined.
        /// </summary>
        [ActionCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_ScriptError")]
        public event EventHandler<WebBrowserScriptErrorEventArgs> ScriptError
        {
            add
            {
                this.Events.AddHandler(ScriptErrorEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(ScriptErrorEvent, value);
            }
        }

        /// <summary>
        /// Occurs when a before the <see cref="Navigating"/> event to allow the modification of the URL to be loaded.
        /// </summary>
        /// <remarks>
        /// The <see cref="WebBrowserControl"/> does not raise this event to modify the URL suplied to <see cref="M:WebBrowser.Navigate"/>.
        /// </remarks>
        [ActionCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_TranslateUrl")]
        public event EventHandler<WebBrowserTranslateUrlEventArgs> TranslateUrl
        {
            add
            {
                this.Events.AddHandler(TranslateUrlEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(TranslateUrlEvent, value);
            }
        }

        #endregion

        #region Behavior

        /// <summary>
        /// Occurs when the window of the object is about to be closed by script.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="ClosingEventArgs.IsChildWindow"/> property specifies whether the window was created from script
        /// (<see langword="true"/> the window was created from script; otherwise <see langword="false"/>).
        /// </para>
        /// <para>
        /// The <see cref="CancelEventArgs.Cancel"/> property specifies whether the window is prevented from closing
        /// (<see langword="true"/> the window is prevented from closing; otherwise <see langword="false"/>).
        /// </para>
        /// </remarks>
        [BehaviorCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_WindowClosing")]
        public event EventHandler<WebBrowserClosingEventArgs> WindowClosing
        {
            add
            {
                this.Events.AddHandler(WindowClosingEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(WindowClosingEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the window of the object has been closed.
        /// </summary>
        [BehaviorCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_WindowClosed")]
        public event EventHandler WindowClosed
        {
            add
            {
                this.Events.AddHandler(WindowClosedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(WindowClosedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when a document has been completely loaded and initialized.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The value of the <see cref="NavigatedEventArgs.Url"/> property might not match the URL that was originally given to the <see cref="WebBrowserControl"/>.
        /// One possible reason for this is that the URL might be converted to a qualified form.
        /// For example, if an application specified a URL of www.microsoft.com in a call to the <see cref="M:WebBrowser.Navigate"/> method, then the URL passed into <see cref="WebBrowserControl.Downloaded"/> is http://www.microsoft.com/.
        /// In addition, if the server has redirected the browser to a different URL, the redirected URL is passed into the URL parameter.
        /// </para>
        /// <para>
        /// The <see cref="WebBrowserControl"/>. fires the <see cref="WebBrowserControl.DocumentCompleted"/> event when the document has completely loaded and the <see cref="P:WebBrowserReadyState"/> property has changed to <see cref="T:WebBrowserReadyState.Complete"/>.
        /// Here are some important points regarding the firing of this event.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// In pages with no frames, this event fires once after loading is complete.
        /// </item>
        /// <item>
        /// In pages where multiple frames are loaded, this event fires for each frame where the <see cref="WebBrowserControl.Downloading"/> event has fired. 
        /// </item>
        /// <item>
        /// This event's <see cref="NavigatedEventArgs.WebBrowser"/> property is the reference to the frame in which this event fires.
        /// </item>
        /// <item>
        /// In the loading process, the highest level frame (which is not necessarily the top-level frame) fires the final <see cref="WebBrowserControl.DocumentCompleted"/> event.
        /// At this time, the <see cref="NavigatedEventArgs.WebBrowser"/> property will be the same as the <see cref="WebBrowser"/> of the highest level frame.
        /// </item>
        /// </list>
        /// <para>
        /// Currently, the <see cref="WebBrowserControl.DocumentCompleted"/> does not fire when the <see cref="P:System.Windows.Forms.Control.Visible"/> property of the <see cref="T:WebBrowserControl"/> is set to false.
        /// For more information, see Knowledge Base Article <a href="http://support.microsoft.com/kb/q259935/"/> .
        /// </para>
        /// <seealso cref="WebBrowserControl.Navigating"/>
        /// <seealso cref="M:WebBrowser.Navigate"/>
        /// <seealso cref="ReadyState"/>
        /// </remarks>
        [BehaviorCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_DocumentCompleted")]
        public new event EventHandler<PauloMorgado.Windows.WebBrowser.WebBrowserDocumentCompletedEventArgs> DocumentCompleted
        {
            add
            {
                this.Events.AddHandler(DocumentCompletedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(DocumentCompletedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the enable state of a toolbar button might have changed.
        /// </summary>
        [BehaviorCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_UpdateCommands")]
        public event EventHandler UpdateCommands
        {
            add
            {
                this.Events.AddHandler(UpdateCommandsEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(UpdateCommandsEvent, value);
            }
        }

        #endregion

        #region Property Changed

        /// <summary>
        /// Occurs when the one of <see cref="P:WebBrowser.Property"/> values changes.
        /// </summary>
        /// <remarks>
        /// The <see cref="PropertyChangedEventArgs.PropertyName"/> contains the name of the property that changed.
        /// <see cref="P:WebBrowser.Property"/>
        /// </remarks>
        [PropertyChangedCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_PropertyChanged")]
        public event EventHandler<PropertyChangedEventArgs> PropertyChanged
        {
            add
            {
                this.Events.AddHandler(PropertyChangedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(PropertyChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the value of the <see cref="P:WebBrowser.ShowMenuBar"/> property changes.
        /// </summary>
        [PropertyChangedCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_ShowMenuBarChanged")]
        public event EventHandler ShowMenuBarChanged
        {
            add
            {
                this.Events.AddHandler(ShowMenuBarChangedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(ShowMenuBarChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the value of the <see cref="P:WebBrowser.ShowStatusBar"/> property changes.
        /// </summary>
        [PropertyChangedCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_ShowStatusBarChanged")]
        public event EventHandler ShowStatusBarChanged
        {
            add
            {
                this.Events.AddHandler(ShowStatusBarChangedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(ShowStatusBarChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the <see cref="StatusText"/> property changes.
        /// </summary>
        /// <remarks>
        /// The container can use the information provided by this event to update the text of a status bar.
        /// <see cref="StatusText"/>
        /// </remarks>
        [PropertyChangedCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_StatusTextChanged")]
        public new event EventHandler<ReadOnlyValueEventArgs<string>> StatusTextChanged
        {
            add
            {
                this.Events.AddHandler(StatusTextChangedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(StatusTextChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the value of the <see cref="P:WebBrowser.ShowToolBar"/> property changes.
        /// </summary>
        [PropertyChangedCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_ShowToolBarChanged")]
        public event EventHandler ShowToolBarChanged
        {
            add
            {
                this.Events.AddHandler(ShowToolBarChangedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(ShowToolBarChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the value of the <see cref="P:WebBrowser.TheaterMode"/> property changes.
        /// </summary>
        [PropertyChangedCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_TheaterModeChanged")]
        public event EventHandler TheaterModeChanged
        {
            add
            {
                this.Events.AddHandler(TheaterModeChangedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(TheaterModeChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the value of the <see cref="P:WebBrowser.Resizable"/> property changes.
        /// </summary>
        [PropertyChangedCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_ResizableChanged")]
        public event EventHandler ResizableChanged
        {
            add
            {
                this.Events.AddHandler(ResizableChangedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(ResizableChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the value of the <see cref="P:WebBrowser.FullScreenMode"/> property changes.
        /// </summary>
        [PropertyChangedCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_FullScreenModeChanged")]
        public event EventHandler FullScreenModeChanged
        {
            add
            {
                this.Events.AddHandler(FullScreenModeChangedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(FullScreenModeChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the <see cref="P:System.Windows.Forms.Control.Text" /> property value changes.
        /// </summary>
        [PropertyChangedCategory]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public new event EventHandler TextChanged
        {
            add
            {
                this.Events.AddHandler(TextChangedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(TextChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the client window changes its height.
        /// </summary>
        [PropertyChangedCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_WindowHeightChanged")]
        public event EventHandler WindowHeigthChanged
        {
            add
            {
                this.Events.AddHandler(WindowHeightChangedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(WindowHeightChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when the client window changes its width.
        /// </summary>
        [PropertyChangedCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_WindowWidthChanged")]
        public event EventHandler WindowWidthChanged
        {
            add
            {
                this.Events.AddHandler(WindowWidthChangedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(WindowWidthChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when  the client window left position changes.
        /// </summary>
        [PropertyChangedCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_WindowLeftChanged")]
        public event EventHandler WindowLeftChanged
        {
            add
            {
                this.Events.AddHandler(WindowLeftChangedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(WindowLeftChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when client window top position changes.
        /// </summary>
        [PropertyChangedCategory]
        [ResourcesDescription("WebBrowserEx_EventDescription_WindowTopChanged")]
        public event EventHandler WindowTopChanged
        {
            add
            {
                this.Events.AddHandler(WindowTopChangedEvent, value);
            }

            remove
            {
                this.Events.RemoveHandler(WindowTopChangedEvent, value);
            }
        }

        #endregion

        #endregion

        #region Event Raisers

        #region Action

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.Downloaded"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> that contains the event data.
        /// </param>
        protected internal virtual void OnDownloaded(System.EventArgs e)
        {
            try
            {
                this.Events.Fire(DownloadedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.Downloading"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> that contains the event data.
        /// </param>
        protected internal virtual void OnDownloading(System.EventArgs e)
        {
            try
            {
                this.Events.Fire(DownloadingEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.FileDownloading"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="System.ComponentModel.CancelEventArgs"/> that contains the event data.
        /// </param>
        protected internal virtual void OnDownloadingFile(WebBrowserDownloadingFileEventArgs e)
        {
            try
            {
                this.Events.Fire(DownloadingFileEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.WebBrowser.Navigated"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:PauloMorgado.Windows.WebBrowser.WebBrowserNavigatedEventArgs"/> that contains the event data.</param>
        protected internal virtual void OnNavigated(PauloMorgado.Windows.WebBrowser.WebBrowserNavigatedEventArgs e)
        {
            try
            {
                this.Events.Fire(NavigatedEvent, this, e);
                base.OnNavigated((System.Windows.Forms.WebBrowserNavigatedEventArgs)e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.NavigateError"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="NavigateErrorEventArgs"/> that contains the event data.
        /// </param>
        protected internal virtual void OnNavigateError(WebBrowserNavigateErrorEventArgs e)
        {
            try
            {
                this.Events.Fire(NavigateErrorEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.WebBrowser.Navigating"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:PauloMorgado.Windows.WebBrowser.WebBrowserNavigatingEventArgs"/> that contains the event data.</param>
        protected internal virtual void OnNavigating(PauloMorgado.Windows.WebBrowser.WebBrowserNavigatingEventArgs e)
        {
            try
            {
                this.Events.Fire(NavigatingEvent, this, e);
                base.OnNavigating((System.Windows.Forms.WebBrowserNavigatingEventArgs)e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// This method is not supported by this control.
        /// </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"/> that contains the event data.</param>
        /// <remarks><see cref="M:OnNewWindow(PauloMorgado.Windows.WebBrowser.WebBrowserNewWindowEventArgs)"/></remarks>
        protected sealed override void OnNewWindow(CancelEventArgs e)
        {
            base.OnNewWindow(e);
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.NewWindow"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="NewWindowEventArgs"/> that contains the event data.
        /// </param>
        protected virtual void OnNewWindow(WebBrowserNewWindowEventArgs e)
        {
            try
            {
                this.Events.Fire(NewWindowEvent, this, e);
                this.OnNewWindow((CancelEventArgs)e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.PrintTemplateDestroyed"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> that contains the event data.
        /// </param>
        protected virtual void OnPrintTemplateDestroyed(WebBrowserPrintTemplateEventArgs e)
        {
            try
            {
                this.Events.Fire(PrintTemplateDestroyedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.PrintTemplateInstantiated"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> that contains the event data.
        /// </param>
        protected virtual void OnPrintTemplateCreated(WebBrowserPrintTemplateEventArgs e)
        {
            try
            {
                this.Events.Fire(PrintTemplateCreatedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.PrivacyImpactedChanged"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="EventArgs"/> that contains the event data.
        /// </param>
        protected virtual void OnPrivacyImpactedChanged(EventArgs e)
        {
            try
            {
                this.Events.Fire(PrivacyImpactedChangedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.ShowHelp"/> event.
        /// </summary>
        /// <param name="e">The <see cref="T:WebBrowserShowHelpEventArgs"/> instance containing the event data.</param>
        protected virtual void OnShowHelp(WebBrowserShowHelpEventArgs e)
        {
            try
            {
                this.Events.Fire(ShowHelpEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.ShowMessage"/> event.
        /// </summary>
        /// <param name="e">The <see cref="T:ShowMessageEventArgs"/> instance containing the event data.</param>
        protected virtual void OnShowMessage(WebBrowserShowMessageEventArgs e)
        {
            try
            {
                this.Events.Fire(ShowMessageEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.ScriptError"/> event.
        /// </summary>
        /// <param name="e">The <see cref="T:WebBrowserScriptErrorEventArgs"/> instance containing the event data.</param>
        protected virtual void OnScriptError(WebBrowserScriptErrorEventArgs e)
        {
            try
            {
                this.Events.Fire(ScriptErrorEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.TranslateUrl"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="WebBrowserTranslateUrlEventArgs"/> instance containing the event data.
        /// </param>
        protected virtual void OnTranslateUrl(WebBrowserTranslateUrlEventArgs e)
        {
            try
            {
                this.Events.Fire(TranslateUrlEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        #endregion

        #region Behavior

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.Closed"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="EventArgs"/> that contains the event data.
        /// </param>
        protected virtual void OnWindowClosed(EventArgs e)
        {
            try
            {
                this.Events.Fire(WindowClosedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.Closing"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="ClosingEventArgs"/> that contains the event data.
        /// </param>
        protected virtual void OnWindowClosing(WebBrowserClosingEventArgs e)
        {
            try
            {
                this.Events.Fire(WindowClosingEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// This method is not supported by this control.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.WebBrowserDocumentCompletedEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// <see cref="M:OnDocumentCompleted(PauloMorgado.Windows.WebBrowser.WebBrowserDocumentCompletedEventArgs)"/>
        /// </remarks>
        protected sealed override void OnDocumentCompleted(System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            base.OnDocumentCompleted(e);

            UnsafeNativeMethods.ICustomDoc customDoc = this.Document.DomDocument as UnsafeNativeMethods.ICustomDoc;

            customDoc.SetUIHandler(this.webBrowserUIHandler);
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.DocumentCompleted"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="NavigatedEventArgs"/> that contains the event data.
        /// </param>
        protected virtual void OnDocumentCompleted(PauloMorgado.Windows.WebBrowser.WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                this.OnDocumentCompleted((System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)e);
                this.Events.Fire(DocumentCompletedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.UpdateCommands"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="EventArgs"/> that contains the event data.
        /// </param>
        protected virtual void OnUpdateCommands(EventArgs e)
        {
            try
            {
                this.Events.Fire(UpdateCommandsEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        #endregion

        #region Property Changed

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.PropertyChanged"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="PropertyChangedEventArgs"/> that contains the event data.
        /// </param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            try
            {
                this.Events.Fire(PropertyChangedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.ShowMenuBarChanged"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="EventArgs"/> that contains the event data.
        /// </param>
        protected virtual void OnShowMenuBarChanged(EventArgs e)
        {
            try
            {
                this.Events.Fire(ShowMenuBarChangedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.ShowToolBarChanged"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="EventArgs"/> that contains the event data.
        /// </param>
        protected virtual void OnShowStatusBarChanged(EventArgs e)
        {
            try
            {
                this.Events.Fire(ShowStatusBarChangedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.ShowToolBarChanged"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="EventArgs"/> that contains the event data.
        /// </param>
        protected virtual void OnShowToolBarChanged(EventArgs e)
        {
            try
            {
                this.Events.Fire(ShowToolBarChangedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.FullScreenModeChanged"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="EventArgs"/> that contains the event data.
        /// </param>
        protected virtual void OnFullScreenModeChanged(EventArgs e)
        {
            try
            {
                this.Events.Fire(FullScreenModeChangedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.TheaterModeChanged"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="EventArgs"/> that contains the event data.
        /// </param>
        protected virtual void OnTheaterModeChanged(EventArgs e)
        {
            try
            {
                this.Events.Fire(TheaterModeChangedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.ResizableChanged"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="EventArgs"/> that contains the event data.
        /// </param>
        protected virtual void OnResizableChanged(EventArgs e)
        {
            try
            {
                this.Events.Fire(ResizableChangedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="T:WebBrowserEx.StatusTextChanged"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="EventArgs"/> that contains the event data.
        /// </param>
        protected virtual void OnStatusTextChanged(ReadOnlyValueEventArgs<string> e)
        {
            try
            {
                this.Events.Fire(StatusTextChangedEvent, this, e);
                base.OnStatusTextChanged(e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.TextChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            try
            {
                this.Events.Fire(TextChangedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.WindowLeftChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected virtual void OnWindowLeftChanged(EventArgs e)
        {
            try
            {
                this.Events.Fire(WindowLeftChangedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.WindowTopChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected virtual void OnWindowTopChanged(EventArgs e)
        {
            try
            {
                this.Events.Fire(WindowTopChangedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.WindowWidthChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected virtual void OnWindowWidthChanged(EventArgs e)
        {
            try
            {
                this.Events.Fire(WindowWidthChangedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.WindowHeightChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected virtual void OnWindowHeightChanged(EventArgs e)
        {
            try
            {
                this.Events.Fire(WindowHeightChangedEvent, this, e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.Application.OnThreadException(ex);
            }
        }

        #endregion

        #endregion
    }
}
