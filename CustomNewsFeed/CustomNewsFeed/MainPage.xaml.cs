using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CustomNewsFeed.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CustomNewsFeed
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       

        public MainPage()
        {
            this.InitializeComponent();
            Articles.Load();
            this.DataContext = this;
            
        }

        public List<Article> Items
        {
            get { return (List<Article>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(List<Article>), typeof(MainPage), new PropertyMetadata(null));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }

        }

        public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(MainPage), new PropertyMetadata(null));

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.Items = new Articles().GetItems();
            this.ItemTemplate = Resources["PhotoTemplate"] as DataTemplate;
            base.OnNavigatedTo(e);
        }
        

        private void Button_Click(object sender, ItemClickEventArgs e)
        {

            //click event
            //Open browser

        }
    }
}
