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
                listBox1.Items.Add(item.title.ToString().Trim() + " " + "(" + item.url.ToString().Trim() + ")");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<WebBrowser.Logic.BookmarkItem> newList = new List<WebBrowser.Logic.BookmarkItem>(WebBrowser.Logic.BookmarkManager.GetBookmarkItems());
            foreach (WebBrowser.Logic.BookmarkItem itemTwo in newList)
            {
                if (textBox1.Text == itemTwo.title)
                {
                    listBox1.Items.Add(itemTwo.title.ToString().Trim() + " " + "(" + itemTwo.url.ToString().Trim() + ")");
                }
                else if (textBox1.Text == itemTwo.url)
                {
                    listBox1.Items.Add(itemTwo.title.ToString().Trim() + " " + "(" + itemTwo.url.ToString().Trim() + ")");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<WebBrowser.Logic.BookmarkItem> dList = new List<WebBrowser.Logic.BookmarkItem>(WebBrowser.Logic.BookmarkManager.GetBookmarkItems());

            int bookmarkID = dList[listBox1.SelectedIndex].bookmarkID;
            string url = dList[listBox1.SelectedIndex].url.Trim();
            string title = dList[listBox1.SelectedIndex].title.Trim();

            WebBrowser.Logic.BookmarkManager.deleteBookmark(bookmarkID, title, url);

            listBox1.Items.Clear();

            List<WebBrowser.Logic.BookmarkItem> eList = new List<WebBrowser.Logic.BookmarkItem>(WebBrowser.Logic.BookmarkManager.GetBookmarkItems());
            foreach (WebBrowser.Logic.BookmarkItem thing in eList)
            {
                listBox1.Items.Add(thing.title.ToString().Trim() + " " + "(" + thing.url.ToString().Trim() + ")");
            }
        }
    }
}
