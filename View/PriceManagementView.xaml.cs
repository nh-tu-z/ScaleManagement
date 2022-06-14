using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//
using scale.Model;
using scale.ViewModelWrapper;
using scale.SQLQuery;
// debugging
using System.Diagnostics;

namespace scale.View
{
    /// <summary>
    /// Interaction logic for PriceManagementView.xaml
    /// </summary>
    public partial class PriceManagementView : Window
    {
        private readonly ViewModel viewModel = new ViewModel();
        public PriceManagementView()
        {
            InitializeComponent();

            viewModel.UnitPriceDataGridItems = MineQuery.GetUnitPrices();
            this.DataContext = viewModel;
        }

        private void addNewPriceManagement(object sender, RoutedEventArgs e)
        {
            PriceManagementInsertionView priceManagementInsertionView = new PriceManagementInsertionView();

            priceManagementInsertionView.Show();

            // TODO - listen collapse event there to refesh the table
        }

        private void edit(object sender, RoutedEventArgs e)
        {
            // getting the current row (item) of table
            UnitPrice selectedUnitPrice = (UnitPrice)merchandiseDataGrid.SelectedItem;

            //...then send to the new view
            PriceManagementInsertionView priceManagementInsertionView = new PriceManagementInsertionView(selectedUnitPrice);
            priceManagementInsertionView.Show();
        }

        private void load(object sender, RoutedEventArgs e)
        {
            editBtn.IsEnabled = false;
            deleteBtn.IsEnabled = false;
        }

        // using selection changed event for getting data record 
        // we might use selected cells changed event when this event does not work in some cases
        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // debug the event
            Trace.WriteLine($"PriceManagementView - Selection Changed event start...");

            // enable edit and delete button
            editBtn.IsEnabled = true;
            deleteBtn.IsEnabled = true;

            // TODO - need to check if we select the header or something is not row 
            // >> ignore the behaviour
            
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            // show confirm box to client aware of their action
            MessageBoxResult result = MessageBox.Show(@"Giá sản phẩm sẽ bị xoá vĩnh viễn và không có khả năng khôi phục,
                                                        bạn có chắc chắn muốn xoá?", "Confirmation", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                // getting the current row (item) of table
                UnitPrice selectedUnitPrice = (UnitPrice)merchandiseDataGrid.SelectedItem;

                // delete the record in database
                int rowChanged = MineQuery.DeleteUnitPrice(selectedUnitPrice.ProductID);

                // debugging
                Trace.WriteLine($"PriceManagementView - Deleted Unit Price - affected row: {rowChanged}");
            }
        }
    }
}
