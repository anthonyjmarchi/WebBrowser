using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowser.Data.BookmarkDatasetTableAdapters;

namespace WebBrowser.Logic
{
    public class BookmarkManager
    {
        public static void AddBookmarkItem(BookmarkItem item)
        {
            var adapter = new BookmarksTableAdapter();
            adapter.Insert(item.url, item.title);
        }

        public static List<BookmarkItem> GetBookmarkItems()

        {
            var adapter = new BookmarksTableAdapter();
            var results = new List<BookmarkItem>();
            var rows = adapter.GetData();

            foreach (var row in rows)
            {
                var item = new BookmarkItem();

                item.title = row.Title;
                item.url = row.URL;
                results.Add(item);
            }
            return results;
        }
    }
}
