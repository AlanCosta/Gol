using Gol.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.IO.Domain.Airplane.Events
{
    public abstract class BaseAirplaneEvent : Event
    {
        public int Id { get; protected set; }
        public string CodigoAviao { get; protected set; }
        public string Modelo { get; protected set; }
        public int QtdPassageiros { get; protected set; }
        public DateTime DataRegistro { get; protected set; }
    }
}
