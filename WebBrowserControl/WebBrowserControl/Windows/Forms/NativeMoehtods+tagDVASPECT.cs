using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Specify the desired data or view aspect of the object when drawing or getting data.
        /// </summary>
        [Flags]
        public enum tagDVASPECT : int
        {
            /// <summary>
            /// Provides a representation of an object so it can be displayed as an embedded object inside of a container.
            /// </summary>
            DVASPECT_CONTENT = 1,

            /// <summary>
            /// Provides a thumbnail representation of an object so it can be displayed in a browsing tool.
            /// </summary>
            DVASPECT_THUMBNAIL = 2,

            /// <summary>
            /// Provides an iconic representation of an object.
            /// </summary>
            DVASPECT_ICON = 4,

            /// <summary>
            /// Provides a representation of the object on the screen as though it were printed to a printer using the Print command from the File menu.
            /// </summary>
            DVASPECT_DOCPRINT = 8
        }
    }
}
