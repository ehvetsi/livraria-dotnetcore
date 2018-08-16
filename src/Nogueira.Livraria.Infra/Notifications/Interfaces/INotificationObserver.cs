using System;

namespace Nogueira.Livraria.Infra.Notifications.Interfaces
{
    public interface INotificationObserver : IObserver<Notification>, IDisposable
    {
        Notification Notification { get; set; }

        void Subscribe(INotificationHandler handler);
    }
}