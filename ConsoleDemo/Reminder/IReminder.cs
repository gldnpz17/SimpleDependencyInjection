using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.Reminder
{
    public interface IReminder
    {
        void SetName(string name);
        void Remind(ReminderItem item);
    }
}
