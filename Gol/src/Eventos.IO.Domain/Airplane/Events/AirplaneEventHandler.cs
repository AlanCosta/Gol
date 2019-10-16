using Gol.IO.Domain.Core.Events;
using System;

namespace Gol.IO.Domain.Airplane.Events
{
    public class AirplaneEventHandler :
        IHandler<AirplaneRegistradoEvent>,
        IHandler<AirplaneAtualizadoEvent>,
        IHandler<AirplaneExcluidoEvent>
    {
        public void Handle(AirplaneRegistradoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Airplane Registrado com Sucesso");
        }

        public void Handle(AirplaneAtualizadoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Airplane Atualizado com Sucesso");
        }

        public void Handle(AirplaneExcluidoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Airplane Excluido com Sucesso");
        }
    }
}
