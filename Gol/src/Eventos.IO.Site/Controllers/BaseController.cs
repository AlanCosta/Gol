using WebMotors.IO.Domain.Core.Notifications;
using WebMotors.IO.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMotors.IO.Site.Controllers
{
    public class BaseController : Controller
    {
        private readonly IDomainNotificationHandler<DomainNotification> notifications;
        private readonly IUser user;
        public BaseController(IDomainNotificationHandler<DomainNotification> _notifications, IUser _user)
        {
            _notifications = notifications;
            user = _user;

        }

        protected bool OperacaoValida()
        {
            return (!notifications.HasNotifications());
        }
    }
}
