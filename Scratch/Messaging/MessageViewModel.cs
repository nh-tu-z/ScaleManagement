using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// plugin
using TheRFramework.Utilities;

// debug
using System.Diagnostics;

namespace scale.Scratch.Messaging
{
    // this is what will be responsible for showing and holding the sent/received messages, as well as the 
    // "To be sent" text (at the bottom of the UI)
    public class MessageViewModel : BaseViewModel
    {
        private int _messagesCount;
        private string _messagesText;
        private string _toBeSentText;

        public int MessagesCount
        {
            get => _messagesCount;
            set => RaisePropertyChanged(ref _messagesCount, value);
        }
        public string MessagesText
        {
            get => _messagesText;
            set => RaisePropertyChanged(ref _messagesText, value);
        }
        public string ToBeSentText
        {
            get => _toBeSentText;
            set => RaisePropertyChanged(ref _toBeSentText, value);
        }

        // Command is inherits ICommand, allowing you to bind a button's command
        // to a function instead of using events
        public Command ClearMessagesCommand { get; }
        public Command SendMessageCommand { get; }
        public MessageSender Sender { get; set; }
        public MessageViewModel(MessageSender sender)
        {
            Sender = sender;

            MessagesCount = 0;
            MessagesText = "";
            ToBeSentText = "";

            ClearMessagesCommand = new Command(ClearMessages);
            SendMessageCommand = new Command(SendMessage);
        }

        private void SendMessage()
        {
            if (!string.IsNullOrEmpty(ToBeSentText))
            {
                Sender.SendMessage(ToBeSentText);
                AddSentMessage(ToBeSentText);
                // clear text after sending
                ToBeSentText = "";
            }
        }

        private void ClearMessages()
        {
            MessagesText = "";
            MessagesCount = 0;
        }

        public void AddSentMessage(string message)
        {
            AddMessage($"{DateTime.Now} | TX> {message}");
        }

        public void AddReceivedMessage(string message)
        {
            AddMessage($"{DateTime.Now} | RX> {message}");
        }

        public void AddMessage(string message)
        {
            Trace.WriteLine(message);
            MessagesCount++;
        }
        public void WriteLine(string text)
        {
            MessagesText += text + '\n';
        }
    }
}
