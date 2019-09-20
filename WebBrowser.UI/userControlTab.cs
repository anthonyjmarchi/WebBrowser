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
            backStack.Push(urlBar.ToString());
        }

        private void urlBar_Click(object sender, EventArgs e)
        {
         
        }

        private void urlBar_KeyDown(object sender, KeyEventArgs e)
        {
        
            if (e.KeyCode == Keys.Enter)
            {
                webBrowser1.Navigate(urlBar.ToString());
                backStack.Push(urlBar.ToString());
            }
        }

  


        //Refresh Button
        private void toolStripButton3_Click(object sender, EventArgs e)
        {   
            webBrowser1.Navigate(urlBar.ToString());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (backStack.Count == 0)
            {
                webBrowser1.Navigate(urlBar.ToString());
            }
            else
            {
                forwardStack.Push(urlBar.ToString());
                String b = backStack.Pop().ToString();
                if (b == urlBar.Text)
                {
                    b = backStack.Pop().ToString();
                }
                webBrowser1.Navigate(b);
                urlBar.Text = b;
            }  
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (forwardStack.Count == 0)
            {
                webBrowser1.Navigate(urlBar.ToString());

            }
            else {
                backStack.Push(urlBar.ToString());
                String a = forwardStack.Pop().ToString();
                webBrowser1.Navigate(a);
                urlBar.Text = a;
            }
       
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser.Logic.HistoryItem a = new Logic.HistoryItem();

            a.URL = urlBar.ToString();
            a.Title = webBrowser1.DocumentTitle;
            a.Date = DateTime.Now;

            WebBrowser.Logic.HistoryManager.AddHistoryItem(a);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            List<WebBrowser.Logic.BookmarkItem> newList = new List<Logic.BookmarkItem>();
            List<String> stringList = new List<String>();
            foreach (WebBrowser.Logic.BookmarkItem item in newList)
            {
                stringList.Add(item.title);
            }
            if (!stringList.Contains(webBrowser1.DocumentTitle)) 
            {
                WebBrowser.Logic.BookmarkItem a = new WebBrowser.Logic.BookmarkItem();
                a.title = webBrowser1.DocumentTitle;
                a.url = urlBar.ToString();
                WebBrowser.Logic.BookmarkManager.AddBookmarkItem(a);
            }
        }
    }
}
