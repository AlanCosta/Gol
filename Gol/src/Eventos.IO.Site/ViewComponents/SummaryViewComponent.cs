using WebMotors.IO.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMotors.IO.Site.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly IDomainNotificationHandler<DomainNotification> notifications;

        public SummaryViewComponent(IDomainNotificationHandler<DomainNotification> _notifications)
        {
            notifications = _notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(notifications.GetNotifications());
            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Value));

            return View();

        }
    }
}
