using Nogueira.Livraria.Infra.Notifications.Interfaces;
using System;

namespace Nogueira.Livraria.Infra.Notifications
{
    public class NotificationObserver : INotificationObserver
    {
        public Notification Notification { get; set; }

        public void Dispose()
        {
            Notification?.Notifications.Clear();
            GC.SuppressFinalize(this);
        }

        public void OnCompleted()
        {
            Dispose();
        }

        public void OnError(Exception error)
        {
            throw error;
        }

        public void OnNext(Notification value)
        {
            Notification = value;
        }

        public void Subscribe(INotificationHandler handler)
        {
            handler.Subscribe(this);
        }
    }
}