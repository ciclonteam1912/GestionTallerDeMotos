﻿using AutoMapper;
using GestionTallerDeMotos.Dtos;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Linq;
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
            _context.Configuration.ProxyCreationEnabled = false;
            var marcas = _context.Marcas.ToList().Select(Mapper.Map<Marca, MarcaDto>);

            return Ok(marcas);
        }

        [Authorize(Roles = RoleName.Administrador)]
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

        [Authorize(Roles = RoleName.Administrador)]
        [HttpDelete]
        public IHttpActionResult EliminarMarca(int id)
        {
            var marca = _context.Marcas.Single(m => m.Id == id);

            _context.Marcas.Remove(marca);
            _context.SaveChanges();

            return Ok();
        }
    }
}
