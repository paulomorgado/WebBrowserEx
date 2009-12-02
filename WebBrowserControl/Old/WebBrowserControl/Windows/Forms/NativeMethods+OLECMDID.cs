using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Specifies which command to execute.
        /// </summary>
        public enum OLECMDID : int
        {
            /// <summary>
            /// File menu, Open command.
            /// </summary>
            OLECMDID_OPEN = 1,

            /// <summary>
            /// File menu, New command.
            /// </summary>
            OLECMDID_NEW = 2,

            /// <summary>
            /// File menu, Save command.
            /// </summary>
            OLECMDID_SAVE = 3,

            /// <summary>
            /// File menu, Save As command.
            /// </summary>
            OLECMDID_SAVEAS = 4,

            /// <summary>
            /// File menu, Save Copy As command.
            /// </summary>
            OLECMDID_SAVECOPYAS = 5,

            /// <summary>
            /// File menu, Print command
            /// </summary>
            OLECMDID_PRINT = 6,

            /// <summary>
            /// File menu, Print Preview command
            /// </summary>
            OLECMDID_PRINTPREVIEW = 7,

            /// <summary>
            /// File menu, Page Setup command
            /// </summary>
            OLECMDID_PAGESETUP = 8,

            /// <summary>
            /// Tools menu, Spelling command
            /// </summary>
            OLECMDID_SPELL = 9,

            /// <summary>
            /// File menu, Properties command
            /// </summary>
            OLECMDID_PROPERTIES = 10,

            /// <summary>
            /// Edit menu, Cut command
            /// </summary>
            OLECMDID_CUT = 11,

            /// <summary>
            /// Edit menu, Copy command
            /// </summary>
            OLECMDID_COPY = 12,

            /// <summary>
            /// Edit menu, Paste command
            /// </summary>
            OLECMDID_PASTE = 13,

            /// <summary>
            /// Edit menu, Paste Special command
            /// </summary>
            OLECMDID_PASTESPECIAL = 14,

            /// <summary>
            /// Edit menu, Undo command
            /// </summary>
            OLECMDID_UNDO = 15,

            /// <summary>
            /// Edit menu, Redo command
            /// </summary>
            OLECMDID_REDO = 16,

            /// <summary>
            /// Edit menu, Select All command
            /// </summary>
            OLECMDID_SELECTALL = 17,

            /// <summary>
            /// Edit menu, Clear command
            /// </summary>
            OLECMDID_CLEARSELECTION = 18,

            /// <summary>
            /// View menu, Zoom command
            /// </summary>
            OLECMDID_ZOOM = 19,

            /// <summary>
            /// Retrieves zoom range applicable to View Zoom.
            /// </summary>
            OLECMDID_GETZOOMRANGE = 20,

            /// <summary>
            /// Informs the receiver, usually a frame, of state changes. The receiver can then query the status of the commands whenever convenient.
            /// </summary>
            OLECMDID_UPDATECOMMANDS = 21,

            /// <summary>
            /// Asks the receiver to refresh its display. Implemented by the document/object.
            /// </summary>
            OLECMDID_REFRESH = 22,

            /// <summary>
            /// Stops all current processing. Implemented by the document/object.
            /// </summary>
            OLECMDID_STOP = 23,

            /// <summary>
            /// View Menu, Toolbars command. Implemented by the document/object to hide its toolbars.
            /// </summary>
            OLECMDID_HIDETOOLBARS = 24,

            /// <summary>
            /// Sets the maximum value of a progress indicator if one is owned by the receiving object, usually a frame. The minimum value is always zero.
            /// </summary>
            OLECMDID_SETPROGRESSMAX = 25,

            /// <summary>
            /// Sets the current value of a progress indicator if one is owned by the receiving object, usually a frame.
            /// </summary>
            OLECMDID_SETPROGRESSPOS = 26,

            /// <summary>
            /// Sets the text contained in a progress indicator if one is owned by the receiving object, usually a frame.
            /// </summary>
            OLECMDID_SETPROGRESSTEXT = 27,

            /// <summary>
            /// Sets the title bar text of the receiving object, usually a frame.
            /// </summary>
            OLECMDID_SETTITLE = 28,

            /// <summary>
            /// Called by the object when downloading state changes. Takes a VT_BOOL parameter, which is <see langword="true"/> if the object is downloading data and <see langword="false"/> if it not. Primarily implemented by the frame.
            /// </summary>
            OLECMDID_SETDOWNLOADSTATE = 29,

            /// <summary>
            /// Stops the download when executed. Typically, this command is propagated to all contained objects. When queried, sets MSOCMDF_ENABLED. Implemented by the document/object.
            /// </summary>
            OLECMDID_STOPDOWNLOAD = 30,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_ONTOOLBARACTIVATED = 31,

            /// <summary>
            /// Edit menu, Find command
            /// </summary>
            OLECMDID_FIND = 32,

            /// <summary>
            /// Edit menu, Delete command
            /// </summary>
            OLECMDID_DELETE = 33,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_HTTPEQUIV = 34,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_HTTPEQUIV_DONE = 35,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_ENABLE_INTERACTION = 36,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_ONUNLOAD = 37,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_PROPERTYBAG2 = 38,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_PREREFRESH = 39,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_SHOWSCRIPTERROR = 40,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_SHOWMESSAGE = 41,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_SHOWFIND = 42,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_SHOWPAGESETUP = 43,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_SHOWPRINT = 44,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_CLOSE = 45,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_ALLOWUILESSSAVEAS = 46,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_DONTDOWNLOADCSS = 47,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_UPDATEPAGESTATUS = 48,

            /// <summary>
            /// File menu, updated Print command
            /// </summary>
            OLECMDID_PRINT2 = 49,

            /// <summary>
            /// File menu, updated Print Preview command 
            /// </summary>
            OLECMDID_PRINTPREVIEW2 = 50,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_SETPRINTTEMPLATE = 51,

            /// <summary>
            /// 
            /// </summary>
            OLECMDID_GETPRINTTEMPLATE = 52,

            /// <summary>
            /// Indicates that a page action has been blocked.
            /// PAGEACTIONBLOCKED is designed for use with applications that host the Internet Explorer WebBrowser control to implement their own UI.
            /// </summary>
            OLECMDID_PAGEACTIONBLOCKED = 55,

            /// <summary>
            /// Specifies which actions are displayed in the Internet Explorer notification band. 
            /// </summary>
            OLECMDID_PAGEACTIONUIQUERY = 56,

            /// <summary>
            /// Causes the Internet Explorer WebBrowser control to focus its default notification band. Hosts can send this command at any time.
            /// </summary>
            /// <remarks>
            /// The return value is S_OK if the band is present and is in focus, or S_FALSE otherwise. 
            /// </remarks>
            OLECMDID_FOCUSVIEWCONTROLS = 57,

            /// <summary>
            /// This notification event is provided for applications that display Internet Explorers default notification band implementation.
            /// </summary>
            /// <remarks>
            /// By default, when the user presses the ALT-N key combination, Internet Explorer treats it as a request to focus the notification band.
            /// </remarks>
            OLECMDID_FOCUSVIEWCONTROLSQUERY = 58,

            /// <summary>
            /// Causes the Internet Explorer WebBrowser control to show the Information Bar menu.
            /// </summary>
            OLECMDID_SHOWPAGEACTIONMENU = 59,

            /// <summary>
            /// Causes the Internet Explorer WebBrowser control to create an entry at the current Travel Log offset.
            /// </summary>
            /// <remarks>
            /// The Docobject should implement ITravelLogClient and IPersist interfaces, which are used by the Travel
            /// Log as it processes this command with calls to GetWindowData and GetPersistID, respectively. 
            /// </remarks>
            OLECMDID_ADDTRAVELENTRY = 60,

            /// <summary>
            /// Called when LoadHistory is processed to update the previous Docobject state.
            /// </summary>
            /// <remarks>
            /// For synchronous handling, this command can be called before returning from the LoadHistory call. For asynchronous handling, it can be called later. 
            /// </remarks>
            OLECMDID_UPDATETRAVELENTRY = 61,

            /// <summary>
            /// Updates the state of the browser's Back and Forward buttons.
            /// </summary>
            OLECMDID_UPDATEBACKFORWARDSTATE = 62,

            /// <summary>
            /// Sets the zoom factor of the browser. Takes a VT_I4 parameter in the range of 10 to 1000 (percent).
            /// </summary>
            OLECMDID_OPTICAL_ZOOM = 63,

            /// <summary>
            /// Retrieves the minimum and maximum browser zoom factor limits.
            /// </summary>
            /// <remarks>
            /// Returns a VT_I4 parameter; the LOWORD is the minimum zoom factor, the HIWORD is the maximum.
            /// </remarks>
            OLECMDID_OPTICAL_GETZOOMRANGE = 64,

            /// <summary>
            /// Notifies the Internet Explorer WebBrowser control of changes in window states, such as losing focus, or becoming hidden or minimized.
            /// </summary>
            /// <remarks>
            /// The host indicates what has changed by setting OLECMDID_WINDOWSTATE_FLAG option flags in nCmdExecOpt.
            /// </remarks>
            OLECMDID_WINDOWSTATECHANGED = 65
        }
    }
}
