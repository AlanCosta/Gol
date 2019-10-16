using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.IO.Domain.Airplane.Commands
{
    public class RegistrarAirplaneCommand : BaseAirplaneCommand
    {
        public RegistrarAirplaneCommand(string codigoAviao, string modelo, int qtdPassageiros, DateTime dataRegistro)
        {
            CodigoAviao = codigoAviao;
            Modelo = modelo;
            QtdPassageiros = qtdPassageiros;
            DataRegistro = dataRegistro;
        }

    }
}
