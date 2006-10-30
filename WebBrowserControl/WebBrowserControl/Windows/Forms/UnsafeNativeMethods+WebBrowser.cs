using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;

namespace Pajocomo.Windows.Forms
{
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// This interface enables applications to implement an instance of the WebBrowser control (Microsoft ActiveX control) or control an instance of the InternetExplorer application (OLE Automation).
        /// </summary>
        /// <remarks>
        /// Note that not all of the methods listed below are supported by the WebBrowser control.
        /// </remarks>
        [
        ComImport,
        SuppressUnmanagedCodeSecurity,
        TypeLibType(TypeLibTypeFlags.FCanCreate | TypeLibTypeFlags.FControl),
        //ComSourceInterfaces("DWebBrowserEvents2"),
        ClassInterface(ClassInterfaceType.None),
        Guid("8856F961-340A-11D0-A96B-00C04FD705A2")
        ]
        public abstract class WebBrowser : IWebBrowser2
        {
            /// <summary>
            /// Navigates backward one item in the history list.
            /// </summary>
            public abstract void GoBack();

            /// <summary>
            /// Navigates forward one item in the history list.
            /// </summary>
            public abstract void GoForward();

            /// <summary>
            /// Navigates to the current home or start page.
            /// </summary>
            public abstract void GoHome();

            /// <summary>
            /// Navigates to the current search page.
            /// </summary>
            public abstract void GoSearch();

            /// <summary>
            /// Navigates to a resource identified by a URL or to the file identified by a full path.
            /// </summary>
            /// <param name="Url">A BSTR expression that evaluates to the URL, full path, or Universal Naming Convention (UNC) location and name of the resource to display.</param>
            /// <param name="flags">Pointer to a variable that specifies whether to add the resource to the history list, whether to read to or write from the cache, and whether to display the resource in a new window.</param>
            /// <param name="targetFrameName">Pointer to a string that contains the name of the frame in which to display the resource.</param>
            /// <param name="postData">Pointer to data to send with the HTTP POST transaction.</param>
            /// <param name="headers">Pointer to a value that contains the HTTP headers to send to the server.</param>
            public abstract void Navigate(string Url, ref object flags, ref object targetFrameName, ref object postData, ref object headers);

            /// <summary>
            /// Reloads the file that is currently displayed in the object.
            /// </summary>
            public abstract void Refresh();

            /// <summary>
            /// Reloads the file that is currently displayed in the object. Unlike IWebBrowser2::Refresh, this method contains a parameter that specifies the refresh level.
            /// </summary>
            /// <param name="level">One of the <see cref="NativeMethods.RefreshConstants"/> enumeration values.</param>
            public abstract void Refresh2(ref object level);

            /// <summary>
            /// Cancels any pending navigation or download operation and stops any dynamic page elements, such as background sounds and animations.
            /// </summary>
            public abstract void Stop();

            /// <summary>
            /// Retrieves the automation object for an application that is hosting the WebBrowser Control.
            /// </summary>
            /// <value>A variable of type IDispatch interface that receives the automation object..</value>
            public abstract object Application { get; }

            /// <summary>
            /// Retrieves the parent of the object.
            /// </summary>
            /// <value>A variable of type IDispatch interface that receives the parent.</value>
            public abstract object Parent { get; }

            /// <summary>
            /// Retrieves an object reference to a container.
            /// </summary>
            /// <value>A variable of type IDispatch interface that receives the reference to the container.</value>
            public abstract object Container { get; }

            /// <summary>
            /// Retrieves the automation object of the active document, if any.
            /// </summary>
            /// <value>The automation object of the active document.</value>
            public abstract object Document { get; }

            /// <summary>
            /// Retrieves a value that indicates whether the object is a top-level container.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the object is a top-level container; otherwise, <see langword="false"/>.
            /// </value>
            public abstract bool TopLevelContainer { get; }

            /// <summary>
            /// Retrieves the type name of the contained document object—that is, Microsoft Windows HTML Viewer.
            /// </summary>
            /// <value>The type name of the contained document object—that is, Microsoft Windows HTML Viewer.</value>
            public abstract string Type { get; }

            /// <summary>
            /// Sets or retrieves the screen coordinate of the left edge of the main window of the object.
            /// </summary>
            /// <value>The screen coordinate of the left edge of the main window of the object.</value>
            public abstract int Left { get; set; }

            /// <summary>
            /// Sets or retrieves the screen coordinate of the top edge of the main window of the object.
            /// </summary>
            /// <value>The screen coordinate of the top edge of the main window of the object.</value>
            public abstract int Top { get; set; }

            /// <summary>
            /// Sets or retrieves the width of the main window for the object.
            /// </summary>
            /// <value>The width of the main window for the object.</value>
            public abstract int Width { get; set; }

            /// <summary>
            /// Sets or retrieves the height of the Microsoft Internet Explorer main window.
            /// </summary>
            /// <value>The height of the Microsoft Internet Explorer main window.</value>
            public abstract int Height { get; set; }

            /// <summary>
            /// Retrieves the name of the resource that Microsoft Internet Explorer is currently displaying.
            /// </summary>
            /// <value>The name of the resource that Microsoft Internet Explorer is currently displaying.</value>
            public abstract string LocationName { get; }

            /// <summary>
            /// Retrieves the URL of the resource that Microsoft Internet Explorer is currently displaying.
            /// </summary>
            /// <value>The location URL.</value>
            public abstract string LocationURL { get; }

            /// <summary>
            /// Retrieves a BOOL value indicating whether the object is engaged in a navigation or downloading operation.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the object is engaged in a navigation or downloading operation; otherwise, <see langword="false"/>.
            /// </value>
            public abstract bool Busy { get; }

            /// <summary>
            /// Closes the object.
            /// </summary>
            /// <remarks>
            /// The WebBrowser object ignores this method.
            /// </remarks>
            public abstract void Quit();

            /// <summary>
            /// Converts the client coordinates of a point to window coordinates.
            /// </summary>
            /// <param name="pcx">Pointer to the x-coordinate of the point to convert, in client coordinates.</param>
            /// <param name="pcy">Pointer to the y-coordinate of the point to convert, in client coordinates.</param>
            public abstract void ClientToWindow(out int pcx, out int pcy);

            /// <summary>
            /// Sets the value of a property associated with the object.
            /// </summary>
            /// <param name="property">The name of the property to set.</param>
            /// <param name="vtValue">the new value of the property.</param>
            public abstract void PutProperty(string property, object vtValue);

            /// <summary>
            /// Retrieves the value of a property associated with the given object.
            /// </summary>
            /// <param name="property">The name of the property to retrieve.</param>
            /// <returns>The value associated with the given property.</returns>
            public abstract object GetProperty(string property);

            /// <summary>
            /// Retrieves the name of the object that contains the WebBrowser Control used by Microsoft Internet Explorer.
            /// </summary>
            /// <value>The name of the object that contains the WebBrowser Control used by Microsoft Internet Explorer.</value>
            public abstract string Name { get; }

            /// <summary>
            /// Retrieves the handle of the Microsoft Internet Explorer main window.
            /// </summary>
            /// <value>The handle of the Microsoft Internet Explorer main window.</value>
            public abstract int HWND { get; }

            /// <summary>
            /// Retrieves the fully qualified path of the Microsoft Internet Explorer executable file.
            /// </summary>
            /// <value>The fully qualified path of the Microsoft Internet Explorer executable file.</value>
            public abstract string FullName { get; }

            /// <summary>
            /// Retrieves the full path to the object.
            /// </summary>
            /// <value>The full path to the object.</value>
            public abstract string Path { get; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the object is visible or hidden.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the object is visible; otherwise, <see langword="false"/>.
            /// </value>
            public abstract bool Visible { get; set; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the status bar for the object is visible.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the status bar for the object is visible; otherwise, <see langword="false"/>.
            /// </value>
            public abstract bool StatusBar { get; set; }

            /// <summary>
            /// Sets or retrieves the text in the status bar for the object.
            /// </summary>
            /// <value>The status text.</value>
            public abstract string StatusText { get; set; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the toolbar for the object is visible.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the toolbar for the object is visible; otherwise, <see langword="false"/>.
            /// </value>
            public abstract bool ToolBar { get; set; }

            /// <summary>
            /// Sets or retrieves a VARIANT_BOOL value that indicates whether the Microsoft Internet Explorer menu bar is visible.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the Microsoft Internet Explorer menu bar is visible; otherwise, <see langword="false"/>.
            /// </value>
            public abstract bool MenuBar { get; set; }

            /// <summary>
            /// Sets or retrieves a VARIANT_BOOL value that indicates whether Microsoft Internet Explorer is in full-screen or normal window mode.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if Internet Explorer is in normal window mode; otherwise, <see langword="false"/>.
            /// </value>
            public abstract bool FullScreen { get; set; }

            /// <summary>
            /// Navigates the browser to a location that might not be able to be expressed as a URL, such as a pointer to an item identifier list (PIDL) for an entity in the Microsoft Windows shell namespace.
            /// </summary>
            /// <param name="URL">Pointer to a VARIANT that contains either a string of type VT_BSTR that specifies a URL to navigate to, or a PIDL that represents a folder to navigate to.</param>
            /// <param name="flags">Pointer to a variable that specifies whether to add the resource to the history list, whether to read to or write from the cache, and whether to display the resource in a new window.</param>
            /// <param name="targetFrameName">Pointer to a string that contains the name of the frame in which to display the resource.</param>
            /// <param name="postData">Pointer to data to send with the HTTP POST transaction.</param>
            /// <param name="headers">Pointer to a value that contains the HTTP headers to send to the server.</param>
            public abstract void Navigate2(ref object URL, ref object flags, ref object targetFrameName, ref object postData, ref object headers);

            /// <summary>
            /// Queries the OLE object for the status of commands using the IOleCommandTarget::QueryStatus method.
            /// </summary>
            /// <param name="cmdID"><see cref="NativeMethods.OLECMDID"/> value of the command for which the caller needs status information.</param>
            /// <returns>Pointer to an <see cref="NativeMethods.OLECMDF"/> value that receives the status of the command.</returns>
            public abstract NativeMethods.OLECMDF QueryStatusWB(NativeMethods.OLECMDID cmdID);

            /// <summary>
            /// Executes a command on an OLE object and returns the status of the command execution using the <see cref="IOleCommandTarget"/> interface.
            /// </summary>
            /// <param name="cmdID"><see cref="NativeMethods.OLECMDID"/> value that specifies the command to execute.</param>
            /// <param name="cmdexecopt"><see cref="NativeMethods.OLECMDEXECOPT"/> value that specifies the command options. </param>
            /// <param name="pvaIn">Structure that contains command input arguments.</param>
            /// <param name="pvaOut">Structure that receives and specifies command output.</param>
            public abstract void ExecWB(NativeMethods.OLECMDID cmdID, NativeMethods.OLECMDEXECOPT cmdexecopt, ref object pvaIn, IntPtr pvaOut);

            /// <summary>
            /// Shows or hides a specified browser bar.
            /// </summary>
            /// <param name="pvaClsid">The class identifier of the browser bar to show or hide.</param>
            /// <param name="pvarShow">Specifies if the browser bar should be shown or hidden.</param>
            /// <param name="pvarSize">Not currently used.</param>
            public abstract void ShowBrowserBar(ref object pvaClsid, ref object pvarShow, ref object pvarSize);

            /// <summary>
            /// Retrieves the ready state of the object.
            /// </summary>
            /// <value>The ready state of the object.</value>
            public abstract System.Windows.Forms.WebBrowserReadyState ReadyState { get; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the object is currently operating in offline mode.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the object is currently operating in offline mode; otherwise, <see langword="false"/>.
            /// </value>
            public abstract bool Offline { get; set; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the object can show dialog boxes.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if dialog boxes are not shown; otherwise, <see langword="false"/>.
            /// </value>
            public abstract bool Silent { get; set; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the object is registered as a top-level browser for target name resolution.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the object is registered as a top-level browser; otherwise, <see langword="false"/>.
            /// </value>
            public abstract bool RegisterAsBrowser { get; set; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the object is registered as a drop target for navigation.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the object registered as a drop target; otherwise, <see langword="false"/>.
            /// </value>
            public abstract bool RegisterAsDropTarget { get; set; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the object is in theater mode.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the object is in theater mode; otherwise, <see langword="false"/>.
            /// </value>
            public abstract bool TheaterMode { get; set; }

            /// <summary>
            /// Sets or retrieves whether the address bar of the object is visible or hidden.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if address bar of the object is visible; otherwise, <see langword="false"/>.
            /// </value>
            public abstract bool AddressBar { get; set; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the object can be resized.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the object can be resized; otherwise, <see langword="false"/>.
            /// </value>
            public abstract bool Resizable { get; set; }
        }
    }
}
