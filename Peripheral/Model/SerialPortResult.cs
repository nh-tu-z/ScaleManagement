using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.Peripheral.Model
{
    public class SerialPortResult
    {
        public string PortName { get; set; } = string.Empty;
        public bool IsConnected { get; set; } = false;
    }
}
