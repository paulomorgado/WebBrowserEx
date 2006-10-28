using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace Pajocomo.Windows.Forms
{
    public abstract partial class ActiveXBase<TActiveX>
    {
        private class ActiveXContainer : UnsafeNativeMethods.IOleContainer, UnsafeNativeMethods.IOleInPlaceFrame
        {
            private ActiveXBase<TActiveX> parent;
            private ActiveXBase<TActiveX> siteActive;
            private ActiveXBase<TActiveX> siteUIActive;
            private ActiveXBase<TActiveX> controlInEditMode;
            private List<Control> containerCache;
            private List<Control> components;
            private IContainer associatedContainer;

            internal ActiveXContainer(ActiveXBase<TActiveX> parent)
            {
                this.containerCache = new List<Control>();
                this.parent = parent;
            }

            #region IOleContainer Members

            int UnsafeNativeMethods.IOleContainer.EnumObjects(NativeMethods.tagOLECONTF grfFlags, out UnsafeNativeMethods.IEnumUnknown ppenum)
            {
                ppenum = null;
                if ((grfFlags & NativeMethods.tagOLECONTF.OLECONTF_EMBEDDINGS) != 0)
                {
                    List<object> list = new List<object>();
                    this.ListActiveXControls(list, true);
                    if (list.Count > 0)
                    {
                        ppenum = new ActiveXHelper.EnumUnknown(list.ToArray());
                        return 0;
                    }
                }
                ppenum = new ActiveXHelper.EnumUnknown(null);
                return NativeMethods.HRESULT.S_OK;
            }

            int UnsafeNativeMethods.IOleContainer.LockContainer(bool fLock)
            {
                return NativeMethods.HRESULT.E_NOTIMPL;
            }

            #endregion

            #region IParseDisplayName Members

            int UnsafeNativeMethods.IParseDisplayName.ParseDisplayName(object pbc, string pszDisplayName, int[] pchEaten, object[] ppmkOut)
            {
                if (ppmkOut != null)
                {
                    ppmkOut[0] = null;
                }
                return NativeMethods.HRESULT.E_NOTIMPL;
            }

            #endregion

            #region IOleInPlaceFrame Members

            int UnsafeNativeMethods.IOleInPlaceFrame.InsertMenus(IntPtr hmenuShared, NativeMethods.tagOleMenuGroupWidths lpMenuWidths)
            {
                return NativeMethods.HRESULT.S_OK;
            }

            int UnsafeNativeMethods.IOleInPlaceFrame.SetMenu(IntPtr hmenuShared, IntPtr holemenu, IntPtr hwndActiveObject)
            {
                return NativeMethods.HRESULT.E_NOTIMPL;
            }

            int UnsafeNativeMethods.IOleInPlaceFrame.RemoveMenus(IntPtr hmenuShared)
            {
                return NativeMethods.HRESULT.E_NOTIMPL;
            }

            int UnsafeNativeMethods.IOleInPlaceFrame.SetStatusText(string pszStatusText)
            {
                return NativeMethods.HRESULT.E_NOTIMPL;
            }

            int UnsafeNativeMethods.IOleInPlaceFrame.EnableModeless(bool fEnable)
            {
                return NativeMethods.HRESULT.E_NOTIMPL;
            }

            int UnsafeNativeMethods.IOleInPlaceFrame.TranslateAccelerator(ref NativeMethods.MSG lpmsg, short wID)
            {
                return NativeMethods.HRESULT.S_FALSE;
            }

            #endregion

            #region IOleInPlaceUIWindow Members

            int UnsafeNativeMethods.IOleInPlaceUIWindow.GetBorder(NativeMethods._RECT lprectBorder)
            {
                return NativeMethods.HRESULT.E_NOTIMPL;
            }

            int UnsafeNativeMethods.IOleInPlaceUIWindow.RequestBorderSpace(NativeMethods._RECT pborderwidths)
            {
                return NativeMethods.HRESULT.E_NOTIMPL;
            }

            int UnsafeNativeMethods.IOleInPlaceUIWindow.SetBorderSpace(NativeMethods._RECT pborderwidths)
            {
                return NativeMethods.HRESULT.E_NOTIMPL;
            }

            int UnsafeNativeMethods.IOleInPlaceUIWindow.SetActiveObject(UnsafeNativeMethods.IOleInPlaceActiveObject pActiveObject, string pszObjName)
            {
                if (pActiveObject == null)
                {
                    if (this.controlInEditMode != null)
                    {
                        this.controlInEditMode.SetEditMode(ActiveXHelper.ActiveXEditMode.None);
                        this.controlInEditMode = null;
                    }
                    return NativeMethods.HRESULT.S_OK;
                }

                ActiveXBase<TActiveX> activeXBase = null;
                UnsafeNativeMethods.IOleObject oleObject = pActiveObject as UnsafeNativeMethods.IOleObject;
                if (oleObject != null)
                {
                    UnsafeNativeMethods.IOleClientSite oleClientSite = null;
                    try
                    {
                        oleClientSite = oleObject.GetClientSite();
                        ActiveXSiteBase activeXSiteBase = oleClientSite as ActiveXSiteBase;
                        if (activeXSiteBase != null)
                        {
                            activeXBase = activeXSiteBase.Host;
                        }
                    }
                    catch (COMException)
                    {
                    }

                    if (this.controlInEditMode != null)
                    {
                        this.controlInEditMode.SetSelectionStyle(ActiveXHelper.SelectionStyle.Selected);
                        this.controlInEditMode.SetEditMode(ActiveXHelper.ActiveXEditMode.None);
                    }

                    if (activeXBase == null)
                    {
                        this.controlInEditMode = null;
                    }
                    else if (!activeXBase.IsUserMode)
                    {
                        this.controlInEditMode = activeXBase;
                        activeXBase.SetEditMode(ActiveXHelper.ActiveXEditMode.Object);
                        activeXBase.AddSelectionHandler();
                        activeXBase.SetSelectionStyle(ActiveXHelper.SelectionStyle.Active);
                    }
                }

                return NativeMethods.HRESULT.S_OK;
            }

            #endregion

            #region IOleWindow Members

            IntPtr UnsafeNativeMethods.IOleWindow.GetWindow()
            {
                return this.parent.Handle;
            }

            int UnsafeNativeMethods.IOleWindow.ContextSensitiveHelp(bool fEnterMode)
            {
                return NativeMethods.HRESULT.S_OK;
            }

            #endregion

            private void ListActiveXControls(List<object> list, bool fuseOcx)
            {
                List<Control> components = this.GetComponents();
                if (components != null)
                {
                    foreach (Control component in components)
                    {
                        ActiveXBase<TActiveX> activeXbase = component as ActiveXBase<TActiveX>;
                        if (activeXbase != null)
                        {
                            if (fuseOcx)
                            {
                                if (activeXbase.activeXInstance != null)
                                {
                                    list.Add(activeXbase.activeXInstance);
                                }
                            }
                            else
                            {
                                list.Add(component);
                            }
                        }
                    }
                }
            }

            private void FillComponentsTable(IContainer container)
            {
                if (container != null)
                {
                    ComponentCollection componentCollection = container.Components;
                    if (componentCollection != null)
                    {
                        this.components = new List<Control>();
                        foreach (IComponent component in componentCollection)
                        {
                            if (((component is Control) && (component != this.parent)) && (component.Site != null))
                            {
                                this.components.Add(component as Control);
                            }
                        }
                        return;
                    }
                }

                System.Diagnostics.Debug.Assert(this.containerCache != null, "null containerCache");
                if ((this.containerCache.Count > 0) && (this.components == null))
                {
                    this.components = new List<Control>();
                }
                else
                {
                    this.containerCache.ForEach(delegate(Control control)
                    {
                        if (!this.components.Contains(control))
                        {
                            this.components.Add(control);
                        }
                    });
                }

                this.GetAllChildren(this.parent);
            }

            private void GetAllChildren(Control control)
            {
                if (control != null)
                {
                    if (this.components == null)
                    {
                        this.components = new List<Control>();
                    }
                    if ((control != this.parent) && !this.components.Contains(control))
                    {
                        this.components.Add(control);
                    }
                    foreach (Control childControl in control.Controls)
                    {
                        this.GetAllChildren(childControl);
                    }
                }
            }

            private List<Control> GetComponents()
            {
                return this.GetComponents(this.GetParentsContainer());
            }

            private List<Control> GetComponents(IContainer cont)
            {
                this.FillComponentsTable(cont);
                return this.components;
            }

            private IContainer GetParentsContainer()
            {
                IContainer container = this.GetParentIContainer();
                if (container != null)
                {
                    return container;
                }
                return this.associatedContainer;
            }

            private IContainer GetParentIContainer()
            {
                ISite site = this.parent.Site;
                if ((site != null) && site.DesignMode)
                {
                    return site.Container;
                }
                return null;
            }

            private void OnComponentRemoved(object sender, ComponentEventArgs e)
            {
                Control control = e.Component as Control;
                if ((sender == this.associatedContainer) && (control != null))
                {
                    this.RemoveControl(control);
                }
            }

            private bool RegisterControl(ActiveXBase<TActiveX> ctl)
            {
                ISite site = ctl.Site;
                if (site != null)
                {
                    IContainer container = site.Container;
                    if (container != null)
                    {
                        if (this.associatedContainer != null)
                        {
                            return (container == this.associatedContainer);
                        }
                        this.associatedContainer = container;

                        IComponentChangeService componentChangeService = (IComponentChangeService)site.GetService(typeof(IComponentChangeService));
                        if (componentChangeService != null)
                        {
                            componentChangeService.ComponentRemoved += new ComponentEventHandler(this.OnComponentRemoved);
                        }

                        return true;
                    }
                }
                return false;
            }

            internal void OnExitEditMode(ActiveXBase<TActiveX> control)
            {
                if (this.controlInEditMode == control)
                {
                    this.controlInEditMode = null;
                }
            }

            internal void RemoveControl(Control control)
            {
                this.containerCache.Remove(control);
            }

            internal static ActiveXContainer FindContainerForControl(ActiveXBase<TActiveX> control)
            {
                if (control != null)
                {
                    if (control.container != null)
                    {
                        return control.container;
                    }
                    if (control.ContainingControl != null)
                    {
                        ActiveXContainer container = control.CreateActiveXContainer();
                        if (container.RegisterControl(control))
                        {
                            container.AddControl(control);
                            return container;
                        }
                    }
                }
                return null;
            }

            internal void AddControl(Control control)
            {
                if (this.containerCache.Contains(control))
                {
                    throw new ArgumentException(ResourcesHelper.GetString("AXDuplicateControl", new object[] { this.GetNameForControl(control) }), "ctl");
                }
                this.containerCache.Add(control);
                if (this.associatedContainer == null)
                {
                    ISite site1 = control.Site;
                    if (site1 != null)
                    {
                        this.associatedContainer = site1.Container;
                        IComponentChangeService componentChangeService = (IComponentChangeService)site1.GetService(typeof(IComponentChangeService));
                        if (componentChangeService != null)
                        {
                            componentChangeService.ComponentRemoved += new ComponentEventHandler(this.OnComponentRemoved);
                        }
                    }
                }
            }

            internal string GetNameForControl(Control control)
            {
                string text1 = (control.Site != null) ? control.Site.Name : control.Name;
                return (text1 ?? string.Empty);
            }

            internal void OnInPlaceDeactivate(ActiveXBase<TActiveX> site)
            {
                if (this.siteActive == site)
                {
                    this.siteActive = null;
                    ContainerControl containerControl = this.parent.FindContainerControlInternal();
                    if (containerControl != null)
                    {
                        ContainerControlShim.SetActiveControlInternal(containerControl, null);
                    }
                }
            }

            internal void OnUIActivate(ActiveXBase<TActiveX> site)
            {
                if (this.siteUIActive != site)
                {
                    if ((this.siteUIActive != null) && (this.siteUIActive != site))
                    {
                        this.siteUIActive.activeXOleInPlaceObject.UIDeactivate();
                    }
                    site.AddSelectionHandler();
                    this.siteUIActive = site;
                    ContainerControl containerControl = site.ContainingControl;
                    if ((containerControl != null) && containerControl.Contains(site))
                    {
                        ContainerControlShim.SetActiveControlInternal(containerControl, site);
                    }
                }
            }

            internal void OnUIDeactivate(ActiveXBase<TActiveX> site)
            {
                this.siteUIActive = null;
                site.RemoveSelectionHandler();
                site.SetSelectionStyle(ActiveXHelper.SelectionStyle.Selected);
                site.SetEditMode(ActiveXHelper.ActiveXEditMode.None);
            }

        }
    }
}
