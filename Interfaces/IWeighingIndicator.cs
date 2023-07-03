using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static scale.Peripheral.XK3190_D10.Constants;

namespace scale.Interfaces
{
    public interface IWeighingIndicator
    {
        int GetDataframeLength();
        object Receive(byte[] dataframe);
        void Send<T>(CommandCode commandCode, T request);
    }
}
