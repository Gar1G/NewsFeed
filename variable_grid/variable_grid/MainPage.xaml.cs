using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using System.Reflection;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace variable_grid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();

            var article = this.GetArticle();

            for(int i=0; i<article.Count; i++)
            {
                article[i].RowSpan = RowSpan(i);
                article[i].ColSpan = ColSpan(i);
            }

            //itm.ItemsSource = article;
            this.DataContext = article;
        }
        //For test purpose
        //Initialises list of articles
        
        public List<Article> GetArticle()
        {
             List<Article> article = new List<Article>();
            article.Add(new Article { Name = "Obama is Cool", image = "Assets/obama.jpg" , Type = 0 });
            article.Add(new Article { Name = "Kim Jong Un", image = "Assets/kju.png", Type = 1 });
            article.Add(new Article { Name = "FB goes IPO", image = "Assets/fb.png" , Type = 2 });
            article.Add(new Article { Name = "Ashes Win", image = "Assets/ashes.jpg", Type = 2 });
            article.Add(new Article { Name = "New Top Gear", image = "Assets/top-gear-uk-wallpaper-1.jpg", Type = 1});
            article.Add(new Article { Name = "FB goes IPO", image = "Assets/a350.jpg", Type = 0 });
            article.Add(new Article { Name = "Ashes Win", image = "Assets/finance.jpg", Type = 1 });
            article.Add(new Article { Name = "New Top Gear", image = "Assets/shopping.jpg" , Type = 1});
            article.Add(new Article { Name = "Ashes Win", image = "Assets/finance.jpg", Type = 2 });
            article.Add(new Article { Name = "New Top Gear", image = "Assets/shopping.jpg", Type = 1 });

            return article;
        }
        

        //Determines rowspan values for each article in list
        //Will write more efficient function
        private int RowSpan(int i)
        {
            if (i == 0 || i==9)
            {
                return 5; //Fullscreen images
            }
            if (i == 1 || i==5 || i==6 || i==7)
            {
                return 2; //Medium sized article image
            }
            
            return 1; //For text only articles
        }
        
        private int ColSpan(int i)
        {
            if (i == 0 || i==9)
            {
                return 4;
            }           
            return 2;
        }

        private void Button_Click(object sender, ItemClickEventArgs e)
        {
            
            //click event
            //Open browser

        }

        private void ptrBox_RefreshInvoked(DependencyObject sender, object args)
        {

        }
    }
}
