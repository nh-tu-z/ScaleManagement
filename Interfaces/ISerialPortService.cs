using scale.Peripheral.Model;
using scale.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.Interfaces
{
    public interface ISerialPortService
    {
        bool IsOpen();
        string PortName();
        void Connect(PortSettings comSettings);
        void Disconnect();
    }
}
