using System;
using System.IO;

namespace demo.Behavioral
{
    class Observer
        : IDemo
    {
        public void Demo(TextWriter writer)
        {
            var first = new Observer1();
            var second = new Observer2();
            var notifier = new Notifier();

            try
            {
                notifier.Notify += first.SendEmail;
                notifier.Notify += second.SendSms;

                notifier.SendNotifications();
            }
            finally
            {
                notifier.Notify -= first.SendEmail;
                notifier.Notify -= second.SendSms;
            }
        }
    }

    class Notifier
    {
        public event EventHandler Notify;

        public void SendNotifications()
        {
            Notify(this, EventArgs.Empty);
        }
    }

    class Observer1
    {
        public void SendEmail(object sender, EventArgs e)
        {
            Console.WriteLine("sending email because {0} sent a notification", sender);
        }
    }

    class Observer2
    {
        public void SendSms(object sender, EventArgs e)
        {
            Console.WriteLine("sending SMS...");
        }
    }
}
