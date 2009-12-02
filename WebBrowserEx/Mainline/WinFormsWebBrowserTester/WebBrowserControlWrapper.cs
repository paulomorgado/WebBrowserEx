namespace WinFormsWebBrowserTester
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;

    public class WebBrowserExWrapper : global::PauloMorgado.Windows.Forms.WebBrowserEx
    {
        [Category("_WinFormsWebBrowserTester")]
        [Description("Handles the NewWindowEvent")]
        [DefaultValue(false)]
        public bool HandleNewWindow { get; set; }

        public WebBrowserExWrapper()
        {
        }

        //protected override PauloMorgado.Windows.WebBrowser.WebBrowserExSiteBase CreateWebBrowserExSite(PauloMorgado.Windows.WebBrowser.WebBrowserShim webBrowserShim)
        //{
        //    if (Properties.Settings.Default.UseWebBrowserSite)
        //    {
        //        return base.CreateWebBrowserExSite(webBrowserShim);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
