namespace WinFormsWebBrowserTester
{
    using System;

    partial class WebBrowserContainer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WebBrowserEx = new WebBrowserExWrapper();
            this.webBrowserPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // WebBrowserExShim
            // 
            this.WebBrowserEx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebBrowserEx.Location = new System.Drawing.Point(0, 0);
            this.WebBrowserEx.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowserEx.Name = "WebBrowserExShim";
            this.WebBrowserEx.Size = new System.Drawing.Size(600, 400);
            this.WebBrowserEx.TabIndex = 6;
            this.WebBrowserEx.HandleNewWindow = true;
            this.WebBrowserEx.RegisterAsBrowser = true;
            this.WebBrowserEx.StatusTextChanged += new EventHandler<PauloMorgado.ComponentModel.ReadOnlyValueEventArgs<string>>(this.WebBrowserEx_StatusTextChanged);
            this.WebBrowserEx.CanGoForwardChanged += new System.EventHandler(this.WebBrowserEx_CanGoForwardChanged);
            this.WebBrowserEx.CanGoBackChanged += new System.EventHandler(this.WebBrowserEx_CanGoBackChanged);
            this.WebBrowserEx.Downloading += new System.EventHandler(this.WebBrowserEx_Downloading);
            this.WebBrowserEx.Navigated += new System.EventHandler<PauloMorgado.Windows.WebBrowser.WebBrowserNavigatedEventArgs>(this.WebBrowserEx_Navigated);
            this.WebBrowserEx.Navigating += new System.EventHandler<PauloMorgado.Windows.WebBrowser.WebBrowserNavigatingEventArgs>(this.WebBrowserEx_Navigating);
            this.WebBrowserEx.NewWindow += new System.EventHandler<PauloMorgado.Windows.WebBrowser.WebBrowserNewWindowEventArgs>(this.WebBrowserEx_NewWindow);
            this.WebBrowserEx.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.WebBrowserEx_ProgressChanged);
            this.WebBrowserEx.DownloadingFile += new System.EventHandler<PauloMorgado.Windows.WebBrowser.WebBrowserDownloadingFileEventArgs>(this.WebBrowserEx_FileDownloading);
            this.WebBrowserEx.EncryptionLevelChanged += new System.EventHandler(this.WebBrowserEx_EncryptionLevelChanged);
            this.WebBrowserEx.TextChanged += new System.EventHandler(this.WebBrowserEx_LocationNameChanged);
            this.WebBrowserEx.PrivacyImpactedChanged += new System.EventHandler(this.WebBrowserEx_PrivacyImpactedChanged);
            this.WebBrowserEx.DocumentCompleted += new System.EventHandler<PauloMorgado.Windows.WebBrowser.WebBrowserDocumentCompletedEventArgs>(this.WebBrowserEx_DocumentCompleted);
            this.WebBrowserEx.WindowClosed += new System.EventHandler(this.WebBrowserEx_Closed);
            this.WebBrowserEx.NavigateError += new System.EventHandler<PauloMorgado.Windows.WebBrowser.WebBrowserNavigateErrorEventArgs>(this.WebBrowserEx_NavigateError);
            this.WebBrowserEx.WindowClosing += new System.EventHandler<PauloMorgado.Windows.WebBrowser.WebBrowserClosingEventArgs>(this.WebBrowserEx_Closing);
            this.WebBrowserEx.Downloaded += new System.EventHandler(this.WebBrowserEx_Downloaded);
            this.WebBrowserEx.ShowMessage += new System.EventHandler<PauloMorgado.Windows.WebBrowser.WebBrowserShowMessageEventArgs>(WebBrowserEx_ShowMessage);
            // 
            // webBrowserPropertyGrid
            // 
            this.webBrowserPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.webBrowserPropertyGrid.Name = "webBrowserPropertyGrid";
            this.webBrowserPropertyGrid.Size = new System.Drawing.Size(46, 100);
            this.webBrowserPropertyGrid.TabIndex = 7;
            this.webBrowserPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.webBrowserPropertyGrid_PropertyValueChanged);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.WebBrowserEx);
            this.splitContainer.Panel1MinSize = 100;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.webBrowserPropertyGrid);
            this.splitContainer.Panel2Collapsed = true;
            this.splitContainer.Panel2MinSize = 100;
            this.splitContainer.Size = new System.Drawing.Size(600, 400);
            this.splitContainer.SplitterDistance = 400;
            this.splitContainer.TabIndex = 8;
            // 
            // WebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "WebBrowser";
            this.Size = new System.Drawing.Size(600, 400);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid webBrowserPropertyGrid;
        private System.Windows.Forms.SplitContainer splitContainer;
        public WebBrowserExWrapper WebBrowserEx;
    }
}
