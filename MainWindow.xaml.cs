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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using scale.CommandText;
// excel
using Microsoft.Office.Interop.Excel;
//
using scale.SQLQuery;
using scale.ViewModelWrapper;
using scale.Model;
using scale.View;
using scale.Helper;
using scale.Peripheral;
//firebase
using Firebase.Database;
using Firebase.Database.Query;
//debug
using System.Diagnostics;
using scale.Interfaces;
using scale.Services;

namespace scale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private ViewModel _viewModel = new ViewModel();
        private IDbService _dbService;
        private IKhachHangService _khachHangService;
        private IMatHangService _matHangService;

        public MainWindow()
        {
            InitializeComponent();

            InitializeService();

            // data is added to DataContext to be shown in table
            _viewModel.OutputSheetDataGridItems = _dbService.Query<OutputSheet>(OutputSheetCommand.Get20OutputSheets);
            DataContext = _viewModel;

            GetKhachHangNameDropDown();
            GetTenHangDropDown();
        }

        private void InitializeService()
        {
            var connectionString = "Server=localhost;Database=sysb;Trusted_Connection=True;";
            _dbService = SqlServerService.CreateInstance(connectionString);
            _khachHangService = new KhachHangService(_dbService);
            _matHangService = new MatHangService(_dbService);
        }

        private async void load(object sender, RoutedEventArgs e)
        {
            //// test scale convertion
            ////Scale indicator = new Scale();
            ////indicator.frameToWeigh(new byte[] { 0x02, 0x2B, 0x30, 0x30, 0x32, 0x30, 0x30, 0x30, 0x32, 0x31, 0x42, 0x03 });

            //// test serial port
            ////COM port = new COM();

            ////port.init();

            //// firebase
            //var firebase = new FirebaseClient("https://tim-phong-tro-1526023386991.firebaseio.com");
            //var dinos = await firebase
            //  .Child("test").OnceAsync<Test>();



            //Trace.WriteLine($"data: {((List<FirebaseObject<Test>>)dinos)[0].Object.name}");
            ////Trace.WriteLine($"data: {dinos.ToString()}");
        }

        private void GetKhachHangNameDropDown()
        {
            _viewModel.KhachHangNames.Clear();
            var allKhachHangNames = _khachHangService.GetAllKhachHangNames();
            _viewModel.KhachHangNames.AddRange(allKhachHangNames);
        }

        private void GetTenHangDropDown()
        {
            _viewModel.TenHang.Clear();
            var tenHang = _matHangService.GetTenHang();
            _viewModel.TenHang.AddRange(tenHang);
        }

        // TODO - for views that has query data from database when they initialize, 
        // we need to add an async process for that view to prevent app from pending state
        private void ConfigViewClick(object sender, RoutedEventArgs e)
        {
            ConfigurationView configView = new ConfigurationView();

            configView.Owner = this;
            configView.ShowDialog();
        }

        private void sheetsManagementViewClick(object sender, RoutedEventArgs e)
        {
            SheetsManagementView sheetsManagementView = new SheetsManagementView();

            sheetsManagementView.ShowDialog();
        }

        private void MerchandiseViewClick(object sender, RoutedEventArgs e)
        {
            MerchandiseView merchandiseView = new MerchandiseView(_dbService);
            merchandiseView.Closed += ClosedEventHandler;
            merchandiseView.ShowDialog();
        }

        private void PriceManagementViewClick(object sender, RoutedEventArgs e)
        {
            PriceManagementView priceManagementView = new PriceManagementView(_dbService);
            priceManagementView.ShowDialog();
        }

        private void ClientManagementViewClickEventHandler(object sender, RoutedEventArgs e)
        {
            ClientManagementView clientManagementView = new ClientManagementView(_dbService);
            clientManagementView.Closed += ClosedEventHandler;
            clientManagementView.ShowDialog();
        }

        private void ClosedEventHandler(object sender, EventArgs e)
        {
            GetKhachHangNameDropDown();
            GetTenHangDropDown();
        }

        private void ClientInsertionViewClickEventHandler(object sender, RoutedEventArgs e)
        {
            ClientInsertionView clientInsertionView = new ClientInsertionView(_dbService);
            clientInsertionView.Closed += ClosedEventHandler;
            clientInsertionView.ShowDialog();
        }

        private void MerchandiseInsertionViewClickEventHandler(object sender, RoutedEventArgs e)
        {
            MerchandiseInsertionView merchandiseInsertionView = new MerchandiseInsertionView();
            merchandiseInsertionView.Closed += ClosedEventHandler;
            merchandiseInsertionView.ShowDialog();
        }

        private async void exportFileClick(object sender, RoutedEventArgs e)
        {
            // disable the button because we might have multiple click
            exportBtn.IsEnabled = false;

            Excel excelWorker = new WeightSheetExcel();
            List<object> obj = MineQuery.GetOutputSheets().Cast<object>().ToList();
            await excelWorker.write(obj);

            // release button
            exportBtn.IsEnabled = true;
            MessageBox.Show("Export successfully", "Information",MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
