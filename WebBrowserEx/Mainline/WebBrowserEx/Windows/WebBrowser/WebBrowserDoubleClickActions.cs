//-----------------------------------------------------------------------
// <copyright file="WebBrowserDoubleClickActions.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Defines values used to indicate the proper action on a double-click event.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    /// <summary>
    /// Defines values used to indicate the proper action on a double-click event.
    /// </summary>
    /// <remarks>DOCHOSTUIDBLCLK</remarks>
    public enum WebBrowserDoubleClickActions : int
    {
        /// <summary>
        /// Perform the default action.
        /// </summary>
        /// <remarks>DOCHOSTUIDBLCLK_DEFAULT</remarks>
        Default = 0,

        /// <summary>
        /// Show the item's properties.
        /// </summary>
        /// <remarks>DOCHOSTUIDBLCLK_SHOWPROPERTIES</remarks>
        ShowProperties = 1,

        /// <summary>
        /// Show the page's source.
        /// </summary>
        /// <remarks>DOCHOSTUIDBLCLK_SHOWCODE</remarks>
        ShowCode = 2
    }
}
