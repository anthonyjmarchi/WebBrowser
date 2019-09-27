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
            List<WebBrowser.Logic.HistoryItem> newList = new List<WebBrowser.Logic.HistoryItem>(WebBrowser.Logic.HistoryManager.GetHistoryItems());
            foreach (WebBrowser.Logic.HistoryItem item in newList)
            {
                listBox1.Items.Add("[" + item.Date + "]" + " " + item.URL + " " + "(" + item.Title + ")");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<WebBrowser.Logic.HistoryItem> newList = new List<WebBrowser.Logic.HistoryItem>(WebBrowser.Logic.HistoryManager.GetHistoryItems());
            foreach (WebBrowser.Logic.HistoryItem item in newList)
            {
                if (textBox1.Text == item.Title)
                {
                    listBox1.Items.Add("[" + item.Date + "]" + " " + item.URL + " " + "(" + item.Title + ")");
                }
                else if (textBox1.Text == item.URL)
                {
                    listBox1.Items.Add("[" + item.Date + "]" + " " + item.URL + " " + "(" + item.Title + ")");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<WebBrowser.Logic.HistoryItem> aList = new List<WebBrowser.Logic.HistoryItem>(WebBrowser.Logic.HistoryManager.GetHistoryItems());



            string URL = aList[listBox1.SelectedIndex].URL;
            string Title = aList[listBox1.SelectedIndex].Title;
            DateTime date = aList[listBox1.SelectedIndex].Date;
            int itemID = aList[listBox1.SelectedIndex].itemID;

            WebBrowser.Logic.HistoryManager.deleteHistoryItem(URL, Title, date, itemID);

            listBox1.Items.Clear();

            List<WebBrowser.Logic.HistoryItem> bList = new List<WebBrowser.Logic.HistoryItem>(WebBrowser.Logic.HistoryManager.GetHistoryItems());
           
            foreach (WebBrowser.Logic.HistoryItem thing in bList)
            {
                listBox1.Items.Add("[" + thing.Date + "]" + " " + thing.URL + " " + "(" + thing.Title + ")");
           
            }

        }
    }
}
