using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.IO.Domain.Airplane.Commands
{
    public class AtualizarAirplaneCommand : BaseAirplaneCommand
    {
        public AtualizarAirplaneCommand(int id, string codigoAviao, string modelo, int qtdPassageiros, DateTime dataRegistro)
        {
            Id = id;
            CodigoAviao = codigoAviao;
            Modelo = modelo;
            QtdPassageiros = qtdPassageiros;
            DataRegistro = dataRegistro;
        }
    }
}
