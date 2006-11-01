using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// Provides the methods that enable a site object to manage each embedded control within a container.
        /// </summary>
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("B196B289-BAB4-101A-B69C-00AA00341D07")]
        public interface IOleControlSite
        {
            /// <summary>
            /// Informs the container that the control's CONTROLINFO structure has changed and that the container should call the control's <see cref="IOleControl.GetControlInfo"/> for an update.
            /// </summary>
            void OnControlInfoChanged();

            /// <summary>
            /// Indicates whether or not this control should remain in-place active, regardless of possible deactivation events.
            /// </summary>
            /// <param name="fLock">Indicates whether to ensure the in-place active state (<see langword="true"/>) or to allow activation to change (<see langword="false"/>).</param>
            void LockInPlaceActive(
                [In, MarshalAs(UnmanagedType.Bool)] bool fLock);

            /// <summary>
            /// Requests an IDispatch pointer to the extended control that the container uses to wrap the real control.
            /// </summary>
            /// <returns>The extended control.</returns>
            [return: MarshalAs(UnmanagedType.IDispatch)]
            object GetExtendedControl();

            /// <summary>
            /// Converts between a POINTL structure expressed in HIMETRIC units (as is standard in OLE) and a POINTF structure expressed in units the container specifies.
            /// </summary>
            /// <param name="pPtlHimetric"><see cref="T:NativeMethods._POINTL">coordinates</see> expressed in HIMETRIC units.</param>
            /// <param name="pPtfContainer">The converted <see cref="T:NativeMethods.tagPOINTF">coordinates</see>.</param>
            /// <param name="dwFlags">Flags indicating the exact conversion to perform.</param>
            void TransformCoords(
                [In, Out] NativeMethods._POINTL pPtlHimetric, 
                [In, Out] NativeMethods.tagPOINTF pPtfContainer, 
                [In, MarshalAs(UnmanagedType.U4)] NativeMethods.tagXFORMCOORDS dwFlags);

            /// <summary>
            /// Instructs the container to process a specified keystroke.
            /// </summary>
            /// <param name="pMsg">Pointer to the <see cref="NativeMethods.MSG"/> structure describing the keystroke to be processed.</param>
            /// <param name="grfModifiers">Flags describing the state of the Control, Alt, and Shift keys. The value of the flag can be any valid <see cref="NativeMethods.tagKEYMODIFIERS"/> enumeration values.</param>
            /// <returns><see cref="F:NativeMethods.HRESULT.S_OK"/> if the container processed the message; <see cref="F:NativeMethods.HRESULT.S_FALSE"/> if the container did not process the message.</returns>
            [PreserveSig]
            NativeMethods.HRESULT TranslateAccelerator(
                [In] ref NativeMethods.MSG pMsg, 
                [In, MarshalAs(UnmanagedType.U4)] NativeMethods.tagKEYMODIFIERS grfModifiers);

            /// <summary>
            /// Indicates whether the embedded control in this control site has gained or lost the focus.
            /// </summary>
            /// <param name="fGotFocus">Indicates whether the control gained (<see langword="true"/>) or lost the focus (<see langword="false"/>).</param>
            void OnFocus(
                [In, MarshalAs(UnmanagedType.Bool)] bool fGotFocus);

            /// <summary>
            /// Instructs the container to show a property page frame for the control object if the container so desires.
            /// </summary>
            void ShowPropertyFrame();
        }
    }
}
