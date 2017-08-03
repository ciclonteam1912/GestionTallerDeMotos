using AutoMapper;
using GestionTallerDeMotos.Dtos;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionTallerDeMotos.Controllers.APIs
{
    public class VehiculosController : ApiController
    {
        private ApplicationDbContext _context;

        public VehiculosController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult ObtenerVehiculos()
        {
            var vehiculos = _context.Vehiculos
                .Include(v => v.Cliente)
                .Include(v => v.Aseguradora)
                .Include(v => v.Modelo)
                .ToList()
                .Select(Mapper.Map<Vehiculo, VehiculoDto>);

            return Ok(vehiculos);
        }

        [HttpPost]
        public IHttpActionResult CrearVehiculo(VehiculoDto vehiculoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehiculo = Mapper.Map<VehiculoDto, Vehiculo>(vehiculoDto);
            vehiculo.FechaDeIngreso = DateTime.Now;
            _context.Vehiculos.Add(vehiculo);
            _context.SaveChanges();

            var resultado = Mapper.Map<Vehiculo, VehiculoDto>(vehiculo);

            return Ok(resultado);
        }
    }
}
