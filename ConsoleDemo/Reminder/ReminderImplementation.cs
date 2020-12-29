using ConsoleDemo.MessageSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.Reminder
{
    public class ReminderImplementation : IReminder
    {
        private readonly IMessageSender _messageSender;
        private string _name;

        public ReminderImplementation(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public async void Remind(ReminderItem item)
        {
            await Task.Delay(item.Delay);

            _messageSender.SendMessage(_name, $"{_name}, you've got a reminder: {item.Message}");
        }

        public void SetName(string name)
        {
            _name = name;
        }
    }
}
