//-----------------------------------------------------------------------
// <copyright file="WebBrowserEvents+DWebBrowserEvents2.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>Handles IWebBrowser2 by implementing DWebBrowserEvents2.</summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using PauloMorgado.Windows.Interop;

    /// <summary>
    /// Handles <see cref="T:Interop.UnsafeNativeMethods.IWebBrowser2"/> by implementing <see cref="T:Interop.UnsafeNativeMethods.DWebBrowserEvents2"/>.
    /// </summary>
    [ClassInterface(ClassInterfaceType.None)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1611:ElementParametersMustBeDocumented", Justification = "Interop Code")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1632:DocumentationTextMustMeetMinimumCharacterLength", Justification = "Interop Code")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Interop Code")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1306:FieldNamesMustBeginWithLowerCaseLetter", Justification = "Interop Code")]
    public partial class WebBrowserEvents : UnsafeNativeMethods.DWebBrowserEvents2
    {
        /// <summary>
        /// <para><c>StatusTextChange</c> method of <c>DWebBrowserEvents2</c> interface.</para>
        /// <para>Statusbar text changed.</para>
        /// </summary>
        /// <remarks>
        /// <para>An original IDL definition of <c>StatusTextChange</c> method was the following:  <c>HRESULT StatusTextChange (BSTR Text)</c>;</para>
        /// </remarks>
        [DispId(102)]
        public void StatusTextChange(string text)
        {
            this.Parent.StatusTextChanged(text);
        }

        /// <summary>
        /// <para><c>ProgressChange</c> method of <c>DWebBrowserEvents2</c> interface.</para>
        /// <para>Fired when download progress is updated.</para>
        /// </summary>
        /// <remarks>
        /// <para>An original IDL definition of <c>ProgressChange</c> method was the following:  <c>HRESULT ProgressChange (long Progress, long ProgressMax)</c>;</para>
        /// </remarks>
        [DispId(108)]
        public void ProgressChange(int progress, int progressMax)
        {
            this.Parent.ProgressChanged(progress, progressMax);
        }

        /// <summary>
        /// <para><c>CommandStateChange</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>The enabled state of a command changed.</para>
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="enable">The command state.</param>
        /// <remarks>
        /// An original IDL definition of <c>CommandStateChange</c> method was the following:  <c>HRESULT CommandStateChange (long Command, VARIANT_BOOL Enable)</c>;
        /// </remarks>
        [DispId(105)]
        public void CommandStateChange(long command, bool enable)
        {
            switch ((WebBrowserCommandStates)command)
            {
                case WebBrowserCommandStates.UpdateCommands:
                    this.Parent.UpdateCommands();
                    break;
                case WebBrowserCommandStates.NavigateBack:
                    this.Parent.SetCanGoBack(enable);
                    break;
                case WebBrowserCommandStates.NavigateForward:
                    this.Parent.SetCanGoForward(enable);
                    break;
            }
        }

        /// <summary>
        /// <para><c>DownloadBegin</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Download of a page started.</para>
        /// </summary>
        /// <remarks>
        /// An original IDL definition of <c>DownloadBegin</c> method was the following:  <c>HRESULT DownloadBegin (void)</c>;
        /// </remarks>
        [DispId(106)]
        public void DownloadBegin()
        {
            this.Parent.Downloading();
        }

        /// <summary>
        /// <para><c>DownloadComplete</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Download of page complete.</para>
        /// </summary>
        /// <remarks>
        /// An original IDL definition of <c>DownloadComplete</c> method was the following:  <c>HRESULT DownloadComplete (void)</c>;
        /// </remarks>
        [DispId(104)]
        public void DownloadComplete()
        {
            this.Parent.Downloaded();
        }

        /// <summary>
        /// <para><c>TitleChange</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Document title changed.</para>
        /// </summary>
        /// <param name="text">The text.</param>
        /// <remarks>
        /// An original IDL definition of <c>TitleChange</c> method was the following:  <c>HRESULT TitleChange (BSTR Text)</c>;
        /// </remarks>
        [DispId(113)]
        public void TitleChange(string text)
        {
            this.Parent.TitleChanged(text);
        }

        /// <summary><para><c>PropertyChange</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when the PutProperty method has been called.</para></summary>
        /// <remarks><para>An original IDL definition of <c>PropertyChange</c> method was the following:  <c>HRESULT PropertyChange (BSTR szProperty)</c>;</para></remarks>
        [DispId(112)]
        public void PropertyChange(string szProperty)
        {
            this.Parent.PropertyChanged(szProperty);
        }

        /// <summary>
        /// <para><c>BeforeNavigate2</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired before navigate occurs in the given WebBrowser (window or frameset element). The processing of this navigation may be modified.</para>
        /// </summary>
        /// <param name="pDisp">The p disp.</param>
        /// <param name="URL">The URL.</param>
        /// <param name="flags">The flags.</param>
        /// <param name="targetFrameName">Name of the target frame.</param>
        /// <param name="postData">The post data.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="cancel">if set to <see langword="true"/> [cancel].</param>
        /// <remarks>
        /// An original IDL definition of <c>BeforeNavigate2</c> method was the following:  <c>HRESULT BeforeNavigate2 (IDispatch* pDisp, [in] VARIANT* URL, [in] VARIANT* Flags, [in] VARIANT* TargetFrameName, [in] VARIANT* PostData, [in] VARIANT* Headers, [in, out] VARIANT_BOOL* Cancel)</c>;
        /// </remarks>
        [DispId(250)]
        public void BeforeNavigate2(object pDisp, ref object URL, ref object flags, ref object targetFrameName, ref object postData, ref object headers, ref bool cancel)
        {
            WebBrowser webBrowser = WebBrowser.Create(pDisp as Interop.UnsafeNativeMethods.IWebBrowser2);

            cancel = this.Parent.Navigating(webBrowser, URL as string, targetFrameName as string, postData as byte[], headers as string);
        }

        /// <summary><para><c>NavigateComplete2</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when the document being navigated to becomes visible and enters the navigation stack.</para></summary>
        /// <remarks><para>An original IDL definition of <c>NavigateComplete2</c> method was the following:  <c>HRESULT NavigateComplete2 (IDispatch* pDisp, [in] VARIANT* URL)</c>;</para></remarks>
        [DispId(252)]
        public void NavigateComplete2(object pDisp, ref object url)
        {
            WebBrowser webBrowser = WebBrowser.Create(pDisp as Interop.UnsafeNativeMethods.IWebBrowser2);

            this.Parent.Navigated(webBrowser, url as string);
        }

        /// <summary><para><c>DocumentComplete</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when the document being navigated to reaches ReadyState_Complete.</para></summary>
        /// <remarks><para>An original IDL definition of <c>DocumentComplete</c> method was the following:  <c>HRESULT DocumentComplete (IDispatch* pDisp, [in] VARIANT* URL)</c>;</para></remarks>
        [DispId(259)]
        public void DocumentComplete(object pDisp, ref object url)
        {
            WebBrowser webBrowser = WebBrowser.Create(pDisp as Interop.UnsafeNativeMethods.IWebBrowser2);

            this.Parent.DocumentCompleted(webBrowser, url as string);
        }

        /// <summary>
        /// <para><c>OnQuit</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when application is quiting.</para>
        /// </summary>
        /// <remarks>
        /// An original IDL definition of <c>OnQuit</c> method was the following:  <c>HRESULT OnQuit (void)</c>;
        /// </remarks>
        [DispId(253)]
        public void OnQuit()
        {
            this.Parent.Quit();
        }

        /// <summary>
        /// <para><c>OnVisible</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when the window should be shown/hidden</para>
        /// </summary>
        /// <param name="visible">if set to <see langword="true"/> [visible].</param>
        /// <remarks>
        /// An original IDL definition of <c>OnVisible</c> method was the following:  <c>HRESULT OnVisible (VARIANT_BOOL Visible)</c>;
        /// </remarks>
        [DispId(254)]
        public void OnVisible(bool visible)
        {
            this.Parent.SetVisiblility(visible);
        }

        /// <summary>
        /// <para><c>OnToolBar</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when the toolbar should be shown/hidden</para>
        /// </summary>
        /// <param name="toolBar">if set to <see langword="true"/> [tool bar].</param>
        /// <remarks>
        /// An original IDL definition of <c>OnToolBar</c> method was the following:  <c>HRESULT OnToolBar (VARIANT_BOOL ShowToolBar)</c>;
        /// </remarks>
        [DispId(255)]
        public void OnToolBar(bool toolBar)
        {
            this.Parent.SetToolBarVisiblility(toolBar);
        }

        /// <summary>
        /// <para><c>OnMenuBar</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when the menubar should be shown/hidden</para>
        /// </summary>
        /// <param name="menuBar">if set to <see langword="true"/> [menu bar].</param>
        /// <remarks>
        /// An original IDL definition of <c>OnMenuBar</c> method was the following:  <c>HRESULT OnMenuBar (VARIANT_BOOL MenuBar)</c>;
        /// </remarks>
        [DispId(256)]
        public void OnMenuBar(bool menuBar)
        {
            this.Parent.SetMenuBarVisiblility(menuBar);
        }

        /// <summary>
        /// <para><c>OnStatusBar</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when the statusbar should be shown/hidden</para>
        /// </summary>
        /// <param name="statusBar">if set to <see langword="true"/> [status bar].</param>
        /// <remarks>
        /// An original IDL definition of <c>OnStatusBar</c> method was the following:  <c>HRESULT OnStatusBar (VARIANT_BOOL StatusBar)</c>;
        /// </remarks>
        [DispId(257)]
        public void OnStatusBar(bool statusBar)
        {
            this.Parent.SetStatusBarVisiblility(statusBar);
        }

        /// <summary>
        /// <para><c>OnFullScreen</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when fullscreen mode should be on/off</para>
        /// </summary>
        /// <param name="fullScreen">if set to <see langword="true"/> [full screen].</param>
        /// <remarks>
        /// An original IDL definition of <c>OnFullScreen</c> method was the following:  <c>HRESULT OnFullScreen (VARIANT_BOOL FullScreen)</c>;
        /// </remarks>
        [DispId(258)]
        public void OnFullScreen(bool fullScreen)
        {
            this.Parent.SetFullScreen(fullScreen);
        }

        /// <summary>
        /// <para><c>OnTheaterMode</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when theater mode should be on/off</para>
        /// </summary>
        /// <param name="theaterMode">if set to <see langword="true"/> [theater mode].</param>
        /// <remarks>
        /// An original IDL definition of <c>OnTheaterMode</c> method was the following:  <c>HRESULT OnTheaterMode (VARIANT_BOOL TheaterMode)</c>;
        /// </remarks>
        [DispId(260)]
        public void OnTheaterMode(bool theaterMode)
        {
            this.Parent.SetTheaterMode(theaterMode);
        }

        /// <summary>
        /// <para><c>WindowSetResizable</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when the host window should allow/disallow resizing</para>
        /// </summary>
        /// <param name="resizable">if set to <see langword="true"/> [resizable].</param>
        /// <remarks>
        /// An original IDL definition of <c>WindowSetResizable</c> method was the following:  <c>HRESULT WindowSetResizable (VARIANT_BOOL Resizable)</c>;
        /// </remarks>
        [DispId(262)]
        public void WindowSetResizable(bool resizable)
        {
            this.Parent.SetResizable(resizable);
        }

        /// <summary>
        /// <para><c>WindowSetLeft</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when the host window should change its Left coordinate</para>
        /// </summary>
        /// <param name="left">The left.</param>
        /// <remarks>
        /// An original IDL definition of <c>WindowSetLeft</c> method was the following:  <c>HRESULT WindowSetLeft (long Left)</c>;
        /// </remarks>
        [DispId(264)]
        public void WindowSetLeft(int left)
        {
            this.Parent.SetWindowLeft(left);
        }

        /// <summary>
        /// <para><c>WindowSetTop</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when the host window should change its Top coordinate</para>
        /// </summary>
        /// <param name="top">The top.</param>
        /// <remarks>
        /// An original IDL definition of <c>WindowSetTop</c> method was the following:  <c>HRESULT WindowSetTop (long Top)</c>;
        /// </remarks>
        [DispId(265)]
        public void WindowSetTop(int top)
        {
            this.Parent.SetWindowTop(top);
        }

        /// <summary>
        /// <para><c>WindowSetWidth</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when the host window should change its width</para>
        /// </summary>
        /// <param name="width">The width.</param>
        /// <remarks>
        /// An original IDL definition of <c>WindowSetWidth</c> method was the following:  <c>HRESULT WindowSetWidth (long Width)</c>;
        /// </remarks>
        [DispId(266)]
        public void WindowSetWidth(int width)
        {
            this.Parent.SetWindowWidth(width);
        }

        /// <summary>
        /// <para><c>WindowSetHeight</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when the host window should change its height</para>
        /// </summary>
        /// <param name="height">The height.</param>
        /// <remarks>
        /// An original IDL definition of <c>WindowSetHeight</c> method was the following:  <c>HRESULT WindowSetHeight (long Height)</c>;
        /// </remarks>
        [DispId(267)]
        public void WindowSetHeight(int height)
        {
            this.Parent.SetWindowHeight(height);
        }

        /// <summary>
        /// <para><c>WindowClosing</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when the WebBrowser is about to be closed by script</para>
        /// </summary>
        /// <param name="isChildWindow">if set to <see langword="true"/> [is child window].</param>
        /// <param name="cancel">if set to <see langword="true"/> [cancel].</param>
        /// <remarks>
        /// An original IDL definition of <c>WindowClosing</c> method was the following:  <c>HRESULT WindowClosing (VARIANT_BOOL IsChildWindow, [in, out] VARIANT_BOOL* Cancel)</c>;
        /// </remarks>
        [DispId(263)]
        public void WindowClosing(bool isChildWindow, ref bool cancel)
        {
            cancel = this.Parent.WindowClosing(isChildWindow, cancel);
        }

        /// <summary>
        /// <para><c>ClientToHostWindow</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired to request client sizes be converted to host window sizes</para>
        /// </summary>
        /// <param name="cx">The cx.</param>
        /// <param name="cy">The cy.</param>
        /// <remarks>
        /// An original IDL definition of <c>ClientToHostWindow</c> method was the following:  <c>HRESULT ClientToHostWindow ([in, out] long* CX, [in, out] long* CY)</c>;
        /// </remarks>
        [DispId(268)]
        public void ClientToHostWindow(ref int cx, ref int cy)
        {
            System.Drawing.Size windowSize = this.Parent.ClientToHostWindow(new System.Drawing.Size(cx, cy));
            cx = windowSize.Width;
            cy = windowSize.Height;
        }

        /// <summary>
        /// <para><c>SetSecureLockIcon</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired to indicate the security level of the current web page contents</para>
        /// </summary>
        /// <param name="secureLockIcon">The secure lock icon.</param>
        /// <remarks>
        /// An original IDL definition of <c>SetSecureLockIcon</c> method was the following:  <c>HRESULT SetSecureLockIcon (long SecureLockIcon)</c>;
        /// </remarks>
        [DispId(269)]
        public void SetSecureLockIcon(int secureLockIcon)
        {
            this.Parent.SetEncryptionLevel((WebBrowserEncryptionLevel)secureLockIcon);
        }

        /// <summary>
        /// <para><c>FileDownload</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired to indicate the File Download dialog is opening</para>
        /// </summary>
        /// <param name="load">If set to <see langword="true"/> indicates that an Active Document server is loading in memory.</param>
        /// <param name="cancel">If set to <see langword="true"/> cancels the file download.</param>
        /// <remarks>
        /// An original IDL definition of <c>FileDownload</c> method was the following:  <c>HRESULT FileDownload ([in, out] VARIANT_BOOL* Cancel)</c>;
        /// </remarks>
        [DispId(270)]
        public void FileDownload(bool load, ref bool cancel)
        {
            cancel = this.Parent.DownloadingFile(load, cancel);
        }

        /// <summary>
        /// <para><c>NavigateError</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when a binding error occurs (window or frameset element).</para>
        /// </summary>
        /// <param name="pDisp">The p disp.</param>
        /// <param name="uRL">The u RL.</param>
        /// <param name="frame">The frame.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="cancel">if set to <see langword="true"/> [cancel].</param>
        /// <remarks>
        /// An original IDL definition of <c>NavigateError</c> method was the following:  <c>HRESULT NavigateError (IDispatch* pDisp, [in] VARIANT* URL, [in] VARIANT* Frame, [in] VARIANT* StatusCode, [in, out] VARIANT_BOOL* Cancel)</c>;
        /// </remarks>
        [DispId(271)]
        public void NavigateError(object pDisp, ref object uRL, ref object frame, ref object statusCode, ref bool cancel)
        {
            WebBrowser webBrowser = WebBrowser.Create(pDisp as Interop.UnsafeNativeMethods.IWebBrowser2);

            cancel = this.Parent.NavigateError(webBrowser, uRL as string, frame as string, (WebBrowserNavigateErrorStatus)statusCode, cancel);
        }

        /// <summary>
        /// <para><c>PrintTemplateInstantiated</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when a print template is instantiated.</para>
        /// </summary>
        /// <param name="pDisp">The p disp.</param>
        /// <remarks>
        /// An original IDL definition of <c>PrintTemplateInstantiation</c> method was the following:  <c>HRESULT PrintTemplateInstantiated (IDispatch* pDisp)</c>;
        /// </remarks>
        [DispId(225)]
        public void PrintTemplateInstantiation(object pDisp)
        {
            WebBrowser webBrowser = WebBrowser.Create(pDisp as Interop.UnsafeNativeMethods.IWebBrowser2);

            this.Parent.PrintTemplateInstantiated(webBrowser);
        }

        /// <summary>
        /// <para><c>PrintTemplateTeardown</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when a print template destroyed.</para>
        /// </summary>
        /// <param name="pDisp">The p disp.</param>
        /// <remarks>
        /// An original IDL definition of <c>PrintTemplateTeardown</c> method was the following:  <c>HRESULT PrintTemplateTeardown (IDispatch* pDisp)</c>;
        /// </remarks>
        [DispId(226)]
        public void PrintTemplateTeardown(object pDisp)
        {
            WebBrowser webBrowser = WebBrowser.Create(pDisp as Interop.UnsafeNativeMethods.IWebBrowser2);

            this.Parent.PrintTemplateDestroyed(webBrowser);
        }

        /// <summary>
        /// <para><c>UpdatePageStatus</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when a page is spooled. When it is fired can be changed by a custom template.</para>
        /// </summary>
        /// <param name="pDisp">The p disp.</param>
        /// <param name="nPage">The n page.</param>
        /// <param name="fDone">The f done.</param>
        /// <remarks>
        /// <para>An original IDL definition of <c>UpdatePageStatus</c> method was the following:  <c>HRESULT UpdatePageStatus (IDispatch* pDisp, [in] VARIANT* nPage, [in] VARIANT* fDone)</c>;</para>
        /// <para>Not implemented.</para>
        /// </remarks>
        [DispId(227)]
        public void UpdatePageStatus(object pDisp, ref object nPage, ref object fDone)
        {
        }

        /// <summary>
        /// <para><c>PrivacyImpactedStateChange</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>Fired when the global privacy impacted state changes</para>
        /// </summary>
        /// <param name="bImpacted">if set to <see langword="true"/> [b impacted].</param>
        /// <remarks>
        /// An original IDL definition of <c>PrivacyImpactedStateChange</c> method was the following:  <c>HRESULT PrivacyImpactedStateChange (VARIANT_BOOL bImpacted)</c>;
        /// </remarks>
        [DispId(272)]
        public void PrivacyImpactedStateChange(bool bImpacted)
        {
            this.Parent.PrivacyImpactedChanged(bImpacted);
        }

        /// <summary>
        /// <para><c>NewWindow3</c> method of <c>DWebBrowserEvents2</c> interface.</para><para>A new, hidden, non-navigated WebBrowser window is needed.</para>
        /// </summary>
        /// <remarks>
        /// An original IDL definition of <c>NewWindow3</c> method was the following:  <c>HRESULT NewWindow3 ([in, out] IDispatch** ppDisp, [in, out] VARIANT_BOOL* Cancel, unsigned long dwFlags, BSTR bstrUrlContext, BSTR bstrUrl)</c>;
        /// </remarks>
        [DispId(273)]
        public void NewWindow3(ref object ppDisp, ref bool cancel, uint flags, string urlContext, string url)
        {
            WebBrowser webBrowser = WebBrowser.Create(ppDisp as Interop.UnsafeNativeMethods.IWebBrowser2);

            cancel = this.Parent.NewWindow(ref webBrowser, cancel, (WebBrowserNewWindowFlags)flags, urlContext, url);
            ppDisp = (webBrowser == null) ? null : webBrowser.ActiveXWebBrowser;
        }
    }
}
