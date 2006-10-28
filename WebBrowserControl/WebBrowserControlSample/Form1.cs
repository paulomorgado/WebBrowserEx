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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string url = "http://www.codeplex.com/";
            object nullObject = null;
            this.webBrowserControl.ActiveXWebBRowser2.Navigate(url, ref nullObject, ref nullObject, ref nullObject, ref nullObject);
        }
    }
}