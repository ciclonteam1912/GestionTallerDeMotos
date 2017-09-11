using AutoMapper;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.AtributosDeAutorizacion;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using GestionTallerDeMotos.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GestionTallerDeMotos.Controllers
{
    public class VehiculoController : Controller
    {
        private ApplicationDbContext _context;

        public VehiculoController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Cliente
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Administrador) || User.IsInRole(RoleName.JefeDeTaller))
                return View("ListaDeVehiculos");

            return View("ListaDeVehiculosSoloLectura");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult NuevoVehiculo()
        {
            var clientes = _context.Clientes.ToList();
            var aseguradoras = _context.Aseguradoras.ToList();
            var modelos = _context.Modelos.ToList();
            var combustibles = _context.Combustibles.ToList();

            var viewModel = new VehiculoViewModel()
            {
                Clientes = clientes,
                Aseguradoras = aseguradoras,
                Modelos = modelos,
                Combustibles = combustibles
            };

            return View("VehiculoFormulario", viewModel);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarVehiculo(Vehiculo vehiculo)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new VehiculoViewModel(vehiculo)
                {
                    Clientes = _context.Clientes.ToList(),
                    Aseguradoras = _context.Aseguradoras.ToList(),
                    Modelos = _context.Modelos.ToList(),
                    Combustibles = _context.Combustibles.ToList()
                };

                return View("VehiculoFormulario", viewModel);
            }

            if (vehiculo.Id == 0)
            {
                vehiculo.FechaDeIngreso = DateTime.Now;
                _context.Vehiculos.Add(vehiculo);
            }
            else
            {
                var vehiculosBD = _context.Vehiculos.Single(c => c.Id == vehiculo.Id);
                Mapper.Map<Vehiculo, Vehiculo>(vehiculo, vehiculosBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult EditarVehiculo(int id)
        {
            var vehiculo = _context.Vehiculos.SingleOrDefault(c => c.Id == id);

            if (vehiculo == null)
                return HttpNotFound();

            var viewModel = new VehiculoViewModel(vehiculo)
            {
                Clientes = _context.Clientes.ToList(),
                Aseguradoras = _context.Aseguradoras.ToList(),
                Modelos = _context.Modelos.ToList(),
                Combustibles = _context.Combustibles.ToList()
            };

            return View("VehiculoFormulario", viewModel);
        }
    }
}