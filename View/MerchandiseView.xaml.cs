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
using scale.ViewModelWrapper;
using scale.SQLQuery;
using scale.Model;
// debugging
using System.Diagnostics;

namespace scale.View
{
    /// <summary>
    /// Interaction logic for MerchandiseView.xaml
    /// </summary>
    public partial class MerchandiseView : Window
    {
        private readonly ViewModel viewModel = new ViewModel();
        public MerchandiseView()
        {
            InitializeComponent();

            // TODO - wrap this to "listen collapse event there to refesh the table" - the same functionality
            viewModel.ProductDataGridItems = MineQuery.GetProducts();
            this.DataContext = viewModel;
        }

        private void addNewProduct(object sender, RoutedEventArgs e)
        {
            MerchandiseInsertionView merchandiseInsertionView = new MerchandiseInsertionView();

            merchandiseInsertionView.Show();

            // TODO - listen collapse event there to refesh the table
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            // show confirm box to client aware of their action
            MessageBoxResult result = MessageBox.Show(@"Sản phẩm sẽ bị xoá vĩnh viễn và không có khả năng khôi phục,
                                                        bạn có chắc chắn muốn xoá?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // getting the current row (item) of table
                Product selectedProduct = (Product)merchandiseDataGrid.SelectedItem;

                // delete the record in database
                int rowChanged = MineQuery.DeleteProduct(selectedProduct.ID);

                // debugging
                Trace.WriteLine($"MerchandiseView - Deleted Product - affected row: {rowChanged}");
            }
        }

        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // enable edition and deletion function when a record is chossen
            editBtn.IsEnabled = true;
            deleteBtn.IsEnabled = true;
        }

        private void load(object sender, RoutedEventArgs e)
        {
            // disable edition and deletion function when no record is chossen
            editBtn.IsEnabled = false;
            deleteBtn.IsEnabled = false;
        }

        private void edit(object sender, RoutedEventArgs e)
        {
            // getting the current row (item) of table
            Product selectedProduct = (Product)merchandiseDataGrid.SelectedItem;

            //...then send to the new view
            MerchandiseInsertionView merchandiseInsertionView = new MerchandiseInsertionView(selectedProduct);
            merchandiseInsertionView.Show();
        }
    }
}
