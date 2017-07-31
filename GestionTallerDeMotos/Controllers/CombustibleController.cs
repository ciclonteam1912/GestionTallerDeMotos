using AutoMapper;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionTallerDeMotos.Controllers
{
    public class CombustibleController : Controller
    {
        private ApplicationDbContext _context;

        public CombustibleController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Combustible
        public ActionResult Index()
        {
            return View("ListaDeCombustibles");
        }

        public ActionResult NuevoCombustible()
        {
            var combustible = new Combustible();
            return View("CombustibleFormulario", combustible);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarCombustible(Combustible combustible)
        {
            if (!ModelState.IsValid)
                return View("CombustibleFormulario", combustible);

            if (combustible.Id == 0)
                _context.Combustibles.Add(combustible);
            else
            {
                var combustibleBD = _context.Combustibles.Single(c => c.Id == combustible.Id);
                Mapper.Map<Combustible, Combustible>(combustible, combustibleBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult EditarCombustible(int id)
        {
            var combustibleBD = _context.Combustibles.SingleOrDefault(c => c.Id == id);

            if (combustibleBD == null)
                return HttpNotFound();

            var combustible = new Combustible(combustibleBD);

            return View("CombustibleFormulario", combustible);
        }
    }
}