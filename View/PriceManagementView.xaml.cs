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
using scale.Interfaces;
using scale.Services;

namespace scale.View
{
    /// <summary>
    /// Interaction logic for PriceManagementView.xaml
    /// </summary>
    public partial class PriceManagementView : Window
    {
        private MainViewModel _viewModel = new MainViewModel();
        private IDonGiaService _donGiaService;
        public PriceManagementView(IDbService dbService)
        {
            InitializeComponent();

            InitializeService(dbService);

            DataContext = _viewModel;
            GetDonGiaTable();
        }

        public void InitializeService(IDbService dbService)
        {
            _donGiaService = new DonGiaService(dbService);
        }

        private void AddNewPriceManagementEventHandler(object sender, RoutedEventArgs e)
        {
            PriceManagementInsertionView priceManagementInsertionView = new PriceManagementInsertionView();
            priceManagementInsertionView.Closed += ClosedEventHandler;
            priceManagementInsertionView.Show();
        }

        private void ClosedEventHandler(object sender, EventArgs e)
        {
            GetDonGiaTable();
        }

        private void EditEventHandler(object sender, RoutedEventArgs e)
        {
            // getting the current row (item) of table
            var selectedUnitPrice = (DonGia)merchandiseDataGrid.SelectedItem;

            //...then send to the new view
            var priceManagementInsertionView = new PriceManagementInsertionView(selectedUnitPrice);
            priceManagementInsertionView.Closed += ClosedEventHandler;
            priceManagementInsertionView.Show();
        }

        private void LoadEventHandler(object sender, RoutedEventArgs e)
        {
            editBtn.IsEnabled = false;
            deleteBtn.IsEnabled = false;
        }

        // using selection changed event for getting data record 
        // we might use selected cells changed event when this event does not work in some cases
        private void SelectionChangedEventHandler(object sender, SelectionChangedEventArgs e)
        {
            // debug the event
            Trace.WriteLine($"PriceManagementView - Selection Changed event start...");

            // enable edit and delete button
            editBtn.IsEnabled = true;
            deleteBtn.IsEnabled = true;

            // TODO - need to check if we select the header or something is not row 
            // >> ignore the behaviour
            
        }

        private void DeleteEventHandler(object sender, RoutedEventArgs e)
        {
            // show confirm box to client aware of their action
            MessageBoxResult result = MessageBox.Show(@"Giá sản phẩm sẽ bị xoá vĩnh viễn và không có khả năng khôi phục,
                                                        bạn có chắc chắn muốn xoá?", "Confirmation", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                // getting the current row (item) of table
                var selectedUnitPrice = (DonGia)merchandiseDataGrid.SelectedItem;

                // delete the record in database
                int rowChanged = MineQuery.DeleteUnitPrice(selectedUnitPrice.SanPhamID);

                GetDonGiaTable();

                // debugging
                Trace.WriteLine($"PriceManagementView - Deleted Unit Price - affected row: {rowChanged}");
            }
        }

        private void GetDonGiaTable()
        {
            _viewModel.UnitPriceDataGridItems.Clear();
            var allDonGias = _donGiaService.GetAllDonGias();
            _viewModel.UnitPriceDataGridItems.AddRange(allDonGias);
        }
    }
}
