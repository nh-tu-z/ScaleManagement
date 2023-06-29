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
using scale.Interfaces;
using scale.Services;
using scale.Model.Entity;

namespace scale.View
{
    /// <summary>
    /// Interaction logic for MerchandiseView.xaml
    /// </summary>
    public partial class MerchandiseView : Window
    {
        private ViewModel _viewModel = new ViewModel();
        private IDbService _dbService;
        private IMatHangService _matHangService;

        public MerchandiseView(IDbService dbService)
        {
            InitializeComponent();

            InitializeService(dbService);

            DataContext = _viewModel;

            GetMatHangTable();
        }

        public void InitializeService(IDbService dbService)
        {
            _dbService = dbService;
            _matHangService = new MatHangService(dbService);
        }

        private void AddNewProductEventHandler(object sender, RoutedEventArgs e)
        {
            MerchandiseInsertionView merchandiseInsertionView = new MerchandiseInsertionView();
            merchandiseInsertionView.Closed += ClosedEventHandler;
            merchandiseInsertionView.Show();
        }

        private void ClosedEventHandler(object sender, EventArgs e)
        {
            GetMatHangTable();
        }

        private void GetMatHangTable()
        {
            _viewModel.ProductDataGridItems.Clear();
            var matHang = _matHangService.GetAllMatHang();
            _viewModel.ProductDataGridItems.AddRange(matHang);
        }

        private void DeleteEventHandler(object sender, RoutedEventArgs e)
        {
            // show confirm box to client aware of their action
            MessageBoxResult result = MessageBox.Show(@"Sản phẩm sẽ bị xoá vĩnh viễn và không có khả năng khôi phục,
                                                        bạn có chắc chắn muốn xoá?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // getting the current row (item) of table
                var selectedProduct = (SanPham)merchandiseDataGrid.SelectedItem;

                // delete the record in database
                int rowChanged = MineQuery.DeleteProduct(selectedProduct.ID);

                // debugging
                Trace.WriteLine($"MerchandiseView - Deleted Product - affected row: {rowChanged}");

                GetMatHangTable();
            }
        }

        private void SelectionChangedEventHandler(object sender, SelectionChangedEventArgs e)
        {
            // enable edition and deletion function when a record is chossen
            editBtn.IsEnabled = true;
            deleteBtn.IsEnabled = true;
        }

        private void LoadEventHandler(object sender, RoutedEventArgs e)
        {
            // disable edition and deletion function when no record is chossen
            editBtn.IsEnabled = false;
            deleteBtn.IsEnabled = false;
        }

        private void EditEventHandler(object sender, RoutedEventArgs e)
        {
            // getting the current row (item) of table
            var selectedProduct = (SanPham)merchandiseDataGrid.SelectedItem;

            //...then send to the new view
            MerchandiseInsertionView merchandiseInsertionView = new MerchandiseInsertionView(selectedProduct);
            merchandiseInsertionView.Closed += ClosedEventHandler;
            merchandiseInsertionView.Show();
        }
    }
}
