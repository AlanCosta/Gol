using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.IO.Domain.Airplane.Events
{
    public class AirplaneExcluidoEvent : BaseAirplaneEvent
    {
        public AirplaneExcluidoEvent(int id)
        {
            Id = id;
        }
    }
}
