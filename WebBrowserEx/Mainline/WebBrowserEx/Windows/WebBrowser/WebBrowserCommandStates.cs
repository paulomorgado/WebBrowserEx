//-----------------------------------------------------------------------
// <copyright file="WebBrowserCommandStates.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Constants for WebBrowser CommandStateChange.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// <para>CommandStateChangeConstants enumeration.</para>
    /// <para>Constants for WebBrowser CommandStateChange</para>
    /// </summary>
    [Guid("34A226E0-DF30-11CF-89A9-00A0C9054129")]
    [TypeLibType((short)0)]
    public enum WebBrowserCommandStates
    {
        /// <summary>
        /// Enabled state of a toolbar button might have changed.
        /// </summary>
        UpdateCommands = -1,

        /// <summary>
        /// Enabled state of the Forward button has changed.
        /// </summary>
        NavigateForward = 1,

        /// <summary>
        /// Enabled state of the Back button has changed.
        /// </summary>
        NavigateBack = 2
    }
}
