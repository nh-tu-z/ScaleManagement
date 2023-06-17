using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// debug
using System.Diagnostics;

namespace scale.Peripheral
{
    public class COM
    {
        public SerialPort Port;
        private Thread ReceiverThread { get; set; }
        private PeripheralType Peripheral { get; set; }
        public List<byte> Frame { get; set; }
        // TODO - make it more general
        private Scale Scale { get; set; }
        public enum PeripheralType
        {
            NotSpecified,
            XK3190_D10_Scale
        }
        public COM(PeripheralType type = PeripheralType.XK3190_D10_Scale /* default */)
        {
            switch(type)
            {
                case PeripheralType.XK3190_D10_Scale:
                    Scale = new Scale();
                    break;
                default:
                    break;
            }
        }
        public void init()
        {
            foreach (string port in SerialPort.GetPortNames())
            {
                Trace.WriteLine($"available port: {port}");
            }
            Port = new SerialPort();
            Port.PortName = "COM3";
            Port.BaudRate = 9600;

            ReceiverThread = new Thread(ReceivedStart);
            ReceiverThread.Start();
        }

        private void ReceivedStart()
        {
            Port.Open();

            bool started = false;

            while(true)
            {
                if (Port != null && Port.IsOpen)
                {
                    int newCharecter = Port.ReadChar();
                    Trace.WriteLine($"Read Char: {newCharecter.ToString("X")}");

                    // convert
                    //Frame.Add((byte)newCharecter);
                    //if (newCharecter == 0x02)
                    //{
                    //    started = true;
                    //}
                    //if(newCharecter == 0x03)
                    //{
                    //    started = false;
                    //}

                    //if(!started)
                    //{
                    //    //// 1 frame 12 bytes
                    //    //if(Frame.Count == 12)
                    //    //{
                    //    //    Trace.WriteLine($"Frame: {Frame.}");
                    //    //}
                    //}
                }
                Thread.Sleep(1);
            }
        }
        public void clearMessage()
        {
            //Message = string.Empty;
        }
    }
}
