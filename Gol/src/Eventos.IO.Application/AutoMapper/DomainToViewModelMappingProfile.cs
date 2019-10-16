using AutoMapper;
using Gol.IO.Application.ViewModels;
using Gol.IO.Domain.Airplane;

namespace Gol.IO.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Airplane, AirplaneViewModel>();
        }
    }
}
