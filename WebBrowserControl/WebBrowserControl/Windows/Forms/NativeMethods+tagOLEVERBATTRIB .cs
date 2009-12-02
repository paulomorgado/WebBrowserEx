using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Constants are used in the <see cref="tagOLEVERB"/> structure to describe the attributes of a specified verb for an object.
        /// </summary>
        [Flags]
        public enum tagOLEVERBATTRIB : int
        {
            /// <summary>
            /// Executing this verb will not cause the object to become dirty and is therefore in need of saving to persistent storage.
            /// </summary>
            OLEVERBATTRIB_NEVERDIRTIES = 1,

            /// <summary>
            /// Indicates a verb that should appear in the container's menu of verbs for this object.
            /// </summary>
            /// <remarks>
            /// <see cref="OLEIVERB.OLEIVERB_HIDE"/>, <see cref="OLEIVERB.OLEIVERB_SHOW"/>, and <see cref="OLEIVERB.OLEIVERB_OPEN"/> never have this value set.
            /// </remarks>
            OLEVERBATTRIB_ONCONTAINERMENU = 2
        }
    }
}
