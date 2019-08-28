using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser.UI
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void exitWebBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Developed by: \nAnthony Marchi \nParma, Italy \n\nStudent ID: \najm151 ", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(urlBar.ToString());
        }

        private void urlBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            webBrowser1.Navigate(urlBar.ToString());
        }
    }
}
