using Gol.IO.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.IO.Application.Interfaces
{
    public interface IAirplaneAppService : IDisposable
    {
        void Registrar(AirplaneViewModel AirplaneViewModel);
        IEnumerable<AirplaneViewModel> ObterTodos();
        AirplaneViewModel ObterPorId(int id);
        void Atualizar(AirplaneViewModel eventoViewModel);
        void Excluir(int id);
    }
}
