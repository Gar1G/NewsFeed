using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VirtualisedGridBasedOnListView
{
    public class Item
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class ItemGroup : ObservableCollection<Item>
    {
    }

    public class VirtualisedList : ObservableCollection<ItemGroup>,
                                   ISupportIncrementalLoading
    {
        public VirtualisedList()
        {
            GrowList(10);
        }

        public bool HasMoreItems
        {
            get
            {
                Debug.WriteLine($"HasMoreItems?");
                return true;
            }
        }

        private void GrowList(int num)
        {
            int currentIdx = Count;
            var grp = new ItemGroup();

            for (int i = 0; i < num; i++)
            {
                grp.Add(new Item
                    {
                        Name = $"Item {currentIdx + i}",
                        Image = "Assets/LockScreenLogo.scale-200.png"
                    });
            }
            Add(grp);
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            Debug.WriteLine($"LoadMoreItemsAsync {count}");

            // Load more...
            return Task.Run(async () =>
            {
                var res = new LoadMoreItemsResult { Count = 10 };
                var disp = Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher;
                await disp.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    GrowList(10);
                });
                return res;
            }).AsAsyncOperation();
        }
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public VirtualisedList Items { get; set; } = new VirtualisedList();

        public MainPage()
        {
            this.InitializeComponent();
        }
    }
}
