using System;
using System.Collections.Generic;
using System.IO.Ports;
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
using scale.Interfaces;
using scale.Peripheral.Model;
using scale.ViewModel;
using scale.Services;

namespace scale.View
{
    /// <summary>
    /// Interaction logic for ConfigurationView.xaml
    /// </summary>
    public partial class ConfigurationView : Window
    {
        public delegate void PortSettingEnventHandler(object sender, COMSettings comSettings);
        public event PortSettingEnventHandler PortSettingChanged;

        private ConfigurationViewModel _viewModel = new ConfigurationViewModel();
        private ICOMService _comService;

        public ConfigurationView(IDbService dbService)
        {
            InitializeComponent();

            InitializeServices(dbService);

            DataContext = _viewModel;
        }

        private void InitializeServices(IDbService dbService)
        {
            _comService = new COMService(dbService);
        }

        private void LoadEventHandler(object sender, RoutedEventArgs e)
        {
            RefreshAvailablePorts();
        }

        private void PortConnectionClickEventHandler(object sender, RoutedEventArgs e)
        {
            var comSettings = new COMSettings()
            {
                PortName = _viewModel.PortSettings.SelectedCOMPort
            };
            PortSettingChanged.Invoke(this, comSettings);
        }

        private void RefreshClickEventHandler(object sender, RoutedEventArgs e)
        {
            RefreshAvailablePorts();
        }

        private void RefreshAvailablePorts()
        {
            _viewModel.PortSettings.AvaliablePorts.Clear();
            foreach (string port in _comService.GetAvailablePorts())
            {
                _viewModel.PortSettings.AvaliablePorts.Add(port);
            }
        }
    }
}
