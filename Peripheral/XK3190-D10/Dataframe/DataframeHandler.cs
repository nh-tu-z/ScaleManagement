using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static scale.Peripheral.XK3190_D10.Constants;

namespace scale.Peripheral.XK3190_D10.Dataframe
{
    /// <summary>
    /// Dataframe handler for XK3190-D10.
    /// Note: Treat Continuously Send mode as 27th command in Command mode to centralize the logic
    /// </summary>
    public abstract class DataframeHandler
    {
        public abstract int Groups { get; set; }
        public abstract CommandCode Code { get; set; }

        public abstract CommunicationMode GetCommunicationMode();
        public abstract object Receive(byte[] dataframe);

        public bool IsDataframe(byte[] dataframe)
        {
            if ((dataframe.First() == 2 && dataframe.Last() == 3) && 
                dataframe.Length == Groups)
            {
                return true;
            }
            return false;
        }
    }
}
