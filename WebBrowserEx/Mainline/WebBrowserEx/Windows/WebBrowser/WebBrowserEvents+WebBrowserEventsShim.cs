//-----------------------------------------------------------------------
// <copyright file="WebBrowserEvents+WebBrowserEventsShim.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Web browser events shim.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <content>
    /// <see cref="T:WebBrowserExEventsShim"/> class.
    /// </content>
    public partial class WebBrowserEvents
    {
        /// <summary>
        /// Shims web browser events to the parent web browser control.
        /// </summary>
        public abstract class WebBrowserEventsShim
        {
            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the enable state of a toolbar button might have changed.
            /// </summary>
            public abstract void UpdateCommands();

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the enable state of the Back button has changed.
            /// </summary>
            /// <param name="enable"><see langword="true"/> the Back button should be enabled; otherwise <see langword="false"/>.</param>
            public abstract void SetCanGoBack(bool enable);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the enable state of the Forward button has changed. 
            /// </summary>
            /// <param name="enable"><see langword="true"/> the Forward button should be enabled; otherwise <see langword="false"/>.</param>
            public abstract void SetCanGoForward(bool enable);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the status bar text has changed.
            /// </summary>
            /// <param name="statusText">The status bar text.</param>
            public abstract void StatusTextChanged(string statusText);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the progress of a download operation is updated.
            /// </summary>
            /// <param name="progress">The amount of total progress to show, or -1 when progress is complete.</param>
            /// <param name="progressMax">The maximum progress value.</param>
            public abstract void ProgressChanged(int progress, int progressMax);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a navigation operation has begun.
            /// </summary>
            /// <remarks>
            /// <para>This event happens shortly after the <see cref="M:Navigating"/> event event, unless the navigation is canceled. Any animation or "busy" indication that the container must display should be connected to this event.</para>
            /// <para>Each <see cref="M:Downloading"/> event has a corresponding <see cref="M:Downloaded"/> event.</para>
            /// </remarks>
            public abstract void Downloading();

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a navigation operation has finished, been halted or failed.
            /// </summary>
            /// <remarks>
            /// <para>Unlike <see cref="M:Navigated"/>, which are happens only when a URL is successfully navigated to, this event always happen after a navigation starts. Any animation or "busy" indication that the container must display should be connected to this event.</para>
            /// <para>Each <see cref="M:Downloading"/> event has a corresponding <see cref="M:Downloaded"/> event.</para>
            /// </remarks>
            public abstract void Downloaded();

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the title of a document became available or changed.
            /// </summary>
            /// <param name="documentTitle">The document title.</param>
            public abstract void TitleChanged(string documentTitle);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a <see cref="P:WebBrowser.Properties">property</see> value has changed.
            /// </summary>
            /// <param name="propertyName">Name of the property.</param>
            public abstract void PropertyChanged(string propertyName);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a navigation is occurring.
            /// </summary>
            /// <param name="webBrowser">The top-level or frame <see cref="T:WebBrowser"/> corresponding to the navigation.</param>
            /// <param name="url">The URL to which the browser is navigating.</param>
            /// <param name="targetFrameName">The frame in which the resource will be displayed, or <see langword="null" /> if no named frame is targeted for the resource.</param>
            /// <param name="postData">Data to send to the server if the HTTP POST transaction is being used.</param>
            /// <param name="headers">Specifies the additional HTTP headers to send to the server (HTTP URLs only). The headers can specify such things as the action required of the server, the type of data being passed to the server, or a status code.</param>
            /// <returns><see langword="true" /> to cancel the navigation operation, or to <see langword="false" /> to allow it to proceed.</returns>
            public abstract bool Navigating(WebBrowser webBrowser, string url, string targetFrameName, byte[] postData, string headers);

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
            public abstract void Navigated(WebBrowser webBrowser, string url);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a document has been completely loaded and initialized.
            /// </summary>
            /// <param name="webBrowser">The top-level or frame <see cref="T:WebBrowser"/> corresponding to the loaded document.</param>
            /// <param name="url">The URL, Universal Naming Convention (UNC) file name, or pointer to an item identifier list (PIDL) of the loaded document.</param>
            public abstract void DocumentCompleted(WebBrowser webBrowser, string url);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the Microsoft Internet Explorer application is quitting.
            /// </summary>
            /// <remarks>The WebBrowser control ignores this event.</remarks>
            public abstract void Quit();

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the value of the <see cref="P:WebBrowser.Visible"/> property has changed.
            /// </summary>
            /// <param name="visible"><see langword="true" /> is the web browser should be visible; otherwise <see langword="false" />.</param>
            public abstract void SetVisiblility(bool visible);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the value of the <see cref="P:WebBrowser.ShowToolBar"/> property has changed.
            /// </summary>
            /// <param name="visible"><see langword="true" /> is the web browser's toolbar should be visible; otherwise <see langword="false" />.</param>
            public abstract void SetToolBarVisiblility(bool visible);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the value of the <see cref="P:WebBrowser.MenuBar"/> property has changed.
            /// </summary>
            /// <param name="visible"><see langword="true" /> is the web browser's menu bar should be visible; otherwise <see langword="false" />.</param>
            public abstract void SetMenuBarVisiblility(bool visible);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the value of the <see cref="P:WebBrowser.StatusBar"/> property has changed.
            /// </summary>
            /// <param name="visible"><see langword="true" /> is the web browser's status bar should be visible; otherwise <see langword="false" />.</param>
            public abstract void SetStatusBarVisiblility(bool visible);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the value of the <see cref="P:WebBrowser.FullScreen"/> property has changed.
            /// </summary>
            /// <param name="fullScreen"><see langword="true" /> is the web browser should be in full screen mode; otherwise <see langword="false" />.</param>
            public abstract void SetFullScreen(bool fullScreen);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the value of the <see cref="P:WebBrowser.TheaterMode"/> property has changed.
            /// </summary>
            /// <param name="theaterMode"><see langword="true" /> is the web browser should be in theater mode; otherwise <see langword="false" />.</param>
            public abstract void SetTheaterMode(bool theaterMode);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> if the host window should allow resizing.
            /// </summary>
            /// <param name="resizable"><see langword="true"/> resizing should be allowed; otherwsie <see langword="false" />.</param>
            public abstract void SetResizable(bool resizable);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that left position changes.
            /// </summary>
            /// <param name="left">The new left position.</param>
            public abstract void SetWindowLeft(int left);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that top position changes.
            /// </summary>
            /// <param name="top">The new top position.</param>
            public abstract void SetWindowTop(int top);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that width changes.
            /// </summary>
            /// <param name="width">The new width.</param>
            public abstract void SetWindowWidth(int width);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that height changes.
            /// </summary>
            /// <param name="height">The new height.</param>
            public abstract void SetWindowHeight(int height);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the window is about to be closed by script.
            /// </summary>
            /// <param name="isChildWindow"><see langword="true"/> if the was created from script; otherwise <see langword="false" />.</param>
            /// <param name="cancel">Indication whether the window should be prevented from closing.</param>
            /// <returns><see langword="true"/> if the window is prevented from closing; otherwise <see langword="false" />.</returns>
            public abstract bool WindowClosing(bool isChildWindow, bool cancel);

            /// <summary>
            /// Requests the <see cref="P:Parent"/> to convert the client window size to the host window size.
            /// </summary>
            /// <param name="size">The size to convert.</param>
            /// <returns>The converted size</returns>
            public abstract System.Drawing.Size ClientToHostWindow(System.Drawing.Size size);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that the encryption level has changed.
            /// </summary>
            /// <param name="encryptionLevel">The <see cref="T:WebBrowserEncryptionLevel">encryption level</see>.</param>
            public abstract void SetEncryptionLevel(WebBrowserEncryptionLevel encryptionLevel);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a file download is about to occur.
            /// </summary>
            /// <param name="activeDocument"><see langword="true"/> if the file is an Active Document; otherwise <see langword="false" />.</param>
            /// <param name="cancel"><see langword="true"/> if the download process should be canceled; otherwise <see langword="false" />.</param>
            /// <returns><see langword="true"/> to cancel the download process; otherwise <see langword="false" />.</returns>
            /// <remarks>If a file download dialog box can be displayed, this event fires prior to the appearance of the dialog box.</remarks>
            public abstract bool DownloadingFile(bool activeDocument, bool cancel);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that an error occured during navigation.
            /// </summary>
            /// <param name="webBrowser">The top-level or frame <see cref="T:WebBrowser"/> corresponding to the navigation.</param>
            /// <param name="url">The URL for which navigation failed.</param>
            /// <param name="frame">The name of the frame in which to display the resource, or <see langword="null" /> if no named frame was targeted for the resource.</param>
            /// <param name="status">The <see cref="T:WebBrowserNavigateErrorStatus">error status code</see>, if available.</param>
            /// <param name="cancel"><see langword="true"/> if the navigation should be canceled; otherwise <see langword="false" />.</param>
            /// <returns><see langword="true"/> to cancel the navigation; otherwise <see langword="false" />.</returns>
            public abstract bool NavigateError(WebBrowser webBrowser, string url, string frame, WebBrowserNavigateErrorStatus status, bool cancel);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a print template is being instantiated.
            /// </summary>
            /// <param name="webBrowser">The top-level or frame <see cref="T:WebBrowser"/> that represents the window or frame.</param>
            public abstract void PrintTemplateInstantiated(WebBrowser webBrowser);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a print template is being destroyed.
            /// </summary>
            /// <param name="webBrowser">The top-level or frame <see cref="T:WebBrowser"/> that represents the window or frame.</param>
            public abstract void PrintTemplateDestroyed(WebBrowser webBrowser);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that an event occurred that impacts privacy, or when a user navigated away from a URL that has impacted privacy.
            /// </summary>
            /// <param name="impacted"><see langword="true"/> if privacy has been impacted; otherwise <see langword="false"/>.</param>
            public abstract void PrivacyImpactedChanged(bool impacted);

            /// <summary>
            /// Notifies the <see cref="P:Parent"/> that a new window is to be created.
            /// </summary>
            /// <param name="webBrowser">The <see cref="T:WebBrowser"/> where the navigation should occur.</param>
            /// <param name="cancel"><see langword="true"/> if the navigation should be canceled; otherwise <see langword="false"/>.</param>
            /// <param name="flags">The <see cref="T:WebBrowserNewWindowFlags">flags</see> that pertain to the new window.</param>
            /// <param name="urlContext">The URL of the page that is opening the new window.</param>
            /// <param name="url">The URL that is opened in the new window.</param>
            /// <returns><see langword="true"/> to cancel the navigation; otherwise <see langword="false"/>.</returns>
            public abstract bool NewWindow(ref WebBrowser webBrowser, bool cancel, WebBrowserNewWindowFlags flags, string urlContext, string url);
        }
    }
}
