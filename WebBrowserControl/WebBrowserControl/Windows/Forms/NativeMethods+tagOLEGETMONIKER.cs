using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Constants indicate the requested behavior of the <see cref="IOleObject.GetMoniker"/> and <see cref="IOleClientSite.GetMoniker"/> methods.
        /// </summary>
        public enum tagOLEGETMONIKER : int
        {
            /// <summary>
            /// If a moniker for the object or container does not exist, GetMoniker should return E_FAIL and not assign a moniker.
            /// </summary>
            OLEGETMONIKER_ONLYIFTHERE = 1,

            /// <summary>
            /// If a moniker for the object or container does not exist, GetMoniker should create one.
            /// </summary>
            OLEGETMONIKER_FORCEASSIGN = 2,

            /// <summary>
            /// <see cref="IOleClientSite.GetMoniker"/> can release the object's moniker (although it is not required to do so). This constant is not valid in <see cref="IOleObject.GetMoniker"/>.
            /// </summary>
            OLEGETMONIKER_UNASSIGN = 3,

            /// <summary>
            /// If a moniker for the object does not exist, <see cref="IOleObject.GetMoniker"/> can create a temporary moniker that can be used for display purposes (IMoniker::GetDisplayName) but not for binding.
            /// </summary>
            OLEGETMONIKER_TEMPFORUSER = 4
        }
    }
}
