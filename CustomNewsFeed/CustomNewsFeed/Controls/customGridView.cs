
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.Foundation;

namespace CustomNewsFeed.Controls
{
    public class customGridView : ListViewBase //inherits from same class as GridView and ListView
    {
        //Encapsulates custom panel and adds on a scroll bar
        private ScrollViewer scroll = null;
        private customPanel panel = new customPanel();
        private bool initialised = false;

        public customGridView()
        {
            this.DefaultStyleKey = typeof(customGridView); //sets style of control to the customGridView
            this.LayoutUpdated += layout_updated;
        }

        // 5 Dependency Properties that will affect layout of this gridView
        // Margin, Padding, MaxCols (or rows), AspectRatio, Orientation


        //Margin
        public Thickness itemMargin
        {
            get { return (Thickness)GetValue(itemMarginProperty); }
            set { SetValue(itemMarginProperty, value); }
        }

        public static readonly DependencyProperty itemMarginProperty = DependencyProperty.Register("itemMargin", typeof(Thickness), typeof(customGridView), new PropertyMetadata(new Thickness(2)));

        public Thickness itemPadding
        {
            get { return (Thickness)GetValue(itemPaddingProperty); }
            set { SetValue(itemPaddingProperty, value); }
        }

        public static readonly DependencyProperty itemPaddingProperty = DependencyProperty.Register("itemPadding", typeof(Thickness), typeof(customGridView), new PropertyMetadata(new Thickness(2)));

        //Orientation
        public Orientation orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(customPanel), new PropertyMetadata(Orientation.Horizontal, OrientationChanged));

        //If Orientation of grid item flow changes then Measure and Arrange calculations must be recalculated
        private static void OrientationChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var obj = o as customGridView;
            obj.SetOrientation((Orientation)e.NewValue);
             //InvalidArrange() automatically called and layout asynchronously updated
        }

        //Aspect Ratio
        public double AspectRatio
        {
            get { return (double)GetValue(AspectRatioProperty); }
            set { SetValue(AspectRatioProperty, value); }
        }

        public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(customPanel), new PropertyMetadata(1.0, AspectRatioChanged));

        private static void AspectRatioChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var obj = o as customGridView;
            obj.InvalidateMeasure();
        }

        //MaxCols (or max rows depending on orientation)
        public int MaxCols
        {
            get { return (int)GetValue(MaxColsProperty); }
            set { SetValue(MaxColsProperty, value); }
        }

        private static void MaxColsChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var obj = o as customGridView;
            obj.InvalidateMeasure();
        }

        public static readonly DependencyProperty MaxColsProperty = DependencyProperty.Register("MaxCols", typeof(int), typeof(customPanel), new PropertyMetadata(0, MaxColsChanged));


        private void SetOrientation(Orientation orientation)
        {
            if (initialised && scroll!= null)
            {
                //if content laid out horizontally then scrolling must be vertical
                if(orientation == Orientation.Horizontal)
                {
                    scroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                    scroll.HorizontalScrollMode = ScrollMode.Disabled;
                    scroll.VerticalScrollBarVisibility = (ScrollBarVisibility)this.GetValue(ScrollViewer.VerticalScrollBarVisibilityProperty);
                    scroll.VerticalScrollMode = ScrollMode.Auto;

                }
                else
                {
                    scroll.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
                    scroll.VerticalScrollMode = ScrollMode.Disabled;
                    if ((ScrollBarVisibility)this.GetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty) == ScrollBarVisibility.Disabled)
                    {
                        scroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                    }
                    else
                    {
                        scroll.HorizontalScrollBarVisibility = (ScrollBarVisibility)this.GetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty);
                    }
                    scroll.HorizontalScrollMode = ScrollMode.Auto;
                }
            }
        }

        protected override void OnItemsChanged(object e)
        {
            base.OnItemsChanged(e);
        }


        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            
            var container = element as ListViewItem;
            container.Margin = this.itemMargin;
            container.Padding = this.itemPadding;
            base.PrepareContainerForItemOverride(element, item);

        }

        private int CalculateSpanProperty()
        {
            return this.positionOfItemAtArray % 3 == 0 ? 2 : 1;
        }

        private int positionOfItemAtArray =0;

        protected override void OnApplyTemplate()
        {
            scroll = base.GetTemplateChild("scrollViewer") as ScrollViewer;
            initialised = true;
            SetOrientation(this.orientation);
            base.OnApplyTemplate();
        }

        private void layout_updated(object sender, object o)
        {
            if(panel == null)
            {
                panel = base.ItemsPanelRoot as customPanel; 
                if(panel != null)
                {
                    panel.ready = true;
                    panel.SetBinding(customPanel.OrientationProperty, new Binding { Source = this, Path = new PropertyPath("Orientation") });
                    panel.SetBinding(customPanel.AspectRatioProperty, new Binding { Source = this, Path = new PropertyPath("AspectRatio") });
                    panel.SetBinding(customPanel.MaxColsProperty, new Binding { Source = this, Path = new PropertyPath("MaxCols") });
                }
            }
        }




    }
}
