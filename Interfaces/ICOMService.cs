using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.Interfaces
{
    public interface ICOMService
    {
        IEnumerable<string> GetAvailablePorts();
        bool DoesPortExist(string portName);
        bool InsertPort(string portName);
    }
}
