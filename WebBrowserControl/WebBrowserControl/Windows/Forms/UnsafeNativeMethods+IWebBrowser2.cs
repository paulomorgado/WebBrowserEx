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
        TypeLibType(TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDual | TypeLibTypeFlags.FHidden),
        Guid("D30C1661-CDAF-11d0-8A3E-00C04FC9E26E")
        ]
        public interface IWebBrowser2
        {
            /// <summary>
            /// Navigates backward one item in the history list.
            /// </summary>
            [DispId(100)]
            void GoBack();

            /// <summary>
            /// Navigates forward one item in the history list.
            /// </summary>
            [DispId(0x65)]
            void GoForward();

            /// <summary>
            /// Navigates to the current home or start page.
            /// </summary>
            [DispId(0x66)]
            void GoHome();

            /// <summary>
            /// Navigates to the current search page.
            /// </summary>
            [DispId(0x67)]
            void GoSearch();

            /// <summary>
            /// Navigates to a resource identified by a URL or to the file identified by a full path.
            /// </summary>
            /// <param name="Url">A BSTR expression that evaluates to the URL, full path, or Universal Naming Convention (UNC) location and name of the resource to display.</param>
            /// <param name="flags">Pointer to a variable that specifies whether to add the resource to the history list, whether to read to or write from the cache, and whether to display the resource in a new window.</param>
            /// <param name="targetFrameName">Pointer to a string that contains the name of the frame in which to display the resource.</param>
            /// <param name="postData">Pointer to data to send with the HTTP POST transaction.</param>
            /// <param name="headers">Pointer to a value that contains the HTTP headers to send to the server.</param>
            [DispId(0x68)]
            void Navigate([In] string Url, [In] ref object flags, [In] ref object targetFrameName, [In] ref object postData, [In] ref object headers);

            /// <summary>
            /// Reloads the file that is currently displayed in the object.
            /// </summary>
            [DispId(-550)]
            void Refresh();

            /// <summary>
            /// Reloads the file that is currently displayed in the object. Unlike IWebBrowser2::Refresh, this method contains a parameter that specifies the refresh level.
            /// </summary>
            /// <param name="level">One of the <see cref="NativeMethods.RefreshConstants"/> enumeration values.</param>
            [DispId(0x69)]
            void Refresh2([In] ref object level);

            /// <summary>
            /// Cancels any pending navigation or download operation and stops any dynamic page elements, such as background sounds and animations.
            /// </summary>
            [DispId(0x6a)]
            void Stop();

            /// <summary>
            /// Retrieves the automation object for an application that is hosting the WebBrowser Control.
            /// </summary>
            /// <value>A variable of type IDispatch interface that receives the automation object..</value>
            [DispId(200)]
            object Application { [return: MarshalAs(UnmanagedType.IDispatch)] get; }

            /// <summary>
            /// Retrieves the parent of the object.
            /// </summary>
            /// <value>A variable of type IDispatch interface that receives the parent.</value>
            [DispId(0xc9)]
            object Parent { [return: MarshalAs(UnmanagedType.IDispatch)] get; }

            /// <summary>
            /// Retrieves an object reference to a container.
            /// </summary>
            /// <value>A variable of type IDispatch interface that receives the reference to the container.</value>
            [DispId(0xca)]
            object Container { [return: MarshalAs(UnmanagedType.IDispatch)] get; }

            /// <summary>
            /// Retrieves the automation object of the active document, if any.
            /// </summary>
            /// <value>The automation object of the active document.</value>
            [DispId(0xcb)]
            object Document { [return: MarshalAs(UnmanagedType.IDispatch)] get; }

            /// <summary>
            /// Retrieves a value that indicates whether the object is a top-level container.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the object is a top-level container; otherwise, <see langword="false"/>.
            /// </value>
            [DispId(0xcc)]
            bool TopLevelContainer { get; }

            /// <summary>
            /// Retrieves the type name of the contained document object—that is, Microsoft Windows HTML Viewer.
            /// </summary>
            /// <value>The type name of the contained document object—that is, Microsoft Windows HTML Viewer.</value>
            [DispId(0xcd)]
            string Type { get; }

            /// <summary>
            /// Sets or retrieves the screen coordinate of the left edge of the main window of the object.
            /// </summary>
            /// <value>The screen coordinate of the left edge of the main window of the object.</value>
            [DispId(0xce)]
            int Left { get; set; }

            /// <summary>
            /// Sets or retrieves the screen coordinate of the top edge of the main window of the object.
            /// </summary>
            /// <value>The screen coordinate of the top edge of the main window of the object.</value>
            [DispId(0xcf)]
            int Top { get; set; }

            /// <summary>
            /// Sets or retrieves the width of the main window for the object.
            /// </summary>
            /// <value>The width of the main window for the object.</value>
            [DispId(0xd0)]
            int Width { get; set; }

            /// <summary>
            /// Sets or retrieves the height of the Microsoft Internet Explorer main window.
            /// </summary>
            /// <value>The height of the Microsoft Internet Explorer main window.</value>
            [DispId(0xd1)]
            int Height { get; set; }

            /// <summary>
            /// Retrieves the name of the resource that Microsoft Internet Explorer is currently displaying.
            /// </summary>
            /// <value>The name of the resource that Microsoft Internet Explorer is currently displaying.</value>
            [DispId(210)]
            string LocationName { get; }

            /// <summary>
            /// Retrieves the URL of the resource that Microsoft Internet Explorer is currently displaying.
            /// </summary>
            /// <value>The location URL.</value>
            [DispId(0xd3)]
            string LocationURL { get; }

            /// <summary>
            /// Retrieves a BOOL value indicating whether the object is engaged in a navigation or downloading operation.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the object is engaged in a navigation or downloading operation; otherwise, <see langword="false"/>.
            /// </value>
            [DispId(0xd4)]
            bool Busy { get; }

            /// <summary>
            /// Closes the object.
            /// </summary>
            /// <remarks>
            /// The WebBrowser object ignores this method.
            /// </remarks>
            [DispId(300)]
            void Quit();

            /// <summary>
            /// Converts the client coordinates of a point to window coordinates.
            /// </summary>
            /// <param name="pcx">Pointer to the x-coordinate of the point to convert, in client coordinates.</param>
            /// <param name="pcy">Pointer to the y-coordinate of the point to convert, in client coordinates.</param>
            [DispId(0x12d)]
            void ClientToWindow(out int pcx, out int pcy);

            /// <summary>
            /// Sets the value of a property associated with the object.
            /// </summary>
            /// <param name="property">The name of the property to set.</param>
            /// <param name="vtValue">the new value of the property.</param>
            [DispId(0x12e)]
            void PutProperty([In] string property, [In] object vtValue);

            /// <summary>
            /// Retrieves the value of a property associated with the given object.
            /// </summary>
            /// <param name="property">The name of the property to retrieve.</param>
            /// <returns>The value associated with the given property.</returns>
            [DispId(0x12f)]
            object GetProperty([In] string property);

            /// <summary>
            /// Retrieves the name of the object that contains the WebBrowser Control used by Microsoft Internet Explorer.
            /// </summary>
            /// <value>The name of the object that contains the WebBrowser Control used by Microsoft Internet Explorer.</value>
            [DispId(0)]
            string Name { get; }

            /// <summary>
            /// Retrieves the handle of the Microsoft Internet Explorer main window.
            /// </summary>
            /// <value>The handle of the Microsoft Internet Explorer main window.</value>
            [DispId(-515)]
            int HWND { get; }

            /// <summary>
            /// Retrieves the fully qualified path of the Microsoft Internet Explorer executable file.
            /// </summary>
            /// <value>The fully qualified path of the Microsoft Internet Explorer executable file.</value>
            [DispId(400)]
            string FullName { get; }

            /// <summary>
            /// Retrieves the full path to the object.
            /// </summary>
            /// <value>The full path to the object.</value>
            [DispId(0x191)]
            string Path { get; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the object is visible or hidden.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the object is visible; otherwise, <see langword="false"/>.
            /// </value>
            [DispId(0x192)]
            bool Visible { get; set; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the status bar for the object is visible.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the status bar for the object is visible; otherwise, <see langword="false"/>.
            /// </value>
            [DispId(0x193)]
            bool StatusBar { get; set; }

            /// <summary>
            /// Sets or retrieves the text in the status bar for the object.
            /// </summary>
            /// <value>The status text.</value>
            [DispId(0x194)]
            string StatusText { get; set; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the toolbar for the object is visible.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the toolbar for the object is visible; otherwise, <see langword="false"/>.
            /// </value>
            [DispId(0x195)]
            bool ToolBar { get; set; }

            /// <summary>
            /// Sets or retrieves a VARIANT_BOOL value that indicates whether the Microsoft Internet Explorer menu bar is visible.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the Microsoft Internet Explorer menu bar is visible; otherwise, <see langword="false"/>.
            /// </value>
            [DispId(0x196)]
            bool MenuBar { get; set; }

            /// <summary>
            /// Sets or retrieves a VARIANT_BOOL value that indicates whether Microsoft Internet Explorer is in full-screen or normal window mode.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if Internet Explorer is in normal window mode; otherwise, <see langword="false"/>.
            /// </value>
            [DispId(0x197)]
            bool FullScreen { get; set; }

            /// <summary>
            /// Navigates the browser to a location that might not be able to be expressed as a URL, such as a pointer to an item identifier list (PIDL) for an entity in the Microsoft Windows shell namespace.
            /// </summary>
            /// <param name="URL">Pointer to a VARIANT that contains either a string of type VT_BSTR that specifies a URL to navigate to, or a PIDL that represents a folder to navigate to.</param>
            /// <param name="flags">Pointer to a variable that specifies whether to add the resource to the history list, whether to read to or write from the cache, and whether to display the resource in a new window.</param>
            /// <param name="targetFrameName">Pointer to a string that contains the name of the frame in which to display the resource.</param>
            /// <param name="postData">Pointer to data to send with the HTTP POST transaction.</param>
            /// <param name="headers">Pointer to a value that contains the HTTP headers to send to the server.</param>
            [DispId(500)]
            void Navigate2([In] ref object URL, [In] ref object flags, [In] ref object targetFrameName, [In] ref object postData, [In] ref object headers);

            /// <summary>
            /// Queries the OLE object for the status of commands using the IOleCommandTarget::QueryStatus method.
            /// </summary>
            /// <param name="cmdID"><see cref="NativeMethods.OLECMDID"/> value of the command for which the caller needs status information.</param>
            /// <returns>Pointer to an <see cref="NativeMethods.OLECMDF"/> value that receives the status of the command.</returns>
            [DispId(0x1f5)]
            NativeMethods.OLECMDF QueryStatusWB([In] NativeMethods.OLECMDID cmdID);

            /// <summary>
            /// Executes a command on an OLE object and returns the status of the command execution using the <see cref="IOleCommandTarget"/> interface.
            /// </summary>
            /// <param name="cmdID"><see cref="NativeMethods.OLECMDID"/> value that specifies the command to execute.</param>
            /// <param name="cmdexecopt"><see cref="NativeMethods.OLECMDEXECOPT"/> value that specifies the command options. </param>
            /// <param name="pvaIn">Structure that contains command input arguments.</param>
            /// <param name="pvaOut">Structure that receives and specifies command output.</param>
            [DispId(0x1f6)]
            void ExecWB([In] NativeMethods.OLECMDID cmdID, [In] NativeMethods.OLECMDEXECOPT cmdexecopt, ref object pvaIn, IntPtr pvaOut);

            /// <summary>
            /// Shows or hides a specified browser bar.
            /// </summary>
            /// <param name="pvaClsid">The class identifier of the browser bar to show or hide.</param>
            /// <param name="pvarShow">Specifies if the browser bar should be shown or hidden.</param>
            /// <param name="pvarSize">Not currently used.</param>
            [DispId(0x1f7)]
            void ShowBrowserBar([In] ref object pvaClsid, [In] ref object pvarShow, [In] ref object pvarSize);

            /// <summary>
            /// Retrieves the ready state of the object.
            /// </summary>
            /// <value>The ready state of the object.</value>
            [DispId(-525)]
            System.Windows.Forms.WebBrowserReadyState ReadyState { get; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the object is currently operating in offline mode.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the object is currently operating in offline mode; otherwise, <see langword="false"/>.
            /// </value>
            [DispId(550)]
            bool Offline { get; set; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the object can show dialog boxes.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if dialog boxes are not shown; otherwise, <see langword="false"/>.
            /// </value>
            [DispId(0x227)]
            bool Silent { get; set; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the object is registered as a top-level browser for target name resolution.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the object is registered as a top-level browser; otherwise, <see langword="false"/>.
            /// </value>
            [DispId(0x228)]
            bool RegisterAsBrowser { get; set; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the object is registered as a drop target for navigation.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the object registered as a drop target; otherwise, <see langword="false"/>.
            /// </value>
            [DispId(0x229)]
            bool RegisterAsDropTarget { get; set; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the object is in theater mode.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the object is in theater mode; otherwise, <see langword="false"/>.
            /// </value>
            [DispId(0x22a)]
            bool TheaterMode { get; set; }

            /// <summary>
            /// Sets or retrieves whether the address bar of the object is visible or hidden.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if address bar of the object is visible; otherwise, <see langword="false"/>.
            /// </value>
            [DispId(0x22b)]
            bool AddressBar { get; set; }

            /// <summary>
            /// Sets or retrieves a value that indicates whether the object can be resized.
            /// </summary>
            /// <value>
            /// 	<see langword="true"/> if the object can be resized; otherwise, <see langword="false"/>.
            /// </value>
            [DispId(0x22c)]
            bool Resizable { get; set; }
        }
    }
}
