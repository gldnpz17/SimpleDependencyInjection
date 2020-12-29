using ConsoleDemo.MessageSender;
using ConsoleDemo.Reminder;
using SimpleDependecyInjectionSystem;
using System;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Register dependencies.
            var Builder = new ContainerBuilder();

            // NOTE: Change the implementation from EmailSender to SmsSender to
            // send an sms instead of an email.
            Builder.Register(typeof(EmailSender), typeof(IMessageSender), true);
            Builder.Register(typeof(ReminderImplementation), typeof(IReminder), false);

            // Get container.
            var Container = Builder.Build();

            // Initialize reminders.
            var AliceReminder = Container.GetInstance<IReminder>();
            var BobReminder = Container.GetInstance<IReminder>();

            AliceReminder.SetName("Alice");
            BobReminder.SetName("Bob");

            // Set reminders.

            BobReminder.Remind(new ReminderItem()
            {
                Delay = TimeSpan.FromSeconds(3),
                Message = "Prepare breakfast."
            });

            AliceReminder.Remind(new ReminderItem()
            {
                Delay = TimeSpan.FromSeconds(1),
                Message = "Fix car headlights."
            });

            AliceReminder.Remind(new ReminderItem()
            {
                Delay = TimeSpan.FromSeconds(5),
                Message = "Eat breakfast with Bob."
            });

            Console.ReadKey();
        }
    }
}
