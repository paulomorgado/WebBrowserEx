//-----------------------------------------------------------------------
// <copyright file="WebBrowserEx+WebBrowserExSite+IDocHostShowUI.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IDocHostShowUI implementation for the WebBrowserEx's WebBrowserExSite.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Forms
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using PauloMorgado.Windows.Interop;
    using PauloMorgado.Windows.WebBrowser;

    /// <content>
    /// <see cref="T:IDocHostShowUI" /> implementation for the <see cref="WebBrowserEx" />'s <see cref="WebBrowserExSite" />.
    /// </content>
    public partial class WebBrowserEx
    {
        /// <content>
        /// <see cref="T:IDocHostShowUI" /> implementation for the <see cref="WebBrowserEx" />'s <see cref="WebBrowserExSite" />.
        /// </content>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Interop Code")]
        protected partial class WebBrowserExSite :
            UnsafeNativeMethods.IDocHostShowUI
        {
            #region IDocHostShowUI Members
            uint UnsafeNativeMethods.IDocHostShowUI.ShowMessage(IntPtr hwnd, string lpstrText, string lpstrCaption, uint dwType, string lpstrHelpFile, uint dwHelpContext, out int lpResult)
            {
                WebBrowserShowMessageEventArgs showMessageEventArgs = new WebBrowserShowMessageEventArgs(
                    NativeWindow.FromHandle(hwnd),
                    lpstrText,
                    lpstrCaption,
                    (MessageBoxButtons)(dwType & 0xF),
                    (MessageBoxIcon)(dwType & 0xF0),
                    lpstrHelpFile,
                    dwHelpContext);

                this.Host.OnShowMessage(showMessageEventArgs);

                if (showMessageEventArgs.Handled)
                {
                    lpResult = (int)(showMessageEventArgs.Result);
                    return UnsafeNativeMethods.HRESULT.S_OK;
                }
                else
                {
                    lpResult = 0;
                    return UnsafeNativeMethods.HRESULT.S_FALSE;
                }
            }

            uint UnsafeNativeMethods.IDocHostShowUI.ShowHelp(IntPtr hwnd, string pszHelpFile, uint uCommand, uint dwData, Interop.NativeMethods.POINT ptMouse, object pDispatchObjectHit)
            {
                WebBrowserShowHelpEventArgs showHelpEventArgs = new WebBrowserShowHelpEventArgs(
                    NativeWindow.FromHandle(hwnd),
                    pszHelpFile,
                    (WebBrowserHelpTypes)uCommand,
                    dwData,
                    new Point(ptMouse.x, ptMouse.y),
                    pDispatchObjectHit);

                this.Host.OnShowHelp(showHelpEventArgs);

                if (showHelpEventArgs.Handled)
                {
                    return UnsafeNativeMethods.HRESULT.S_OK;
                }
                else
                {
                    return UnsafeNativeMethods.HRESULT.S_FALSE;
                }
            }

            #endregion
        }
    }
}
