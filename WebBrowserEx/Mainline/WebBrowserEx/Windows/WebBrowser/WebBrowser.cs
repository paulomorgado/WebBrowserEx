//-----------------------------------------------------------------------
// <copyright file="WebBrowser.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// ActiveX Web Browser wrapper.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;
    using PauloMorgado.Windows.Interop;

    /// <summary>
    /// Represents a Web Browser instance.
    /// </summary>
    /// <remarks>
    /// Wraps the <see cref="IWebBrowser"/> instance.
    /// </remarks>
    public partial class WebBrowser : IEquatable<WebBrowser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowser"/> class.
        /// </summary>
        /// <param name="activeXWebBrowser">The ActiveX Web Browser.</param>
        internal WebBrowser(UnsafeNativeMethods.IWebBrowser2 activeXWebBrowser)
        {
            this.ActiveXWebBrowser = activeXWebBrowser;
            this.Properties = new WebBrowserPropertyAccessor(this);
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="T:WebBrowser"/> class from being created.
        /// </summary>
        private WebBrowser()
        {
        }

        /// <summary>
        /// Cancels any pending navigation and stops any dynamic page elements, such as background sounds and animations.
        /// </summary>
        public void Stop()
        {
            this.CheckActiveXState();
            this.ActiveXWebBrowser.Stop();
        }

        /// <summary>
        /// Reloads the document currently displayed in the WebBrowser object using the specified refresh options.
        /// </summary>
        /// <param name="option">
        /// One of the <see cref="T:WebBrowserRefreshOption"/> values. 
        /// </param>
        public void Refresh(WebBrowserRefreshOption option)
        {
            this.CheckActiveXState();
            object levelObj = option;
            try
            {
                this.ActiveXWebBrowser.Refresh2(ref levelObj);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Reloads the document currently displayed in the WebBrowser object by checking the server for an updated version. 
        /// </summary>
        public void Refresh()
        {
            this.CheckActiveXState();
            try
            {
                this.ActiveXWebBrowser.Refresh();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Loads the document at the specified Uniform Resource Identifier (URI) <see cref="string"/> into the WebBrowser object, replacing the previous document. 
        /// </summary>
        /// <param name="url">
        /// A Uniform Resource Identifier (URI) <see cref="string"/> specification.
        /// </param>
        public void Navigate(string url)
        {
            this.Navigate(url, WebBrowserNavigateFlags.None, string.Empty, new byte[] { }, string.Empty);
        }

        /// <summary>
        /// Loads the document at the specified Uniform Resource Identifier (URI) <see cref="string"/> into the WebBrowser object, requesting it using the specified HTTP data and replacing the contents of the Web page frame with the specified name.
        /// </summary>
        /// <param name="url">
        /// A Uniform Resource Identifier (URI) <see cref="string"/> specification.
        /// </param>
        /// <param name="flags">
        /// A <see cref="NavigateFlags"/> combination of values.
        /// </param>
        /// <param name="targetFrameName">
        /// <para>
        /// The name of the frame in which to load the document.
        /// </para>
        /// <list type="bullet">
        /// <listheader>Possible values are:</listheader>
        /// <item>_BLANK: Load the link into a new unnamed window.</item>
        /// <item>_PARENT: Load the link into the immediate parent of the document the link is in.</item>
        /// <item>_SELF: Load the link into the same window the link was clicked in.</item>
        /// <item>_TOP: Load the link into the full body of the current window.</item>
        /// <item>&lt;WINDOW_NAME&gt;: A named HTML frame. If no frame or window exists that matches the specified target name, a new window is opened for the specified link.</item>
        /// </list>
        /// </param>
        /// <param name="postData">
        /// Data to send with the HTTP POST transaction. For example, the POST transaction is used to send data gathered by an HTML form. If this parameter does not specify any post data, an HTTP GET transaction is issued. This parameter is ignored if URL is not an HTTPURL. 
        /// </param>
        /// <param name="headers">
        /// The HTTP headers to send to the server. These headers are added to the default Microsoft Internet Explorer headers. The headers can specify things such as the action required of the server, the type of data being passed to the server, or a status code. This parameter is ignored if URL is not an HTTPURL. 
        /// </param>
        public void Navigate(string url, WebBrowserNavigateFlags flags, string targetFrameName, byte[] postData, string headers)
        {
            this.CheckActiveXState();
            object flagsObj = (flags == WebBrowserNavigateFlags.None) ? null : (object)flags;
            object targetFrameNameObj = targetFrameName;
            object headersObj = headers;
            object postDataObj = postData;

            this.ActiveXWebBrowser.Navigate(url, ref flagsObj, ref targetFrameNameObj, ref postDataObj, ref headersObj);
        }

        /// <summary>
        /// Navigates to the current search page.
        /// </summary>
        public void GoSearch()
        {
            this.CheckActiveXState();
            this.ActiveXWebBrowser.GoSearch();
        }

        /// <summary>
        /// Navigates to the current home or start page.
        /// </summary>
        public void GoHome()
        {
            this.CheckActiveXState();
            this.ActiveXWebBrowser.GoHome();
        }

        /// <summary>
        /// Navigates the <see cref="T:WebBrowser"/> forward one item in the history list.
        /// </summary>
        /// <returns>true if the navigation succeeds; false if a subsequent page in the navigation history is not available.</returns>
        public bool GoForward()
        {
            this.CheckActiveXState();
            try
            {
                this.ActiveXWebBrowser.GoForward();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Navigates the <see cref="T:WebBrowser"/> back one item in the history list.
        /// </summary>
        /// <returns>true if the navigation succeeds; false if a previous page in the navigation history is not available.</returns>
        public bool GoBack()
        {
            this.CheckActiveXState();
            try
            {
                this.ActiveXWebBrowser.GoBack();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Prints the document currently displayed in the <see cref="WebBrowser"/> control using the current print and page settings.
        /// </summary>
        public void Print()
        {
            this.ExecuteCommand(WebBrowserCommands.Print, WebBrowserCommandOptions.DontPromptUser);
        }

        /// <summary>
        /// Opens the Internet Explorer Page Setup dialog box.  
        /// </summary>
        public void ShowPageSetupDialog()
        {
            this.ExecuteCommand(WebBrowserCommands.PageSetup, WebBrowserCommandOptions.PromptUser);
        }

        /// <summary>
        /// Opens the Internet Explorer Print dialog without setting header and footer values.
        /// </summary>
        public void ShowPrintDialog()
        {
            this.ExecuteCommand(WebBrowserCommands.Print, WebBrowserCommandOptions.PromptUser);
        }

        /// <summary>
        /// Opens the Internet Explorer Print dialog box, setting the header and footer text to the specified values.
        /// </summary>
        /// <param name="header">
        /// The text used for the page headers.
        /// </param>
        /// <param name="footer">
        /// The text used for the page footers.
        /// </param>
        public void ShowPrintDialog(string header, string footer)
        {
            this.ExecuteCommand(WebBrowserCommands.Print, WebBrowserCommandOptions.PromptUser, new string[] { header, footer });
        }

        /// <summary>
        /// Opens the Internet Explorer Print Preview dialog box.
        /// </summary>
        public void ShowPrintPreviewDialog()
        {
            this.ExecuteCommand(WebBrowserCommands.PrintPreview, WebBrowserCommandOptions.PromptUser);
        }

        /// <summary>
        /// Opens the Internet Explorer Properties dialog box for the current document.
        /// </summary>
        public void ShowPropertiesDialog()
        {
            this.ExecuteCommand(WebBrowserCommands.Properties, WebBrowserCommandOptions.PromptUser);
        }

        /// <summary>
        /// Opens the Internet Explorer Save Web Page dialog box or the save dialog box of the hosted document if it is not an HTML page.
        /// </summary>
        public void ShowSaveAsDialog()
        {
            this.ExecuteCommand(WebBrowserCommands.SaveAs, WebBrowserCommandOptions.DoDefault);
        }

        /// <summary>
        /// Executes a command on the WebRowser object.
        /// </summary>
        /// <param name="command">A <see cref="WebBrowserCommands"/> value that specifies the command to execute.</param>
        /// <param name="options">A <see cref="WebBrowserCommandOptions"/> value that specifies the command options.</param>
        /// <returns>The command output.</returns>
        public object ExecuteCommand(WebBrowserCommands command, WebBrowserCommandOptions options)
        {
            return this.ExecuteCommand(command, options, null);
        }

        /// <summary>
        /// Executes a command on the WebRowser object.
        /// </summary>
        /// <param name="command">A <see cref="WebBrowserCommands"/> value that specifies the command to execute.</param>
        /// <param name="options">A <see cref="WebBrowserCommandOptions"/> value that specifies the command options.</param>
        /// <param name="arguments">The command arguments.</param>
        /// <returns>The command output.</returns>
        public object ExecuteCommand(WebBrowserCommands command, WebBrowserCommandOptions options, object arguments)
        {
            try
            {
                this.CheckActiveXState();

                object result = null;

                this.ActiveXWebBrowser.ExecWB(command, options, ref arguments, ref result);

                return result;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Queries the WebRowser object for the status of commands.
        /// </summary>
        /// <param name="command">
        /// A <see cref="WebBrowserCommands"/> value that specifies the command to query.
        /// </param>
        /// <returns>
        /// A <see cref="WebBrowserCommandStatus"/> value with the status of the command.
        /// </returns>
        public WebBrowserCommandStatus GetCommandStatus(WebBrowserCommands command)
        {
            this.CheckActiveXState();
            return this.ActiveXWebBrowser.QueryStatusWB(command);
        }

        #region IEquatable<WebBrowser> Members

        /// <summary>
        /// Indicates whether the current <see cref="T:WebBrowser"/> is equal to another <see cref="T:WebBrowser"/> of the same type.
        /// </summary>
        /// <param name="other">An <see cref="T:WebBrowser"/> to compare with this <see cref="T:WebBrowser"/>.</param>
        /// <returns>
        /// <see langword="true" /> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(WebBrowser other)
        {
            if (other == null)
            {
                return false;
            }

            return ActiveXWebBrowserEquals(this.ActiveXWebBrowser, other.ActiveXWebBrowser);
        }

        #endregion

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            IntPtr webBrowserObjectPtr = IntPtr.Zero;
            try
            {
                webBrowserObjectPtr = System.Runtime.InteropServices.Marshal.GetComInterfaceForObject(this.ActiveXWebBrowser, typeof(Interop.UnsafeNativeMethods.IWebBrowser2));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.Release(webBrowserObjectPtr);
            }

            return webBrowserObjectPtr.ToInt32();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// <see langword="true"/> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="other"/> parameter is null.
        /// </exception>
        public override bool Equals(object obj)
        {
            WebBrowser other = obj as WebBrowser;

            if (other == null)
            {
                return false;
            }

            return ActiveXWebBrowserEquals(this.ActiveXWebBrowser, other.ActiveXWebBrowser);
        }

        /// <summary>
        /// Creates an instance of the <see cref="T:WebBrowser"/>.
        /// </summary>
        /// <param name="activeXWebBrowser">The ActiveX Web Browser.</param>
        /// <returns>An instance of <see cref="T:WebBrowser"/> or <see langword="null"/> if <paramref name="activeXWebBrowser"/> is <see langword="null"/>.</returns>
        internal static WebBrowser Create(Interop.UnsafeNativeMethods.IWebBrowser2 activeXWebBrowser)
        {
            if (activeXWebBrowser == null)
            {
                return null;
            }

            return new WebBrowser(activeXWebBrowser);
        }

        /// <summary>
        /// Determines whether two <see cref="T:Interop.UnsafeNativeMethods.IWebBrowser2"/> are the same.
        /// </summary>
        /// <param name="activeXWebBrowser1">The first <see cref="T:Interop.UnsafeNativeMethods.IWebBrowser2"/> to compare.</param>
        /// <param name="activeXWebBrowser2">The second <see cref="T:Interop.UnsafeNativeMethods.IWebBrowser2"/> to compare.</param>
        /// <returns>
        /// <see langword="true" /> if the two <see cref="T:Interop.UnsafeNativeMethods.IWebBrowser2"/> are the same; otherwise, <see langword="false" />.
        /// </returns>
        private static bool ActiveXWebBrowserEquals(Interop.UnsafeNativeMethods.IWebBrowser2 activeXWebBrowser1, Interop.UnsafeNativeMethods.IWebBrowser2 activeXWebBrowser2)
        {
            try
            {
                return (GetPtrForActiveXWebBrowser(activeXWebBrowser1) == GetPtrForActiveXWebBrowser(activeXWebBrowser2));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
                return false;
            }
        }

        /// <summary>
        /// Gets the <see cref="T:IntPtr"/> for <see cref="T:Interop.UnsafeNativeMethods.IWebBrowser2"/>.
        /// </summary>
        /// <param name="activeXWebBrowser">The <see cref="T:Interop.UnsafeNativeMethods.IWebBrowser2"/>.</param>
        /// <returns>The <see cref="T:IntPtr"/> for <see cref="T:Interop.UnsafeNativeMethods.IWebBrowser2"/>.</returns>
        private static IntPtr GetPtrForActiveXWebBrowser(Interop.UnsafeNativeMethods.IWebBrowser2 activeXWebBrowser)
        {
            IntPtr activeXWebBrowserPtr = IntPtr.Zero;

            try
            {
                activeXWebBrowserPtr = System.Runtime.InteropServices.Marshal.GetComInterfaceForObject(activeXWebBrowser, typeof(Interop.UnsafeNativeMethods.IWebBrowser2));
            }
            finally
            {
                if (activeXWebBrowserPtr != IntPtr.Zero)
                {
                    System.Runtime.InteropServices.Marshal.Release(activeXWebBrowserPtr);
                }
            }

            return activeXWebBrowserPtr;
        }

        /// <summary>
        /// If it detects error, generate exception with method/property name
        /// (inferred by Reflection).
        /// </summary>
        private void CheckActiveXState()
        {
            if (this.ActiveXWebBrowser == null)
            {
                MethodBase wrongMethod = new System.Diagnostics.StackFrame(1, false).GetMethod();

                if (wrongMethod.Name.StartsWith("get_"))
                {
                    throw new AxHost.InvalidActiveXStateException(
                        wrongMethod.Name.Substring("get_".Length),
                        AxHost.ActiveXInvokeKind.PropertyGet);
                }
                else if (wrongMethod.Name.StartsWith("set_"))
                {
                    throw new AxHost.InvalidActiveXStateException(
                        wrongMethod.Name.Substring("set_".Length),
                        AxHost.ActiveXInvokeKind.PropertySet);
                }
                else
                {
                    throw new AxHost.InvalidActiveXStateException(
                        wrongMethod.Name,
                        AxHost.ActiveXInvokeKind.MethodInvoke);
                }
            }
        }
    }
}
