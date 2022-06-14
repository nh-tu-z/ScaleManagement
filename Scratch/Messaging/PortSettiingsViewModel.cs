using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// plugin
using TheRFramework.Utilities;

namespace scale.Scratch.Messaging
{
    class PortSettiingsViewModel : BaseViewModel
    {
        private string _selectedComPort;
        public string SelectedCOMPort
        {
            get => _selectedComPort;
            set => RaisePropertyChanged(ref _selectedComPort, value);
        }
        public ObservableCollection<string> AvailablePorts { get; set; }

        public int BaudRate = 9600;
        public int DataBits = 8;
        public StopBits StopBits = StopBits.None;
        public Parity Parity = Parity.None;
        public Handshake HandShake = Handshake.None;

        public Command RefreshPortsCommand { get; }
        public PortSettiingsViewModel()
        {
            AvailablePorts = new ObservableCollection<string>();

            RefreshPortsCommand = new Command(RefreshPorts);
        }

        private void RefreshPorts()
        {
            AvailablePorts.Clear();
            foreach(string port in SerialPort.GetPortNames())
            {
                AvailablePorts.Add(port);
            }
        }
    }
}
