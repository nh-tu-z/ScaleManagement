using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.Peripheral.XK3190_D10
{
    public static class Constants
    {
        public enum CommunicationMode
        {
            ContinuouslySend,
            Command
        }

        // FACT - Treat Continuously Send mode as 27th command in Command mode to centralize the logic
        public enum CommandCode : byte
        {
            ContinuouslySendMode = 0,
            A = 65
            // TODO - command A -> Z
        }

        // FACT - ASCII
        public const byte StartByte = 2;

        public const byte EndByte = 3;

        public const byte DotByte = 46;
    }
}
