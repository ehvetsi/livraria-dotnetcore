using Nogueira.Livraria.Infra.Enums;
using System.Collections.Generic;

namespace Nogueira.Livraria.Infra.Notifications
{
    public class Notification
    {
        public Notification()
        {
            Notifications = new List<KeyValuePair<NotificationType, string>>();
        }

        public List<KeyValuePair<NotificationType, string>> Notifications { get; set; }
    }
}