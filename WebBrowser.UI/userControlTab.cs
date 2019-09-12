using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser.UI
{
    public partial class userControlTab : UserControl
    {
        public Stack<string> backStack = new Stack<string>();
        public Stack<string> forwardStack = new Stack<string>();
        
            public userControlTab()
        {
            InitializeComponent();
        }


        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(urlBar.ToString());
        }

        private void urlBar_Click(object sender, EventArgs e)
        {
         
        }

        private void urlBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webBrowser1.Navigate(urlBar.ToString());
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(urlBar.ToString());
        }

    }
}
