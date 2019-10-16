using Gol.IO.Domain.CommandHandlers;
using Gol.IO.Domain.Core.Bus;
using Gol.IO.Domain.Core.Events;
using Gol.IO.Domain.Core.Notifications;
using Gol.IO.Domain.Airplane.Events;
using Gol.IO.Domain.Airplane.Repository;
using Gol.IO.Domain.Interfaces;
using System;

namespace Gol.IO.Domain.Airplane.Commands
{
    public class AirplaneCommandHandler : CommandHandler,
        IHandler<RegistrarAirplaneCommand>,
        IHandler<AtualizarAirplaneCommand>,
        IHandler<ExcluirAirplaneCommand>
    {
        private readonly IAirplaneRepository AirplaneRepository;
        private readonly IBus bus;
        public AirplaneCommandHandler(IAirplaneRepository _AirplaneRepository, IUnitOfWork uow, IBus _bus, IDomainNotificationHandler<DomainNotification> notifications) : base(uow, _bus, notifications)
        {
            AirplaneRepository = _AirplaneRepository;
            bus = _bus;
        }


        public void Handle(RegistrarAirplaneCommand message)
        {
            var airplane = Airplane.AirplaneFactory.NovoAirplaneCompleto(message.Id, message.CodigoAviao, message.Modelo,
                message.QtdPassageiros, message.DataRegistro);

            if (!AirplaneValido(airplane)) return;

            //Validações de Negocio

            //Persistencia
            AirplaneRepository.Adicionar(airplane);

            if (Commit())
            {
                //Notificar processo concluido!
                //evento registrado com sucesso
                bus.RaiseEvent(new AirplaneRegistradoEvent(airplane.Id, airplane.CodigoAviao, airplane.Modelo,
                airplane.QtdPassageiros, airplane.DataRegistro));
            }
        }

        public void Handle(AtualizarAirplaneCommand message)
        {
            var AirplaneAtual = AirplaneRepository.ObterPorId(message.Id);

            if (!AirplaneExistente(message.Id, message.MessageType)) return;

            //TODO: Validar se o evento pertence a pessoa que esta editando.


            var airplane = Airplane.AirplaneFactory.NovoAirplaneCompleto(message.Id, message.CodigoAviao, message.Modelo,
                message.QtdPassageiros, message.DataRegistro);

            if (!AirplaneValido(airplane)) return;

            AirplaneRepository.Atualizar(airplane);

            if (Commit())
            {
                bus.RaiseEvent(new AirplaneAtualizadoEvent(airplane.Id, airplane.CodigoAviao, airplane.Modelo,
                airplane.QtdPassageiros, airplane.DataRegistro));
            }
            
        }

        public void Handle(ExcluirAirplaneCommand message)
        {
            if (!AirplaneExistente(message.Id, message.MessageType)) return;

            AirplaneRepository.Remover(message.Id);

            if (Commit())
            {
                bus.RaiseEvent(new AirplaneExcluidoEvent(message.Id));
            }
        }

        private bool AirplaneValido(Airplane Airplane)
        {
            if (Airplane.EhValido()) return true;

            NotificarValidãcoesErro(Airplane.ValidationResult);
            return false;
        }

        private bool AirplaneExistente(int id, string messageType)
        {
            var Airplane = AirplaneRepository.ObterPorId(id);

            if (Airplane != null) return true;

            bus.RaiseEvent(new DomainNotification(messageType, "Airplane não encontrado."));
            return false;
        }
    }
}
