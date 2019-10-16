using AutoMapper;
using Gol.IO.Application.ViewModels;
using Gol.IO.Domain.Airplane;
using Gol.IO.Domain.Airplane.Commands;

namespace Gol.IO.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AirplaneViewModel, RegistrarAirplaneCommand>()
                .ConstructUsing(c => new RegistrarAirplaneCommand(c.CodigoAviao,c.Modelo, c.QtdPassageiros, c.DataRegistro));

            CreateMap<AirplaneViewModel, AtualizarAirplaneCommand>()
                .ConstructUsing(c => new AtualizarAirplaneCommand(c.Id, c.CodigoAviao, c.Modelo, c.QtdPassageiros, c.DataRegistro));

            CreateMap<AirplaneViewModel, ExcluirAirplaneCommand>()
                .ConstructUsing(c => new ExcluirAirplaneCommand(c.Id));

            CreateMap<AirplaneViewModel, Airplane>();

        }
    }
}
