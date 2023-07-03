using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static scale.Peripheral.XK3190_D10.Constants;

namespace scale.Peripheral.XK3190_D10.Dataframe
{
    public class ContinuouslySendDataframeHandler : DataframeHandler
    {
        public override int Groups { get; set; } = 12;
        public override CommandCode Code { get; set; } = CommandCode.ContinuouslySendMode;

        public ContinuouslySendDataframeHandler()
        {
        }

        public override CommunicationMode GetCommunicationMode()
        {
            return CommunicationMode.ContinuouslySend;
        }

        /// <summary>
        /// Return the weighing data
        /// Note: type of returned data is float
        /// </summary>
        public override object Receive(byte[] dataframe)
        {
            float result = -1; // error
            if (IsDataframe(dataframe))
            {
                // FACT - logic based on one frame received data in docs
                byte[] rawData = new byte[8];
                Array.Copy(dataframe, 1, rawData, 0, rawData.Length);
                var decimalPointString = Encoding.ASCII.GetString(new byte[] { rawData.Last() });
                if (int.TryParse(decimalPointString, out var decimalPoint))
                {
                    var wholeNumber = rawData.Take(rawData.Length - decimalPoint);
                    var fractionalPart = new byte[decimalPoint];
                    Array.Copy(rawData, rawData.Length - decimalPoint, fractionalPart, 0, fractionalPart.Length);
                    var weighingString = wholeNumber.Concat(new byte[] { DotByte })
                                                  .Concat(fractionalPart);
                    float.TryParse(Encoding.ASCII.GetString(weighingString.ToArray()), out result);
                };
            }
            return result;
        }
    }
}
