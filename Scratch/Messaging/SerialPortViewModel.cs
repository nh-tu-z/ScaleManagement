using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// plugin
using TheRFramework.Utilities;

namespace scale.Scratch.Messaging
{
    class SerialPortViewModel :BaseViewModel
    {
        private string _connectedPort;
        public string ConnectedPort
        {
            get => _connectedPort;
            set => RaisePropertyChanged(ref _connectedPort, value);
        }
        public SerialPort Port { get; set; }
        public bool IsConnected { get => Port.IsOpen; }
        public Command AutoConnectDisconnectCommand { get; }
        public Command ClearBuffersCommand { get; }
        public PortSettiingsViewModel Settings { get; set; }
        public MessageViewModel Messages { get; set; }
        public MessageReceiver Receiver { get; set; }
        public MessageSender Sender { get; set; }
        public SerialPortViewModel()
        {
            Port = new SerialPort();
            Settings = new PortSettiingsViewModel();

            AutoConnectDisconnectCommand = new Command(AutoConnectDisconnect);
            ClearBuffersCommand = new Command(ClearBuffers); 
        }

        private void AutoConnectDisconnect()
        {
            if(Port.IsOpen)
            {
                Disconnect();
            }
            else
            {
                Connect();
            }
        }
        public void Connect()
        {
            if (Port.IsOpen)
            {
                Messages.AddMessage("Port is already open!");
                return;
            }
            // COM1 is a system com port and can't be used
            if(Settings.SelectedCOMPort == "COM1")
            {
                Messages.AddMessage("Cannot use COM1");
                return;
            }
            if(string.IsNullOrEmpty(Settings.SelectedCOMPort))
            {
                Messages.AddMessage("Error with the COM port");
            }
            try
            {
                Port.PortName = Settings.SelectedCOMPort;
                Port.Open();
            }
            catch(Exception e)
            {
                Messages.AddMessage("Error opening port: " + e.StackTrace);
            }
        }
        public void Disconnect()
        {
            if (!Port.IsOpen)
            {
                Messages.AddMessage("Port is already closed!");
                return;
            }

            try
            {
                Port.Close();
            }
            catch (Exception e)
            {
                Messages.AddMessage("Error closing port: " + e.StackTrace);
            }

            Receiver.CanReceive = false;
        }
        private void ClearBuffers()
        {
            if(!Port.IsOpen)
            {
                Messages.AddMessage("You need to be connected to clear the buffers");
            }

            Port.DiscardInBuffer();
            Port.DiscardOutBuffer();
        }
    }
}
