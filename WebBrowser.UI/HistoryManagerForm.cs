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
    public partial class HistoryManagerForm : Form
    {
        public HistoryManagerForm()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HistoryManagerForm_Load(object sender, EventArgs e)
        {
            
        }

        private void ProgramViwer_Load(object sender, EventArgs e)
        {
            foreach (WebBrowser.Logic.HistoryItem item in WebBrowser.Logic.HistoryManager.GetHistoryItems())
            {
                listBox1.Items.Add("[" + item.Date + "]" + " " + item.Title + " " + "(" + item.URL + ")");
            } 
           
          
        }
    }
}
