using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WebBrowserControlSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            object url = this.urlTextBox.Text;
            object flags = 0;
            object nullObject = null;
            this.webBrowserControl.ActiveXWebBRowser2.Navigate2(ref url, ref flags, ref nullObject, ref nullObject, ref nullObject);
        }
    }
}