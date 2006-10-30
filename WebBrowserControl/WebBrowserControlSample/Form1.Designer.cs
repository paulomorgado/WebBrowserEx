namespace WebBrowserControlSample
{
    partial class Form1
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
            this.webBrowserControl = new Pajocomo.Windows.Forms.WebBrowserControl();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.inputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowserControl
            // 
            this.webBrowserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserControl.Location = new System.Drawing.Point(0, 32);
            this.webBrowserControl.Name = "webBrowserControl";
            this.webBrowserControl.Size = new System.Drawing.Size(292, 234);
            this.webBrowserControl.TabIndex = 0;
            // 
            // inputPanel
            // 
            this.inputPanel.Controls.Add(this.goButton);
            this.inputPanel.Controls.Add(this.urlTextBox);
            this.inputPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputPanel.Location = new System.Drawing.Point(0, 0);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(292, 32);
            this.inputPanel.TabIndex = 1;
            // 
            // urlTextBox
            // 
            this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.urlTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.urlTextBox.Location = new System.Drawing.Point(4, 4);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(246, 20);
            this.urlTextBox.TabIndex = 0;
            this.urlTextBox.Text = "http://www.codeplex.com/";
            // 
            // goButton
            // 
            this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goButton.Location = new System.Drawing.Point(256, 4);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(33, 20);
            this.goButton.TabIndex = 1;
            this.goButton.Text = "GO";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.webBrowserControl);
            this.Controls.Add(this.inputPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Pajocomo.Windows.Forms.WebBrowserControl webBrowserControl;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.TextBox urlTextBox;

    }
}

