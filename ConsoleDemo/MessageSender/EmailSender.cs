using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.MessageSender
{
    public class EmailSender : IMessageSender
    {
        public void SendMessage(string recipient, string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"An email has been sent to {recipient}. Message: \"{message}\"");
        }
    }
}
