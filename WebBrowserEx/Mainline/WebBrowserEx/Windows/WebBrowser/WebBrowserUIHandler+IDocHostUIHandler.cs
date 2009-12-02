//-----------------------------------------------------------------------
// <copyright file="WebBrowserUIHandler+IDocHostUIHandler.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IDocHostUIHandler implementation.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using System;
    using System.Windows.Forms;
    using PauloMorgado.Windows.Interop;

    /// <content>
    /// <see cref="IDocHostUIHandler" /> implementation.
    /// </content>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Interop Code")]
    public partial class WebBrowserUIHandler : UnsafeNativeMethods.IDocHostUIHandler
    {
        #region IDocHostUIHandler Members

        int UnsafeNativeMethods.IDocHostUIHandler.ShowContextMenu(int dwID, NativeMethods.POINT pt, object pcmdtReserved, object pdispReserved)
        {
            return UnsafeNativeMethods.HRESULT.S_FALSE;
        }

        int UnsafeNativeMethods.IDocHostUIHandler.GetHostInfo(NativeMethods.DOCHOSTUIINFO info)
        {
            var capabilities = WebBrowserCapabilities.DisableScriptInactive;

            if (this.Parent.No3DOuterBorder)
            {
                capabilities |= WebBrowserCapabilities.No3DOuterBorder;
            }

            if (this.Parent.No3DBorder)
            {
                capabilities |= WebBrowserCapabilities.No3DBorder;
            }

            if (this.Parent.ScrollBarsEnabled)
            {
                capabilities |= WebBrowserCapabilities.FlatScrollbars;
            }
            else
            {
                capabilities |= WebBrowserCapabilities.NoScrollBars;
            }

            if (this.Parent.ScrollBarsEnabled)
            {
                capabilities |= WebBrowserCapabilities.FlatScrollbars;
            }
            else
            {
                capabilities |= WebBrowserCapabilities.NoScrollBars;
            }

            if (System.Windows.Forms.Application.RenderWithVisualStyles)
            {
                capabilities |= WebBrowserCapabilities.Theme;
            }
            else
            {
                capabilities |= WebBrowserCapabilities.NoTheme;
            }

            info.dwDoubleClick = WebBrowserDoubleClickActions.Default;
            info.dwFlags = this.Parent.GetWebBrowserCapabilities(capabilities);

            return UnsafeNativeMethods.HRESULT.S_OK;
        }

        int UnsafeNativeMethods.IDocHostUIHandler.ShowUI(int dwID, UnsafeNativeMethods.IOleInPlaceActiveObject activeObject, NativeMethods.IOleCommandTarget commandTarget, UnsafeNativeMethods.IOleInPlaceFrame frame, UnsafeNativeMethods.IOleInPlaceUIWindow doc)
        {
            return UnsafeNativeMethods.HRESULT.S_OK;
        }

        int UnsafeNativeMethods.IDocHostUIHandler.HideUI()
        {
            return UnsafeNativeMethods.HRESULT.S_OK;
        }

        int UnsafeNativeMethods.IDocHostUIHandler.UpdateUI()
        {
            return UnsafeNativeMethods.HRESULT.S_OK;
        }

        int UnsafeNativeMethods.IDocHostUIHandler.EnableModeless(bool fEnable)
        {
            return UnsafeNativeMethods.HRESULT.S_OK;
        }

        int UnsafeNativeMethods.IDocHostUIHandler.OnDocWindowActivate(bool fActivate)
        {
            return UnsafeNativeMethods.HRESULT.S_OK;
        }

        int UnsafeNativeMethods.IDocHostUIHandler.OnFrameWindowActivate(bool fActivate)
        {
            return UnsafeNativeMethods.HRESULT.S_OK;
        }

        int UnsafeNativeMethods.IDocHostUIHandler.ResizeBorder(NativeMethods.RECT rect, UnsafeNativeMethods.IOleInPlaceUIWindow doc, bool fFrameWindow)
        {
            return UnsafeNativeMethods.HRESULT.S_OK;
        }

        int UnsafeNativeMethods.IDocHostUIHandler.TranslateAccelerator(ref NativeMethods.MSG msg, ref Guid group, int nCmdID)
        {
            Message message = Message.Create(msg.hwnd, msg.message, msg.wParam, msg.lParam);
            bool handled = this.Parent.TranslateAccelerator(ref message);
            msg.hwnd = message.HWnd;
            msg.message = message.Msg;
            msg.wParam = message.WParam;
            msg.lParam = message.LParam;
            return (handled) ? UnsafeNativeMethods.HRESULT.S_OK : UnsafeNativeMethods.HRESULT.S_FALSE;
        }

        int UnsafeNativeMethods.IDocHostUIHandler.GetOptionKeyPath(string[] pbstrKey, int dw)
        {
            return UnsafeNativeMethods.HRESULT.S_OK;
        }

        int UnsafeNativeMethods.IDocHostUIHandler.GetDropTarget(UnsafeNativeMethods.IOleDropTarget pDropTarget, out UnsafeNativeMethods.IOleDropTarget ppDropTarget)
        {
            ppDropTarget = null;
            return UnsafeNativeMethods.HRESULT.S_OK;
        }

        int UnsafeNativeMethods.IDocHostUIHandler.GetExternal(out object ppDispatch)
        {
            ppDispatch = this.Parent.ObjectForScripting;

            return UnsafeNativeMethods.HRESULT.S_OK;
        }

        int UnsafeNativeMethods.IDocHostUIHandler.TranslateUrl(int dwTranslate, string strURLIn, out string pstrURLOut)
        {
            pstrURLOut = this.Parent.TranslateUrl(strURLIn);

            return (pstrURLOut == null) ? UnsafeNativeMethods.HRESULT.S_FALSE : UnsafeNativeMethods.HRESULT.S_OK;
        }

        int UnsafeNativeMethods.IDocHostUIHandler.FilterDataObject(System.Runtime.InteropServices.ComTypes.IDataObject pDO, out System.Runtime.InteropServices.ComTypes.IDataObject ppDORet)
        {
            ppDORet = null;
            return UnsafeNativeMethods.HRESULT.S_OK;
        }

        #endregion
    }
}
