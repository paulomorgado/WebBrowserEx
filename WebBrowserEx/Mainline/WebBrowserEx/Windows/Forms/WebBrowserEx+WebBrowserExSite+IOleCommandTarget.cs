//-----------------------------------------------------------------------
// <copyright file="WebBrowserEx+WebBrowserExSite+IOleCommandTarget.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IOleCommandTarget implementation for the WebBrowserEx's WebBrowserExSite.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Forms
{
    using System;
    using System.Runtime.InteropServices;
    using PauloMorgado.Windows.Interop;
    using PauloMorgado.Windows.WebBrowser;

    /// <content>
    /// <see cref="T:IOleCommandTarget" /> implementation for the <see cref="WebBrowserEx" />'s <see cref="WebBrowserExSite" />.
    /// </content>
    public partial class WebBrowserEx
    {
        /// <content>
        /// <see cref="T:IOleCommandTarget" /> implementation for the <see cref="WebBrowserEx" />'s <see cref="WebBrowserExSite" />.
        /// </content>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Interop Code")]
        protected partial class WebBrowserExSite :
            NativeMethods.IOleCommandTarget
        {
            #region IOleCommandTarget Members

            public int QueryStatus(IntPtr pguidCmdGroup, WebBrowserCommands cCmds, IntPtr prgCmds, IntPtr pCmdText)
            {
                return UnsafeNativeMethods.HRESULT.S_OK;
            }

            public int Exec(IntPtr pguidCmdGroup, WebBrowserCommands nCmdID, WebBrowserCommandOptions nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
            {
                ////if (pguidCmdGroup is Guid)
                if (pguidCmdGroup != IntPtr.Zero)
                {
                    Guid guidCmdGroup = (Guid)Marshal.PtrToStructure(pguidCmdGroup, typeof(Guid));
                    ////Guid guidCmdGroup = (Guid)pguidCmdGroup;
                    if (guidCmdGroup == Interop.UnsafeNativeMethods.DocHostCommandHandlerCgid)
                    {
                        switch (nCmdID)
                        {
                            case WebBrowserCommands.ShowScriptError:
                                var htmlDocument = (pvaIn != IntPtr.Zero) ? Marshal.GetObjectForNativeVariant(pvaIn) : null;

                                var scriptErrorEventArgs = new WebBrowserScriptErrorEventArgs(htmlDocument);

                                this.Host.OnScriptError(scriptErrorEventArgs);

                                if (!scriptErrorEventArgs.Handled)
                                {
                                    return Interop.UnsafeNativeMethods.HRESULT.S_FALSE;
                                }

                                if (pvaOut != IntPtr.Zero)
                                {
                                    Marshal.GetNativeVariantForObject(scriptErrorEventArgs.ContinueScripts, pvaOut);
                                }

                                return Interop.UnsafeNativeMethods.HRESULT.S_OK;
                        }

                        return Interop.NativeMethods.OLECMDERR.OLECMDERR_E_NOTSUPPORTED;
                    }
                }

                return Interop.NativeMethods.OLECMDERR.OLECMDERR_E_UNKNOWNGROUP;
            }

            #endregion
        }
    }
}
