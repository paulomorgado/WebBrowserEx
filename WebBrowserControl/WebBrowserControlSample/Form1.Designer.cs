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
            this.SuspendLayout();
            // 
            // webBrowserControl
            // 
            this.webBrowserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserControl.Location = new System.Drawing.Point(0, 0);
            this.webBrowserControl.Name = "webBrowserControl";
            this.webBrowserControl.Size = new System.Drawing.Size(292, 266);
            this.webBrowserControl.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.webBrowserControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Pajocomo.Windows.Forms.WebBrowserControl webBrowserControl;

    }
}

