//-----------------------------------------------------------------------
// <copyright file="WebBrowserCommandStatus.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// WebBrowser command execution status.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    /// <summary>
    /// <see cref="T:WebBrowser"/> command execution status.
    /// </summary>
    /// <remarks><para>OLECMDF enumeration.</para></remarks>
    ////[System.Runtime.InteropServices.TypeLibType((short)0)]
    [System.Flags]
    public enum WebBrowserCommandStatus : int
    {
        /// <summary>
        /// The command is supported by the <see cref="WebBrowser"/>.
        /// </summary>
        /// <remarks>OLECMDF.OLECMDF_SUPPORTED</remarks>
        Supported = 1,

        /// <summary>
        /// The command is available and enabled.
        /// </summary>
        /// <remarks>OLECMDF.OLECMDF_ENABLED</remarks>
        Enabled = 2,

        /// <summary>
        /// The command is an on-off toggle and is currently on.
        /// </summary>
        /// <remarks>OLECMDF.OLECMDF_LATCHED</remarks>
        Latched = 4,

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        /// <remarks>OLECMDF.OLECMDF_NINCHED</remarks>
        Ninched = 8,

        /// <summary>
        /// Set invisible.
        /// </summary>
        /// <remarks>OLECMDF.OLECMDF_INVISIBLE</remarks>
        Invisible = 16,

        /// <summary>
        /// Def. hide context menu.
        /// </summary>
        /// <remarks>OLECMDF.OLECMDF_DEFHIDEONCTXTMENU</remarks>
        DefHideContextMenu = 32
    }
}
