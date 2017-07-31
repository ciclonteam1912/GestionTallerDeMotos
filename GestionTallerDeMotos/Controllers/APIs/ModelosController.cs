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
    public class ModelosController : ApiController
    {
        private ApplicationDbContext _context;

        public ModelosController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult ObtenerModelos()
        {
            var modelos = _context.Modelos.Include(m => m.Marca).ToList().Select(Mapper.Map<Modelo, ModeloDto>);

            return Ok(modelos);
        }

        [HttpPost]
        public IHttpActionResult CrearModelo(ModeloDto modeloDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var modelo = Mapper.Map<ModeloDto, Modelo>(modeloDto);

            _context.Modelos.Add(modelo);
            _context.SaveChanges();

            modelo = _context.Modelos.Find(modelo.Id);

            var resultado = Mapper.Map<Modelo, ModeloDto>(modelo);
            return Ok(resultado);
        }
    }
}
