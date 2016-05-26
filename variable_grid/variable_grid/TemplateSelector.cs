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

namespace variable_grid
{
    public class TemplateSelector : DataTemplateSelector
    {
        public DataTemplate large_tmp { get; set; }
        public DataTemplate medium_tmp { get; set; }
        public DataTemplate small_tmp { get; set; }

        protected override Windows.UI.Xaml.DataTemplate SelectTemplateCore(object item, Windows.UI.Xaml.DependencyObject container)
        {
            var dataItem = item as Article;

            if (dataItem.Type == 1)
            {
                return medium_tmp;
            }
            else if (dataItem.Type == 2)
            {
                return small_tmp;
            }
            return large_tmp;
        }

    }


}
