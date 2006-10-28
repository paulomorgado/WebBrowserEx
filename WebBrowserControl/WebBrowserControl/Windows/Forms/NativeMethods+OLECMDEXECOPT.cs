using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Specifies command execution options.
        /// </summary>
        public enum OLECMDEXECOPT : int
        {
            /// <summary>
            /// Prompt the user for input or not, whichever is the default behavior.
            /// </summary>
            OLECMDEXECOPT_DODEFAULT = 0x00,

            /// <summary>
            /// Execute the command after obtaining user input.
            /// </summary>
            OLECMDEXECOPT_PROMPTUSER = 0x01,

            /// <summary>
            /// Execute the command without prompting the user. For example, clicking the Print toolbar button causes a document to be immediately printed without user input. 
            /// </summary>
            OLECMDEXECOPT_DONTPROMPTUSER = 0x02,

            /// <summary>
            /// Show help for the corresponding command, but do not execute.
            /// </summary>
            OLECMDEXECOPT_SHOWHELP = 0x03
        }
    }
}
