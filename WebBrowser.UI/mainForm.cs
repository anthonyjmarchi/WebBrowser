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

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Developed by: \nAnthony Marchi \nParma, Italy \n\nStudent ID: \najm151 ", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitWebBrowserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage newPage = new TabPage("New Page");
            userControlTab a = new userControlTab();
            a.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(newPage);
            newPage.Controls.Add(a);
            tabControl1.SelectedTab = newPage;
        }

        private void closeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.T)
            {
                TabPage newPage = new TabPage("New Page");
                userControlTab a = new userControlTab();
                a.Dock = DockStyle.Fill;
                tabControl1.TabPages.Add(newPage);
                newPage.Controls.Add(a);
                tabControl1.SelectedTab = newPage;
            }
        }

        private void manageHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryManagerForm historyFormThing = new HistoryManagerForm();
            historyFormThing.ShowDialog();

        }

        private void userControlTab1_Load(object sender, EventArgs e)
        {

        }
    }
}

