using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Indicate which part of an object's moniker is being set or retrieved.
        /// </summary>
        public enum tagOLEWHICHMK : int
        {
            /// <summary>
            /// The moniker of the object's container.
            /// </summary>
            OLEWHICHMK_CONTAINER = 1,

            /// <summary>
            /// The moniker of the object relative to its container.
            /// </summary>
            OLEWHICHMK_OBJREL = 2,

            /// <summary>
            /// The full moniker of the object.
            /// </summary>
            OLEWHICHMK_OBJFULL = 3
        }
    }
}
