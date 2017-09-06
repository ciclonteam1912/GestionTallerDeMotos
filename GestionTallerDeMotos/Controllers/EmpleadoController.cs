using AutoMapper;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using GestionTallerDeMotos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionTallerDeMotos.Controllers
{
    public class EmpleadoController : Controller
    {
        private ApplicationDbContext _context;

        public EmpleadoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Empleado
        public ActionResult Index()
        {
            return View("ListaDeEmpleados");
        }

        public ActionResult NuevoEmpleado()
        {
            var cargos = _context.Cargos.ToList();

            var viewModel = new EmpleadoViewModel()
            {
                Cargos = cargos
            };

            return View("EmpleadoFormulario", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarEmpleado(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EmpleadoViewModel(empleado)
                {
                    Cargos = _context.Cargos.ToList()
                };

                return View("EmpleadoFormulario", viewModel);
            }

            if (empleado.Id == 0)
            {
                empleado.FechaDeIngreso = DateTime.Now;
                _context.Empleados.Add(empleado);
            }
            else
            {
                var empleadoBD = _context.Empleados.Single(c => c.Id == empleado.Id);
                Mapper.Map<Empleado, Empleado>(empleado, empleadoBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult EditarEmpleado(int id)
        {
            var empleado = _context.Empleados.SingleOrDefault(c => c.Id == id);

            if (empleado == null)
                return HttpNotFound();

            var viewModel = new EmpleadoViewModel(empleado)
            {
                Cargos = _context.Cargos.ToList()
            };

            return View("EmpleadoFormulario", viewModel);
        }
    }
}