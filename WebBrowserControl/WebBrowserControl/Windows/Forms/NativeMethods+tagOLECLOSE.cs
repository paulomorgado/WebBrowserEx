using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// constants are used in the <see cref="IOleObject.Close"/> method to determine whether the object should be saved before closing.
        /// </summary>
        public enum tagOLECLOSE : int
        {
            /// <summary>
            /// The object should be saved if it is dirty.
            /// </summary>
            OLECLOSE_SAVEIFDIRTY = 0,

            /// <summary>
            /// The object should not be saved, even if it is dirty. This flag is typically used when an object is being deleted.
            /// </summary>
            OLECLOSE_NOSAVE = 1,

            /// <summary>
            /// If the object is dirty, the <see cref="IOleObject.Close"/> implementation should display a dialog box to let the end user determine whether to save the object.
            /// </summary>
            OLECLOSE_PROMPTSAVE = 2
        }
    }
}
