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
    public class MarcasController : ApiController
    {
        private ApplicationDbContext _context;

        public MarcasController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult ObtenerMarcas()
        {
            var marcas = _context.Marcas.ToList().Select(Mapper.Map<Marca, MarcaDto>);

            return Ok(marcas);
        }

        [HttpPost]
        public IHttpActionResult CrearMarca(MarcaDto marcaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var marca = Mapper.Map<MarcaDto, Marca>(marcaDto);

            _context.Marcas.Add(marca);
            _context.SaveChanges();


            marca = _context.Marcas.Find(marca.Id);

            var resultado = Mapper.Map<Marca, MarcaDto>(marca);

            return Ok(resultado);
        }
    }
}
