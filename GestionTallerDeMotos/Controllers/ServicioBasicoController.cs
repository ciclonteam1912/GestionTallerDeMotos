﻿using AutoMapper;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Linq;
using System.Web.Mvc;

namespace GestionTallerDeMotos.Controllers
{
    public class ServicioBasicoController : Controller
    {
        private ApplicationDbContext _context;

        public ServicioBasicoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: ServicioBasico
        public ActionResult Index()
        {
            if(User.IsInRole(RoleName.Administrador))
                return View("ListaDeServiciosBasicos");

            return View("ListaDeServiciosBasicosSoloLectura");
        }

        [Authorize(Roles = RoleName.Administrador)]
        public ActionResult NuevoServicioBasico()
        {
            var servicioBasico = new ServicioBasico();

            return View("ServicioBasicoFormulario", servicioBasico);
        }

        [Authorize(Roles = RoleName.Administrador)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarServicioBasico(ServicioBasico servicioBasico)
        {
            if (!ModelState.IsValid)
            {
                return View("ServicioBasicoFormulario", servicioBasico);
            }

            if (servicioBasico.Id == 0)
                _context.ServiciosBasicos.Add(servicioBasico);
            else
            {
                var servicioBasicoBD = _context.ServiciosBasicos.Single(sb => sb.Id == servicioBasico.Id);
                Mapper.Map<ServicioBasico, ServicioBasico>(servicioBasico, servicioBasicoBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = RoleName.Administrador)]
        public ActionResult EditarServicioBasico(int id)
        {
            var servicioBasicoBD = _context.ServiciosBasicos.SingleOrDefault(c => c.Id == id);

            if (servicioBasicoBD == null)
                return HttpNotFound();

            var servicioBasico = new ServicioBasico(servicioBasicoBD);

            return View("ServicioBasicoFormulario", servicioBasico);            
        }
    }
}