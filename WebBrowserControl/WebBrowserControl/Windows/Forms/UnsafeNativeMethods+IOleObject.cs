using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;

namespace Pajocomo.Windows.Forms
{
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// Represents the principal means by which an embedded object provides basic functionality to, and communicates with, its container.
        /// </summary>
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000112-0000-0000-C000-000000000046"), SuppressUnmanagedCodeSecurity]
        public interface IOleObject
        {
            /// <summary>
            /// Informs object of its client site in container.
            /// </summary>
            /// <param name="pClientSite">Pointer to the IOleClientSite interface on the container application's client-site.</param>
            /// <returns>This method supports the <see cref="T:NativeMethods.HRESULT">standard return values</see>.</returns>
            [PreserveSig]
            NativeMethods.HRESULT SetClientSite(
                [In, MarshalAs(UnmanagedType.Interface)] UnsafeNativeMethods.IOleClientSite pClientSite);

            /// <summary>
            /// Obtains a pointer to an embedded object's client site.
            /// </summary>
            /// <returns>Address of <see cref="UnsafeNativeMethods.IOleClientSite"/>* pointer variable that receives the interface pointer to the object's client site.</returns>
            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethods.IOleClientSite GetClientSite();

            /// <summary>
            /// Provides an object with the name of its container application and the compound document in which it is embedded.
            /// </summary>
            /// <param name="szContainerApp">Pointer to the name of the container application in which the object is running.</param>
            /// <param name="szContainerObj">Pointer to the name of the compound document that contains the object. If you do not wish to display the name of the compound document, you can set this parameter to <see langword="null"/>.</param>
            /// <returns>This method supports the <see cref="T:NativeMethods.HRESULT">standard return values</see>.</returns>
            [PreserveSig]
            NativeMethods.HRESULT SetHostNames(
                [In, MarshalAs(UnmanagedType.LPWStr)] string szContainerApp,
                [In, MarshalAs(UnmanagedType.LPWStr)] string szContainerObj);

            /// <summary>
            /// Changes an embedded object from the running to the loaded state. Disconnects a linked object from its link source.
            /// </summary>
            /// <param name="dwSaveOption"></param>
            /// <returns>Indicates whether the object is to be saved as part of the transition to the loaded state. Valid values are taken from the enumeration <see cref="NativeMethods.tagOLECLOSE"/>.</returns>
            [PreserveSig]
            NativeMethods.HRESULT Close(
                [In, MarshalAs(UnmanagedType.U4)] NativeMethods.tagOLECLOSE dwSaveOption);

            /// <summary>
            /// Notifies an object of its container's moniker, the object's own moniker relative to the container, or the object's full moniker.
            /// </summary>
            /// <param name="dwWhichMoniker">Value specifying which moniker is passed in pmk. Values are from the enumeration <see cref="NativeMethods.tagOLEWHICHMK"/>.</param>
            /// <param name="pmk">Pointer to where to return the moniker.</param>
            /// <returns>This method supports the <see cref="T:NativeMethods.HRESULT">standard return values</see>.</returns>
            [PreserveSig]
            NativeMethods.HRESULT SetMoniker(
                [In, MarshalAs(UnmanagedType.U4)] NativeMethods.tagOLEWHICHMK dwWhichMoniker,
                [In, MarshalAs(UnmanagedType.Interface)] object pmk);

            /// <summary>
            /// Retrieves an embedded object's moniker, which the caller can use to link to the object.
            /// </summary>
            /// <param name="dwAssign">Determines how the moniker is assigned to the object.</param>
            /// <param name="dwWhichMoniker">Specifies the form of the moniker being requested. Valid values are taken from the enumeration <see cref="NativeMethods.tagOLEWHICHMK"/>.</param>
            /// <param name="moniker"></param>
            /// <returns>The object's moniker (IMoniker interface).</returns>
            [return: MarshalAs(UnmanagedType.Interface)]
            int GetMoniker(
                [In, MarshalAs(UnmanagedType.U4)] NativeMethods.tagOLEGETMONIKER dwAssign,
                [In, MarshalAs(UnmanagedType.U4)] NativeMethods.tagOLEWHICHMK dwWhichMoniker);

            /// <summary>
            /// Initializes a newly created object with data from a specified data object, which can reside either in the same container or on the Clipboard.
            /// </summary>
            /// <param name="pDataObject">Pointer to the IDataObject interface on the data object from which the initialization data is to be obtained.</param>
            /// <param name="fCreation"><see langword="true"/> indicates the container is inserting a new object inside itself and initializing that object with data from the current selection; <see langword="false"/> indicates a more general programmatic data transfer, most likely from a source other than the current selection.</param>
            /// <param name="dwReserved">Reserved for future use; must be zero.</param>
            /// <returns>This method supports the <see cref="T:NativeMethods.HRESULT">standard return values</see>.</returns>
            [PreserveSig]
            NativeMethods.HRESULT InitFromData(
                [In, MarshalAs(UnmanagedType.Interface)] IDataObject pDataObject,
                [In, MarshalAs(UnmanagedType.Bool)] bool fCreation,
                [In, MarshalAs(UnmanagedType.U4)] int dwReserved);

            /// <summary>
            /// Retrieves a data object containing the current contents of the embedded object on which this method is called. Using the pointer to this data object, it is possible to create a new embedded object with the same data as the original.
            /// </summary>
            /// <param name="dwReserved">Reserved for future use; must be zero.</param>
            /// <returns>The <see cref="T:IDataObject">data object</see>.</returns>
            [return: MarshalAs(UnmanagedType.Interface)]
            IDataObject GetClipboardData(
                [In, MarshalAs(UnmanagedType.U4)] int dwReserved);

            /// <summary>
            /// Requests an object to perform an action in response to an end-user's action. The possible actions are enumerated for the object in IOleObject::EnumVerbs.
            /// </summary>
            /// <param name="iVerb">Number assigned to the verb in the <see cref="NativeMethods.OLEIVERB"/> structure returned by IOleObject::EnumVerbs.</param>
            /// <param name="lpmsg">Pointer to the MSG structure describing the event (such as a double-click) that invoked the verb.The caller should pass the MSG structure unmodified, without attempting to interpret or alter the values of any of the fields of lpmsg.</param>
            /// <param name="pActiveSite">Pointer to the <see cref="IOleClientSite"/> interface on the object's active client site, where the event occurred that invoked the verb.</param>
            /// <param name="lindex">Reserved for future use; must be zero.</param>
            /// <param name="hwndParent">Handle of the document window containing the object.</param>
            /// <param name="lprcPosRect">Pointer to the <see cref="NativeMethods._RECT"/> structure containing the coordinates, in pixels, that define an object's bounding rectangle in <paramref name="hwndParent"/>.</param>
            /// <returns>This method supports the <see cref="T:NativeMethods.HRESULT">standard return values</see>.</returns>
            [PreserveSig]
            NativeMethods.HRESULT DoVerb(
                [In, MarshalAs(UnmanagedType.U4)] NativeMethods.OLEIVERB iVerb,
                [In] IntPtr lpmsg,
                [In, MarshalAs(UnmanagedType.Interface)] UnsafeNativeMethods.IOleClientSite pActiveSite,
                [In, MarshalAs(UnmanagedType.U4)] int lindex,
                [In] IntPtr hwndParent,
                [In] NativeMethods._RECT lprcPosRect);

            /// <summary>
            /// Exposes a pull-down menu listing the verbs available for an object in ascending order by verb number.
            /// </summary>
            /// <returns>The interface pointer to the <see cref="UnsafeNativeMethods.IEnumOLEVERB">enumerator object</see>.</returns>
            [return: MarshalAs(UnmanagedType.Interface)]
            UnsafeNativeMethods.IEnumOLEVERB EnumVerbs();

            /// <summary>
            /// Updates an object handler's or link object's data or view caches.
            /// </summary>
            void Update();

            /// <summary>
            /// Checks recursively whether or not an object is up to date.
            /// </summary>
            void IsUpToDate();

            /// <summary>
            /// Returns an object's class identifier, the CLSID corresponding to the string identifying the object to an end user.
            /// </summary>
            /// <returns>The class identifier (CLSID). An object's CLSID is the binary equivalent of the user-type name returned by <see cref="M:IOleObject.GetUserType"/>.</returns>
            Guid GetUserClassID();

            /// <summary>
            /// Retrieves the user-type name of an object for display in user-interface elements such as menus, list boxes, and dialog boxes.
            /// </summary>
            /// <param name="dwFormOfType">Value specifying the form of the user-type name to be presented to users. Valid values are obtained from the <see cref="NativeMethods.tagUSERCLASSTYPE"/> enumeration.</param>
            /// <returns>The user type string.</returns>
            [return: MarshalAs(UnmanagedType.LPWStr)]
            int GetUserType(
                [In, MarshalAs(UnmanagedType.U4)] NativeMethods.tagUSERCLASSTYPE dwFormOfType);

            /// <summary>
            /// Informs an object of how much display space its container has assigned it.
            /// </summary>
            /// <param name="dwDrawAspect">Describes which form, or "aspect," of an object is to be displayed.</param>
            /// <param name="pSizel">The size limit for the object.</param>
            void SetExtent(
                [In, MarshalAs(UnmanagedType.U4)] NativeMethods.tagDVASPECT dwDrawAspect,
                [In, MarshalAs(UnmanagedType.LPStruct)] NativeMethods.tagSIZEL pSizel);

            /// <summary>
            /// Retrieves a running object's current display size.
            /// </summary>
            /// <param name="dwDrawAspect">Value indicating the aspect of the object whose limit is to be retrieved.</param>
            void GetExtent(
                [In, MarshalAs(UnmanagedType.U4)] NativeMethods.tagDVASPECT2 dwDrawAspect,
                [Out, MarshalAs(UnmanagedType.LPStruct)] NativeMethods.tagSIZEL pSizel);

            /// <summary>
            /// Establishes an advisory connection between a compound document object and the calling object's advise sink, through which the calling object receives notification when the compound document object is renamed, saved, or closed.
            /// </summary>
            /// <param name="pAdvSink">Pointer to the IAdviseSink interface on the advise sink of the calling object.</param>
            /// <returns>A <see langword="int"/> token that can be passed to IOleObject::Unadvise to delete the advisory connection.</returns>
            [return: MarshalAs(UnmanagedType.U4)]
            int Advise(
                [In, MarshalAs(UnmanagedType.U4)] IAdviseSink pAdvSink);

            /// <summary>
            /// Deletes a previously established advisory connection.
            /// </summary>
            /// <param name="dwConnection">Contains a token of nonzero value, which was previously returned from IOleObject::Advise through its pdwConnection parameter.</param>
            void Unadvise(
                [In, MarshalAs(UnmanagedType.U4)] int dwConnection);

            /// <summary>
            /// Retrieves a pointer to an enumerator that can be used to enumerate the advisory connections registered for an object, so a container can know what to release prior to closing down.
            /// </summary>
            /// <returns>The <see cref="T:IEnumSTATDATA">enumerator object</see>.</returns>
            [return: MarshalAs(UnmanagedType.Interface)]
            IEnumSTATDATA EnumAdvise();

            /// <summary>
            /// Returns a value indicating the status of an object at creation and loading.
            /// </summary>
            /// <param name="dwAspect">Value indicating the aspect of an object about which status information is being requested.</param>
            /// <returns>The status information.</returns>
            [return: MarshalAs(UnmanagedType.U4)]
            NativeMethods.tagOLEMISC GetMiscStatus(
                [In, MarshalAs(UnmanagedType.U4)] NativeMethods.tagDVASPECT dwAspect);

            /// <summary>
            /// Specifies the color palette that the object application should use when it edits the specified object.
            /// </summary>
            /// <param name="pLogpal">Pointer to a <see cref="T:NativeMethods.tagLOGPALETTE"/> structure that specifies the recommended palette.</param>
            void SetColorScheme(
                [In, MarshalAs(UnmanagedType.LPStruct)] NativeMethods.tagLOGPALETTE pLogpal);
        }
    }
}
