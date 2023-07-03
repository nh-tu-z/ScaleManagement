using scale.Interfaces;
using scale.Peripheral.XK3190_D10.Dataframe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static scale.Peripheral.XK3190_D10.Constants;

namespace scale.Peripheral.XK3190_D10
{
    /// <summary>
    /// XK3190-D10 is a weighing indicator, it retrieves data from the loadcell(s)
    /// and return data through RS232/RS422. This class handles XK3190-D10 instance behaviour.
    /// Will be hooked into serial port to get intended data
    /// Note:
    /// - Communication mode is Continuously Send by default
    /// </summary>
    public class XK3190D10 : IWeighingIndicator
    {
        private CommunicationMode _communicationMode = CommunicationMode.ContinuouslySend;
        private DataframeHandler _dataframeHandler;

        public XK3190D10()
        {
            SetupHandler();
        }

        public XK3190D10(CommunicationMode mode)
        {
            _communicationMode = mode;
            SetupHandler();
        }

        private void SetupHandler()
        {
            // FACT - factory
            if (_communicationMode == CommunicationMode.ContinuouslySend)
            {
                _dataframeHandler = new ContinuouslySendDataframeHandler();
            }
            else if (_communicationMode == CommunicationMode.Command)
            {
                throw new NotImplementedException();
            }
        }

        public int GetDataframeLength()
        {
            return _dataframeHandler.Groups;
        }

        /// <summary>
        /// Receive data from the device
        /// </summary>
        public object Receive(byte[] dataframe)
        {
            return _dataframeHandler.Receive(dataframe);
        }

        /// <summary>
        /// Send data to device
        /// </summary>
        public void Send<T>(CommandCode commandCode, T request)
        {
            throw new NotImplementedException();
        }
    }
}
