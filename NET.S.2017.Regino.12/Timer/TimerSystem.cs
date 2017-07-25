using System;
using System.Threading;

namespace Timer
{
    public sealed class NewTimerEventArgs: EventArgs
    {
        private readonly string _notification;
        private readonly DateTime _timeNow;
        private readonly int _minutes;
        

        public string Notification => _notification;
        public int Minutes => _minutes;
        public DateTime TimeNow => _timeNow;

        public NewTimerEventArgs(int minutes, string notification)
        {
            _notification = notification;
            _minutes = minutes;
            _timeNow = DateTime.Now;
        }

    }

    public class Timer
    {
        public event EventHandler<NewTimerEventArgs> NewTimer = delegate { };

        protected virtual void OnNewTimer(NewTimerEventArgs e)
        {
            EventHandler<NewTimerEventArgs> temp = NewTimer;

            temp?.Invoke(this, e);
        }

        public void SimulateNewTimer(int hours, int minutes, int seconds, string notification)
        {
            hours *= 3600000;
            minutes *= 60000;
            seconds *= 1000;
            Thread.Sleep(seconds + hours + minutes);
            OnNewTimer(new NewTimerEventArgs(seconds, notification));
        }
    }

    public sealed class MobilePhone
    {
        public MobilePhone(Timer timer)
        {
            timer.NewTimer += MobilePhoneMsg;
        }

        private void MobilePhoneMsg(object sender, NewTimerEventArgs eventArgs)
        {
            Console.WriteLine("Task for timer complited om mobile phone:");
            Console.WriteLine($"Task for timer complited:{Environment.NewLine}" +
                              $"Was set on: {eventArgs.TimeNow}," +
                              $"  Minutes passed: {eventArgs.Minutes}" +
                              $" Notification: {eventArgs.Notification}");
        }

        public void Unregister(Timer timer)
        {
            timer.NewTimer -= MobilePhoneMsg;
        }
    }

    public sealed class Pager
    {
        public void Register(Timer timer)
        {
            timer.NewTimer += PagerMsg;
        }

        private void PagerMsg(object sender, NewTimerEventArgs eventArgs)
        {
            Console.WriteLine("Task for timer complited on pager:");
            Console.WriteLine($"Task for timer complited:{Environment.NewLine}" +
                              $"Was set on: {eventArgs.TimeNow}," +
                              $"  Minutes passed: {eventArgs.Minutes}" +
                              $" Notification: {eventArgs.Notification}");
        }

        public void Unregister(Timer timer)
        {
            timer.NewTimer -= PagerMsg;
        }
    }
}
