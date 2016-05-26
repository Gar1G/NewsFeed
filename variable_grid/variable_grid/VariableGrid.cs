using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace variable_grid
{
    public class MyGridView : GridView
    {
        protected override void PrepareContainerForItemOverride(Windows.UI.Xaml.DependencyObject element, object item)
        {
            
            try
            {
                dynamic model = item;
                element.SetValue(Windows.UI.Xaml.Controls.VariableSizedWrapGrid.ColumnSpanProperty, model.ColSpan);
                element.SetValue(Windows.UI.Xaml.Controls.VariableSizedWrapGrid.RowSpanProperty, model.RowSpan);
                
            }
            catch
            {
                element.SetValue(Windows.UI.Xaml.Controls.VariableSizedWrapGrid.ColumnSpanProperty, 1);
                element.SetValue(Windows.UI.Xaml.Controls.VariableSizedWrapGrid.RowSpanProperty, 1);
            }
            finally
            {
                element.SetValue(VerticalContentAlignmentProperty, VerticalAlignment.Stretch);
                element.SetValue(HorizontalContentAlignmentProperty, HorizontalAlignment.Stretch);
                base.PrepareContainerForItemOverride(element, item);
            }
        }

        // refresh the variablesizedwrapgrid layout
        
        public void Update()
        {
            if (!(this.ItemsPanelRoot is VariableSizedWrapGrid))
                throw new ArgumentException("ItemsPanel is not VariableSizedWrapGrid");

            foreach (var container in this.ItemsPanelRoot.Children.Cast<GridViewItem>())
            {
                dynamic data = container.Content;
                VariableSizedWrapGrid.SetRowSpan(container, data.RowSpan);
                VariableSizedWrapGrid.SetColumnSpan(container, data.ColSpan);
            }

            this.ItemsPanelRoot.InvalidateMeasure();
        }
        
    }
}
