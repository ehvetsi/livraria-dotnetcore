using Nogueira.Livraria.Infra.Enums;
using System;
using System.Collections.Generic;

namespace Nogueira.Livraria.Infra.Notifications.Interfaces
{
    public interface INotificationHandler : IObservable<Notification>
    {
        Notification Notification { get; set; }

        List<IObserver<Notification>> Observers { get; set; }

        void Notify(NotificationType notificationType, string notification);
    }
}