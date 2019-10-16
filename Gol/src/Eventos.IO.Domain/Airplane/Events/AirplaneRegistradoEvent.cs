using System;

namespace Gol.IO.Domain.Airplane.Events
{
    public class AirplaneRegistradoEvent : BaseAirplaneEvent
    {
        public AirplaneRegistradoEvent(int id, string codigoAviao, string modelo, int qtdPassageiros, DateTime dataRegistro)
        {
            Id = id;
            CodigoAviao = codigoAviao;
            Modelo = modelo;
            QtdPassageiros = qtdPassageiros;
            DataRegistro = dataRegistro;
        }
    }
}
