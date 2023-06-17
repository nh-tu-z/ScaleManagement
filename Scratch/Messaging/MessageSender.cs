using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.Scratch.Messaging
{
    public class MessageSender
    {
        public bool CanSend { get; set; }
        public SerialPort Port { get; set; }
        public MessageViewModel Messages { get; set; }
        public MessageSender()
        {
            CanSend = true;
        }
        // send a message through the serial port
        public void SendMessage(string message, bool shouldSendNewLine = true)
        {
            // add a new line if needed 
            string newMessage = message + (shouldSendNewLine ? "\n" : "");
            // get the bytes of message using serial port's encoding 
            // will be using a byte buffer because it's faster than sending strings using 
            // the serial port's build in methods
            byte[] buffer = Port.Encoding.GetBytes(newMessage);

            for(int i = 0; i < buffer.Length; ++i)
            {
                Port.BaseStream.WriteByte(buffer[i]);
            }
        }
    }
}
