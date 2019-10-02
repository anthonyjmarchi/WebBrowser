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

        //Go Button
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(urlBar.ToString());
            backStack.Push(urlBar.ToString());
        }

        private void urlBar_Click(object sender, EventArgs e)
        {
         
        }

        //Enter Key for URL Bar
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
        
        //Forward Button
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

        //Backward Button
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

        //Add Item to History
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser.Logic.HistoryItem a = new Logic.HistoryItem();

            a.URL = urlBar.ToString();
            a.Title = webBrowser1.DocumentTitle;
            a.Date = DateTime.Now;

            WebBrowser.Logic.HistoryManager.AddHistoryItem(a);
        }

        //Add Bookmark Button
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

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
           
        }

        private void WebBrowser1_ProgressChanged(Object sender,
                                         WebBrowserProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Maximum = (int)e.MaximumProgress;
            toolStripProgressBar1.Value = (int)e.CurrentProgress;
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            String google = "www.google.com";
            webBrowser1.Navigate(google);
            backStack.Push(urlBar.ToString());
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            toolStripStatusLabel1.Text = "loading";
            toolStripProgressBar1.MarqueeAnimationSpeed = 30;
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
        }

        //Navigate (Progress Bar and Mouse Over)
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            toolStripProgressBar1.MarqueeAnimationSpeed = 0;
            toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
            toolStripStatusLabel1.Text = "done";
            this.webBrowser1.Document.MouseOver += new HtmlElementEventHandler(this.Browser_Mouse_Moved);
        }

        private void Browser_Mouse_Moved(object sender, HtmlElementEventArgs e)
        {
            string element = webBrowser1.Document.GetElementFromPoint(e.ClientMousePosition).GetAttribute("href");
            toolStripStatusLabel2.Text = element;
        }

        public void printPage(object sender, EventArgs e) {
            webBrowser1.ShowPrintDialog();
        }
    }
}
