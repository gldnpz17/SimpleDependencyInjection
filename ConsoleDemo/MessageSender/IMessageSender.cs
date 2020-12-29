﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.MessageSender
{
    public interface IMessageSender
    {
        void SendMessage(string recipient, string message);
    }
}
