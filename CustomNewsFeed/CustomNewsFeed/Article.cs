using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using Windows.Storage.Streams;
namespace CustomNewsFeed
{
    public class Articles
    {
        static public List<Article> _articles = null;
        

        public List<Article> GetItems()
        {
            return _articles;
        }

        static public void Load()
        {
            _articles = new List<Article>();
            _articles.Add(new Article { Name = "Obama is Cool", image = "Assets/obama.jpg", Type = 0, description = "helo" });
            _articles.Add(new Article { Name = "Kim Jong Un", image = "Assets/kju.png", Type = 1 });
            _articles.Add(new Article { Name = "FB goes IPO", image = "Assets/fb.png", Type = 2 });
            _articles.Add(new Article { Name = "Ashes Win", image = "Assets/ashes.jpg", Type = 2 });
            _articles.Add(new Article { Name = "New Top Gear", image = "Assets/top-gear-uk-wallpaper-1.jpg", Type = 1 });
            _articles.Add(new Article { Name = "FB goes IPO", image = "Assets/a350.jpg", Type = 0 });
            _articles.Add(new Article { Name = "Ashes Win", image = "Assets/finance.jpg", Type = 1 });
            _articles.Add(new Article { Name = "New Top Gear", image = "Assets/shopping.jpg", Type = 1 });
            _articles.Add(new Article { Name = "Ashes Win", image = "Assets/finance.jpg", Type = 2 });
            _articles.Add(new Article { Name = "New Top Gear", image = "Assets/shopping.jpg", Type = 1 });
        }

    }


    public class Article
    {
        public  string Name { get; set; } // title of artice
        public string image { get; set; } //Image associated with article
        public string description { get; set; } //Article description
        public int Type { get; set; }
        
    }
}
