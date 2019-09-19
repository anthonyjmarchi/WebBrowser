﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowser.Data.historyDatasetTableAdapters;

namespace WebBrowser.Logic
{
    public class HistoryManager
    {
        public static void AddHistoryItem(HistoryItem item)
        {
            var adapter = new HistoryTableAdapter();
            adapter.Insert(item.url, item.title, item.date);
        }

        public static List<HistoryItem> GetHistoryItems()
        {
            var adapter = new HistoryTableAdapter();
            var results = new List<HistoryItem>();
            var rows = adapter.GetData();

            foreach(var row in rows)
            {
                var item = new HistoryItem();
                item.url = row.URL;
                item.title = row.Title;
                item.date = row.Date;
                item.Id = row.Id;

                results.Add(item);
            }
            return results;
        }
    }
}