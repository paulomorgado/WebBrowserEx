using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Drawing;

namespace Pajocomo.Windows.Forms
{
    /// <summary>
    /// Enables the user to navigate Web pages inside your form.
    /// </summary>
    /// <filterpriority>1</filterpriority>
    [
    ComVisible(true),
    //Designer("System.Windows.Forms.Design.WebBrowserDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"),
    DefaultProperty("Url"),
    ClassInterface(ClassInterfaceType.AutoDispatch), DefaultEvent("DocumentCompleted"),
    Docking(DockingBehavior.AutoDock),
    ResourcesDescription("DescriptionWebBrowser"), PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust"),
    ToolboxItem(true),
    ToolboxBitmap(typeof(System.Windows.Forms.WebBrowser)),
    PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")
    ]
    public class WebBrowserControl : ActiveXBase<UnsafeNativeMethods.IWebBrowser2>
    {
        public UnsafeNativeMethods.IWebBrowser2 ActiveXWebBRowser2
        {
            get
            {
                return base.ActiveXInstance;
            }
        }
    }
}
