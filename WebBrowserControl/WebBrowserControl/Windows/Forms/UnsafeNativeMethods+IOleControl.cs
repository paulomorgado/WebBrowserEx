using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;

namespace Pajocomo.Windows.Forms
{
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// Provides the features for supporting keyboard mnemonics (GetControlInfo, OnMnemonic), ambient properties (OnAmbientPropertyChange), and events (FreezeEvents) in control objects.
        /// </summary>
        [ComImport, Guid("B196B288-BAB4-101A-B69C-00AA00341D07"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), SuppressUnmanagedCodeSecurity]
        public interface IOleControl
        {
            /// <summary>
            /// Fills in a CONTROLINFO structure with information about a control's keyboard mnemonics and keyboard behavior.
            /// </summary>
            /// <param name="pCI">Pointer to the caller-allocated CONTROLINFO structure to be filled in.</param>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int GetControlInfo([Out] NativeMethods.tagCONTROLINFO pCI);

            /// <summary>
            /// Informs a control that the user has pressed a keystroke that matches one of the ACCEL entries in the mnemonic table returned through <see cref="IOleControl.GetControlInfo"/>. The control takes whatever action is appropriate for the keystroke.
            /// </summary>
            /// <param name="pMsg">Pointer to the <see cref="NativeMethods.MSG"/> structure describing the keystroke to be processed.</param>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int OnMnemonic([In] ref NativeMethods.MSG pMsg);

            /// <summary>
            /// Informs a control that one or more of the container's ambient properties (available through the control site's IDispatch) has changed.
            /// </summary>
            /// <param name="dispID">Dispatch identifier of the ambient property that changed. If the dispID parameter is DISPID_UNKNOWN, it indicates that multiple properties changed.</param>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int OnAmbientPropertyChange(int dispID);

            /// <summary>
            /// Indicates whether the container is ignoring or accepting events from the control.
            /// </summary>
            /// <param name="bFreeze">Indicates whether the container will ignore (<see langword="true"/>) or now process (<see langword="false"/>) events from the control.</param>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int FreezeEvents(bool bFreeze);
        }
    }
}
