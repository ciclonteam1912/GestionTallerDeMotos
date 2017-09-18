using AutoMapper;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.AtributosDeAutorizacion;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using GestionTallerDeMotos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionTallerDeMotos.Controllers
{
    public class TalonarioController : Controller
    {
        private ApplicationDbContext _context;

        public TalonarioController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Talonario
        public ActionResult Index()
        {
            if(User.IsInRole(RoleName.Administrador) || User.IsInRole(RoleName.JefeDeTaller) || User.IsInRole(RoleName.Mecanico))           
                return View("ListaDeTalonarios");

            return View("ListaDeTalonariosSoloLectura");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult NuevoTalonario()
        {
            var talonario = new TalonarioViewModel();

            return View("TalonarioFormulario", talonario);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarTalonario(Talonario talonario)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TalonarioViewModel(talonario);

                return View("TalonarioFormulario", viewModel);
            }

            if (talonario.Id == 0)
                _context.Talonarios.Add(talonario);
            else
            {
                var talonarioBD = _context.Talonarios.Single(t => t.Id == talonario.Id);
                Mapper.Map<Talonario, Talonario>(talonario, talonarioBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult EditarTalonario(int id)
        {
            var talonario = _context.Talonarios.SingleOrDefault(t => t.Id == id);

            if (talonario == null)
                return HttpNotFound();

            var viewModel = new TalonarioViewModel(talonario);

            return View("TalonarioFormulario", viewModel);
        }
    }

}