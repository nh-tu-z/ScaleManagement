using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// plugin
using TheRFramework.Utilities;

namespace scale.Scratch.Messaging
{
    class MainViewModel : BaseViewModel
    {
        public MessageViewModel Messages { get; set; }
        public MessageReceiver Receiver { get; set; }
        public MessageSender Sender { get; set; }
        public SerialPortViewModel SerialPort { get; set; }
        public MainViewModel()
        {
            SerialPort = new SerialPortViewModel();
            Receiver = new MessageReceiver();
            Sender = new MessageSender();
            Messages = new MessageViewModel(Sender);
            SerialPort.Receiver = Receiver;
            SerialPort.Sender = Sender;
            SerialPort.Messages = Messages;
        }
    }
}
