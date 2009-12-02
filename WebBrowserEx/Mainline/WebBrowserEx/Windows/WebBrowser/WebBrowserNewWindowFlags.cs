//-----------------------------------------------------------------------
// <copyright file="WebBrowserNewWindowFlags.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Represents the new window manager flags.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Represents the new window manager flags.
    /// </summary>
    /// <remarks>
    /// These values are taken into account in the decision of whether to display a pop-up window.
    /// </remarks>
    [TypeLibType((short)0)]
    [Flags]
    public enum WebBrowserNewWindowFlags : uint
    {
        /// <summary>
        /// <para>No flag set.</para>
        /// <para>Constant value is 0.</para>
        /// </summary>
        None = 0x0000,

        /// <summary>
        /// <para>The page is unloading. This flag is set in response to the onbeforeunload and onunload events. Some pages load pop-up windows when you leave them rather than when you enter. This flag is used to identify those situations.</para>
        /// <para>Constant value is 1.</para>
        /// </summary>
        Unloading = 0x0001,

        /// <summary>
        /// <para>The call to INewWindowManager::EvaluateNewWindow is the result of a user-initiated action (a mouse click or key press). Use this flag in conjunction with the FirstUserInitied flag to determine whether the call is a direct or indirect result of the user-initiated action.</para>
        /// <para>Constant value is 2.</para>
        /// </summary>
        UserInitied = 0x0002,

        /// <summary>
        /// <para>When UserInitied is present, this flag indicates that the call to INewWindowManager::EvaluateNewWindow is the first query that results from this user-initiated action. Always use this flag in conjunction with UserInitied.</para>
        /// <para>Constant value is 4.</para>
        /// </summary>
        FirstUserInitied = 0x0004,

        /// <summary>
        /// <para>The override key (ALT) was pressed. The override key is used to bypass the pop-up manager—allowing all pop-up windows to display—and must be held down at the time that INewWindowManager::EvaluateNewWindow is called.</para>
        /// <para>Constant value is 8.</para>
        /// </summary>
        /// <remarks><para><b>Note:</b> When INewWindowManager::EvaluateNewWindow is implemented for a WebBrowser control host, the implementer can choose to ignore the override key.</para></remarks>
        OverrideKey = 0x0008,

        /// <summary>
        /// <para>The new window attempting to load is the result of a call to the showHelp method. Help is sometimes displayed in a separate window, and this flag is valuable in those cases.</para>
        /// <para>Constant value is 16.</para>
        /// </summary>
        ShowHelp = 0x0010,

        /// <summary>
        /// <para>The new window is a dialog box that displays HTML content.</para>
        /// <para>Constant value is 32.</para>
        /// </summary>
        HtmlDialog = 0x0020,

        /// <summary>
        /// <para>Indicates that the EvaluateNewWindow method is being called through a marshalled Component Object Model (COM) proxy from another thread. In this situation, the method should make a decision and return immediately without performing blocking operations such as showing modal user interface (UI). Lengthy operations will cause the calling thread to appear unresponsive.</para>
        /// <para>Constant value is 64.</para>
        /// </summary>
        FromProxy = 0x0040,

        /// <summary>
        /// <para>User opened a link in a new window.</para>
        /// <para>Constant value is 128.</para>
        /// </summary>
        ForceNewWindow = 0x0080,

        /// <summary>
        /// <para>User opened a link in a new tab.</para>
        /// <para>Constant value is 256.</para>
        /// </summary>
        ForceTab = 0x0100,

        /// <summary>
        /// <para>An inactive tab tried to open a window.</para>
        /// <para>Constant value is 512.</para>
        /// </summary>
        InactiveTab = 0x0200
    }
}
