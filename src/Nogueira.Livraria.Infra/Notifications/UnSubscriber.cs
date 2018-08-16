using System;
using System.Collections.Generic;

namespace Nogueira.Livraria.Infra.Notifications
{
    public class UnSubscriber : IDisposable
    {
        private readonly IObserver<Notification> observer;
        private readonly List<IObserver<Notification>> observers;

        public UnSubscriber(IObserver<Notification> observer, List<IObserver<Notification>> observers)
        {
            this.observer = observer;
            this.observers = observers;
        }

        public void Dispose()
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }
    }
}