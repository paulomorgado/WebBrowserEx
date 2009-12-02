namespace WinFormsWebBrowserTester
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.webBrowserTabs = new System.Windows.Forms.TabControl();
            this.newTab = new System.Windows.Forms.TabPage();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripWebBrowserStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stautsStripEncrytionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stautsStripPrivacyLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.webBrowserProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripBackButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripForwardButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripPropertiesButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripCloseButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripStopButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripRefreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripGoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripAddressTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.webBrowserTabs.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowserTabs
            // 
            this.webBrowserTabs.Controls.Add(this.newTab);
            this.webBrowserTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserTabs.Location = new System.Drawing.Point(0, 25);
            this.webBrowserTabs.Name = "webBrowserTabs";
            this.webBrowserTabs.SelectedIndex = 0;
            this.webBrowserTabs.ShowToolTips = true;
            this.webBrowserTabs.Size = new System.Drawing.Size(792, 519);
            this.webBrowserTabs.TabIndex = 0;
            this.webBrowserTabs.SelectedIndexChanged += new System.EventHandler(this.webBrowserTabs_SelectedIndexChanged);
            // 
            // newTab
            // 
            this.newTab.Location = new System.Drawing.Point(4, 22);
            this.newTab.Name = "newTab";
            this.newTab.Size = new System.Drawing.Size(784, 493);
            this.newTab.TabIndex = 0;
            this.newTab.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripWebBrowserStatusLabel,
            this.stautsStripEncrytionLabel,
            this.stautsStripPrivacyLabel,
            this.webBrowserProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 544);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip.ShowItemToolTips = true;
            this.statusStrip.Size = new System.Drawing.Size(792, 22);
            this.statusStrip.TabIndex = 10;
            // 
            // statusStripWebBrowserStatusLabel
            // 
            this.statusStripWebBrowserStatusLabel.Name = "statusStripWebBrowserStatusLabel";
            this.statusStripWebBrowserStatusLabel.Size = new System.Drawing.Size(675, 17);
            this.statusStripWebBrowserStatusLabel.Spring = true;
            this.statusStripWebBrowserStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stautsStripEncrytionLabel
            // 
            this.stautsStripEncrytionLabel.AutoSize = false;
            this.stautsStripEncrytionLabel.Image = ((System.Drawing.Image)(resources.GetObject("stautsStripEncrytionLabel.Image")));
            this.stautsStripEncrytionLabel.Name = "stautsStripEncrytionLabel";
            this.stautsStripEncrytionLabel.Size = new System.Drawing.Size(20, 17);
            this.stautsStripEncrytionLabel.Visible = false;
            // 
            // stautsStripPrivacyLabel
            // 
            this.stautsStripPrivacyLabel.Image = ((System.Drawing.Image)(resources.GetObject("stautsStripPrivacyLabel.Image")));
            this.stautsStripPrivacyLabel.Name = "stautsStripPrivacyLabel";
            this.stautsStripPrivacyLabel.Size = new System.Drawing.Size(16, 17);
            this.stautsStripPrivacyLabel.ToolTipText = "Privacy Impacted";
            this.stautsStripPrivacyLabel.Visible = false;
            // 
            // webBrowserProgressBar
            // 
            this.webBrowserProgressBar.Name = "webBrowserProgressBar";
            this.webBrowserProgressBar.Size = new System.Drawing.Size(100, 16);
            this.webBrowserProgressBar.ToolTipText = "Progress";
            // 
            // toolStrip
            // 
            this.toolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBackButton,
            this.toolStripForwardButton,
            this.toolStripPropertiesButton,
            this.toolStripCloseButton,
            this.toolStripStopButton,
            this.toolStripRefreshButton,
            this.toolStripGoButton,
            this.toolStripAddressTextBox});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(792, 25);
            this.toolStrip.TabIndex = 11;
            this.toolStrip.Layout += new System.Windows.Forms.LayoutEventHandler(this.toolStrip_Layout);
            // 
            // toolStripBackButton
            // 
            this.toolStripBackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBackButton.Enabled = false;
            this.toolStripBackButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBackButton.Image")));
            this.toolStripBackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBackButton.Name = "toolStripBackButton";
            this.toolStripBackButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripBackButton.Text = "Back";
            this.toolStripBackButton.Click += new System.EventHandler(this.toolStripBackButton_Click);
            // 
            // toolStripForwardButton
            // 
            this.toolStripForwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripForwardButton.Enabled = false;
            this.toolStripForwardButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripForwardButton.Image")));
            this.toolStripForwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripForwardButton.Name = "toolStripForwardButton";
            this.toolStripForwardButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripForwardButton.Text = "Forward";
            this.toolStripForwardButton.Click += new System.EventHandler(this.toolStripForwardButton_Click);
            // 
            // toolStripPropertiesButton
            // 
            this.toolStripPropertiesButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripPropertiesButton.CheckOnClick = true;
            this.toolStripPropertiesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPropertiesButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPropertiesButton.Image")));
            this.toolStripPropertiesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPropertiesButton.Name = "toolStripPropertiesButton";
            this.toolStripPropertiesButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripPropertiesButton.Text = "Properties";
            this.toolStripPropertiesButton.Click += new System.EventHandler(this.toolStripPropertiesButton_Click);
            // 
            // toolStripCloseButton
            // 
            this.toolStripCloseButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripCloseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCloseButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCloseButton.Image")));
            this.toolStripCloseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCloseButton.Name = "toolStripCloseButton";
            this.toolStripCloseButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripCloseButton.Text = "Close";
            this.toolStripCloseButton.Click += new System.EventHandler(this.toolStripCloseButton_Click);
            // 
            // toolStripStopButton
            // 
            this.toolStripStopButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripStopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStopButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStopButton.Image")));
            this.toolStripStopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStopButton.Name = "toolStripStopButton";
            this.toolStripStopButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripStopButton.Text = "Stop";
            this.toolStripStopButton.Click += new System.EventHandler(this.toolStripStopButton_Click);
            // 
            // toolStripRefreshButton
            // 
            this.toolStripRefreshButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripRefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRefreshButton.Image")));
            this.toolStripRefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRefreshButton.Name = "toolStripRefreshButton";
            this.toolStripRefreshButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripRefreshButton.Text = "Refresh";
            this.toolStripRefreshButton.Click += new System.EventHandler(this.toolStripRefreshButton_Click);
            // 
            // toolStripGoButton
            // 
            this.toolStripGoButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripGoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripGoButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripGoButton.Image")));
            this.toolStripGoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripGoButton.Name = "toolStripGoButton";
            this.toolStripGoButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripGoButton.Text = "Go";
            this.toolStripGoButton.Click += new System.EventHandler(this.toolStripGoButton_Click);
            // 
            // toolStripAddressTextBox
            // 
            this.toolStripAddressTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.toolStripAddressTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.toolStripAddressTextBox.Name = "toolStripAddressTextBox";
            this.toolStripAddressTextBox.Size = new System.Drawing.Size(223, 25);
            this.toolStripAddressTextBox.ToolTipText = "Address";
            this.toolStripAddressTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripAddressTextBox_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.webBrowserTabs);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.webBrowserTabs.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl webBrowserTabs;
        private System.Windows.Forms.TabPage newTab;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusStripWebBrowserStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel stautsStripEncrytionLabel;
        private System.Windows.Forms.ToolStripStatusLabel stautsStripPrivacyLabel;
        private System.Windows.Forms.ToolStripProgressBar webBrowserProgressBar;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripBackButton;
        private System.Windows.Forms.ToolStripButton toolStripForwardButton;
        private System.Windows.Forms.ToolStripButton toolStripPropertiesButton;
        private System.Windows.Forms.ToolStripButton toolStripStopButton;
        private System.Windows.Forms.ToolStripButton toolStripRefreshButton;
        private System.Windows.Forms.ToolStripButton toolStripGoButton;
        private System.Windows.Forms.ToolStripTextBox toolStripAddressTextBox;
        private System.Windows.Forms.ToolStripButton toolStripCloseButton;
    }
}

