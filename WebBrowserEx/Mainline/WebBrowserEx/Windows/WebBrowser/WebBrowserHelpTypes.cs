//-----------------------------------------------------------------------
// <copyright file="WebBrowserHelpTypes.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Represents the possible help types for the ShowHelp event.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    /// <summary>
    /// Represents the possible help types for the <see cref ="WebBrowserControl.ShowHelp"/> event.
    /// </summary>
    public enum WebBrowserHelpTypes : uint
    {
        /// <summary>
        /// Displays the topic identified by the specified context identifier defined in the [MAP] section of the .hpj file.
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Contains the context identifier for the topic.
        /// </remarks>
        Context = 0x0001, // HELP_CONTEXT

        /// <summary>
        /// Informs Windows Help that it is no longer needed. If no other applications have asked for help, Windows closes Windows Help.
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Ignored; set to 0.
        /// </remarks>
        Quit = 0x0002, // HELP_QUIT

        /// <summary>
        /// Displays the topic specified by the Contents option in the [OPTIONS] section of the .hpj file. This command is for backward compatibility. New applications should use the HELP_FINDER command. 
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Ignored; set to 0.
        /// </remarks>
        Index = 0x0003, // HELP_INDEX

        /// <summary>
        /// Displays the topic specified by the Contents option in the [OPTIONS] section of the .hpj file. This command is for backward compatibility. New applications should provide a .cnt file and use the HELP_FINDER command.
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Ignored; set to 0.
        /// </remarks>
        Contents = 0x0003, // HELP_CONTENTS

        /// <summary>
        /// Displays help on how to use Windows Help, if the Winhlp32.hlp file is available.
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Ignored; set to 0.
        /// </remarks>
        HelpOnHelp = 0x0004, // HELP_HELPONHELP

        /// <summary>
        /// Specifies the Contents topic. Windows Help displays this topic when the user clicks the Contents button if the Help file does not have an associated .cnt file.
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Contains the context identifier for the Contents topic.
        /// </remarks>
        SetContents = 0x0005, // HELP_SETCONTENTS

        /// <summary>
        /// Displays the topic identified by the specified context identifier defined in the [MAP] section of the .hpj file in a pop-up window.
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Contains the context identifier for a topic.
        /// </remarks>
        ContextPopup = 0x0008, // HELP_CONTEXTPOPUP

        /// <summary>
        /// Ensures that Windows Help is displaying the correct Help file. If the incorrect Help file is being displayed, Windows Help opens the correct one; otherwise, there is no action.
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Ignored; set to 0.
        /// </remarks>
        ForceFile = 0x0009, // HELP_FORCEFILE

        /// <summary>
        /// Displays the topic in the keyword table that matches the specified keyword, if there is an exact match. If there is more than one match, displays the Index with the topics listed in the Topics Found list box.
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Address of a keyword string. Multiple keywords must be separated by semicolons.
        /// </remarks>
        Key = 0x0101, // HELP_KEY

        /// <summary>
        /// Executes a Help macro or macro string.
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Address of a string that specifies the name of the Help macro(s) to run. If the string specifies multiple macro names, the names must be separated by semicolons. You must use the short form of the macro name for some macros because Windows Help does not support the long name.
        /// </remarks>
        Command = 0x0102, // HELP_COMMAND

        /// <summary>
        /// Displays the topic in the keyword table that matches the specified keyword, if there is an exact match. If there is more than one match, displays the Topics Found dialog box. To display the index without passing a keyword, use a pointer to an empty string.
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Address of a keyword string. Multiple keywords must be separated by semicolons.
        /// </remarks>
        PartialKey = 0x0105, // HELP_PARTIALKEY

        /// <summary>
        /// Displays the topic specified by a keyword in an alternative keyword table.
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Address of a MULTIKEYHELP structure that specifies a table footnote character and a keyword.
        /// </remarks>
        MultiKey = 0x0201, // HELP_MULTIKEY

        /// <summary>
        /// Displays the Windows Help window, if it is minimized or in memory, and sets its size and position as specified.
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Address of a HELPWININFO structure that specifies the size and position of either a primary or secondary Help window.
        /// </remarks>
        SetWinpos = 0x0203, // HELP_SETWINPOS

        /// <summary>
        /// Displays the Help menu for the selected window, then displays the topic for the selected control in a pop-up window.
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Address of an array of double word pairs. The first double word in each pair is the control identifier, and the second is the context identifier for the topic. The array must be terminated by a pair of zeros {0,0}. If you do not want to add Help to a particular control, set its context identifier to -1.
        /// </remarks>
        ContextMenu = 0x000a, // HELP_CONTEXTMENU

        /// <summary>
        /// Displays the Help Topics dialog box. 
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Ignored; set to 0.
        /// </remarks>
        Finder = 0x000b, // HELP_FINDER

        /// <summary>
        /// Displays the topic for the control identified by the hWndMain parameter in a pop-up window.
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Address of an array of double word pairs. The first double word in each pair is a control identifier, and the second is a context identifier for a topic. The array must be terminated by a pair of zeros {0,0}. If you do not want to add Help to a particular control, set its context identifier to -1.
        /// </remarks>
        MainWindowHelp = 0x000c, // HELP_WM_HELP

        /// <summary>
        /// Sets the position of the subsequent pop-up window.
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Contains the position data. Use MAKELONG to concatenate the horizontal and vertical coordinates into a single value. The pop-up window is positioned as if the mouse cursor were at the specified point when the pop-up window was invoked. 
        /// </remarks>
        SetPopupPosition = 0x000d, // HELP_SETPOPUP_POS

        /// <summary>
        /// Indicates that a command is for a training card instance of Windows Help. Combine this command with other commands using the bitwise OR operator.
        /// </summary>
        /// <remarks>
        /// <see cref ="ShowHelpEventArgs.Data"/> value: Depends on the command with which this command is combined.
        /// </remarks>
        TrainingCard = 0x8000 // HELP_TCARD
    }
}
