﻿using AutoMapper;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Linq;
using System.Web.Mvc;

namespace GestionTallerDeMotos.Controllers
{
    public class MarcaController : Controller
    {
        private ApplicationDbContext _context;

        public MarcaController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Marca
        public ActionResult Index()
        {
            return View("ListaDeMarcas");
        }

        public ActionResult NuevaMarca()
        {
            var marca = new Marca();
            return View("MarcaFormulario", marca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarMarca(Marca marca)
        {
            if (!ModelState.IsValid)
                return View("MarcaFormulario", marca);

            if (marca.Id == 0)
                _context.Marcas.Add(marca);
            else
            {
                var marcaDB = _context.Marcas.Single(m => m.Id == marca.Id);
                Mapper.Map<Marca, Marca>(marca, marcaDB);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult EditarMarca(int id)
        {
            var marcaBD = _context.Marcas.SingleOrDefault(c => c.Id == id);

            if (marcaBD == null)
                return HttpNotFound();

            var marca = new Marca(marcaBD);

            return View("MarcaFormulario", marca);
        }
    }
}