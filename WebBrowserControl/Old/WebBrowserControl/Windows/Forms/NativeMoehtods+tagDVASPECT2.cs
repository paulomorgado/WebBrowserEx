using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Values used in IViewObject::Draw to specify new drawing aspects used to optimize the drawing process.
        /// </summary>
        [Flags]
        public enum tagDVASPECT2 : int
        {
            /// <summary>
            /// Provides a representation of an object so it can be displayed as an embedded object inside of a container.
            /// </summary>
            DVASPECT_CONTENT = tagDVASPECT.DVASPECT_CONTENT,

            /// <summary>
            /// Provides a thumbnail representation of an object so it can be displayed in a browsing tool.
            /// </summary>
            DVASPECT_THUMBNAIL = tagDVASPECT.DVASPECT_THUMBNAIL,

            /// <summary>
            /// Provides an iconic representation of an object.
            /// </summary>
            DVASPECT_ICON = tagDVASPECT.DVASPECT_ICON,

            /// <summary>
            /// Provides a representation of the object on the screen as though it were printed to a printer using the Print command from the File menu.
            /// </summary>
            DVASPECT_DOCPRINT = tagDVASPECT.DVASPECT_DOCPRINT,

            /// <summary>
            /// Represents the opaque, easy to clip parts of an object. Objects may or may not support this aspect.
            /// </summary>
            DVASPECT_OPAQUE = 16,

            /// <summary>
            /// Represents the transparent or irregular parts of on object, typically parts that are expensive or impossible to clip out. Objects may or may not support this aspect.
            /// </summary>
            DVASPECT_TRANSPARENT = 32
        }
    }
}
