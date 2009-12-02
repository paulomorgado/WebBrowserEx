//-----------------------------------------------------------------------
// <copyright file="WebBrowserCommands.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// WebBrowser commands.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    /// <summary>
    /// <see cref="T:WebBrowser"/> commands.
    /// </summary>
    /// <remarks><para><c>OLECMDID</c> enumeration.</para><para>Not all apply to the <see cref="T:WebBrowser"/>.</para></remarks>
    public enum WebBrowserCommands : uint
    {
        /// <summary>
        /// File menu, Open command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_OPEN</remarks>
        Open = 1,

        /// <summary>
        /// File menu, New command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_NEW</remarks>
        New = 2,

        /// <summary>
        /// File menu, Save command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_SAVE</remarks>
        Save = 3,

        /// <summary>
        /// File menu, Save As command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_SAVEAS</remarks>
        SaveAs = 4,

        /// <summary>
        /// File menu, Save Copy As command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_SAVECOPYAS</remarks>
        SaveCopyAs = 5,

        /// <summary>
        /// File menu, Print command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_PRINT</remarks>
        Print = 6,

        /// <summary>
        /// File menu, Print Preview command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_PRINTPREVIEW</remarks>
        PrintPreview = 7,

        /// <summary>
        /// File menu, Page Setup command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_PAGESETUP</remarks>
        PageSetup = 8,

        /// <summary>
        /// Tools menu, Spelling command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_SPELL</remarks>
        Spell = 9,

        /// <summary>
        /// File menu, Properties command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_PROPERTIES</remarks>
        Properties = 10,

        /// <summary>
        /// Edit menu, Cut command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_CUT</remarks>
        Cut = 11,

        /// <summary>
        /// Edit menu, Copy command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_COPY</remarks>
        Copy = 12,

        /// <summary>
        /// Edit menu, Paste command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_PASTE</remarks>
        Paste = 13,

        /// <summary>
        /// Edit menu, Paste Special command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_PASTESPECIAL</remarks>
        PasteSpecial = 14,

        /// <summary>
        /// Edit menu, Undo command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_UNDO</remarks>
        Undo = 15,

        /// <summary>
        /// Edit menu, Redo command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_REDO</remarks>
        Redo = 16,

        /// <summary>
        /// Edit menu, Select All command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_SELECTALL</remarks>
        SelectAll = 17,

        /// <summary>
        /// Edit menu, Clear command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_CLEARSELECTION</remarks>
        ClearSelection = 18,

        /// <summary>
        /// View menu, Zoom command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_ZOOM</remarks>
        Zoom = 19,

        /// <summary>
        /// Retrieves zoom range applicable to View Zoom.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_GETZOOMRANGE</remarks>
        GetZoomRange = 20,

        /// <summary>
        /// Informs the receiver, usually a frame, of state changes. The receiver can then query the status of the commands whenever convenient.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_UPDATECOMMANDS</remarks>
        UpdateCommands = 21,

        /// <summary>
        /// Asks the receiver to refresh its display. Implemented by the document/object.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_REFRESH</remarks>
        Refresh = 22,

        /// <summary>
        /// Stops all current processing. Implemented by the document/object.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_STOP</remarks>
        Stop = 23,

        /// <summary>
        /// View Menu, Toolbars command. Implemented by the document/object to hide its toolbars.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_HIDETOOLBARS</remarks>
        HideToolbars = 24,

        /// <summary>
        /// Sets the maximum value of a progress indicator if one is owned by the receiving object, usually a frame. The minimum value is always zero.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_SETPROGRESSMAX</remarks>
        SetProgressMaximum = 25,

        /// <summary>
        /// Sets the current value of a progress indicator if one is owned by the receiving object, usually a frame. 
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_SETPROGRESSPOS</remarks>
        SetProgressValue = 26,

        /// <summary>
        /// Sets the text contained in a progress indicator if one is owned by the receiving object, usually a frame.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_SETPROGRESSTEXT</remarks>
        SetProgressText = 27,

        /// <summary>
        /// Sets the title bar text of the receiving object, usually a frame.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_SETTITLE</remarks>
        SetTitle = 28,

        /// <summary>
        /// Called by the object when downloading state changes.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_SETDOWNLOADSTATE</remarks>
        SetDownloadState = 29,

        /// <summary>
        /// Stops the download when executed.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_STOPDOWNLOAD</remarks>
        StopDownload = 30,

        /// <summary>
        /// On Toolbar activated.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_ONTOOLBARACTIVATED</remarks>
        OnToolbarActivated = 31,

        /// <summary>
        /// Edit menu, Find command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_FIND</remarks>
        Find = 32,

        /// <summary>
        /// Edit menu, Delete command.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_DELETE</remarks>
        Delete = 33,

        /// <summary>
        /// HTTTP EQUIV.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_HTTPEQUIV</remarks>
        HttpEquiv = 34,

        /// <summary>
        /// HTTP EQUIV done.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_HTTPEQUIV_DONE</remarks>
        HttpEquivDone = 35,

        /// <summary>
        /// Enable interaction.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_ENABLE_INTERACTION</remarks>
        EnableInteraction = 36,

        /// <summary>
        /// On unload.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_ONUNLOAD</remarks>
        OnUnload = 37,

        /// <summary>
        /// Property bag 2.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_PROPERTYBAG2</remarks>
        PropertyBag2 = 38,

        /// <summary>
        /// Pre refresh.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_PREREFRESH</remarks>
        PreRefresh = 39,

        /// <summary>
        /// Show script error.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_SHOWSCRIPTERROR</remarks>
        ShowScriptError = 40,

        /// <summary>
        /// Show message.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_SHOWMESSAGE</remarks>
        ShowMessage = 41,

        /// <summary>
        /// Show find.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_SHOWFIND</remarks>
        ShowFind = 42,

        /// <summary>
        /// Show page setup.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_SHOWPAGESETUP</remarks>
        ShowPageSetup = 43,

        /// <summary>
        /// Show print.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_SHOWPRINT</remarks>
        ShowPrint = 44,

        /// <summary>
        /// Close document.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_CLOSE</remarks>
        Close = 45,
        
        /// <summary>
        /// Allow UI save as.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_ALLOWUILESSSAVEAS</remarks>
        AllowUISaveAs = 46,

        /// <summary>
        /// Dont' download CSS.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_DONTDOWNLOADCSS</remarks>
        DontDownloadCss = 47,

        /// <summary>
        /// Update page status.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_UPDATEPAGESTATUS</remarks>
        UpadatePageStatus = 48,

        /// <summary>
        /// File menu, updated Print command
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_PRINT2</remarks>
        Print2 = 49,

        /// <summary>
        /// File menu, updated Print Preview command
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_PRINTPREVIEW2</remarks>
        PrintPreview2 = 50,

        /// <summary>
        /// Set print template.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_SETPRINTTEMPLATE</remarks>
        SetPrintTemplate = 51,

        /// <summary>
        /// Get print template.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_GETPRINTTEMPLATE</remarks>
        GetPrintTemplate = 52,

        /// <summary>
        /// Indicates that a page action has been blocked.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_PAGEACTIONBLOCKED</remarks>
        PageActionBlocked = 55,

        /// <summary>
        /// Specifies which actions are displayed in the Internet Explorer notification band.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_PAGEACTIONUIQUERY</remarks>
        PageActionUIQuery = 56,

        /// <summary>
        /// Causes the Internet Explorer WebBrowser control to focus its default notification band.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_FOCUSVIEWCONTROLS</remarks>
        FocusViewControls = 57,

        /// <summary>
        /// This notification event is provided for applications that display Internet Explorers default notification band implementation.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_FOCUSVIEWCONTROLSQUERY</remarks>
        FocusViewControlsQuery = 58,

        /// <summary>
        /// Causes the Internet Explorer WebBrowser control to show the Information Bar menu.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_SHOWPAGEACTIONMENU</remarks>
        ShowPageActionMenu = 59,

        /// <summary>
        /// Causes the Internet Explorer WebBrowser control to create an entry at the current Travel Log offset.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_ADDTRAVELENTRY</remarks>
        AddTravelEntry = 60,

        /// <summary>
        /// Called when LoadHistory is processed to update the previous Docobject state.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_UPDATETRAVELENTRY</remarks>
        UpdateTravelEntry = 61,

        /// <summary>
        /// Updates the state of the browser's Back and Forward buttons.
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_UPDATEBACKFORWARDSTATE</remarks>
        UpdateBackForwardState = 62,

        /// <summary>
        /// Sets the zoom factor of the browser (Windows Internet Explorer 7 and later).
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_OPTICAL_ZOOM</remarks>
        OpticalZoom = 63,

        /// <summary>
        /// Retrieves the minimum and maximum browser zoom factor limits (Windows Internet Explorer 7 and later).
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_OPTICAL_GETZOOMRANGE</remarks>
        OpticalGetZoomRange = 64,

        /// <summary>
        /// Notifies the Internet Explorer WebBrowser control of changes in window states, such as losing focus, or becoming hidden or minimized (Windows Internet Explorer 7 and later).
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_WINDOWSTATECHANGED</remarks>
        WindowStateChanged = 65,

        /// <summary>
        /// Notifies Trident to use the indicated Install Scope to install the ActiveX Control specified by the indicated Class ID. For more information, see the Remarks section.
        /// (Windows Internet Explorer 8 with Windows Vista. Has no effect with Windows Internet Explorer 8 with Windows XP.)
        /// </summary>
        /// <remarks>OLECMDID.OLECMDID_ACTIVEXINSTALLSCOPE</remarks>
        ActiveXInstallScope = 66
    }
}
