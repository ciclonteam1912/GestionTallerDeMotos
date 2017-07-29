using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using GestionTallerDeMotos.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionTallerDeMotos.Controllers
{
    public class ClienteController : Controller
    {
        private ApplicationDbContext _context;

        public ClienteController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Cliente
        public ActionResult Index()
        {
            var clientes = _context.Clientes
                .Include(c => c.TipoDocumento)
                .Include(c => c.Personeria)
                .ToList();

            return View("ListaDeClientes", clientes);
        }


        public ActionResult NuevoCliente()
        {
            var tiposDocumentos = _context.TiposDocumento.ToList();
            var personerias = _context.Personerias.ToList();

            var viewModel = new ClienteViewModel()
            {
                TiposDocumentos = tiposDocumentos,
                Personerias = personerias
            };

            return View("ClienteFormulario", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ClienteViewModel(cliente)
                {
                    Personerias = _context.Personerias.ToList(),
                    TiposDocumentos = _context.TiposDocumento.ToList()
                };

                return View("ClienteFormulario", viewModel);
            }

            if (cliente.Id == 0) {
                cliente.FechaDeIngreso = DateTime.Now;
                _context.Clientes.Add(cliente);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}