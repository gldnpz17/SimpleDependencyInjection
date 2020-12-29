using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.MessageSender
{
    public class SmsSender : IMessageSender
    {
        public void SendMessage(string recipient, string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"An sms has been sent to {recipient}. Message: \"{message}\"");
        }
    }
}
