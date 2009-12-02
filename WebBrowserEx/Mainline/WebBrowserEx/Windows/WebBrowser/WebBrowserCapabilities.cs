//-----------------------------------------------------------------------
// <copyright file="WebBrowserCapabilities.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// WebBrowser's capability values.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using PauloMorgado.ComponentModel;

    /// <summary>
    /// Represents the <see cref="WebBrowser"/>'s capabilities.
    /// </summary>
    [System.Flags()]
    public enum WebBrowserCapabilities : uint
    {
        /// <summary>
        /// No web browser capabilities defined.
        /// </summary>
        None = 0x00000000, // nothing

        /// <summary>
        /// MSHTML does not enable selection of the text in the form. 
        /// </summary>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_Dialog")]
        Dialog = 0x00000001, // DOCHOSTUIFLAG_DIALOG

        /// <summary>
        /// MSHTML does not add the Help menu item to the container's menu. 
        /// </summary>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_DisableHelpMenu")]
        DisableHelpMenu = 0x00000002, // DOCHOSTUIFLAG_DISABLE_HELP_MENU

        /// <summary>
        /// MSHTML does not use 3-D borders on any frames or framesets.
        /// To turn the border off on only the outer frameset use <see cref="No3DOuterBorder"/>
        /// </summary>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_No3DBorder")]
        No3DBorder = 0x00000004, // DOCHOSTUIFLAG_NO3DBORDER

        /// <summary>
        /// MSHTML does not have scroll bars.
        /// </summary>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_NoScrollBars")]
        NoScrollBars = 0x00000008, // DOCHOSTUIFLAG_SCROLL_NO

        /// <summary>
        /// MSHTML does not execute any script when loading pages. This flag is used to postpone script execution until the host is active and, therefore, ready for script to be executed.
        /// </summary>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_DisableScriptInactive")]
        DisableScriptInactive = 0x00000010, // DOCHOSTUIFLAG_DISABLE_SCRIPT_INACTIVE

        /// <summary>
        /// MSHTML opens a site in a new window when a link is clicked rather than browse to the new site using the same browser window. 
        /// </summary>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_BrowseOpenNewWindow")]
        BrowseOpenNewWindow = 0x00000020, // DOCHOSTUIFLAG_OPENNEWWIN

        /// <summary>
        /// Not implemented. 
        /// </summary>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_DisableOffscreen")]
        DisableOffScreen = 0x00000040, // DOCHOSTUIFLAG_DISABLE_OFFSCREEN

        /// <summary>
        /// MSHTML uses flat scroll bars for any user interface (UI) it displays. 
        /// </summary>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_FlatScrollbars")]
        FlatScrollbars = 0x00000080, // DOCHOSTUIFLAG_FLAT_SCROLLBAR

        /// <summary>
        /// MSHTML inserts the <b>div</b> tag if a return is entered in edit mode. Without this flag, MSHTML will use the p tag.
        /// </summary>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_DivBlockDefault")]
        DivBlockDefault = 0x00000100, // DOCHOSTUIFLAG_DIV_BLOCKDEFAULT

        /// <summary>
        /// MSHTML only becomes UI active if the mouse is clicked in the client area of the window.
        /// It does not become UI active if the mouse is clicked on a nonclient area, such as a scroll bar. 
        /// </summary>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_ActivateOnClientHitOnly")]
        ActivateOnClientHitOnly = 0x00000200, // DOCHOSTUIFLAG_ACTIVATE_CLIENTHIT_ONLY

        /// <summary>
        /// MSHTML consults the host before retrieving a behavior from the URL specified on the page.
        /// If the host does not support the behavior, MSHTML does not proceed to query other hosts or instantiate the behavior itself,
        /// even for behaviors developed in script (HTML Components (HTCs)).
        /// </summary>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_OverrideBehaviorFactory")]
        OverrideBehaviorFactory = 0x00000400, // DOCHOSTUIFLAG_OVERRIDEBEHAVIORFACTORY

        /// <summary>
        /// Provides font selection compatibility for Microsoft Outlook Express.
        /// If the flag is enabled, the displayed characters are inspected to determine whether the current font supports the code page.
        /// If disabled, the current font is used, even if it does not contain a glyph for the character.
        /// This flag assumes that the user is using Internet Explorer 5 and Outlook Express 4.0.
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 5 or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_CodepageLinkedFonts")]
        CodepageLinkedFonts = 0x00000800, // DOCHOSTUIFLAG_CODEPAGELINKEDFONTS

        /// <summary>
        /// Controls how nonnative URLs are transmitted over the Internet.
        /// Nonnative refers to characters outside the multibyte encoding of the URL.
        /// If this flag is set, the URL is not submitted to the server in UTF-8 encoding.
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 5 or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_DisableUTF8Encoding")]
        DisableUTF8Encoding = 0x00001000, // DOCHOSTUIFLAG_URL_ENCODING_DISABLE_UTF8

        /// <summary>
        /// Controls how nonnative URLs are transmitted over the Internet.
        /// Nonnative refers to characters outside the multibyte encoding of the URL. 
        /// If this flag is set, the URL is submitted to the server in UTF-8 encoding.
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 5 or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_EnableUTF8Encoding")]
        EnableUTF8Encoding = 0x00002000, // DOCHOSTUIFLAG_URL_ENCODING_ENABLE_UTF8

        /// <summary>
        /// This flag enables the AutoComplete feature for forms in the hosted browser.
        /// The Intelliforms feature is only turned on if the user has previously enabled it.
        /// If the user has turned the AutoComplete feature off for forms, it is off whether this flag is specified or not.
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 5 or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_EnableFormsAutoComplete")]
        EnableFormsAutoComplete = 0x00004000, // DOCHOSTUIFLAG_ENABLE_FORMS_AUTOCOMPLETE

        /// <summary>
        /// This flag enables the host to specify that navigation should happen in place.
        /// This means that applications hosting MSHTML directly can specify that navigation happen in the application's window.
        /// For instance, if this flag is set, you can click a link in HTML mail and navigate in the mail instead of opening a new Internet Explorer window.
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 5 or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_EnableInPlaceNavigation")]
        EnableInPlaceNavigation = 0x00010000, // DOCHOSTUIFLAG_ENABLE_INPLACE_NAVIGATION

        /// <summary>
        /// During initialization, the host can set this flag to enable Input Method Editor (IME) reconversion,
        /// allowing computer users to employ IME reconversion while browsing Web pages. An input method editor is a program that allows users
        /// to enter complex characters and symbols, such as Japanese Kanji characters, using a standard keyboard. For more information, see the
        /// International Features reference in the Base Services section of the Microsoft Platform Software Development Kit (SDK).
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 5 or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_ImeEnableReconversion")]
        ImeEnableReconversion = 0x00020000, // DOCHOSTUIFLAG_IME_ENABLE_RECONVERSION

        /// <summary>
        /// Specifies that the hosted browser should use themes for pages it displays.
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 6 or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_Theme")]
        Theme = 0x00040000, // DOCHOSTUIFLAG_THEME

        /// <summary>
        /// Specifies that the hosted browser should not use themes for pages it displays.
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 6 or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_NoTheme")]
        NoTheme = 0x00080000, // DOCHOSTUIFLAG_NOTHEME

        /// <summary>
        /// Disables PICS ratings for the hosted browser.
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 6 or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_NoPics")]
        NoPics = 0x00100000, // DOCHOSTUIFLAG_NOPICS

        /// <summary>
        /// Turns off any 3-D border on the outermost frame or frameset only.
        /// To turn borders off on all frame sets, use <see cref="No3DBorder"/>
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 6 or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_No3DOuterBorder")]
        No3DOuterBorder = 0x00200000, // DOCHOSTUIFLAG_NO3DOUTERBORDER

        /// <summary>
        /// Disables the automatic correction of namespaces when editing HTML elements.
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 6 or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_DisableEditNSFixup")]
        DisableEditNSFixup = 0x00400000, // DOCHOSTUIFLAG_DISABLE_EDIT_NS_FIXUP

        /// <summary>
        /// Prevents Web sites in the Internet zone from accessing files in the Local Machine zone.
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 6 or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_LocalMachineAccessCheck")]
        LocalMachineAccessCheck = 0x00800000, // DOCHOSTUIFLAG_LOCAL_MACHINE_ACCESS_CHECK

        /// <summary>
        /// Turns off untrusted protocols. Untrusted protocols include ms-its, ms-itss, its, and mk:@msitstore.
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 6 or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_DisableUntrustedProtocol")]
        DisableUntrustedProtocol = 0x01000000, // DOCHOSTUIFLAG_DISABLE_UNTRUSTEDPROTOCOL

        /// <summary>
        /// Indicates that navigation is delegated to the host; otherwise, MSHTML will perform navigation.
        /// This flag is used primarily for non-HTML document types.
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 7 or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_HostNavigates")]
        HostNavigates = 0x02000000, // ?

        /// <summary>
        /// Causes MSHTML to fire an additional <see cref="E:WebBrowser.Navigating"/> event when redirect navigations occur.
        /// Applications hosting the <see cref="T:WebBrowserControl">WebBrowser Control</see> can choose to cancel or continue the redirect by returning an appropriate value in the <see cref="P:NavigatingEventArgs.Cancel">Cancel</see> parameter of the event.
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 7 or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_EnableRedirectNotification")]
        EnableRedirectNotification = 0x04000000, // DOCHOSTUIFLAG_ENABLE_REDIRECT_NOTIFICATION

        /// <summary>
        /// Causes MSHTML to use the Document Object Model (DOM) to create native "windowless" select controls that can be visually layered under other elements.
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 7 or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_UseWindowlessSelectControl")]
        UseWindowlessSelectControl = 0x08000000, // DOCHOSTUIFLAG_USE_WINDOWLESS_SELECTCONTROL

        /// <summary>
        /// Causes MSHTML to create standard Microsoft Win32 "windowed" select and drop-down controls.
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 7 or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_UseWindowedSelectControl")]
        UseWindowedSelectControl = 0x10000000, // DOCHOSTUIFLAG_USE_WINDOWED_SELECTCONTROL

        /// <summary>
        /// Requires user activation for Microsoft ActiveX controls and Java Applets embedded within a web page.
        /// This flag enables interactive control blocking, which provisionally disallows direct interaction with ActiveX controls loaded by the APPLET, EMBED, or OBJECT elements.
        /// When a control is inactive, it does not respond to user input; however, it can perform operations that do not involve interaction.
        /// </summary>
        /// <remarks>
        /// Microsoft Internet Explorer 6 for Microsoft Windows XP Service Pack 2 (SP2) or later.
        /// </remarks>
        [ResourcesDescription("WebBrowserCapabilities_ValueDescription_EnableActiveXInactivateMode")]
        EnableActiveXInactivateMode = 0x20000000 // DOCHOSTUIFLAG_ENABLE_ACTIVEX_INACTIVATE_MODE
    }
}
