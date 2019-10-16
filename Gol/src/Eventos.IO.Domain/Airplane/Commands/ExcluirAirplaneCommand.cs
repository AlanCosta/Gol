using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.IO.Domain.Airplane.Commands
{
    public class ExcluirAirplaneCommand : BaseAirplaneCommand
    {
        public ExcluirAirplaneCommand(int id)
        {
            Id = id;
        }
    }
}
