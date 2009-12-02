using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// Represents the primary means by which an embedded object obtains information about the location and extent of its display site, its moniker, its user interface, and other resources provided by its container.
        /// </summary>
        [ComImport, Guid("00000118-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IOleClientSite
        {
            /// <summary>
            /// Saves the object associated with the client site.
            /// </summary>
            void SaveObject();

            /// <summary>
            /// Returns a moniker to an object's client site.
            /// </summary>
            /// <param name="dwAssign">Specifies whether to get a moniker only if one already exists, force assignment of a moniker, create a temporary moniker, or remove a moniker that has been assigned.</param>
            /// <param name="dwWhichMoniker">Specifies whether to return the container's moniker, the object's moniker relative to the container, or the object's full moniker.</param>
            /// <returns>The moniker for the object's client site.</returns>
            [return: MarshalAs(UnmanagedType.Interface)]
            object GetMoniker(
                [In, MarshalAs(UnmanagedType.U4)] NativeMethods.tagOLEGETMONIKER dwAssign,
                [In, MarshalAs(UnmanagedType.U4)] NativeMethods.tagOLEWHICHMK dwWhichMoniker);

            /// <summary>
            /// Returns a pointer to the container's IOleContainer interface.
            /// </summary>
            /// <param name="container">Address of IOleContainer* pointer variable that receives the interface pointer to the container object.</param>
            /// <returns>The <see cref="T:UnsafeNativeMethods.IOleContainer">container</see> object.</returns>
            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethods.IOleContainer GetContainer();

            /// <summary>
            /// Tells the container to position the object so it is visible to the user. This method ensures that the container itself is visible and not minimized.
            /// </summary>
            void ShowObject();

            /// <summary>
            /// Notifies a container when an embedded object's window is about to become visible or invisible.
            /// </summary>
            /// <param name="fShow">Value that indicates whether an object's window is open (<see langword="true"/>) or closed (<see langword="false"/>).</param>
            void OnShowWindow(
                [In, MarshalAs(UnmanagedType.Bool)] bool fShow);

            /// <summary>
            /// Asks container to allocate more or less space for displaying an embedded object.
            /// </summary>
            void RequestNewObjectLayout();
        }
    }
}
