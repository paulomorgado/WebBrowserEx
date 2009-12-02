using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Specifies the verb to execute.
        /// </summary>
        /// <remarks>
        /// A "verb" is an action that an OLE object takes in response to a message from its container. An object's
        /// container, or a client linked to the object, normally calls <see cref="IOleObject.DoVerb"/> in response to some end-user
        /// action, such as double-clicking on the object. The various actions that are available for a given object
        /// are enumerated in an OLEVERB structure, which the container obtains by calling <see cref="IOleObject.EnumVerbs"/>.
        /// <see cref="IOleObject.DoVerb"/> matches the value of iVerb against the iVerb member of the structure to determine which
        /// verb to invoke.
        /// <seealso cref="http://windowssdk.msdn.microsoft.com/en-us/library/ms694508.aspx"/>
        /// </remarks>
        public enum OLEIVERB : int
        {
            /// <summary>
            /// Defines the action taken when the user double-clicks the control.
            /// </summary>
            /// <remarks>
            /// Specifies the action that occurs when an end user double-clicks the object in its container.
            /// The object, not the container, determines this action. If the object supports in-place activation,
            /// the primary verb usually activates the object in place.
            /// </remarks>
            OLEIVERB_PRIMARY = 0,

            /// <summary>
            /// Tells the container to make the control visible.
            /// </summary>
            /// <remarks>
            /// Instructs an object to show itself for editing or viewing. Called to display newly inserted objects for
            /// initial editing and to show link sources. Usually an alias for some other object-defined verb.
            /// </remarks>
            OLEIVERB_SHOW = -1,

            /// <summary>
            /// Causes the control to be open-edited in a separate window.
            /// </summary>
            /// <remarks>
            /// Instructs an object, including one that otherwise supports in-place activation, to open itself for editing
            /// in a window separate from that of its container. If the object does not support in-place activation, this
            /// verb has the same semantics as OLEIVERB_SHOW.
            /// </remarks>
            OLEIVERB_OPEN = -2,

            /// <summary>
            /// Deactivates and removes the control's user interface, and hides the control.
            /// </summary>
            /// <remarks>
            /// Causes an object to remove its user interface from the view. Applies only to objects that are activated in-place.
            /// </remarks>
            OLEIVERB_HIDE = -3,

            /// <summary>
            /// Activates the control's user interface and notifies the container that its menus are being replaced by composite menus.
            /// </summary>
            /// <remarks>
            /// Activates an object in place, along with its full set of user-interface tools, including menus, toolbars, and its name
            /// in the title bar of the container window. If the object does not support in-place activation, it should return E_NOTIMPL.
            /// </remarks>
            OLEIVERB_UIACTIVATE = -4,

            /// <summary>
            /// Runs the control and installs its window, but does not install the control's user interface.
            /// </summary>
            /// <remarks>
            /// Activates an object in place without displaying tools, such as menus and toolbars, that end users need to change
            /// the behavior or appearance of the object. Single-clicking such an object causes it to negotiate the display of its
            /// user-interface tools with its container. If the container refuses, the object remains active but without its tools
            /// displayed.
            /// </remarks>
            OLEIVERB_INPLACEACTIVATE = -5,

            /// <summary>
            /// Tells the control to discard any undo state it is maintaining.
            /// </summary>
            /// <remarks>
            /// Used to tell objects to discard any undo state that they may be maintaining without deactivating the object.
            /// </remarks>
            OLEIVERB_DISCARDUNDOSTATE = -6
        }
    }
}
