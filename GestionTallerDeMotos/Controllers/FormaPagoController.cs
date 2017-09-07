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
    public class FormaPagoController : Controller
    {
        private ApplicationDbContext _context;

        public FormaPagoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: FormaPago
        public ActionResult Index()
        {
            return View("ListaDeFormasDePago");
        }

        public ActionResult NuevoFormaPago()
        {
            var formaPago = new FormaPago();

            return View("NuevoFormaPagoFormulario", formaPago);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarFormaPago(FormaPago formaPago)
        {
            if (!ModelState.IsValid)
            {
                return View("NuevoFormaPagoFormulario", formaPago);
            }

            if (formaPago.Id == 0)
            {                
                _context.FormaPagos.Add(formaPago);
            }
            else
            {
                var formaPagoBD = _context.FormaPagos.Single(c => c.Id == formaPago.Id);
                Mapper.Map<FormaPago, FormaPago>(formaPago, formaPagoBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult EditarFormaPago(int id)
        {
            var formaPagoBD = _context.FormaPagos.SingleOrDefault(c => c.Id == id);

            if (formaPagoBD == null)
                return HttpNotFound();

            var formaPago = new FormaPago(formaPagoBD);

            return View("NuevoFormaPagoFormulario", formaPago);
        }
    }
}