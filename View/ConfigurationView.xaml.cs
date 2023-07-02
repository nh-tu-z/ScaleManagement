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
using static scale.Common.CustomEvent;
using static scale.Common.Constants;

namespace scale.View
{
    /// <summary>
    /// Interaction logic for ConfigurationView.xaml
    /// </summary>
    public partial class ConfigurationView : Window
    {
        private ConfigurationViewModel _viewModel = new ConfigurationViewModel();
        private ICOMService _comService;

        public MainWindow ParentWindow;
        public event CustomEventHandler<PortSettings> PortSettingChanged;

        public ConfigurationView(MainWindow parent, IDbService dbService)
        {
            InitializeComponent();

            InitializeServices(dbService);

            DataContext = _viewModel;
            _viewModel.PortSettings.ComPortState = COMPortAction.Connect.ToString();

            ParentWindow = parent;
            ParentWindow.SerialPortResult += SerialPortResultEventHandler;
        }

        private void SerialPortResultEventHandler(object sender, SerialPortResult result)
        {
            if (result.IsConnected)
            {
                _viewModel.PortSettings.ComPortState = COMPortAction.Disconnect.ToString();
            }
            else
            {
                _viewModel.PortSettings.ComPortState = COMPortAction.Connect.ToString();
            }
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
            COMPortAction action;
            if (_viewModel.PortSettings.ComPortState == COMPortAction.Connect.ToString())
            {
                action = COMPortAction.Connect;
            }
            else
            {
                action = COMPortAction.Disconnect;
            }

            var comSettings = new PortSettings()
            {
                PortName = _viewModel.PortSettings.SelectedCOMPort,
                Action = action
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
