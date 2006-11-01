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
    public abstract partial class ActiveXBase<TActiveXClass, TActiveXInterface>
    {
        private class ActiveXContainer : UnsafeNativeMethods.IOleContainer, UnsafeNativeMethods.IOleInPlaceFrame
        {
            private ActiveXBase<TActiveXClass, TActiveXInterface> parent;
            private ActiveXBase<TActiveXClass, TActiveXInterface> siteActive;
            private ActiveXBase<TActiveXClass, TActiveXInterface> siteUIActive;
            private ActiveXBase<TActiveXClass, TActiveXInterface> controlInEditMode;
            private List<Control> containerCache;
            private List<Control> components;
            private IContainer associatedContainer;

            internal ActiveXContainer(ActiveXBase<TActiveXClass, TActiveXInterface> parent)
            {
                this.containerCache = new List<Control>();
                this.parent = parent;
            }

            #region IOleContainer Members

            #region IParseDisplayName Members

            void UnsafeNativeMethods.IOleContainer/*.IParseDisplayName*/.ParseDisplayName(object pbc, string pszDisplayName, int[] pchEaten, object[] ppmkOut)
            {
                throw new COMException("IOleContainer", (int)NativeMethods.HRESULT.E_NOTIMPL);
            }

            #endregion

            UnsafeNativeMethods.IEnumUnknown UnsafeNativeMethods.IOleContainer.EnumObjects(NativeMethods.tagOLECONTF grfFlags)
            {
                if ((grfFlags & NativeMethods.tagOLECONTF.OLECONTF_EMBEDDINGS) != 0)
                {
                    List<object> list = new List<object>();
                    this.ListActiveXControls(list, true);
                    if (list.Count > 0)
                    {
                        return new ActiveXHelper.EnumUnknown(list.ToArray());
                    }
                }
                return new ActiveXHelper.EnumUnknown(null);
            }

            void UnsafeNativeMethods.IOleContainer.LockContainer(bool fLock)
            {
                throw new COMException("IOleContainer", (int)NativeMethods.HRESULT.E_NOTIMPL);
            }

            #endregion

            #region IOleInPlaceFrame Members

            #region IOleInPlaceUIWindow Members

            #region IOleWindow Members

            IntPtr UnsafeNativeMethods.IOleInPlaceFrame/*IOleWindow*/.GetWindow()
            {
                return this.parent.Handle;
            }

            void UnsafeNativeMethods.IOleInPlaceFrame/*IOleWindow*/.ContextSensitiveHelp(bool fEnterMode)
            {
            }

            #endregion

            NativeMethods._RECT UnsafeNativeMethods.IOleInPlaceFrame/*IOleInPlaceUIWindow*/.GetBorder()
            {
                throw new COMException("IOleInPlaceFrame", (int)NativeMethods.HRESULT.E_NOTIMPL);
            }

            void UnsafeNativeMethods.IOleInPlaceFrame/*IOleInPlaceUIWindow*/.RequestBorderSpace(NativeMethods._RECT pborderwidths)
            {
                throw new COMException("IOleInPlaceFrame", (int)NativeMethods.HRESULT.E_NOTIMPL);
            }

            void UnsafeNativeMethods.IOleInPlaceFrame/*IOleInPlaceUIWindow*/.SetBorderSpace(NativeMethods._RECT pborderwidths)
            {
                throw new COMException("IOleInPlaceFrame", (int)NativeMethods.HRESULT.E_NOTIMPL);
            }

            void UnsafeNativeMethods.IOleInPlaceFrame/*IOleInPlaceUIWindow*/.SetActiveObject(UnsafeNativeMethods.IOleInPlaceActiveObject pActiveObject, string pszObjName)
            {
                if (pActiveObject == null)
                {
                    if (this.controlInEditMode != null)
                    {
                        this.controlInEditMode.SetEditMode(ActiveXHelper.ActiveXEditMode.None);
                        this.controlInEditMode = null;
                    }
                    return;
                }

                ActiveXBase<TActiveXClass, TActiveXInterface> activeXBase = null;
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
            }

            #endregion

            NativeMethods.tagOleMenuGroupWidths UnsafeNativeMethods.IOleInPlaceFrame.InsertMenus(IntPtr hmenuShared)
            {
                throw new COMException("IOleInPlaceFrame", (int)NativeMethods.HRESULT.E_NOTIMPL);
                //return new NativeMethods.tagOleMenuGroupWidths();
            }

            void UnsafeNativeMethods.IOleInPlaceFrame.SetMenu(IntPtr hmenuShared, IntPtr holemenu, IntPtr hwndActiveObject)
            {
                throw new COMException("IOleInPlaceFrame", (int)NativeMethods.HRESULT.E_NOTIMPL);
            }

            void UnsafeNativeMethods.IOleInPlaceFrame.RemoveMenus(IntPtr hmenuShared)
            {
                throw new COMException("IOleInPlaceFrame", (int)NativeMethods.HRESULT.E_NOTIMPL);
            }

            void UnsafeNativeMethods.IOleInPlaceFrame.SetStatusText(string pszStatusText)
            {
                throw new COMException("IOleInPlaceFrame", (int)NativeMethods.HRESULT.E_NOTIMPL);
            }

            void UnsafeNativeMethods.IOleInPlaceFrame.EnableModeless(bool fEnable)
            {
                throw new COMException("IOleInPlaceFrame", (int)NativeMethods.HRESULT.E_NOTIMPL);
            }

            NativeMethods.HRESULT UnsafeNativeMethods.IOleInPlaceFrame.TranslateAccelerator(ref NativeMethods.MSG lpmsg, short wID)
            {
                return NativeMethods.HRESULT.S_FALSE;
            }

            #endregion

            private void ListActiveXControls(List<object> list, bool fuseOcx)
            {
                List<Control> components = this.GetComponents();
                if (components != null)
                {
                    foreach (Control component in components)
                    {
                        ActiveXBase<TActiveXClass, TActiveXInterface> activeXbase = component as ActiveXBase<TActiveXClass, TActiveXInterface>;
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

            private bool RegisterControl(ActiveXBase<TActiveXClass, TActiveXInterface> ctl)
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

            internal void OnExitEditMode(ActiveXBase<TActiveXClass, TActiveXInterface> control)
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

            internal static ActiveXContainer FindContainerForControl(ActiveXBase<TActiveXClass, TActiveXInterface> control)
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
                    throw new ArgumentException(ResourcesHelper.GetString(ResourcesHelper.ActiveXDuplicateControl, new object[] { this.GetNameForControl(control) }), "ctl");
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

            internal void OnInPlaceDeactivate(ActiveXBase<TActiveXClass, TActiveXInterface> site)
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

            internal void OnUIActivate(ActiveXBase<TActiveXClass, TActiveXInterface> site)
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

            internal void OnUIDeactivate(ActiveXBase<TActiveXClass, TActiveXInterface> site)
            {
                this.siteUIActive = null;
                site.RemoveSelectionHandler();
                site.SetSelectionStyle(ActiveXHelper.SelectionStyle.Selected);
                site.SetEditMode(ActiveXHelper.ActiveXEditMode.None);
            }

        }
    }
}
