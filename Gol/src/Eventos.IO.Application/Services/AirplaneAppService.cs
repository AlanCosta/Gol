using AutoMapper;
using Gol.IO.Application.Interfaces;
using Gol.IO.Application.ViewModels;
using Gol.IO.Domain.Core.Bus;
using Gol.IO.Domain.Airplane.Commands;
using Gol.IO.Domain.Airplane.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Gol.IO.Domain.Airplane;

namespace Gol.IO.Application.Services
{
    public class AirplaneAppService : IAirplaneAppService
    {
        private readonly IBus bus;
        private readonly IMapper mapper;
        private readonly IAirplaneRepository AirplaneRepository;

        public AirplaneAppService(IBus _bus, IMapper _mapper, IAirplaneRepository _AirplaneRepository)
        {
            bus = _bus;
            mapper = _mapper;
            AirplaneRepository = _AirplaneRepository;
        }

        public void Atualizar(AirplaneViewModel eventoViewModel)
        {
            Airplane model = new Airplane(eventoViewModel.Id, eventoViewModel.CodigoAviao, eventoViewModel.Modelo, eventoViewModel.QtdPassageiros, DateTime.Now);
            AirplaneRepository.Atualizar(model);
            AirplaneRepository.SaveChanges();
            //var atualizarEventoCommand = mapper.Map<AtualizarAirplaneCommand>(eventoViewModel);
            //bus.SendCommand(atualizarEventoCommand);
        }

        public void Dispose()
        {
            AirplaneRepository.Dispose();
        }

        public void Excluir(int id)
        {
            AirplaneRepository.Remover(id);
            AirplaneRepository.SaveChanges();
            //bus.SendCommand(new ExcluirAirplaneCommand(id));
        }

        public AirplaneViewModel ObterPorId(int id)
        {
            var airplane = AirplaneRepository.ObterPorId(id);
            AirplaneViewModel model = new AirplaneViewModel();
            if (airplane != null)
            {
                model.Id = airplane.Id;
                model.CodigoAviao = airplane.CodigoAviao;
                model.Modelo = airplane.Modelo;
                model.QtdPassageiros = airplane.QtdPassageiros;
                model.DataRegistro = airplane.DataRegistro;
            }
            return model;
        }

        public IEnumerable<AirplaneViewModel> ObterTodos()
        {
            var modelList = AirplaneRepository.ObterTodos();
            IEnumerable<AirplaneViewModel> listF;
            List<AirplaneViewModel> list = new List<AirplaneViewModel>();
            foreach (var item in modelList)
            {
                AirplaneViewModel model = new AirplaneViewModel();
                model.Id = item.Id;
                model.CodigoAviao = item.CodigoAviao;
                model.Modelo = item.Modelo;
                model.QtdPassageiros = item.QtdPassageiros;
                model.DataRegistro = item.DataRegistro;
                list.Add(model);
            }
            listF = list;
            return listF;
        }

        public void Registrar(AirplaneViewModel eventoViewModel)
        {
            Airplane model = new Airplane(eventoViewModel.Id,eventoViewModel.CodigoAviao, eventoViewModel.Modelo, eventoViewModel.QtdPassageiros, DateTime.Now);
            //Mapper.Map(eventoViewModel, model);
            AirplaneRepository.Adicionar(model);
            AirplaneRepository.SaveChanges();
            //var registroCommand = mapper.Map<RegistrarAirplaneCommand>(eventoViewModel);
            //bus.SendCommand(registroCommand);

        }
    }
}
