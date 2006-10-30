using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Pajocomo.Windows.Forms
{
    public abstract partial class ActiveXBase<TActiveXClass, TActiveXInterface>
    {
        protected class ActiveXSiteBase :
            IDisposable,
            UnsafeNativeMethods.IOleClientSite,
            UnsafeNativeMethods.IOleControlSite,
            UnsafeNativeMethods.IOleInPlaceSite,
            UnsafeNativeMethods.IPropertyNotifySink,
            UnsafeNativeMethods.ISimpleFrameSite
        {
            private ActiveXBase<TActiveXClass, TActiveXInterface> host;
            private AxHost.ConnectionPointCookie connectionPoint;

            #region Instance lifecycle

            private ActiveXSiteBase()
            {
            }

            internal ActiveXSiteBase(ActiveXBase<TActiveXClass, TActiveXInterface> host)
            {
                if (host == null)
                {
                    throw new ArgumentNullException("host");
                }
                this.host = host;
            }

            /// <summary>
            /// Releases the unmanaged resources used by the <see cref="TActiveX:ActiveXSiteBase"></see> and optionally releases the managed resources.
            /// </summary>
            /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    this.StopEvents();
                }
            }

            #region IDisposable Members

            /// <summary>
            /// Releases all resources used by the <see cref="TActiveX:ActiveXSiteBase"></see>.
            /// </summary>
            public void Dispose()
            {
                this.Dispose(true);
            }

            #endregion

            #endregion

            private int OnActiveXRectChange(NativeMethods._RECT lprcPosRect)
            {
                this.Host.activeXOleInPlaceObject.SetObjectRects(NativeMethods._RECT.FromXYWH(0, 0, lprcPosRect.right - lprcPosRect.left, lprcPosRect.bottom - lprcPosRect.top), ActiveXHelper.GetClipRect());
                this.Host.MakeDirty();
                return 0;
            }

            protected internal ActiveXBase<TActiveXClass, TActiveXInterface> Host
            {
                get
                {
                    return this.host;
                }
            }

            protected internal virtual void StopEvents()
            {
                if (this.connectionPoint != null)
                {
                    this.connectionPoint.Disconnect();
                    this.connectionPoint = null;
                }
            }

            protected internal virtual void StartEvents()
            {
                if (this.connectionPoint == null && this.Host.activeXInstance != null)
                {
                    try
                    {
                        this.connectionPoint = new AxHost.ConnectionPointCookie(this.Host.activeXInstance, this, typeof(UnsafeNativeMethods.IPropertyNotifySink));
                    }
                    catch (Exception ex)
                    {
                        if (Utils.IsCriticalException(ex))
                        {
                            throw;
                        }
                    }
                }
            }

            protected virtual void OnPropertyChanged(int dispid)
            {
                try
                {
                    if (this.Host.Site != null)
                    {
                        IComponentChangeService componentChangeService = (IComponentChangeService)this.Host.Site.GetService(typeof(IComponentChangeService));
                        if (componentChangeService != null)
                        {
                            try
                            {
                                componentChangeService.OnComponentChanging(this.Host, null);
                            }
                            catch (CheckoutException checkoutException)
                            {
                                if (checkoutException != CheckoutException.Canceled)
                                {
                                    throw checkoutException;
                                }
                                return;
                            }
                            componentChangeService.OnComponentChanged(this.Host, null, null, null);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            #region IOleClientSite Members

            int UnsafeNativeMethods.IOleClientSite.GetContainer(out UnsafeNativeMethods.IOleContainer container)
            {
                container = this.Host.GetParentContainer();
                return NativeMethods.HRESULT.S_OK;
            }

            int UnsafeNativeMethods.IOleClientSite.GetMoniker(NativeMethods.tagOLEGETMONIKER dwAssign, NativeMethods.tagOLEWHICHMK dwWhichMoniker, out object moniker)
            {
                moniker = null;
                return NativeMethods.HRESULT.E_NOTIMPL;
            }

            int UnsafeNativeMethods.IOleClientSite.OnShowWindow(bool fShow)
            {
                return NativeMethods.HRESULT.S_OK;
            }

            int UnsafeNativeMethods.IOleClientSite.RequestNewObjectLayout()
            {
                return NativeMethods.HRESULT.E_NOTIMPL;
            }

            int UnsafeNativeMethods.IOleClientSite.SaveObject()
            {
                return NativeMethods.HRESULT.E_NOTIMPL;
            }

            int UnsafeNativeMethods.IOleClientSite.ShowObject()
            {
                if (this.Host.activeXState >= ActiveXHelper.ActiveXState.InPlaceActive)
                {
                    IntPtr window = this.Host.activeXOleInPlaceObject.GetWindow();
                    if (NativeMethods.Succeeded(window))
                    {
                        if ((this.Host.GetHandleNoCreate() != window) && (window != IntPtr.Zero))
                        {
                            this.Host.AttachWindow(window);
                            this.OnActiveXRectChange(new NativeMethods._RECT(this.Host.Bounds));
                        }
                    }
                    else if (this.Host.activeXOleInPlaceObject is UnsafeNativeMethods.IOleInPlaceObjectWindowless)
                    {
                        throw new InvalidOperationException(ResourcesHelper.GetString(ResourcesHelper.ActiveXWindowlessControl));
                    }
                }
                return NativeMethods.HRESULT.S_OK;
            }

            #endregion

            #region IOleControlSite Members

            int UnsafeNativeMethods.IOleControlSite.OnControlInfoChanged()
            {
                return NativeMethods.HRESULT.S_OK;
            }

            int UnsafeNativeMethods.IOleControlSite.LockInPlaceActive(int fLock)
            {
                return NativeMethods.HRESULT.E_NOTIMPL;
            }

            int UnsafeNativeMethods.IOleControlSite.GetExtendedControl(out object ppDisp)
            {
                ppDisp = null;
                return NativeMethods.HRESULT.E_NOTIMPL;
            }

            int UnsafeNativeMethods.IOleControlSite.TransformCoords(NativeMethods._POINTL pPtlHimetric, NativeMethods.tagPOINTF pPtfContainer, NativeMethods.tagXFORMCOORDS dwFlags)
            {
                if ((dwFlags & NativeMethods.tagXFORMCOORDS.XFORMCOORDS_HIMETRICTOCONTAINER) != 0)
                {
                    if ((dwFlags & NativeMethods.tagXFORMCOORDS.XFORMCOORDS_SIZE) != 0)
                    {
                        pPtfContainer.x = ActiveXHelper.HM2Pix(pPtlHimetric.x, ActiveXHelper.LogPixelsX);
                        pPtfContainer.y = ActiveXHelper.HM2Pix(pPtlHimetric.y, ActiveXHelper.LogPixelsY);
                        return NativeMethods.HRESULT.S_OK;
                    }
                    if ((dwFlags & NativeMethods.tagXFORMCOORDS.XFORMCOORDS_POSITION) != 0)
                    {
                        pPtfContainer.x = ActiveXHelper.HM2Pix(pPtlHimetric.x, ActiveXHelper.LogPixelsX);
                        pPtfContainer.y = ActiveXHelper.HM2Pix(pPtlHimetric.y, ActiveXHelper.LogPixelsY);
                        return NativeMethods.HRESULT.S_OK;
                    }
                    return NativeMethods.HRESULT.E_INVALIDARG;
                }
                if ((dwFlags & NativeMethods.tagXFORMCOORDS.XFORMCOORDS_CONTAINERTOHIMETRIC) != 0)
                {
                    if ((dwFlags & NativeMethods.tagXFORMCOORDS.XFORMCOORDS_SIZE) != 0)
                    {
                        pPtlHimetric.x = ActiveXHelper.Pix2HM((int)pPtfContainer.x, ActiveXHelper.LogPixelsX);
                        pPtlHimetric.y = ActiveXHelper.Pix2HM((int)pPtfContainer.y, ActiveXHelper.LogPixelsY);
                        return NativeMethods.HRESULT.S_OK;
                    }
                    if ((dwFlags & NativeMethods.tagXFORMCOORDS.XFORMCOORDS_POSITION) != 0)
                    {
                        pPtlHimetric.x = ActiveXHelper.Pix2HM((int)pPtfContainer.x, ActiveXHelper.LogPixelsX);
                        pPtlHimetric.y = ActiveXHelper.Pix2HM((int)pPtfContainer.y, ActiveXHelper.LogPixelsY);
                        return NativeMethods.HRESULT.S_OK;
                    }
                }
                return NativeMethods.HRESULT.E_INVALIDARG;
            }

            int UnsafeNativeMethods.IOleControlSite.TranslateAccelerator(ref NativeMethods.MSG pMsg, NativeMethods.tagKEYMODIFIERS grfModifiers)
            {
                int num1;
                this.Host.SetActiveXHostState(ActiveXHelper.SiteProcessedInputKey, true);
                Message message1 = new Message();
                message1.Msg = pMsg.message;
                message1.WParam = pMsg.wParam;
                message1.LParam = pMsg.lParam;
                message1.HWnd = pMsg.hwnd;
                try
                {
                    num1 = (this.Host.PreProcessControlMessage(ref message1) == PreProcessControlState.MessageProcessed) ? 0 : 1;
                }
                finally
                {
                    this.Host.SetActiveXHostState(ActiveXHelper.SiteProcessedInputKey, false);
                }
                return num1;
            }

            int UnsafeNativeMethods.IOleControlSite.OnFocus(bool fGotFocus)
            {
                return NativeMethods.HRESULT.S_OK;
            }

            int UnsafeNativeMethods.IOleControlSite.ShowPropertyFrame()
            {
                return NativeMethods.HRESULT.E_NOTIMPL;
            }

            #endregion

            #region IOleInPlaceSite Members

            int UnsafeNativeMethods.IOleInPlaceSite.CanInPlaceActivate()
            {
                return NativeMethods.HRESULT.S_OK;
            }

            int UnsafeNativeMethods.IOleInPlaceSite.OnInPlaceActivate()
            {
                this.Host.activeXState = ActiveXHelper.ActiveXState.InPlaceActive;
                this.OnActiveXRectChange(new NativeMethods._RECT(this.Host.Bounds));
                return NativeMethods.HRESULT.S_OK;
            }

            int UnsafeNativeMethods.IOleInPlaceSite.OnUIActivate()
            {
                this.Host.activeXState = ActiveXHelper.ActiveXState.UIActive;
                this.Host.GetParentContainer().OnUIActivate(this.Host);
                return NativeMethods.HRESULT.S_OK;
            }

            int UnsafeNativeMethods.IOleInPlaceSite.GetWindowContext(out UnsafeNativeMethods.IOleInPlaceFrame ppFrame, out UnsafeNativeMethods.IOleInPlaceUIWindow ppDoc, NativeMethods._RECT lprcPosRect, NativeMethods._RECT lprcClipRect, NativeMethods.tagOIFI lpFrameInfo)
            {
                ppDoc = null;
                ppFrame = this.Host.GetParentContainer();
                lprcPosRect.left = this.Host.Bounds.X;
                lprcPosRect.top = this.Host.Bounds.Y;
                lprcPosRect.right = this.Host.Bounds.Width + this.Host.Bounds.X;
                lprcPosRect.bottom = this.Host.Bounds.Height + this.Host.Bounds.Y;
                lprcClipRect = ActiveXHelper.GetClipRect();
                if (lpFrameInfo != null)
                {
                    lpFrameInfo.cb = Marshal.SizeOf(typeof(NativeMethods.tagOIFI));
                    lpFrameInfo.fMDIApp = false;
                    lpFrameInfo.hAccel = IntPtr.Zero;
                    lpFrameInfo.cAccelEntries = 0;
                    lpFrameInfo.hwndFrame = (this.Host.Parent == null) ? IntPtr.Zero : this.Host.Parent.Handle;
                }
                return NativeMethods.HRESULT.S_OK;
            }

            int UnsafeNativeMethods.IOleInPlaceSite.Scroll(NativeMethods.tagSIZE scrollExtant)
            {
                return NativeMethods.HRESULT.S_FALSE;
            }

            int UnsafeNativeMethods.IOleInPlaceSite.OnUIDeactivate(int fUndoable)
            {
                this.Host.GetParentContainer().OnUIDeactivate(this.Host);
                if (this.Host.activeXState > ActiveXHelper.ActiveXState.InPlaceActive)
                {
                    this.Host.activeXState = ActiveXHelper.ActiveXState.InPlaceActive;
                }
                return NativeMethods.HRESULT.S_OK;
            }

            int UnsafeNativeMethods.IOleInPlaceSite.OnInPlaceDeactivate()
            {
                if (this.Host.activeXState == ActiveXHelper.ActiveXState.UIActive)
                {
                    ((UnsafeNativeMethods.IOleInPlaceSite)this).OnUIDeactivate(0);
                }
                this.Host.GetParentContainer().OnInPlaceDeactivate(this.Host);
                this.Host.activeXState = ActiveXHelper.ActiveXState.Running;
                return NativeMethods.HRESULT.S_OK;
            }

            int UnsafeNativeMethods.IOleInPlaceSite.DiscardUndoState()
            {
                return NativeMethods.HRESULT.S_OK;
            }

            int UnsafeNativeMethods.IOleInPlaceSite.DeactivateAndUndo()
            {
                return this.Host.activeXOleInPlaceObject.UIDeactivate();
            }

            int UnsafeNativeMethods.IOleInPlaceSite.OnPosRectChange(NativeMethods._RECT lprcPosRect)
            {
                return this.OnActiveXRectChange(lprcPosRect);
            }

            #endregion

            #region IOleWindow Members

            IntPtr UnsafeNativeMethods.IOleWindow.GetWindow()
            {
                IntPtr parentWindowPtr;
                try
                {
                    parentWindowPtr = UnsafeNativeMethods.GetParent(new HandleRef(this.Host, this.Host.Handle));
                }
                catch (Exception)
                {
                    throw;
                }
                return parentWindowPtr;
            }

            int UnsafeNativeMethods.IOleWindow.ContextSensitiveHelp(bool fEnterMode)
            {
                return NativeMethods.HRESULT.E_NOTIMPL;
            }

            #endregion

            #region IPropertyNotifySink Members

            void UnsafeNativeMethods.IPropertyNotifySink.OnChanged(int dispID)
            {
                if (this.Host.numberOfComponentChangeEvents == 0)
                {
                    this.Host.numberOfComponentChangeEvents++;
                    try
                    {
                        this.OnPropertyChanged(dispID);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        this.Host.numberOfComponentChangeEvents--;
                    }
                }
            }

            int UnsafeNativeMethods.IPropertyNotifySink.OnRequestEdit(int dispID)
            {
                return NativeMethods.HRESULT.S_OK;
            }

            #endregion

            #region ISimpleFrameSite Members

            int UnsafeNativeMethods.ISimpleFrameSite.PreMessageFilter(IntPtr hwnd, int msg, IntPtr wp, IntPtr lp, ref IntPtr plResult, ref int pdwCookie)
            {
                return NativeMethods.HRESULT.S_OK;
            }

            int UnsafeNativeMethods.ISimpleFrameSite.PostMessageFilter(IntPtr hwnd, int msg, IntPtr wp, IntPtr lp, ref IntPtr plResult, int dwCookie)
            {
                return NativeMethods.HRESULT.S_FALSE;
            }

            #endregion
        }
    }
}