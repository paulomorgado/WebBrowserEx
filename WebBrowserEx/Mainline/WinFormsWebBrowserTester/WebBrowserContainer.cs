namespace WinFormsWebBrowserTester
{
    using System;
    using System.Windows.Forms;
    using PauloMorgado.Windows.WebBrowser;
    using System.Diagnostics;
    using System.ComponentModel;
    using System.Drawing;
    using PauloMorgado.ComponentModel;

    public partial class WebBrowserContainer : UserControl
    {
        private static int instances = 0;

        private int instance = 0;
        private int currentProgress = 0;
        private int maximumProgress = 0;
        private string statusText;
        private string locationTitle;
        private string locationAddress;
        private WebBrowserEncryptionLevel encryptionLevel;
        private MainForm form;
        private TabPage tabPage;

        public WebBrowserContainer(MainForm form, TabPage tabPage)
        {
            this.form = form;
            this.tabPage = tabPage;

            this.instance = ++instances;

            InitializeComponent();

            ////if (this.instance == 1)
            ////{
            ////    this.locationAddress = Application.StartupPath + @"\HTMLPage.htm";
            ////}
            ////else
            {
                this.locationAddress = "about:blank";
            }

            ////this.WebBrowserEx.Url = this.locationAddress;

            this.WebBrowserEx.UserAgent = string.IsNullOrEmpty(Properties.Settings.Default.UserAgent) ? null : Properties.Settings.Default.UserAgent;

            SetText();
        }

        private WebBrowserContainer()
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.WebBrowserEx.WebBrowser.Navigate(this.locationAddress);
        }

        private void WebBrowserEx_Closed(object sender, System.EventArgs e)
        {
            Trace.WriteLine(string.Empty, string.Format("[{0}] WebBrowserEx.WindowClosed", this.instance));
            this.form.CloseTab(this.tabPage);
        }

        private void WebBrowserEx_Closing(object sender, PauloMorgado.Windows.WebBrowser.WebBrowserClosingEventArgs e)
        {
            Trace.WriteLine(string.Format("IsChildWindow={1}, >>Cancel={0}", e.Cancel, e.IsChildWindow), "[" + this.instance + "] WebBrowserEx.WindowClosing");
            e.Cancel = (MessageBox.Show("Web browser window being closed by script. Alow?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes);
            Trace.WriteLine(string.Format("<<Cancel={0}", e.Cancel), string.Format("[{0}] WebBrowserEx.WindowClosing", this.instance));
        }

        private void WebBrowserEx_DocumentCompleted(object sender, PauloMorgado.Windows.WebBrowser.WebBrowserDocumentCompletedEventArgs e)
        {
            Trace.WriteLine(string.Format("URL={0}", e.Url), string.Format("[{0}] WebBrowserEx.DocumentCompleted", this.instance));
        }

        private void WebBrowserEx_Downloading(object sender, EventArgs e)
        {
            Trace.WriteLine(string.Empty, string.Format("[{0}] WebBrowserEx.Downloading", this.instance));
        }

        private void WebBrowserEx_Downloaded(object sender, EventArgs e)
        {
            Trace.WriteLine(string.Empty, string.Format("[{0}] WebBrowserEx.Downloaded", this.instance));
        }

        private void WebBrowserEx_FileDownloading(object sender, WebBrowserDownloadingFileEventArgs e)
        {
            Trace.WriteLine(string.Format("ActiveDocumentServerLoading={0}, Cancel={1}", e.ActiveDocumentServerLoading, e.Cancel), "[" + this.instance + "] WebBrowserEx.FileDownloading");
        }

        private void WebBrowserEx_WindowSizeChanged(object sender, ReadOnlyValueEventArgs<Size> e)
        {

        }

        private void WebBrowserEx_Navigated(object sender, PauloMorgado.Windows.WebBrowser.WebBrowserNavigatedEventArgs e)
        {
            Trace.WriteLine(string.Format("URL={0}", e.Url), string.Format("[{0}] WebBrowserEx.Navigated", this.instance));

            if (this.WebBrowserEx.WebBrowser.Equals(e.WebBrowser))
            {
                this.locationAddress = e.Url.ToString();
                this.form.SetLocationAddress(this);
            }
        }

        private void WebBrowserEx_NavigateError(object sender, WebBrowserNavigateErrorEventArgs e)
        {
            Trace.WriteLine(string.Format("URL={0}, TargetFrameName={1}, StatusCode={2}", e.Url, e.TargetFrameName, e.StatusCode), string.Format("[{0}] WebBrowserEx.NavigateError", this.instance));
        }

        private void WebBrowserEx_Navigating(object sender, PauloMorgado.Windows.WebBrowser.WebBrowserNavigatingEventArgs e)
        {
            Trace.WriteLine(string.Format("URL={0}, TargetFrameName={1}, Cancel={2}", e.Url, e.TargetFrameName, e.Cancel), string.Format("[{0}] WebBrowserEx.Navigating", this.instance));
        }

        private void WebBrowserEx_NewWindow(object sender, PauloMorgado.Windows.WebBrowser.WebBrowserNewWindowEventArgs e)
        {
            Trace.WriteLine(string.Format("Url=\"{0}\", UrlContext=\"{1}\", Flags={2}, >>Cancel={0}", e.Url, e.UrlContext, e.Flags, e.Cancel), string.Format("[{0}] WebBrowserEx.NewWindowEx", this.instance));

            //e.Cancel = !this.WebBrowserEx.AllowNewWindow && (MessageBox.Show("Web browser window being opened by script. Alow?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes);
            if (this.WebBrowserEx.HandleNewWindow && !e.Cancel)
            {
                e.WebBrowser = this.form.AddWebBrowserTab().WebBrowserEx.WebBrowser;
            }
            Trace.WriteLine(string.Format("Url=\"{0}\", UrlContext=\"{1}\", Flags={2}, <<Cancel={0}", e.Url, e.UrlContext, e.Flags, e.Cancel), string.Format("[{0}] WebBrowserEx.NewWindowEx", this.instance));
        }

        private void WebBrowserEx_PrivacyImpactedChanged(object sender, EventArgs e)
        {
            Trace.WriteLine(string.Format("PrivacyImpacted={0}", WebBrowserPrivacyImpacted), string.Format("[{0}] WebBrowserEx.PrivacyImpactedChanged", this.instance));
            this.form.SetPrivacy(this);
        }

        private void WebBrowserEx_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            this.currentProgress = (int)e.CurrentProgress;
            this.maximumProgress = (int)e.MaximumProgress;
            Trace.WriteLine(string.Format("Current={0}, Maximum={1}", this.currentProgress, this.maximumProgress), string.Format("[{0}] WebBrowserEx.ProgressChanged", this.instance));
            try
            {
                this.form.SetProgress(this);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString(), string.Format("[{0}] WebBrowserEx.ProgressChanged", this.instance));
            }
        }

        private void WebBrowserEx_CanGoBackChanged(object sender, EventArgs e)
        {
            Trace.WriteLine(string.Empty, string.Format("[{0}] WebBrowserEx.CanGoBackChanged", this.instance));
            this.form.SetCanGoBack(this);
        }

        private void WebBrowserEx_CanGoForwardChanged(object sender, EventArgs e)
        {
            Trace.WriteLine(string.Empty, string.Format("[{0}] WebBrowserEx.CanGoForwardChanged", this.instance));
            this.form.SetCanGoForward(this);
        }

        private void WebBrowserEx_StatusTextChanged(object sender, EventArgs e)
        {
            this.statusText = this.WebBrowserEx.StatusText;
            Trace.WriteLine(string.Format("StatusText=\"{0}\"", this.statusText), string.Format("[{0}] WebBrowserEx.StatusTextChanged", this.instance));
            this.form.SetStatusText(this);
        }

        private void WebBrowserEx_LocationNameChanged(object sender, EventArgs e)
        {
            this.locationTitle = this.WebBrowserEx.WebBrowser.LocationName;
            SetText();
            Trace.WriteLine(string.Format("LocationName=\"{0}\"", this.locationTitle), string.Format("[{0}] WebBrowserEx.DocumentTitleChanged", this.instance));
        }

        private void WebBrowserEx_ResizableChanged(object sender, EventArgs e)
        {
            //bool resizable = this.WebBrowserEx.Resizable;
            ////this.FormBorderStyle = (resizable) ? FormBorderStyle.Sizable : FormBorderStyle.Fixed3D;
            //Trace.WriteLine(string.Format("Resizable={0}", resizable), "[" + this.instance + "] WebBrowserEx.ResizableChanged");
        }

        private void WebBrowserEx_EncryptionLevelChanged(object sender, EventArgs e)
        {
            this.encryptionLevel = this.WebBrowserEx.EncryptionLevel;
            Trace.WriteLine(string.Format("EncryptionLevel={0}", encryptionLevel), string.Format("[{0}] WebBrowserEx.EncryptionLevelChanged", this.instance));
            this.form.SetEncrytion(this);
        }

        void WebBrowserEx_ShowMessage(object sender, WebBrowserShowMessageEventArgs e)
        {
            Trace.WriteLine(string.Format("Caption=\"{0}\", Text=\"{1}\", Buttons={2}, Icon={3}, >>Result={4}, >>Handled={5}", e.Caption, e.Text, e.Buttons, e.Icon, e.Result, e.Handled), "[" + this.instance + "] WebBrowserEx.EncryptionLevelChanged");
            e.Result = MessageBox.Show(e.Window, e.Text, (string.Format("WebBrowserEx {0}", this.instance)), e.Buttons, e.Icon);
            e.Handled = true;
            Trace.WriteLine(string.Format("Caption=\"{0}\", Text=\"{1}\", Buttons={2}, Icon={3}, <<Result={4}, <<Handled={5}", e.Caption, e.Text, e.Buttons, e.Icon, e.Result, e.Handled), "[" + this.instance + "] WebBrowserEx.EncryptionLevelChanged");
        }

        private void SetText()
        {
            this.tabPage.ToolTipText = this.Text = this.locationTitle;
            this.tabPage.Text = this.locationTitle != null && this.locationTitle.Length > 50 ? string.Format("{0}..", this.locationTitle.Substring(0, 47)) : this.locationTitle;
            this.form.SetLocationTitle(this);
        }

        public TabPage TabPage
        {
            get
            {
                return this.tabPage;
            }
        }

        public WebBrowserEncryptionLevel WebBrowserEncryptionLevel
        {
            get
            {
                return this.encryptionLevel;
            }
        }

        public string WebBrowserStatusText
        {
            get
            {
                return this.statusText;
            }
        }

        public int WebBrowserCurrentProgress
        {
            get
            {
                return this.currentProgress;
            }
        }

        public int WebBrowserMaximumProgress
        {
            get
            {
                return this.maximumProgress;
            }
        }

        public bool WebBrowserPropertyGridVisible
        {
            get
            {
                return !this.splitContainer.Panel2Collapsed;
            }
            set
            {
                this.webBrowserPropertyGrid.SelectedObject =
                    (this.splitContainer.Panel2Collapsed = !value)
                    ? null
                    : this.WebBrowserEx;
            }
        }

        public void WebBrowserGoBack()
        {
            this.WebBrowserEx.WebBrowser.GoBack();
        }

        public void WebBrowserGoForward()
        {
            this.WebBrowserEx.WebBrowser.GoForward();
        }

        public void WebBrowserRefresh()
        {
            this.WebBrowserEx.WebBrowser.Refresh();
        }

        public void WebBrowserStop()
        {
            this.WebBrowserEx.WebBrowser.Stop();
        }

        public void WebBrowserNavigate(string url)
        {
            this.WebBrowserEx.WebBrowser.Navigate(url);
        }

        public bool WebBrowserCanGoBack
        {
            get
            {
                return this.WebBrowserEx.CanGoBack;
            }
        }

        public bool WebBrowserCanGoForward
        {
            get
            {
                return this.WebBrowserEx.CanGoForward;
            }
        }

        public string WebBrowserLocationAddress
        {
            get
            {
                return this.locationAddress;
            }
        }

        public string WebBrowserLocationTitle
        {
            get
            {
                return this.locationTitle;
            }
        }

        public int Instance
        {
            get
            {
                return instance;
            }
        }

        public bool WebBrowserPrivacyImpacted
        {
            get
            {
                return this.WebBrowserEx.PrivacyImpacted;
            }
        }

        private void webBrowserPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            this.WebBrowserEx.Refresh();
        }
    }
}
