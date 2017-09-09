using AutoMapper;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using GestionTallerDeMotos.ViewModels;
using System;
using System.Linq;
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
            if(User.IsInRole(RoleName.Administrador))
                return View("ListaDeClientes");

            return View("ListaDeClientesSoloLectura");
        }

        [Authorize(Roles = RoleName.Administrador)]
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

        [Authorize(Roles = RoleName.Administrador)]
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
            else
            {
                var clientesBD = _context.Clientes.Single(c => c.Id == cliente.Id);
                Mapper.Map<Cliente, Cliente>(cliente, clientesBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = RoleName.Administrador)]
        public ActionResult EditarCliente(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();

            var viewModel = new ClienteViewModel(cliente)
            {
                Personerias = _context.Personerias.ToList(),
                TiposDocumentos = _context.TiposDocumento.ToList()
            };

            return View("ClienteFormulario", viewModel);
        }
    }
}