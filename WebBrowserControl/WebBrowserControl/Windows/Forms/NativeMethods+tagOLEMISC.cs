using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Constants that can be combined to describe miscellaneous characteristics of an object or class of objects.
        /// </summary>
        [Flags]
        public enum tagOLEMISC
        {
            /// <summary>
            /// When the container resizes the space allocated to displaying one of the object's presentations, the object wants to recompose the presentation.
            /// </summary>
            OLEMISC_RECOMPOSEONRESIZE = 0x000001,

            /// <summary>
            /// The object has no useful content view other than its icon.
            /// </summary>
            OLEMISC_ONLYICONIC = 0x000002,

            /// <summary>
            /// The object has initialized itself from the data in the container's current selection.
            /// </summary>
            OLEMISC_INSERTNOTREPLACE = 0x000004,

            /// <summary>
            /// This object is a static object, which is an object that contains only a presentation; it contains no native data.
            /// </summary>
            OLEMISC_STATIC = 0x000008,

            /// <summary>
            /// This object cannot be the link source that when bound to activates (runs) the object.
            /// </summary>
            OLEMISC_CANTLINKINSIDE = 0x000010,

            /// <summary>
            /// This object can be linked to by OLE 1 containers. This bit is used in the dwStatus member of the <b>OBJECTDESCRIPTOR</b> structure transferred with the Object and Link Source Descriptor formats.
            /// </summary>
            OLEMISC_CANLINKBYOLE1 = 0x000020,

            /// <summary>
            /// This object is a link object. This bit is significant to OLE 1 and is set by the OLE 2 link object; object applications have no need to set this bit.
            /// </summary>
            OLEMISC_ISLINKOBJECT = 0x000040,

            /// <summary>
            /// This object is capable of activating in-place, without requiring installation of menus and toolbars to run.
            /// </summary>
            OLEMISC_INSIDEOUT = 0x000080,

            /// <summary>
            /// This bit is set only when <see cref="OLEMISC_INSIDEOUT"/> is set, and indicates that this object prefers to be activated whenever it is visible.
            /// </summary>
            OLEMISC_ACTIVATEWHENVISIBLE = 0x000100,

            /// <summary>
            /// This object does not pay any attention to target devices. Its presention data will be the same in all cases.
            /// </summary>
            OLEMISC_RENDERINGISDEVICEINDEPENDENT = 0x000200,

            /// <summary>
            /// Indicates that the control has no run-time user interface, but that it should be visible at design time.
            /// </summary>
            OLEMISC_INVISIBLEATRUNTIME = 0x000400,

            /// <summary>
            /// Tells the container that this control always wants to be running.
            /// </summary>
            OLEMISC_ALWAYSRUN = 0x000800,

            /// <summary>
            /// Indicates that the control is buttonlike in that it understands and obeys the container's DisplayAsDefault ambient property.
            /// </summary>
            OLEMISC_ACTSLIKEBUTTON = 0x001000,

            /// <summary>
            /// Marks the control as a label for whatever control comes after it in the form's ordering.
            /// </summary>
            OLEMISC_ACTSLIKELABEL = 0x002000,

            /// <summary>
            /// Indicates that the control has no UI active state, meaning that it requires no in-place tools, no shared menu, and no accelerators.
            /// </summary>
            OLEMISC_NOUIACTIVATE = 0x004000,

            /// <summary>
            /// Indicates that the control understands how to align itself within its display rectangle, according to alignment properties such as left, center, and right.
            /// </summary>
            OLEMISC_ALIGNABLE = 0x008000,

            /// <summary>
            /// Indicates that the control is a simple grouping of other controls and does little more than pass Windows messages to the control container managing the form.
            /// </summary>
            OLEMISC_SIMPLEFRAME = 0x010000,

            /// <summary>
            /// Indicates that the control wants to use <see cref="M:IOleObject.SetClientSite"/> as its initialization function, even before a call such as <b>IPersistStreamInit::InitNew</b> or IPersistStorage::InitNew.
            /// </summary>
            OLEMISC_SETCLIENTSITEFIRST = 0x020000,

            /// <summary>
            /// A control that works with an Input Method Editor (IME) system component can control the state of the IME through the IMEMode property rather than using this value in the OLEMISC enumeration.
            /// </summary>
            [Obsolete]
            OLEMISC_IMEMODE = 0x040000,

            /// <summary>
            /// For new ActiveX controls to work in an older container, the control may need to have the <see cref="OLEMISC_ACTIVATEWHENVISIBLE"/> value set.
            /// </summary>
            OLEMISC_IGNOREACTIVATEWHENVISIBLE = 0x080000,

            /// <summary>
            /// A control that can merge its menu with its container sets this value.
            /// </summary>
            OLEMISC_WANTSTOMENUMERGE = 0x100000,

            /// <summary>
            /// A control that supports multi-level undo sets this value.
            /// </summary>
            OLEMISC_SUPPORTSMULTILEVELUNDO = 0x200000
        }
    }
}