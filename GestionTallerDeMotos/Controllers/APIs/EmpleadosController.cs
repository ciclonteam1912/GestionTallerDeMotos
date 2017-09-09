using AutoMapper;
using GestionTallerDeMotos.Dtos;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System;
using System.Linq;
using System.Web.Http;

namespace GestionTallerDeMotos.Controllers.APIs
{
    public class EmpleadosController : ApiController
    {
        private ApplicationDbContext _context;

        public EmpleadosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerEmpleados()
        {
            var empleados = _context.Empleados
                .ToList()
                .Select(Mapper.Map<Empleado, EmpleadoDto>);

            return Ok(empleados);
        }

        [Authorize(Roles = RoleName.Administrador)]
        [HttpPost]
        public IHttpActionResult CrearEmpleado(EmpleadoDto empleadoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var empleado = Mapper.Map<EmpleadoDto, Empleado>(empleadoDto);
            empleado.FechaDeIngreso = DateTime.Now;

            _context.Empleados.Add(empleado);
            _context.SaveChanges();

            var resultado = Mapper.Map<Empleado, EmpleadoDto>(empleado);

            return Ok(resultado);
        }

        [Authorize(Roles = RoleName.Administrador)]
        [HttpDelete]
        public IHttpActionResult EliminarEmpleado(int id)
        {
            var empleado = _context.Empleados.Single(e => e.Id == id);

            _context.Empleados.Remove(empleado);
            _context.SaveChanges();

            return Ok();
        }
    }
}
