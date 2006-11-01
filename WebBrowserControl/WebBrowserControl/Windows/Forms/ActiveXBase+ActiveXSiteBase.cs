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

            UnsafeNativeMethods.IOleContainer UnsafeNativeMethods.IOleClientSite.GetContainer()
            {
                return this.Host.GetParentContainer();
            }

            object UnsafeNativeMethods.IOleClientSite.GetMoniker(NativeMethods.tagOLEGETMONIKER dwAssign, NativeMethods.tagOLEWHICHMK dwWhichMoniker)
            {
                throw new COMException("IOleClientSite", (int)NativeMethods.HRESULT.E_NOTIMPL);
            }

            void UnsafeNativeMethods.IOleClientSite.OnShowWindow(bool fShow)
            {
            }

            void UnsafeNativeMethods.IOleClientSite.RequestNewObjectLayout()
            {
                throw new COMException("IOleClientSite", (int)NativeMethods.HRESULT.E_NOTIMPL);
            }

            void UnsafeNativeMethods.IOleClientSite.SaveObject()
            {
                throw new COMException("IOleClientSite", (int)NativeMethods.HRESULT.E_NOTIMPL);
            }

            void UnsafeNativeMethods.IOleClientSite.ShowObject()
            {
                if (this.Host.activeXState >= ActiveXHelper.ActiveXState.InPlaceActive)
                {
                    IntPtr window = this.Host.activeXOleInPlaceObject.GetWindow();
                    if (window != IntPtr.Zero)
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
            }

            #endregion

            #region IOleControlSite Members

            object UnsafeNativeMethods.IOleControlSite.GetExtendedControl()
            {
                throw new COMException("IOleControlSite", (int)NativeMethods.HRESULT.E_NOTIMPL);
            }

            void UnsafeNativeMethods.IOleControlSite.LockInPlaceActive(bool fLock)
            {
                throw new COMException("IOleControlSite", (int)NativeMethods.HRESULT.E_NOTIMPL);
            }

            void UnsafeNativeMethods.IOleControlSite.OnControlInfoChanged()
            {
            }

            void UnsafeNativeMethods.IOleControlSite.OnFocus(bool fGotFocus)
            {
            }

            void UnsafeNativeMethods.IOleControlSite.ShowPropertyFrame()
            {
                throw new COMException("IOleControlSite", (int)NativeMethods.HRESULT.E_NOTIMPL);
            }

            void UnsafeNativeMethods.IOleControlSite.TransformCoords(NativeMethods._POINTL pPtlHimetric, NativeMethods.tagPOINTF pPtfContainer, NativeMethods.tagXFORMCOORDS dwFlags)
            {
                if ((dwFlags & NativeMethods.tagXFORMCOORDS.XFORMCOORDS_HIMETRICTOCONTAINER) != 0)
                {
                    if ((dwFlags & NativeMethods.tagXFORMCOORDS.XFORMCOORDS_SIZE) != 0)
                    {
                        pPtfContainer.x = ActiveXHelper.HM2Pix(pPtlHimetric.x, ActiveXHelper.LogPixelsX);
                        pPtfContainer.y = ActiveXHelper.HM2Pix(pPtlHimetric.y, ActiveXHelper.LogPixelsY);
                        return;
                    }
                    if ((dwFlags & NativeMethods.tagXFORMCOORDS.XFORMCOORDS_POSITION) != 0)
                    {
                        pPtfContainer.x = ActiveXHelper.HM2Pix(pPtlHimetric.x, ActiveXHelper.LogPixelsX);
                        pPtfContainer.y = ActiveXHelper.HM2Pix(pPtlHimetric.y, ActiveXHelper.LogPixelsY);
                        return;
                    }
                    throw new COMException("IOleControlSite", (int)NativeMethods.HRESULT.E_INVALIDARG);
                }
                if ((dwFlags & NativeMethods.tagXFORMCOORDS.XFORMCOORDS_CONTAINERTOHIMETRIC) != 0)
                {
                    if ((dwFlags & NativeMethods.tagXFORMCOORDS.XFORMCOORDS_SIZE) != 0)
                    {
                        pPtlHimetric.x = ActiveXHelper.Pix2HM((int)pPtfContainer.x, ActiveXHelper.LogPixelsX);
                        pPtlHimetric.y = ActiveXHelper.Pix2HM((int)pPtfContainer.y, ActiveXHelper.LogPixelsY);
                        return;
                    }
                    if ((dwFlags & NativeMethods.tagXFORMCOORDS.XFORMCOORDS_POSITION) != 0)
                    {
                        pPtlHimetric.x = ActiveXHelper.Pix2HM((int)pPtfContainer.x, ActiveXHelper.LogPixelsX);
                        pPtlHimetric.y = ActiveXHelper.Pix2HM((int)pPtfContainer.y, ActiveXHelper.LogPixelsY);
                        return;
                    }
                }
                throw new COMException("IOleControlSite", (int)NativeMethods.HRESULT.E_INVALIDARG);
            }

            /// <summary>
            /// Instructs the container to process a specified keystroke.
            /// </summary>
            /// <param name="pMsg">Pointer to the <see cref="NativeMethods.MSG"/> structure describing the keystroke to be processed.</param>
            /// <param name="grfModifiers">Flags describing the state of the Control, Alt, and Shift keys. The value of the flag can be any valid <see cref="NativeMethods.tagKEYMODIFIERS"/> enumeration values.</param>
            /// <returns>
            /// 	<see langword="false"/> if the container processed the message; otherwise <see langword="true"/>.
            /// </returns>
            NativeMethods.HRESULT UnsafeNativeMethods.IOleControlSite.TranslateAccelerator(ref NativeMethods.MSG pMsg, NativeMethods.tagKEYMODIFIERS grfModifiers)
            {
                try
                {
                    this.Host.SetActiveXHostState(ActiveXHelper.SiteProcessedInputKey, true);

                    Message message = (Message)pMsg;

                    return (this.Host.PreProcessControlMessage(ref message) == PreProcessControlState.MessageProcessed) ? NativeMethods.HRESULT.S_OK : NativeMethods.HRESULT.S_FALSE;
                }
                finally
                {
                    this.Host.SetActiveXHostState(ActiveXHelper.SiteProcessedInputKey, false);
                }
            }

            #endregion

            #region IOleInPlaceSite Members

            void UnsafeNativeMethods.IOleInPlaceSite.CanInPlaceActivate()
            {
            }

            void UnsafeNativeMethods.IOleInPlaceSite.OnInPlaceActivate()
            {
                this.Host.activeXState = ActiveXHelper.ActiveXState.InPlaceActive;
                this.OnActiveXRectChange(new NativeMethods._RECT(this.Host.Bounds));
            }

            void UnsafeNativeMethods.IOleInPlaceSite.OnUIActivate()
            {
                this.Host.activeXState = ActiveXHelper.ActiveXState.UIActive;
                this.Host.GetParentContainer().OnUIActivate(this.Host);
            }

            void UnsafeNativeMethods.IOleInPlaceSite.GetWindowContext(out UnsafeNativeMethods.IOleInPlaceFrame ppFrame, out UnsafeNativeMethods.IOleInPlaceUIWindow ppDoc, NativeMethods._RECT lprcPosRect, NativeMethods._RECT lprcClipRect, NativeMethods.tagOIFI lpFrameInfo)
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
            }

            bool UnsafeNativeMethods.IOleInPlaceSite.Scroll(NativeMethods.tagSIZE scrollExtant)
            {
                return true;
            }

            void UnsafeNativeMethods.IOleInPlaceSite.OnUIDeactivate(bool fUndoable)
            {
                this.Host.GetParentContainer().OnUIDeactivate(this.Host);
                if (this.Host.activeXState > ActiveXHelper.ActiveXState.InPlaceActive)
                {
                    this.Host.activeXState = ActiveXHelper.ActiveXState.InPlaceActive;
                }
            }

            void UnsafeNativeMethods.IOleInPlaceSite.OnInPlaceDeactivate()
            {
                if (this.Host.activeXState == ActiveXHelper.ActiveXState.UIActive)
                {
                    ((UnsafeNativeMethods.IOleInPlaceSite)this).OnUIDeactivate(false);
                }
                this.Host.GetParentContainer().OnInPlaceDeactivate(this.Host);
                this.Host.activeXState = ActiveXHelper.ActiveXState.Running;
            }

            void UnsafeNativeMethods.IOleInPlaceSite.DiscardUndoState()
            {
            }

            void UnsafeNativeMethods.IOleInPlaceSite.DeactivateAndUndo()
            {
                this.Host.activeXOleInPlaceObject.UIDeactivate();
            }

            void UnsafeNativeMethods.IOleInPlaceSite.OnPosRectChange(NativeMethods._RECT lprcPosRect)
            {
                this.OnActiveXRectChange(lprcPosRect);
            }

            #endregion

            #region IOleWindow Members

            IntPtr UnsafeNativeMethods.IOleInPlaceSite/*.IOleWindow*/.GetWindow()
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

            void UnsafeNativeMethods.IOleInPlaceSite/*.IOleWindow*/.ContextSensitiveHelp(bool fEnterMode)
            {
                throw new COMException("IOleInPlaceSite", (int)NativeMethods.HRESULT.E_NOTIMPL);
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

            void UnsafeNativeMethods.IPropertyNotifySink.OnRequestEdit(int dispID)
            {
            }

            #endregion

            #region ISimpleFrameSite Members

            bool UnsafeNativeMethods.ISimpleFrameSite.PreMessageFilter(IntPtr hwnd, int msg, IntPtr wp, IntPtr lp, ref IntPtr plResult, ref int pdwCookie)
            {
                return false;
            }

            bool UnsafeNativeMethods.ISimpleFrameSite.PostMessageFilter(IntPtr hwnd, int msg, IntPtr wp, IntPtr lp, ref IntPtr plResult, int dwCookie)
            {
                return true;
            }

            #endregion
        }
    }
}