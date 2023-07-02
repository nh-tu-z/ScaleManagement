using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scale.Interfaces;
using scale.Peripheral.Model;

namespace scale.Services
{
    public class SerialPortService : ISerialPortService
    {
        private SerialPort _mainPort;
        private static SerialPortService _instance;

        protected SerialPortService() 
        {
        }

        public static ISerialPortService CreateInstance()
        {
            if (_instance == null) 
            {
                _instance = new SerialPortService();
            }
            return _instance;
        }

        public bool IsOpen()
        {
            return _mainPort?.IsOpen ?? false;
        }

        public string PortName()
        {
            return _mainPort.PortName ?? string.Empty;
        }

        public void Connect(PortSettings comSettings)
        {
            if (ValidateConnection(comSettings))
            {
                try
                {
                    _mainPort = new SerialPort(comSettings.PortName);
                    _mainPort.Open();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void Disconnect()
        {
            try
            {
                _mainPort?.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private bool ValidateConnection(PortSettings comSettings)
        {
            if (_mainPort?.IsOpen ?? false)
            {
                if (PortName() == comSettings.PortName)
                {
                    return false;
                }
                else
                {
                    Disconnect();
                }
            }
            // FACT - COM1 is a system com port and can't be used
            if (string.IsNullOrEmpty(comSettings.PortName) ||
                comSettings.PortName == "COM1")
            {
                return false;
            }
            return true;
        }
    }
}
