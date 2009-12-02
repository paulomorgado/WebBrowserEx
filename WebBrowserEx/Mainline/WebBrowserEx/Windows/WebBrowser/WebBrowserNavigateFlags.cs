//-----------------------------------------------------------------------
// <copyright file="WebBrowserNavigateFlags.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Contains values used by the Navigate method.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    /// <summary>
    /// Contains values used by the <see cref="M:WebBrowser.Navigate(string,WebBrowserNavigateFlags,string,byte[],string)"/> method.
    /// </summary>
    [System.Flags]
    public enum WebBrowserNavigateFlags : int
    {
        /// <summary>
        /// No option set.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Open the resource or file in a new window.
        /// </summary>
        OpenInNewWindow = 0x1,

        /// <summary>
        /// Do not add the resource or file to the history list. The new page replaces the current page in the list.
        /// </summary>
        NoHistory = 0x2,

        /// <summary>
        /// Not currently supported.
        /// </summary>
        NoReadFromCache = 0x4,

        /// <summary>
        /// Not currently supported.
        /// </summary>
        NoWriteToCache = 0x8,

        /// <summary>
        /// If the navigation fails, the autosearch functionality attempts to navigate common root domains (.com, .edu, and so on). If this also fails, the URL is passed to a search engine.
        /// </summary>
        AllowAutosearch = 0x10,

        /// <summary>
        /// Causes the current Explorer Bar to navigate to the given item, if possible.
        /// </summary>
        BrowserBar = 0x20,

        /// <summary>
        /// If the navigation fails when a hyperlink is being followed, this constant specifies that the resource should then be bound to the moniker using the BINDF_HYPERLINK flag.
        /// </summary>
        Hyperlink = 0x40
    }
}
