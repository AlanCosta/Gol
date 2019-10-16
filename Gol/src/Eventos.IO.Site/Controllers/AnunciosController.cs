using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMotors.IO.Application.Interfaces;
using WebMotors.IO.Application.ViewModels;
using WebMotors.IO.Domain.Core.Notifications;
using WebMotors.IO.Domain.Interfaces;

namespace WebMotors.IO.Site.Controllers
{
    public class AnunciosController : BaseController
    {
        private readonly IAnuncioAppService context;

        public AnunciosController(IAnuncioAppService _context,
            IDomainNotificationHandler<DomainNotification> notifications,
            IUser _user) : base(notifications, _user)
        {
            context = _context;
        }
        // GET: Anuncios
        public ActionResult Index()
        {
            return View(context.ObterTodos());
        }

        // GET: Anuncios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoViewModel = context.ObterPorId(id.Value);
            if (eventoViewModel == null)
            {
                return NotFound();
            }

            return View(eventoViewModel);
        }

        // GET: Anuncios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Anuncios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnuncioViewModel collection)
        {
            if (!ModelState.IsValid) return View(collection);
            context.Registrar(collection);

            ViewBag.RetornoPost = OperacaoValida() ? "sucesso,Evento registrado com sucesso" : "error,Evento nao registrado verifique as mensagens!";

            return View(collection);
        }

        // GET: Anuncios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncioViewModel = context.ObterPorId(id.Value);

            if (anuncioViewModel == null)
            {
                return NotFound();
            }

            return View(anuncioViewModel);
        }

        // POST: Anuncios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, AnuncioViewModel collection)
        {
            if (!ModelState.IsValid) return View(collection);

            context.Atualizar(collection);

            // TODO: Validar se a operação ocorreu com sucesso!
            ViewBag.RetornoPost = OperacaoValida() ? "sucesso,Evento Atualizado com sucesso" : "error,Evento nao pode ser atualizado verifique as mensagens!";
            return View(collection);
        }

        // GET: Anuncios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoViewModel = context.ObterPorId(id.Value);
            if (eventoViewModel == null)
            {
                return NotFound();
            }

            return View(eventoViewModel);
        }

        // POST: Anuncios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            context.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}