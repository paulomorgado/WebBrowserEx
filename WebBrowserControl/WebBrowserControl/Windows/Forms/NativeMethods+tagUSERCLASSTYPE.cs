using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Indicate the different variants of the display name associated with a class of objects.
        /// </summary>
        public enum tagUSERCLASSTYPE : int
        {
            /// <summary>
            /// The full type name of the class.
            /// </summary>
            USERCLASSTYPE_FULL = 1,

            /// <summary>
            /// A short name (maximum of 15 characters) that is used for popup menus and the Links dialog box.
            /// </summary>
            USERCLASSTYPE_SHORT = 2,

            /// <summary>
            /// The name of the application servicing the class and is used in the Result text in dialog boxes.
            /// </summary>
            USERCLASSTYPE_APPNAME = 3,
        }
    }
}
