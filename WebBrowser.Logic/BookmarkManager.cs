using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowser.Data.BrowserDBDataSetTableAdapters;


namespace WebBrowser.Logic
{
    public class BookmarkManager
    {
        public static void AddBookmarkItem(BookmarkItem item)
        {
            if (CheckIfDuplicate(item))
            {
                var adapter = new WebBrowser.Data.BrowserDBDataSetTableAdapters.BookmarkTableAdapter();
                adapter.Insert(item.url, item.title);
            }
        }


        public static Boolean CheckIfDuplicate(BookmarkItem item)
        {
            Boolean value = true;
            var currentItems = new List<BookmarkItem>();
            currentItems = GetBookmarkItems();
            foreach (BookmarkItem row in currentItems)
            {
                String urlFirst = row.url.ToString().Trim();
                String urlSecond = item.url.ToString();
                if (urlFirst.Equals(urlSecond)) 
                {
                    value = false;
                }
            }
            return value;
        }


        public static List<BookmarkItem> GetBookmarkItems()


        {
            var adapter = new WebBrowser.Data.BrowserDBDataSetTableAdapters.BookmarkTableAdapter();
            var results = new List<BookmarkItem>();
            var rows = adapter.GetData();

            foreach (var row in rows)
            {
                var item = new BookmarkItem();

                item.title = row.Title;
                item.url = row.URL;
                item.bookmarkID = row.Id;
                results.Add(item);
            }
            return results;
        }

        public static void deleteBookmark(int bookmarkID, string Title, string URL)
        {
            var adapterFour = new WebBrowser.Data.BrowserDBDataSetTableAdapters.BookmarkTableAdapter();
            adapterFour.Delete(bookmarkID, URL, Title);
        }
    }
}
