using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.Reminder
{
    public struct ReminderItem
    {
        public string Message { get; set; }
        public TimeSpan Delay { get; set; }
    }
}
