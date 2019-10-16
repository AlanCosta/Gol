using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gol.IO.Application.Interfaces;
using Gol.IO.Application.ViewModels;
using Gol.IO.Domain.Core.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gol.IO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneController : ControllerBase
    {
        private readonly IAirplaneAppService context;

        public AirplaneController(IAirplaneAppService _context,
            IDomainNotificationHandler<DomainNotification> notifications) : base()
        {
            context = _context;
        }
        // GET: api/Airplane
        [HttpGet]
        public IEnumerable<AirplaneViewModel> Get()
        {
            return context.ObterTodos();
        }

        // GET: api/Airplane/5
        [HttpGet("{id}", Name = "Get")]
        public AirplaneViewModel Get(int id)
        {
            return context.ObterPorId(id); ;
        }

        // POST: api/Airplane
        [HttpPost]
        public void Post(AirplaneViewModel model)
        {
            context.Registrar(model);
        }

        // PUT: api/Airplane/5
        [HttpPut("{id}")]
        public void Put(int id, AirplaneViewModel model)
        {
            model.Id = id;
            context.Atualizar(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.Excluir(id);
        }
    }
}
