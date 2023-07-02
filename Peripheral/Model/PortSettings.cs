using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static scale.Common.Constants;

namespace scale.Peripheral.Model
{
    public class PortSettings
    {
        public string PortName { get; set; }
        public COMPortAction Action { get; set; }
    }
}
