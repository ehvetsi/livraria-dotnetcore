using Nogueira.Livraria.Infra.Enums;
using Nogueira.Livraria.Infra.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nogueira.Livraria.Infra.Notifications
{
    public class NotificationHandler : INotificationHandler
    {
        public NotificationHandler()
        {
            Observers = new List<IObserver<Notification>>();
            Notification = new Notification();
        }

        public Notification Notification { get; set; }
        public List<IObserver<Notification>> Observers { get; set; }

        public void Notify(NotificationType notificationType, string notification)
        {
            Notification.Notifications.Add(new KeyValuePair<NotificationType, string>(notificationType, notification));
            if (Observers.Any())
            {
                foreach (var observer in Observers)
                {
                    observer.OnNext(Notification);
                }
            }
        }

        public IDisposable Subscribe(IObserver<Notification> observer)
        {
            if (!Observers.Contains(observer))
            {
                Observers.Add(observer);
            }
            observer.OnNext(Notification);
            return new UnSubscriber(observer, Observers);
        }
    }
}