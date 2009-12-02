//-----------------------------------------------------------------------
// <copyright file="WebBrowserDownloadControlOptions.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// WebBrowser download control options.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using PauloMorgado.ComponentModel;

    /// <summary>
    /// Represents the <see cref="WebBrowser"/> download control options.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="http://msdn.microsoft.com/library/default.asp?url=/workshop/browser/overview/Overview.asp">MSDN</see>
    /// </remarks>
    [System.Flags]
    public enum WebBrowserDownloadControlOptions : uint
    {
        /// <summary>
        /// The <see cref="WebBrowserControl"/> default. No flags are set.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_Default")]
        Default = 0x00000000, // default

        /// <summary>
        /// The <see cref="WebBrowserControl"/> will download images from the server.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_DownloadImages")]
        DownloadImages = 0x00000010, // DLCTL_DLIMAGES

        /// <summary>
        /// The <see cref="WebBrowserControl"/> will download and display video media.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_PlayVideos")]
        PlayVideos = 0x00000020, // DLCTL_VIDEOS

        /// <summary>
        /// The <see cref="WebBrowserControl"/> will play background sounds associated with the document.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_PlayBackgroundSounds")]
        PlayBackgroundSounds = 0x00000040, // DLCTL_BGSOUNDS

        /// <summary>
        /// The <see cref="WebBrowserControl"/> will not execute any scripts.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_NoScripts")]
        NoScripts = 0x00000080, // DLCTL_NO_SCRIPTS

        /// <summary>
        /// The <see cref="WebBrowserControl"/> will not execute any Java applets.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_NoJava")]
        NoJava = 0x00000100, // DLCTL_NO_JAVA

        /// <summary>
        /// The <see cref="WebBrowserControl"/> will not execute any ActiveX Controls in the document.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_NoActiveXRun")]
        NoActiveXRun = 0x00000200, // DLCTL_NO_RUNACTIVEXCTLS

        /// <summary>
        /// The <see cref="WebBrowserControl"/> will not download any ActiveX Controls in the document.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_NoActiveXDownload")]
        NoActiveXDownload = 0x00000400, // DLCTL_NO_DLACTIVEXCTLS

        /// <summary>
        /// The <see cref="WebBrowserControl"/> will ignore what is in the cache and ask the server for updated information.
        /// The cached information will be used if the server indicates that the cached information is up to date.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_Resynchronize")]
        Resynchronize = 0x00002000, // DLCTL_RESYNCHRONIZE

        /// <summary>
        /// The <see cref="WebBrowserControl"/> will force the request through to the server and ignore the proxy,
        /// even if the proxy indicates that the data is up to date.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_PragmaNoCache")]
        PragmaNoCache = 0x00004000, // DLCTL_PRAGMA_NO_CACHE

        /// <summary>
        /// The <see cref="WebBrowserControl"/> will not execute any behaviors.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_NoBehaviours")]
        NoBehaviours = 0x00008000, // DLCTL_NO_BEHAVIORS

        /// <summary>
        /// The <see cref="WebBrowserControl"/> will suppress HTML Character Sets reflected by meta elements in the document.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_NoMetaCharSets")]
        NoMetaCharSets = 0x00010000, // DLCTL_NO_METACHARSET

        /// <summary>
        /// The <see cref="WebBrowserControl"/> will disable UTF-8 encoding.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_DisableUTF8Encoding")]
        DisableUTF8Encoding = 0x00020000, // DLCTL_URL_ENCODING_DISABLE_UTF8

        /// <summary>
        /// The <see cref="WebBrowserControl"/> will enable UTF-8 encoding.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_EnableUTF8Encoding")]
        EnableUTF8Encoding = 0x00040000, // DLCTL_URL_ENCODING_ENABLE_UTF8

        /// <summary>
        /// The <see cref="WebBrowserControl"/> will not download frames but will download and parse the frameset page.
        /// The <see cref="WebBrowserControl"/> will also ignore the frameset, and will render no frame tags.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_NoFrameDownload")]
        NoFrameDownload = 0x00080000, // DLCTL_NO_FRAMEDOWNLOAD

        /// <summary>
        /// The <see cref="WebBrowserControl"/> will always operate in offline mode.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_ForceOffline")]
        ForceOffline = 0x10000000, // DLCTL_FORCEOFFLINE

        /// <summary>
        /// The <see cref="WebBrowserControl"/> will not perform any client pull operations.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_NoClientPull")]
        NoClientPull = 0x20000000, // DLCTL_NO_CLIENTPULL

        /// <summary>
        /// The <see cref="WebBrowserControl"/> will operate in offline mode if not connected to the Internet.
        /// </summary>
        [ResourcesDescription("WebBrowserDownloadControlOptions_ValueDescription_OfflineIfNotConnected")]
        OfflineIfNotConnected = 0x80000000, // DLCTL_OFFLINEIFNOTCONNECTED
    }
}
