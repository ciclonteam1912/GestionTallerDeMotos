using AutoMapper;
using GestionTallerDeMotos.Dtos;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionTallerDeMotos.Controllers.APIs
{
    public class AseguradorasController : ApiController
    {
        private ApplicationDbContext _context;

        public AseguradorasController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult ObtenerAseguradoras()
        {
            var aseguradoras = _context.Aseguradoras
                .ToList()
                .Select(Mapper.Map<Aseguradora, AseguradoraDto>);

            return Ok(aseguradoras);
        }

        [HttpPost]
        public IHttpActionResult CrearAseguradora(AseguradoraDto aseguradoraDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var aseguradora = Mapper.Map<AseguradoraDto, Aseguradora>(aseguradoraDto);

            _context.Aseguradoras.Add(aseguradora);
            _context.SaveChanges();

            var resultado = Mapper.Map<Aseguradora, AseguradoraDto>(aseguradora);

            return Ok(resultado);
        }
    }
}
