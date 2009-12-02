using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Indicates the kind of objects to be enumerated by the returned IEnumUnknown interface.
        /// </summary>
        public enum tagOLECONTF : int
        {
            /// <summary>
            /// Enumerates the embedded objects in the container.
            /// </summary>
            OLECONTF_EMBEDDINGS = 1,

            /// <summary>
            /// Enumerates the linked objects in the container.
            /// </summary>
            OLECONTF_LINKS = 2,

            /// <summary>
            /// Enumerates all objects in the container that are not OLE compound document objects (i.e., objects other than linked or embedded objects). Use this flag to enumerate the container's pseudo-objects.
            /// </summary>
            OLECONTF_OTHERS = 4,

            /// <summary>
            /// Enumerates only those objects the user is aware of. For example, hidden named-ranges in Microsoft Excel would not be enumerated using this value.
            /// </summary>
            OLECONTF_ONLYUSER = 8,

            /// <summary>
            /// Enumerates only those linked or embedded objects that are currently in the running state for this container.
            /// </summary>
            OLECONTF_ONLYIFRUNNING = 16

        }
    }
}
