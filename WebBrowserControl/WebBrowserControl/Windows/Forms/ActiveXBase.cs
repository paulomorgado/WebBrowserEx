using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;
using System.ComponentModel.Design;
using System.Security.Permissions;
using System.Globalization;

namespace Pajocomo.Windows.Forms
{
    /// <summary>
    /// Represents a base ActiveX control.
    /// </summary>
    /// <typeparam name="TActiveXClass">The ActiveX control's class.</typeparam>
    /// <typeparam name="TActiveXInterface">The ActiveX control's interface.</typeparam>
    public abstract partial class ActiveXBase<TActiveXClass, TActiveXInterface> : System.Windows.Forms.Control
        where TActiveXClass : TActiveXInterface
        where TActiveXInterface : class
    {
        #region Private Instance Fields

        private TActiveXInterface activeXInstance;
        private ContainerControl containingControl;
        private Size activeXBaseChangingSize;
        private IntPtr hwndFocus;
        private BitVector32 activeXHostState;
        private ActiveXSiteBase activeXSite;
        private ActiveXHelper.ActiveXState activeXState;
        private ActiveXHelper.ActiveXState activeXReloadingState;
        private ActiveXContainer activeXContainer;
        private ActiveXBaseNativeWindow activeXWindow;
        private ActiveXContainer container;
        private UnsafeNativeMethods.IOleObject activeXOleObject;
        private UnsafeNativeMethods.IOleInPlaceObject activeXOleInPlaceObject;
        private UnsafeNativeMethods.IOleInPlaceActiveObject activexOleInPlaceActiveObject;
        private UnsafeNativeMethods.IOleControl activeXOleControl;
        private int numberOfComponentChangeEvents;
        private EventHandler selectionChangeHandler;
        private ActiveXHelper.ActiveXEditMode activeXEditMode;
        private ActiveXHelper.SelectionStyle selectionStyle;

        #endregion

        #region Instance Lifetime

        public ActiveXBase()
        {
            this.activeXHostState = new BitVector32();
            this.hwndFocus = IntPtr.Zero;
            this.activeXBaseChangingSize = Size.Empty;
            if (System.Windows.Forms.Application.OleRequired() != ApartmentState.STA)
            {
                throw new ThreadStateException(ResourcesHelper.GetString(ResourcesHelper.ActiveXMTAThread, new object[] { typeof(TActiveXInterface).GUID }));
            }
            base.SetStyle(ControlStyles.UserPaint, false);
            this.activeXBaseChangingSize.Width = -1;
            this.SetActiveXHostState(ActiveXHelper.IsMaskEdit, typeof(TActiveXInterface).GUID.Equals(ActiveXHelper.Clsids.MaskEdit));
        }

        #endregion

        #region Private Instance Properties

        #endregion

        #region Internal Instance Properties

        private ActiveXSiteBase ActiveXSite
        {
            get
            {
                if (this.activeXSite == null)
                {
                    this.activeXSite = this.CreateActiveXSiteBase();
                }
                return this.activeXSite;
            }
        }
 
        private ContainerControl ContainingControl
        {
            get
            {
                if ((this.containingControl == null) || this.GetActiveXHostState(ActiveXHelper.RecomputeContainingControl))
                {
                    this.containingControl = this.FindContainerControlInternal();
                }
                return this.containingControl;
            }
        }

        private bool IsUserMode
        {
            get
            {
                if (this.Site != null)
                {
                    return !base.DesignMode;
                }
                return true;
            }
        }

        #endregion

        #region Public Instance Properties

        public virtual TActiveXInterface ActiveXInstance
        {
            get
            {
                if (this.activeXInstance == null)
                {
                    if (base.IsDisposed)
                    {
                        throw new ObjectDisposedException(base.GetType().Name);
                    }
                    this.ChangeActiveXStateUpTo(ActiveXHelper.ActiveXState.InPlaceActive);
                }
                if (this.activeXInstance == null)
                {
                    throw new InvalidOperationException(ResourcesHelper.GetString(ResourcesHelper.ActiveXBaseNoCastToInterface, typeof(TActiveXInterface).FullName));
                }
                return this.activeXInstance;
            }
        }

        #endregion

        #region Private Instance Methods

        private void AttachInterfacesInternal()
        {
            this.activeXOleObject = (UnsafeNativeMethods.IOleObject)this.ActiveXInstance;
            this.activeXOleInPlaceObject = (UnsafeNativeMethods.IOleInPlaceObject)this.ActiveXInstance;
            this.activexOleInPlaceActiveObject = (UnsafeNativeMethods.IOleInPlaceActiveObject)this.ActiveXInstance;
            this.activeXOleControl = (UnsafeNativeMethods.IOleControl)this.ActiveXInstance;
            this.AttachInterfaces(this.ActiveXInstance);
        }

        private void DetachInterfacesInternal()
        {
            this.activeXOleObject = null;
            this.activeXOleInPlaceObject = null;
            this.activexOleInPlaceActiveObject = null;
            this.activeXOleControl = null;
            this.DetachInterfaces();
        }

        private void StartEvents()
        {
            if (!this.GetActiveXHostState(ActiveXHelper.SinkAttached))
            {
                this.SetActiveXHostState(ActiveXHelper.SinkAttached, true);
                this.CreateSink();
            }
            this.ActiveXSite.StartEvents();
        }

        private void StopEvents()
        {
            if (this.GetActiveXHostState(ActiveXHelper.SinkAttached))
            {
                this.SetActiveXHostState(ActiveXHelper.SinkAttached, false);
                this.DetachSink();
            }
            this.ActiveXSite.StopEvents();
        }

        private Size GetExtent()
        {
            NativeMethods.tagSIZEL size = new NativeMethods.tagSIZEL();
            this.activeXOleObject.GetExtent(NativeMethods.tagDVASPECT2.DVASPECT_CONTENT, size);
            this.HiMetric2Pixel(size, size);
            return new Size(size.cx, size.cy);
        }

        private Size SetExtent(int width, int height)
        {
            NativeMethods.tagSIZEL size = new NativeMethods.tagSIZEL();
            size.cx = width;
            size.cy = height;
            bool shouldSetExtend = base.DesignMode;
            try
            {
                this.Pixel2hiMetric(size, size);
                this.activeXOleObject.SetExtent(NativeMethods.tagDVASPECT.DVASPECT_CONTENT, size);
            }
            catch (COMException)
            {
                shouldSetExtend = true;
            }
            if (shouldSetExtend)
            {
                this.activeXOleObject.GetExtent(NativeMethods.tagDVASPECT2.DVASPECT_CONTENT, size);
                try
                {
                    this.activeXOleObject.SetExtent(NativeMethods.tagDVASPECT.DVASPECT_CONTENT, size);
                }
                catch (COMException)
                {
                }
            }
            return this.GetExtent();
        }

        private void Pixel2hiMetric(NativeMethods.tagSIZEL sz, NativeMethods.tagSIZEL szout)
        {
            NativeMethods.tagPOINTF pointf = new NativeMethods.tagPOINTF();
            pointf.x = sz.cx;
            pointf.y = sz.cy;
            NativeMethods._POINTL _pointl = new NativeMethods._POINTL();
            ((UnsafeNativeMethods.IOleControlSite)this.activeXSite).TransformCoords(_pointl, pointf, NativeMethods.tagXFORMCOORDS.XFORMCOORDS_CONTAINERTOHIMETRIC | NativeMethods.tagXFORMCOORDS.XFORMCOORDS_SIZE);
            szout.cx = _pointl.x;
            szout.cy = _pointl.y;
        }

        private void HiMetric2Pixel(NativeMethods.tagSIZEL sz, NativeMethods.tagSIZEL szout)
        {
            NativeMethods._POINTL _pointl = new NativeMethods._POINTL();
            _pointl.x = sz.cx;
            _pointl.y = sz.cy;
            NativeMethods.tagPOINTF pointf = new NativeMethods.tagPOINTF();
            ((UnsafeNativeMethods.IOleControlSite)this.activeXSite).TransformCoords(_pointl, pointf, NativeMethods.tagXFORMCOORDS.XFORMCOORDS_HIMETRICTOCONTAINER | NativeMethods.tagXFORMCOORDS.XFORMCOORDS_SIZE);
            szout.cx = (int)pointf.x;
            szout.cy = (int)pointf.y;
        }

        private EventHandler SelectionChangeHandler
        {
            get
            {
                if (this.selectionChangeHandler == null)
                {
                    this.selectionChangeHandler = new EventHandler(this.OnNewSelection);
                }
                return this.selectionChangeHandler;
            }
        }

        private void OnNewSelection(object sender, EventArgs e)
        {
            if (base.DesignMode)
            {
                ISelectionService selectionService = ActiveXHelper.GetSelectionService(this);
                if (selectionService != null)
                {
                    if (!selectionService.GetComponentSelected(this))
                    {
                        if (this.activeXEditMode != ActiveXHelper.ActiveXEditMode.None)
                        {
                            this.GetParentContainer().OnExitEditMode(this);
                            this.SetEditMode(ActiveXHelper.ActiveXEditMode.None);
                        }
                        this.SetSelectionStyle(ActiveXHelper.SelectionStyle.Selected);
                        this.RemoveSelectionHandler();
                    }
                    else
                    {
                        PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(this)["SelectionStyle"];
                        if ((propertyDescriptor != null) && (propertyDescriptor.PropertyType == typeof(int)))
                        {
                            int selectionStyle = (int)propertyDescriptor.GetValue(this);
                            if (((ActiveXHelper.SelectionStyle)selectionStyle) != this.selectionStyle)
                            {
                                propertyDescriptor.SetValue(this, this.selectionStyle);
                            }
                        }
                    }
                }
            }
        }

        private void SetSelectionStyle(ActiveXHelper.SelectionStyle selectionStyle)
        {
            if (base.DesignMode)
            {
                ISelectionService selectionService = ActiveXHelper.GetSelectionService(this);
                this.selectionStyle = selectionStyle;
                if ((selectionService != null) && selectionService.GetComponentSelected(this))
                {
                    PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(this)["SelectionStyle"];
                    if ((propertyDescriptor != null) && (propertyDescriptor.PropertyType == typeof(int)))
                    {
                        propertyDescriptor.SetValue(this, (int)selectionStyle);
                    }
                }
            }
        }

        private void AmbientChanged(int dispid)
        {
            if (this.activeXInstance != null)
            {
                try
                {
                    base.Invalidate();
                    this.activeXOleControl.OnAmbientPropertyChange(dispid);
                }
                catch (Exception exception1)
                {
                    if (Utils.IsCriticalException(exception1))
                    {
                        throw;
                    }
                }
            }
        }

        #endregion

        #region Protected Instance Methods

        /// <summary>Called by the control when the underlying ActiveX control is created.</summary>
        /// <param name="nativeActiveXObject">An object that represents the underlying ActiveX control.</param>
        protected virtual void AttachInterfaces(object nativeActiveXObject)
        {
        }

        /// <summary>
        /// Called by the control when the underlying ActiveX control is discarded.
        /// </summary>
        protected virtual void DetachInterfaces()
        {
        }

        /// <summary>
        /// Returns a reference to the unmanaged ActiveX control site.
        /// </summary>
        /// <returns>
        /// A <see cref="TActiveX:ActiveXSiteBase"></see> that represents the site of the underlying ActiveX control.
        /// </returns>
        protected virtual ActiveXSiteBase CreateActiveXSiteBase()
        {
            return new ActiveXSiteBase(this);
        }

        /// <summary>
        /// Called by the control when it stops listening to events.
        /// </summary>
        protected virtual void DetachSink()
        {
        }

        /// <summary>
        /// Called by the control to prepare it for listening to events.
        /// </summary>
        protected virtual void CreateSink()
        {
        }

        protected override bool IsInputChar(char charCode)
        {
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.ChangeActiveXStateDownTo(ActiveXHelper.ActiveXState.Passive);
            }
            base.Dispose(disposing);
        }

        /// <summary>Performs the work of setting the specified bounds of this control.</summary>
        /// <param name="y">The new <see cref="P:System.Windows.Forms.Control.Top"></see> property value of the control. </param>
        /// <param name="specified">A bitwise combination of the <see cref="T:System.Windows.Forms.BoundsSpecified"></see> values. </param>
        /// <param name="width">The new <see cref="P:System.Windows.Forms.Control.Width"></see> property value of the control. </param>
        /// <param name="height">The new <see cref="P:System.Windows.Forms.Control.Height"></see> property value of the control. </param>
        /// <param name="x">The new <see cref="P:System.Windows.Forms.Control.Left"></see> property value of the control. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (this.activeXState >= ActiveXHelper.ActiveXState.InPlaceActive
                && this.IsHandleCreated
                && (((this.Left != x) || (this.Top != y)) || ((this.Width != width) || (this.Height != height))))
            {
                try
                {
                    this.activeXBaseChangingSize.Width = width;
                    this.activeXBaseChangingSize.Height = height;
                    this.activeXOleInPlaceObject.SetObjectRects(new NativeMethods._RECT(new Rectangle(0, 0, width, height)), ActiveXHelper.GetClipRect());
                }
                finally
                {
                    this.activeXBaseChangingSize.Width = -1;
                }
            }
            base.SetBoundsCore(x, y, width, height, specified);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        /// <exception cref="T:System.Threading.ThreadStateException">The <see cref="P:System.Threading.Thread.ApartmentState"></see> property of the application is not set to <see cref="F:System.Threading.ApartmentState.STA"></see>. </exception>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override void OnHandleCreated(EventArgs e)
        {
            if (Application.OleRequired() != ApartmentState.STA)
            {
                throw new ThreadStateException(ResourcesHelper.GetString(ResourcesHelper.ThreadMustBeSTA));
            }
            base.OnHandleCreated(e);
            if ((this.activeXReloadingState != ActiveXHelper.ActiveXState.Passive) && (this.activeXReloadingState != this.activeXState))
            {
                if (this.activeXState < this.activeXReloadingState)
                {
                    this.ChangeActiveXStateUpTo(this.activeXReloadingState);
                }
                else
                {
                    this.ChangeActiveXStateDownTo(this.activeXReloadingState);
                }
                this.activeXReloadingState = ActiveXHelper.ActiveXState.Passive;
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (!base.ContainsFocus)
            {
                this.ChangeActiveXStateDownTo(ActiveXHelper.ActiveXState.InPlaceActive);
            }
        }

        public override bool PreProcessMessage(ref Message message)
        {
            if (this.IsUserMode)
            {
                if (this.GetActiveXHostState(ActiveXHelper.SiteProcessedInputKey))
                {
                    return base.PreProcessMessage(ref message);
                }
                NativeMethods.MSG msg = new NativeMethods.MSG();
                msg.message = message.Msg;
                msg.wParam = message.WParam;
                msg.lParam = message.LParam;
                msg.hwnd = message.HWnd;
                this.SetActiveXHostState(ActiveXHelper.SiteProcessedInputKey, false);
                try
                {
                    if (this.activeXOleInPlaceObject != null)
                    {
                        int accelatorTranslation = this.activexOleInPlaceActiveObject.TranslateAccelerator(ref msg);
                        if (accelatorTranslation == NativeMethods.HRESULT.S_OK)
                        {
                            return true;
                        }
                        message.Msg = msg.message;
                        message.WParam = msg.wParam;
                        message.LParam = msg.lParam;
                        message.HWnd = msg.hwnd;
                        if (accelatorTranslation == NativeMethods.HRESULT.S_FALSE)
                        {
                            return base.PreProcessMessage(ref message);
                        }
                        if (this.GetActiveXHostState(ActiveXHelper.SiteProcessedInputKey))
                        {
                            return base.PreProcessMessage(ref message);
                        }
                        return false;
                    }
                }
                finally
                {
                    this.SetActiveXHostState(ActiveXHelper.SiteProcessedInputKey, false);
                }
            }
            return false;
        }

        /// <summary>
        /// This member overrides <see cref="M:System.Windows.Forms.Control.WndProc(System.Windows.Forms.Message@)"></see>.
        /// </summary>
        /// <param name="m">The windows <see cref="T:System.Windows.Forms.Message"></see> to process.</param>
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust"), SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode), PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_LBUTTONDOWN:
                case NativeMethods.WM_RBUTTONDOWN:
                case NativeMethods.WM_MBUTTONDOWN:
                case NativeMethods.WM_MOUSEACTIVATE:
                    if (!base.DesignMode)
                    {
                        this.Focus();
                    }
                    this.DefWndProc(ref m);
                    return;
                case NativeMethods.WM_LBUTTONUP:
                case NativeMethods.WM_LBUTTONDBLCLK:
                case NativeMethods.WM_RBUTTONUP:
                case NativeMethods.WM_RBUTTONDBLCLK:
                case NativeMethods.WM_MBUTTONUP:
                case NativeMethods.WM_MBUTTONDBLCLK:
                case NativeMethods.x2055:
                case NativeMethods.WM_CONTEXTMENU:
                case NativeMethods.WM_ERASEBKGND:
                case NativeMethods.WM_SYSCOLORCHANGE:
                case NativeMethods.WM_SETCURSOR:
                case NativeMethods.WM_DRAWITEM:
                    this.DefWndProc(ref m);
                    return;
                case NativeMethods.WM_COMMAND:
                    if (!ControlShim.ReflectMessageInternal(m.LParam, ref m))
                    {
                        this.DefWndProc(ref m);
                    }
                    return;
                case NativeMethods.WM_HELP:
                    base.WndProc(ref m);
                    this.DefWndProc(ref m);
                    return;
                case NativeMethods.WM_DESTROY:
                    break;
                case NativeMethods.WM_KILLFOCUS:
                    this.hwndFocus = m.WParam;
                    try
                    {
                        base.WndProc(ref m);
                        return;
                    }
                    finally
                    {
                        this.hwndFocus = IntPtr.Zero;
                    }
                default:
                    if (m.Msg == ActiveXHelper.REGMSG_MSG)
                    {
                        m.Result = (IntPtr)0x7b;
                    }
                    else
                    {
                        base.WndProc(ref m);
                    }
                    return;
            }

            if ((this.activeXState >= ActiveXHelper.ActiveXState.InPlaceActive))
            {
                IntPtr window = this.activeXOleInPlaceObject.GetWindow();
                if (NativeMethods.Succeeded(window))
                {
                    ApplicationShim.ParkHandle(new HandleRef(this.activeXOleInPlaceObject, window));
                }
            }
            if (base.RecreatingHandle)
            {
                this.activeXReloadingState = this.activeXState;
            }
            this.ChangeActiveXStateDownTo(ActiveXHelper.ActiveXState.Running);
            if (this.activeXWindow != null)
            {
                this.activeXWindow.ReleaseHandle();
            }
            this.OnHandleDestroyed(EventArgs.Empty);
        }

        [UIPermission(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows)]
        protected override bool ProcessMnemonic(char charCode)
        {
            if (base.CanSelect)
            {
                try
                {
                    NativeMethods.tagCONTROLINFO controlInfo = new NativeMethods.tagCONTROLINFO();
                    if (NativeMethods.Succeeded(this.activeXOleControl.GetControlInfo(controlInfo)))
                    {
                        NativeMethods.MSG msg = new NativeMethods.MSG();
                        msg.hwnd = IntPtr.Zero;
                        msg.message = 260;
                        msg.wParam = (IntPtr)char.ToUpper(charCode, CultureInfo.CurrentCulture);
                        msg.lParam = (IntPtr)0x20180001;
                        msg.time = SafeNativeMethods.GetTickCount();
                        NativeMethods.POINT cursorPos = new NativeMethods.POINT();
                        UnsafeNativeMethods.GetCursorPos(cursorPos);
                        msg.pt = new NativeMethods._POINTL();
                        msg.pt.x = cursorPos.x;
                        msg.pt.y = cursorPos.y;
                        if (!SafeNativeMethods.IsAccelerator(new HandleRef(controlInfo, controlInfo.hAccel), controlInfo.cAccel, ref msg, null))
                        {
                            return false;
                        }
                        this.activeXOleControl.OnMnemonic(ref msg);
                        this.Focus();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    if (Utils.IsCriticalException(ex))
                    {
                        throw;
                    }
                }
            }
            return false;
        }

        #endregion

        #region Internal Instance Methods

        private bool CanSelectCore()
        {
            return (this.activeXState >= ActiveXHelper.ActiveXState.InPlaceActive);
        }

        private bool GetActiveXHostState(int mask)
        {
            return this.activeXHostState[mask];
        }

        private void SetActiveXHostState(int mask, bool value)
        {
            this.activeXHostState[mask] = value;
        }

        private void ChangeActiveXStateDownTo(ActiveXHelper.ActiveXState state)
        {
            if (!this.GetActiveXHostState(ActiveXHelper.InTransition))
            {
                this.SetActiveXHostState(ActiveXHelper.InTransition, true);
                try
                {
                    while (state < this.activeXState)
                    {
                        switch (this.activeXState)
                        {
                            case ActiveXHelper.ActiveXState.Loaded:
                                this.numberOfComponentChangeEvents++;
                                try
                                {
                                    if (this.activeXInstance != null)
                                    {
                                        this.DetachInterfacesInternal();
                                        Marshal.FinalReleaseComObject(this.activeXInstance);
                                        this.activeXInstance = null;
                                    }
                                }
                                finally
                                {
                                    this.numberOfComponentChangeEvents--;
                                }
                                this.activeXState = ActiveXHelper.ActiveXState.Passive;
                                continue;
                            case ActiveXHelper.ActiveXState.Running:
                                this.StopEvents();
                                ActiveXContainer activeXContainer = this.GetParentContainer();
                                if (activeXContainer != null)
                                {
                                    activeXContainer.RemoveControl(this);
                                }
                                this.activeXOleObject.SetClientSite(null);
                                this.activeXState = ActiveXHelper.ActiveXState.Loaded;
                                continue;
                            case (ActiveXHelper.ActiveXState.Running | ActiveXHelper.ActiveXState.Loaded):
                                break;
                            case ActiveXHelper.ActiveXState.InPlaceActive:
                                ContainerControl containingControl = this.ContainingControl;
                                if ((containingControl != null) && (containingControl.ActiveControl == this))
                                {
                                    ContainerControlShim.SetActiveControlInternal(containingControl, null);
                                }
                                this.activeXOleInPlaceObject.InPlaceDeactivate();
                                this.activeXState = ActiveXHelper.ActiveXState.Running;
                                continue;
                            case ActiveXHelper.ActiveXState.UIActive:
                                this.activeXOleInPlaceObject.UIDeactivate();
                                this.activeXState = ActiveXHelper.ActiveXState.InPlaceActive;
                                continue;
                        }
                        this.activeXState -= ActiveXHelper.ActiveXState.Loaded;
                    }
                }
                finally
                {
                    this.SetActiveXHostState(ActiveXHelper.InTransition, false);
                }
            }
        }

        private void ChangeActiveXStateUpTo(ActiveXHelper.ActiveXState state)
        {
            if (!this.GetActiveXHostState(ActiveXHelper.InTransition))
            {
                this.SetActiveXHostState(ActiveXHelper.InTransition, true);
                try
                {
                    while (state > this.activeXState)
                    {
                        switch (this.activeXState)
                        {
                            case ActiveXHelper.ActiveXState.Passive:
                                this.activeXInstance = UnsafeNativeMethods.CoCreateInstance<TActiveXClass, TActiveXInterface>(null, NativeMethods.tagCLSCTX.CLSCTX_INPROC_SERVER, NativeMethods.ActiveX.IID_IUnknown);
                                this.activeXState = ActiveXHelper.ActiveXState.Loaded;
                                this.AttachInterfacesInternal();
                                continue;
                            case ActiveXHelper.ActiveXState.Loaded:
                                int miscStatus = 0;
                                if (NativeMethods.Succeeded(this.activeXOleObject.GetMiscStatus(NativeMethods.tagDVASPECT.DVASPECT_CONTENT, out miscStatus))
                                    && ((miscStatus & 0x20000) != 0))
                                {
                                    this.activeXOleObject.SetClientSite(this.ActiveXSite);
                                }
                                if (!base.DesignMode)
                                {
                                    this.StartEvents();
                                }
                                this.activeXState = ActiveXHelper.ActiveXState.Running;
                                continue;
                            case ActiveXHelper.ActiveXState.Running:
                                try
                                {
                                    this.DoVerb(NativeMethods.OLEIVERB.OLEIVERB_INPLACEACTIVATE);
                                }
                                catch (Exception exception1)
                                {
                                    throw new TargetInvocationException(ResourcesHelper.GetString(ResourcesHelper.ActiveXNoWindowHandle, new object[] { base.GetType().Name }), exception1);
                                }
                                ControlShim.CreateControl(this, true);
                                this.activeXState = ActiveXHelper.ActiveXState.InPlaceActive;
                                continue;
                            case ActiveXHelper.ActiveXState.InPlaceActive:
                                try
                                {
                                    this.DoVerb(NativeMethods.OLEIVERB.OLEIVERB_UIACTIVATE);
                                }
                                catch (Exception ex)
                                {
                                    throw new TargetInvocationException(ResourcesHelper.GetString(ResourcesHelper.ActiveXNoWindowHandle, new object[] { base.GetType().Name }), ex);
                                }
                                this.activeXState = ActiveXHelper.ActiveXState.UIActive;
                                continue;
                        }
                        //this.activeXState += ActiveXHelper.ActiveXState.Loaded;
                        this.activeXState = (ActiveXHelper.ActiveXState)((int)(this.activeXState) + (int)(ActiveXHelper.ActiveXState.Loaded));
                    }
                }
                finally
                {
                    this.SetActiveXHostState(ActiveXHelper.InTransition, false);
                }
            }
        }

        private bool DoVerb(NativeMethods.OLEIVERB verb)
        {
            return (this.activeXOleObject.DoVerb(verb, IntPtr.Zero, this.ActiveXSite, 0, base.Handle, new NativeMethods._RECT(base.Bounds)) == 0);
        }

        private void MakeDirty()
        {
            ISite site = this.Site;
            if (site != null)
            {
                IComponentChangeService componentChangeService = (IComponentChangeService)site.GetService(typeof(IComponentChangeService));
                if (componentChangeService != null)
                {
                    componentChangeService.OnComponentChanging(this, null);
                    componentChangeService.OnComponentChanged(this, null, null, null);
                }
            }
        }

        private ActiveXContainer GetParentContainer()
        {
            if (this.container == null)
            {
                this.container = ActiveXContainer.FindContainerForControl(this);
            }
            if (this.container == null)
            {
                this.container = this.CreateActiveXContainer();
                this.container.AddControl(this);
            }
            return this.container;
        }

        internal ContainerControl FindContainerControlInternal()
        {
            if (this.Site != null)
            {
                IDesignerHost designerHost = (IDesignerHost)this.Site.GetService(typeof(IDesignerHost));
                if (designerHost != null)
                {
                    IComponent component = designerHost.RootComponent;
                    if ((component != null) && (component is ContainerControl))
                    {
                        return (ContainerControl)component;
                    }
                }
            }
            ContainerControl containerControl = null;
            for (Control control = this; control != null; control = control.Parent)
            {
                ContainerControl control_as_ContainerContral = control as ContainerControl;
                if (control_as_ContainerContral != null)
                {
                    containerControl = control_as_ContainerContral;
                }
            }
            if (containerControl == null)
            {
                containerControl = Control.FromHandle(UnsafeNativeMethods.GetParent(new HandleRef(this, base.Handle))) as ContainerControl;
            }
            if (ApplicationShim.IsParkingWindow(containerControl))
            {
                containerControl = null;
            }
            this.SetActiveXHostState(ActiveXHelper.RecomputeContainingControl, containerControl == null);
            return containerControl;
        }

        private ActiveXContainer CreateActiveXContainer()
        {
            if (this.activeXContainer == null)
            {
                this.activeXContainer = new ActiveXContainer(this);
            }
            return this.activeXContainer;
        }
 
       private IntPtr GetHandleNoCreate()
        {
            if (!base.IsHandleCreated)
            {
                return IntPtr.Zero;
            }
            return base.Handle;
        }

        private void AttachWindow(IntPtr hwnd)
        {
            UnsafeNativeMethods.SetParent(new HandleRef(null, hwnd), new HandleRef(this, base.Handle));
            if (this.activeXWindow != null)
            {
                this.activeXWindow.ReleaseHandle();
            }
            this.activeXWindow = new ActiveXBaseNativeWindow(this);
            NativeWindowShim.AssignHandle(this.activeXWindow, hwnd, false);
            base.UpdateZOrder();
            base.UpdateBounds();
            Size size = base.Size;
            size = this.SetExtent(size.Width, size.Height);
            Point point = base.Location;
            base.Bounds = new Rectangle(point.X, point.Y, size.Width, size.Height);
        }

        private void AddSelectionHandler()
        {
            if (!this.GetActiveXHostState(ActiveXHelper.AddedSelectionHandler))
            {
                this.SetActiveXHostState(ActiveXHelper.AddedSelectionHandler, true);
                ISelectionService selectionService = ActiveXHelper.GetSelectionService(this);
                if (selectionService != null)
                {
                    selectionService.SelectionChanging += this.SelectionChangeHandler;
                }
            }
        }

        private void SetEditMode(ActiveXHelper.ActiveXEditMode activeXEditMode)
        {
            this.activeXEditMode = activeXEditMode;
        }

        private bool RemoveSelectionHandler()
        {
            bool addedSelectionHandler = this.GetActiveXHostState(ActiveXHelper.AddedSelectionHandler);
            if (addedSelectionHandler)
            {
                this.SetActiveXHostState(ActiveXHelper.AddedSelectionHandler, false);
                ISelectionService selectionService = ActiveXHelper.GetSelectionService(this);
                if (selectionService != null)
                {
                    selectionService.SelectionChanging -= this.SelectionChangeHandler;
                }
            }
            return addedSelectionHandler;
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            this.AmbientChanged(NativeMethods.ActiveX.DISPID_AMBIENT_BACKCOLOR);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            this.AmbientChanged(NativeMethods.ActiveX.DISPID_AMBIENT_FORECOLOR);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            this.AmbientChanged(NativeMethods.ActiveX.DISPID_AMBIENT_FONT);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (this.activeXState < ActiveXHelper.ActiveXState.UIActive)
            {
                this.ChangeActiveXStateUpTo(ActiveXHelper.ActiveXState.UIActive);
            }
            base.OnGotFocus(e);
        }

        #endregion

        #region Public Instance Methods

        #endregion
    }
}
