using System;
using System.Windows.Forms;
using PauloMorgado.Windows.WebBrowser;

namespace WinFormsWebBrowserTester
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AddWebBrowserTab();
        }

        public WebBrowserContainer AddWebBrowserTab()
        {
            TabPage tabPage = new TabPage();

            WebBrowserContainer webBrowserContainer = new WebBrowserContainer(this, tabPage);
            webBrowserContainer.Dock = DockStyle.Fill;

            tabPage.Controls.Add(webBrowserContainer);
            tabPage.Tag = webBrowserContainer;

            this.webBrowserTabs.TabPages.Insert(this.webBrowserTabs.TabPages.Count - 1, tabPage);
            this.webBrowserTabs.SelectedTab = tabPage;

            return webBrowserContainer;
        }

        private void webBrowserTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.webBrowserTabs.SelectedTab == this.newTab)
            {
                AddWebBrowserTab();
            }

            WebBrowserContainer webBrowserContainer = GetSelectedWebBrowser();

            SetCanGoBackPrivate(webBrowserContainer);
            SetCanGoForwardPrivate(webBrowserContainer);
            SetLocationAddressPrivate(webBrowserContainer);
            SetLocationTitlePrivate(webBrowserContainer);
            SetStatusTextPrivate(webBrowserContainer);
            SetEncrytionPrivate(webBrowserContainer);
            SetPrivacyPrivate(webBrowserContainer);
            SetPropertyGridVisiblePrivate(webBrowserContainer);
        }

        private void toolStrip_Layout(object sender, LayoutEventArgs e)
        {
            if ((e.AffectedProperty == "Bounds") || (e.AffectedProperty == "Visible"))
            {
                int toolStripAddressTextBoxWidth = this.toolStrip.DisplayRectangle.Width - this.toolStripAddressTextBox.Margin.Horizontal;
                foreach (ToolStripItem toolStripItem in this.toolStrip.Items)
                {
                    if ((toolStripItem != this.toolStripAddressTextBox) && (toolStripItem.Visible))
                    {
                        toolStripAddressTextBoxWidth -= toolStripItem.Width - toolStripItem.Margin.Horizontal;
                    }
                }

                this.toolStripAddressTextBox.Size = new System.Drawing.Size(toolStripAddressTextBoxWidth, this.toolStripAddressTextBox.Height);
            }
        }

        private void toolStripPropertiesButton_Click(object sender, EventArgs e)
        {
            GetSelectedWebBrowser().WebBrowserPropertyGridVisible = this.toolStripPropertiesButton.Checked;
        }

        private void toolStripBackButton_Click(object sender, EventArgs e)
        {
            GetSelectedWebBrowser().WebBrowserGoBack();
        }

        private void toolStripForwardButton_Click(object sender, EventArgs e)
        {
            GetSelectedWebBrowser().WebBrowserGoForward();
        }

        private void toolStripGoButton_Click(object sender, EventArgs e)
        {
            WebBrowserNavigate();
        }

        private void toolStripRefreshButton_Click(object sender, EventArgs e)
        {
            GetSelectedWebBrowser().WebBrowserRefresh();
        }

        private void toolStripStopButton_Click(object sender, EventArgs e)
        {
            GetSelectedWebBrowser().WebBrowserStop();
        }

        private void toolStripCloseButton_Click(object sender, EventArgs e)
        {
            CloseTab(this.webBrowserTabs.SelectedTab);
        }

        public void SetStatusText(WebBrowserContainer webBrowserContainer)
        {
            if (this.webBrowserTabs.SelectedTab == webBrowserContainer.TabPage)
            {
                SetStatusTextPrivate(webBrowserContainer);
            }
        }

        public void SetPrivacy(WebBrowserContainer webBrowserContainer)
        {
            if (this.webBrowserTabs.SelectedTab == webBrowserContainer.TabPage)
            {
                SetPrivacyPrivate(webBrowserContainer);
            }
        }

        public void SetEncrytion(WebBrowserContainer webBrowserContainer)
        {
            if (this.webBrowserTabs.SelectedTab == webBrowserContainer.TabPage)
            {
                SetEncrytionPrivate(webBrowserContainer);
            }
        }

        public void SetProgress(WebBrowserContainer webBrowserContainer)
        {
            if (this.webBrowserTabs.SelectedTab == webBrowserContainer.TabPage)
            {
                SetProgressPrivate(webBrowserContainer);
            }
        }

        private void SetEncrytionPrivate(WebBrowserContainer webBrowserContainer)
        {
            WebBrowserEncryptionLevel encryptionLevel = webBrowserContainer.WebBrowserEncryptionLevel;
            if (encryptionLevel != WebBrowserEncryptionLevel.Insecure)
            {
                this.stautsStripEncrytionLabel.ToolTipText = encryptionLevel.ToString();
                this.stautsStripEncrytionLabel.Visible = true;
            }
            else
            {
                this.stautsStripEncrytionLabel.Visible = false;
            }
        }

        private void SetPrivacyPrivate(WebBrowserContainer webBrowserContainer)
        {
            this.stautsStripPrivacyLabel.Visible = webBrowserContainer.WebBrowserPrivacyImpacted;
        }

        public void SetCanGoForward(WebBrowserContainer webBrowserContainer)
        {
            if (this.webBrowserTabs.SelectedTab == webBrowserContainer.TabPage)
            {
                SetCanGoForwardPrivate(webBrowserContainer);
            }
        }

        public void SetCanGoBack(WebBrowserContainer webBrowserContainer)
        {
            if (this.webBrowserTabs.SelectedTab == webBrowserContainer.TabPage)
            {
                SetCanGoBackPrivate(webBrowserContainer);
            }
        }

        public void SetLocationAddress(WebBrowserContainer webBrowserContainer)
        {
            if (this.webBrowserTabs.SelectedTab == webBrowserContainer.TabPage)
            {
                SetLocationAddressPrivate(webBrowserContainer);
            }
        }

        public void SetLocationTitle(WebBrowserContainer webBrowserContainer)
        {
            if (this.webBrowserTabs.SelectedTab == webBrowserContainer.TabPage)
            {
                SetLocationTitlePrivate(webBrowserContainer);
            }
        }

        private void SetStatusTextPrivate(WebBrowserContainer webBrowserContainer)
        {
            this.statusStripWebBrowserStatusLabel.Text = webBrowserContainer.WebBrowserStatusText;
        }

        private void SetProgressPrivate(WebBrowserContainer webBrowserContainer)
        {
            int currentProgress = webBrowserContainer.WebBrowserCurrentProgress;
            int maximumProgress = webBrowserContainer.WebBrowserMaximumProgress;
            if (currentProgress < maximumProgress && maximumProgress > 0 && currentProgress > 0)
            {
                this.webBrowserProgressBar.Visible = true;
                if (currentProgress > this.webBrowserProgressBar.Maximum)
                {
                    this.webBrowserProgressBar.Maximum = maximumProgress;
                    this.webBrowserProgressBar.Value = currentProgress;
                }
                else
                {
                    this.webBrowserProgressBar.Value = currentProgress;
                    this.webBrowserProgressBar.Maximum = maximumProgress;
                }
            }
            else
            {
                this.webBrowserProgressBar.Visible = false;
                this.webBrowserProgressBar.Value = 0;
                this.webBrowserProgressBar.Maximum = 0;
            }
        }

        private void SetPropertyGridVisiblePrivate(WebBrowserContainer webBrowserContainer)
        {
            this.toolStripPropertiesButton.Checked = webBrowserContainer.WebBrowserPropertyGridVisible;
        }

        private void SetCanGoBackPrivate(WebBrowserContainer webBrowserContainer)
        {
            this.toolStripBackButton.Enabled = webBrowserContainer.WebBrowserCanGoBack;
        }

        private void SetCanGoForwardPrivate(WebBrowserContainer webBrowserContainer)
        {
            this.toolStripForwardButton.Enabled = webBrowserContainer.WebBrowserCanGoForward;
        }

        private void SetLocationAddressPrivate(WebBrowserContainer webBrowserContainer)
        {
            this.toolStripAddressTextBox.Text = webBrowserContainer.WebBrowserLocationAddress;
        }

        private void SetLocationTitlePrivate(WebBrowserContainer webBrowserContainer)
        {
            this.Text = webBrowserContainer.Text;
        }

        private WebBrowserContainer GetSelectedWebBrowser()
        {
            return this.webBrowserTabs.SelectedTab.Tag as WebBrowserContainer;
        }

        private void toolStripAddressTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Modifiers == 0)
            {
                WebBrowserNavigate();
            }
        }

        private void WebBrowserNavigate()
        {
            GetSelectedWebBrowser().WebBrowserNavigate(this.toolStripAddressTextBox.Text);
        }

        public void CloseTab(TabPage tabPage)
        {
            tabPage.Dispose();
            //this.webBrowserTabs.TabPages.Remove(tabPage);
        }
    }
}
