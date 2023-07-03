using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static scale.Peripheral.XK3190_D10.Constants;

namespace scale.Peripheral.XK3190_D10.Dataframe
{
    public class CommandDataframeHandler : DataframeHandler
    {
        public override int Groups { get; set; }
        public override CommandCode Code { get; set; }

        public CommandDataframeHandler()
        {

        }

        public override CommunicationMode GetCommunicationMode()
        {
            return CommunicationMode.Command;
        }

        public override object Receive(byte[] dataframe)
        {
            throw new NotImplementedException();
        }
    }
}
