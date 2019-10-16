using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gol.IO.Domain.Core.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler<DomainNotification>
    {
        private List<DomainNotification> notifications;

        public DomainNotificationHandler()
        {
            notifications = new List<DomainNotification>();
        }

        public List<DomainNotification> GetNotifications()
        {
            return notifications;
        }

        public void Handle(DomainNotification message)
        {
            notifications.Add(message);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Erro: {message.Key} - {message.Value}");
        }

        public bool HasNotifications()
        {
            return notifications.Any();
        }

        public void Dispose()
        {
            notifications = new List<DomainNotification>();
        }
    }
}
