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
    public partial class BookmarkManager : Form
    {
        public BookmarkManager()
        {
            InitializeComponent();
        }

        private void ProgramViwer_Load(object sender, EventArgs e)
        {
            foreach (WebBrowser.Logic.BookmarkItem item in WebBrowser.Logic.BookmarkManager.GetBookmarkItems())
            {
                listBox1.Items.Add(item.title + "(" + item.url + ")");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    
    }
}
