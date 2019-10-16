using Gol.IO.Domain.Core.Bus;
using Gol.IO.Domain.Core.Events;
using Gol.IO.Domain.Core.Notifications;
using Gol.IO.Domain.Airplane.Commands;
using Gol.IO.Domain.Airplane.Events;
using Gol.IO.Domain.Airplane.Repository;
using Gol.IO.Domain.Interfaces;
using Gol.IO.Infra.CrossCutting.Bus;
using Gol.IO.Infra.Data.Context;
using Gol.IO.Infra.Data.Repository;
using Gol.IO.Infra.Data.Uow;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Gol.IO.Application.Interfaces;
using Gol.IO.Application.Services;
using AutoMapper;

namespace Gol.IO.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IUser, AspNetUser>();

            //Application
            //services.AddSingleton(Mapper.Configuration);
            //services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IAirplaneAppService, AirplaneAppService>();

            //Domain - commands
            services.AddScoped<IHandler<RegistrarAirplaneCommand>, AirplaneCommandHandler>();
            services.AddScoped<IHandler<AtualizarAirplaneCommand>, AirplaneCommandHandler>();
            services.AddScoped<IHandler<ExcluirAirplaneCommand>, AirplaneCommandHandler>();
            //Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<AirplaneRegistradoEvent>, AirplaneEventHandler>();
            services.AddScoped<IHandler<AirplaneAtualizadoEvent>, AirplaneEventHandler>();
            services.AddScoped<IHandler<AirplaneExcluidoEvent>, AirplaneEventHandler>();
            //Infra - Data
            services.AddScoped<IAirplaneRepository, AirplaneRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AirplanesContext>();

            //INfra - bus
            services.AddScoped<IBus, InMemoryBus>();

        }
    }
}
