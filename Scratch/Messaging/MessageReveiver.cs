using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;
// References: https://www.youtube.com/watch?v=nagkdMZz7DA
namespace scale.Scratch.Messaging
{
    class MessageReceiver
    {
        private Thread ReceiverThread { get; set; }
        public bool CanReceive { get; set; }
        public bool ShouldShutDownPermanently { get; set; }
        public SerialPort Port { set; get; }

        public MessageViewModel Messages { get; set; }

        public MessageReceiver()
        {
            CanReceive = true;
            ShouldShutDownPermanently = false;

            ReceiverThread = new Thread(ReceiveLoop);
            ReceiverThread.Start();
        }
        
        private void ReceiveLoop()
        {
            // will act like a "receiver buffer", and it is better than creating a new  string every loop
            string message = "";
            char read = ' ';
            while(true)
            {
                // Used for when exiting the application
                if(ShouldShutDownPermanently)
                {
                    return;
                }

                // Used for pausing/resuming the receiver
                if(CanReceive)
                {
                    if(Port != null && Port.IsOpen)
                    {
                        while(Port.BytesToRead > 0)
                        {
                            read = (char)Port.ReadChar();
                            switch(read)
                            {
                                case '\r':
                                    break;
                                case '\n':
                                    // New Line reached. This will be classed as a new message
                                    Messages.AddReceivedMessage(message);
                                    message = "";
                                    break;
                                default:
                                    // Add the read char to the buffer
                                    message += read;
                                    break;
                            }
                        }
                    }
                }

                // Stop the thread  looping  millions of times per second which eats up CPU
                Thread.Sleep(1);
            }
        }
        public void StopThreadLoop()
        {
            CanReceive = false;
            ShouldShutDownPermanently = true;
            ReceiverThread.Abort();
        }
    }
}
