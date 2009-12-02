//-----------------------------------------------------------------------
// <copyright file="WebBrowserEx+WebBrowserExSite+IServiceProvider.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IServiceProvider implementation for the WebBrowserEx's WebBrowserExSite.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Forms
{
    using System;
    using PauloMorgado.Windows.Interop;

    /// <content>
    /// <see cref="T:IServiceProvider" /> implementation for the <see cref="WebBrowserEx" />'s <see cref="WebBrowserExSite" />.
    /// </content>
    public partial class WebBrowserEx
    {
        /// <content>
        /// <see cref="T:IServiceProvider" /> implementation for the <see cref="WebBrowserEx" />'s <see cref="WebBrowserExSite" />.
        /// </content>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Interop Code")]
        protected partial class WebBrowserExSite : UnsafeNativeMethods.IServiceProvider
        {
            #region IServiceProvider Members

            public int QueryService(IntPtr pguidService, IntPtr priid, out IntPtr ppvObject)
            {
                ppvObject = IntPtr.Zero;

                /*
                if ((pguidService != IntPtr.Zero) && (this.webBrowserControlShim.ServiceProvidersInternal != null))
                {
                    Guid guidService = (Guid)Marshal.PtrToStructure(pguidService, typeof(Guid));

                    ppvObject = this.webBrowserControlShim.ServiceProvidersInternal.GetOleServiceProviderPtr(guidService);

                    //    System.Diagnostics.Debug.WriteLine(guidService, "WebBrowserControlSite.IServiceProvider.QueryService");

                    //    if (guidService == typeof(Interop.UnsafeNativeMethods.IInternetSecurityManager).GUID)
                    //    {
                    //        ppvObject = Marshal.GetComInterfaceForObject(this.InternetSecurityManagerService, typeof(Interop.UnsafeNativeMethods.IInternetSecurityManager));
                    //    }
                }
                */

                return (ppvObject == IntPtr.Zero) ? Interop.UnsafeNativeMethods.HRESULT.E_NOINTERFACE : Interop.UnsafeNativeMethods.HRESULT.S_OK;
            }

            #endregion
        }
    }
}
