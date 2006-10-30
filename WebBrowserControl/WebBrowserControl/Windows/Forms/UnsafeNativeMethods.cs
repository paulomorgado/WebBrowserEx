using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Pajocomo.Windows.Forms
{
    public static partial class UnsafeNativeMethods
    {
        private static readonly MethodInfo GetDCMethodInfo;
        private static readonly MethodInfo ReleaseDCMethodInfo;

        static UnsafeNativeMethods()
        {
            Type windowsFormsUnsafeNativeMethodsType = Type.GetType("System.Windows.Forms.UnsafeNativeMethods," + typeof(System.Windows.Forms.Control).Assembly.FullName);

            UnsafeNativeMethods.GetDCMethodInfo = windowsFormsUnsafeNativeMethodsType.GetMethod("GetDC",
                BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof(HandleRef) }, null);
            UnsafeNativeMethods.ReleaseDCMethodInfo = windowsFormsUnsafeNativeMethodsType.GetMethod("ReleaseDC",
                BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof(HandleRef), typeof(HandleRef) }, null);
        }

        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        /// <param name="pt">Pointer to a <see cref="NativeMethods.POINT"/> structure that receives the screen coordinates of the cursor.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool GetCursorPos([In, Out] NativeMethods.POINT pt);

        /// <summary>
        /// Gets device-specific information for the specified device.
        /// </summary>
        /// <param name="hDC">The Handle to the DC.</param>
        /// <param name="nIndex">Specifies the item to return..</param>
        /// <returns>The return value specifies the value of the desired item.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int GetDeviceCaps(HandleRef hDC, int nIndex);

        /// <summary>
        /// Gets a handle to the specified window's parent or owner..
        /// </summary>
        /// <param name="hWnd">Handle to the window whose parent window handle is to be retrieved..</param>
        /// <returns>If the window is a child window, the return value is a handle to the parent window.
        /// If the window is a top-level window, the return value is a handle to the owner window.
        /// If the window is a top-level unowned window or if the function fails, the return value is <see langword="null"/>.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr GetParent(HandleRef hWnd);

        /// <summary>
        /// Changes the parent window of the specified child window.
        /// </summary>
        /// <param name="hWnd">Handle to the child window.</param>
        /// <param name="hWndParent">Handle to the new parent window.</param>
        /// <returns>If the function succeeds, the return value is a handle to the previous parent window.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr SetParent(HandleRef hWnd, HandleRef hWndParent);

        /// <summary>
        /// Creates a single uninitialized object of the class associated with a specified <paramref name="clsid">CLSID</paramref>.
        /// </summary>
        /// <remarks>
        /// Call <see cref="M:CoCreateInstance"/> when you want to create only one object on the local system. To create a single object on a remote system,
        /// call <see cref="M:CoCreateInstanceEx"/>, as <see cref="M:CoCreateInstance"/> requires that the HKCR\APPID\{appid}\RemoteServerName key be set to specify where
        /// remote activation of the object must occur. To create multiple objects based on a single CLSID, refer to the <see cref="M:CoGetClassObject"/> function.
        /// <seealso cref="http://windowssdk.msdn.microsoft.com/en-us/library/ms686615.aspx"/>
        /// </remarks>
        /// <param name="clsid">CLSID associated with the data and code that will be used to create the object.</param>
        /// <param name="punkOuter"><see langword="null"/> if the object is not being created as part of an aggregate;
        /// otherwise, a reference to the aggregate object's IUnknown interface (the controlling IUnknown).</param>
        /// <param name="context">Context in which the code that manages the newly created object will run. The values are taken from the enumeration <see cref="TActiveX:NativeMethods.tagCLSCTX"/>.</param>
        /// <param name="iid">Reference to the identifier of the interface to be used to communicate with the object.</param>
        /// <returns>The instance requested in <paramref name="riid"/>.</returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        [DllImport("ole32.dll", ExactSpelling = true, PreserveSig = false)]
        public static extern object CoCreateInstance(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid clsid,
            [In, MarshalAs(UnmanagedType.Interface)] object punkOuter,
            [In, MarshalAs(UnmanagedType.I4)] NativeMethods.tagCLSCTX context,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid iid);

        /// <summary>
        /// Creates a single uninitialized object of the class associated with a specified <typeparamref name="TActiveX">type</typeparamref>.
        /// </summary>
        /// <typeparam name="TClass">Class to create instance of.</typeparam>
        /// <typeparam name="TInterface">Interface to cast to.</typeparam>
        /// <param name="punkOuter"><see langword="null"/> if the object is not being created as part of an aggregate;
        /// otherwise, a reference to the aggregate object's IUnknown interface (the controlling IUnknown).</param>
        /// <param name="context">Context in which the code that manages the newly created object will run. The values are taken from the enumeration <see cref="TActiveX:NativeMethods.tagCLSCTX"/>.</param>
        /// <param name="iid">Reference to the identifier of the interface to be used to communicate with the object.</param>
        /// <returns>
        /// The instance requested in <paramref name="riid"/>.
        /// </returns>
        /// <remarks>
        /// Wrapper to <see cref="M:CoCreateInstance"/>.
        /// </remarks>
        /// <typeparam name="TActiveX">The type of the instance to be created.</typeparam>
        public static TInterface CoCreateInstance<TClass, TInterface>(object punkOuter, NativeMethods.tagCLSCTX context, Guid iid)
        {
            return (TInterface)CoCreateInstance(typeof(TClass).GUID, punkOuter, context, iid);
        }

        public static IntPtr GetDC(HandleRef hWnd)
        {
            return (IntPtr)(UnsafeNativeMethods.GetDCMethodInfo.Invoke(null, new object[] { hWnd }));
        }

        public static int ReleaseDC(HandleRef hWnd, HandleRef hDC)
        {
            return (int)(UnsafeNativeMethods.ReleaseDCMethodInfo.Invoke(null, new object[] { hWnd, hDC }));
        }


    }
}
