using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowser.Data.BrowserDBDataSetTableAdapters;

namespace WebBrowser.Logic
{
    public class HistoryManager
    {

        public static void AddHistoryItem(HistoryItem item)
        {
            var adapter = new WebBrowser.Data.BrowserDBDataSetTableAdapters.HistoryTableAdapter();
            adapter.Insert(item.Title, item.URL, item.Date);
        }

        public static List<HistoryItem> GetHistoryItems()
        {
            var adapterTwo = new WebBrowser.Data.BrowserDBDataSetTableAdapters.HistoryTableAdapter();
            var results = new List<HistoryItem>();
            var rows = adapterTwo.GetData();

            foreach(var row in rows)
            {
                var item = new HistoryItem();

              
                item.Title = row.Title; 
                item.URL = row.URL;
                item.Date = row.Date;
                item.itemID = row.Id;
                results.Add(item);
            }

            return results;
        }

        public static void deleteHistoryItem(string URL, string Title, DateTime date, int itemID)
        {
            
            var adapterThree = new WebBrowser.Data.BrowserDBDataSetTableAdapters.HistoryTableAdapter();
            adapterThree.Delete(itemID, URL, Title, date);

        }

        public static void deleteAllHistory(List<HistoryItem> deleteAllList)
        {
            var adapterFour = new WebBrowser.Data.BrowserDBDataSetTableAdapters.HistoryTableAdapter();

            foreach (HistoryItem entry in deleteAllList)
            {
                adapterFour.Delete(entry.itemID, entry.URL, entry.Title, entry.Date);
            }
          
        }

    }
}

