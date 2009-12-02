//-----------------------------------------------------------------------
// <copyright file="WebBrowserCommandOptions.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// WebBrowser's command execution options.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    /// <summary>
    /// <see cref="T:WebBrowser"/> command execution options.
    /// </summary>
    /// <remarks><para><c>OLECMDEXECOPT</c> enumeration.</para></remarks>
    public enum WebBrowserCommandOptions : int
    {
        /// <summary>
        /// Prompt the user for input or not, whichever is the default behavior.
        /// </summary>
        /// <remarks>OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT</remarks>
        DoDefault = 0,

        /// <summary>
        /// Execute the command after obtaining user input.
        /// </summary>
        /// <remarks>OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER</remarks>
        PromptUser = 1,

        /// <summary>
        /// Execute the command without prompting the user.
        /// </summary>
        /// <remarks>OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER</remarks>
        DontPromptUser = 2,

        /// <summary>
        /// Show help for the corresponding command, but do not execute.
        /// </summary>
        /// <remarks>OLECMDEXECOPT.OLECMDEXECOPT_SHOWHELP</remarks>
        ShowHelp = 3
    }
}
