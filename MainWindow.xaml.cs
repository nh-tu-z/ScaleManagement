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
        private readonly ViewModel _viewModel = new ViewModel();
        private IDbService _dbService;

        public MainWindow()
        {
            InitializeComponent();

            InitializeService();

            // data is added to DataContext to be shown in table
            _viewModel.OutputSheetDataGridItems = _dbService.Query<OutputSheet>(OutputSheetCommand.Get20OutputSheets);
            DataContext = _viewModel;
        }

        private void InitializeService()
        {
            var connectionString = "Server=localhost;Database=sysb;Trusted_Connection=True;";
            _dbService = SqlServerService.CreateInstance(connectionString);
        }

        private async void load(object sender, RoutedEventArgs e)
        {
            // TODO - we might need to use binding data in combo box
            // add client name data to combo box
            clientNameComboBox.ItemsSource = _dbService.Query<string>(KhachHangCommand.GetKhachHangName);

            // add merchandise name to combo box
            merchandiseNameComboBox.ItemsSource = _dbService.Query<string>(SanPhamCommand.GetSanPhamName);

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

        // TODO - for views that has query data from database when they initialize, 
        // we need to add an async process for that view to prevent app from pending state
        private void configViewClick(object sender, RoutedEventArgs e)
        {
            // TODO -  prevent duplication
            ConfigurationView configView = new ConfigurationView();

            configView.Owner = this;
            configView.Show();
        }

        private void sheetsManagementViewClick(object sender, RoutedEventArgs e)
        {
            // TODO -  prevent duplication
            SheetsManagementView sheetsManagementView = new SheetsManagementView();

            sheetsManagementView.Show();
        }

        private void merchandiseViewClick(object sender, RoutedEventArgs e)
        {
            // TODO -  prevent duplication
            MerchandiseView merchandiseView = new MerchandiseView();

            merchandiseView.Show();
        }

        private void priceManagementViewClick(object sender, RoutedEventArgs e)
        {
            // TODO -  prevent duplication
            PriceManagementView priceManagementView = new PriceManagementView();

            priceManagementView.Show();
        }

        private void clientManagementViewClick(object sender, RoutedEventArgs e)
        {
            // TODO -  prevent duplication
            ClientManagementView clientManagementView = new ClientManagementView(_dbService);

            clientManagementView.Show();
        }

        private void clientInsertionViewClick(object sender, RoutedEventArgs e)
        {
            // TODO -  prevent duplication
            ClientInsertionView clientInsertionView = new ClientInsertionView(_dbService);

            clientInsertionView.Show();
        }

        private void merchandiseInsertionViewClick(object sender, RoutedEventArgs e)
        {
            // TODO -  prevent duplication
            MerchandiseInsertionView merchandiseInsertionView = new MerchandiseInsertionView();

            merchandiseInsertionView.Show();
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
