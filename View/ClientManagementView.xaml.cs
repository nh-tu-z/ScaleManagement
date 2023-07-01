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
using scale.Interfaces;
// debugging
using System.Diagnostics;
using scale.CommandText;
using scale.Services;

namespace scale.View
{
    /// <summary>
    /// Interaction logic for ClientManagementView.xaml
    /// </summary>
    public partial class ClientManagementView : Window
    {
        private MainViewModel _viewModel = new MainViewModel();
        private IDbService _dbService;
        private IKhachHangService _khachHangService;

        public ClientManagementView(IDbService dbService)
        {
            InitializeComponent();

            InitializeServices(dbService);

            DataContext = _viewModel;

            GetKhachHangTable();
        }

        private void InitializeServices(IDbService dbService)
        {
            _dbService = dbService;
            _khachHangService = new KhachHangService(dbService);
        }

        private void DeleteEventHandler(object sender, RoutedEventArgs e)
        {
            // show confirm box to client aware of their action
            MessageBoxResult result = MessageBox.Show(@"Thông tin khách hàng này sẽ bị xoá vĩnh viễn và không có khả năng khôi phục,
                                                        bạn có chắc chắn muốn xoá?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // getting the current row (item) of table
                KhachHang selectedClient = (KhachHang)clientDataGrid.SelectedItem;

                // delete the record in database
                int rowChanged = MineQuery.DeleteClient(selectedClient.ID);

                // debugging
                Trace.WriteLine($"ClientManagementView - Deleted Product - affected row: {rowChanged}");

                GetKhachHangTable();
            }
        }

        private void AddEventHandler(object sender, RoutedEventArgs e)
        {
            ClientInsertionView clientInsertionView = new ClientInsertionView(_dbService);
            clientInsertionView.Closed += ClosedEventHandler;
            clientInsertionView.Show();
        }

        private void ClosedEventHandler(object sender, EventArgs e)
        {
            GetKhachHangTable();
        }

        private void SelectionChangedEventHandler(object sender, SelectionChangedEventArgs e)
        {
            // enable edition and deletion function when a record is chossen
            editBtn.IsEnabled = true;
            deleteBtn.IsEnabled = true;
        }

        private void LoadEventHandler(object sender, RoutedEventArgs e)
        {
            // disable edition and deletion function when a record is chossen
            editBtn.IsEnabled = false;
            deleteBtn.IsEnabled = false;
        }

        private void EditEventHandler(object sender, RoutedEventArgs e)
        {
            // getting the current row (item) of table
            KhachHang selectedClient = (KhachHang)clientDataGrid.SelectedItem;

            //...then send to the new view
            ClientInsertionView clientInsertionView = new ClientInsertionView(selectedClient);
            clientInsertionView.Closed += ClosedEventHandler;
            clientInsertionView.Show();


        }

        private void GetKhachHangTable()
        {
            _viewModel.ClientDataGridItems.Clear();
            var khachHangs = _khachHangService.GetAllKhachHangs();
            _viewModel.ClientDataGridItems.AddRange(khachHangs);
        }
    }
}
