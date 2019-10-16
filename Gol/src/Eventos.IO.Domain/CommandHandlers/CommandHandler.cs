using Gol.IO.Domain.Core.Bus;
using Gol.IO.Domain.Core.Notifications;
using Gol.IO.Domain.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.IO.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork uow;
        private readonly IBus bus;
        private readonly IDomainNotificationHandler<DomainNotification> notifications;
        public CommandHandler(IUnitOfWork _uow, IBus _bus, IDomainNotificationHandler<DomainNotification> _notifications)
        {
            uow = _uow;
            bus = _bus;
            notifications = _notifications;
        }

        protected void NotificarValidãcoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
                bus.RaiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }

        protected bool Commit()
        {
            if (notifications.HasNotifications()) return false;
            var commandResponse = uow.Commit();
            if (commandResponse.Success) return true;
            bus.RaiseEvent(new DomainNotification("Commit", "Ocorreu um erro ao salvar os dados no Banco!"));
            return false;
        }
    }
}
