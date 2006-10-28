using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// Enables a windowless object to process window messages and participate in drag and drop operations.
        /// </summary>
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("1C2056CC-5EF4-101B-8BC8-00AA003E3B29")]
        public interface IOleInPlaceObjectWindowless : IOleInPlaceObject
        {
            /// <summary>
            /// Dispatches a message from the container to a windowless object.
            /// </summary>
            /// <param name="msg">Identifier for the window message provided to the container by Windows.</param>
            /// <param name="wParam">Parameter for the window message provided to the container by Windows.</param>
            /// <param name="lParam">Parameter for the window message provided to the container by Windows.</param>
            /// <param name="plResult">Pointer to result code for the window message as defined in the Windows API.</param>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int OnWindowMessage([In, MarshalAs(UnmanagedType.U4)] int msg, [In, MarshalAs(UnmanagedType.U4)] int wParam, [In, MarshalAs(UnmanagedType.U4)] int lParam, [Out, MarshalAs(UnmanagedType.U4)] int plResult);
            
            /// <summary>
            /// Supplies the IDropTarget interface for a windowless object that supports drag and drop.
            /// </summary>
            /// <param name="ppDropTarget">Address of IDropTarget* pointer variable that receives the interface pointer to the windowless object.</param>
            /// <returns>This method supports the standard return values.</returns>
            [PreserveSig]
            int GetDropTarget([Out, MarshalAs(UnmanagedType.Interface)] object ppDropTarget);
        }

    }
}
