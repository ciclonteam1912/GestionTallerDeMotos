﻿using AutoMapper;
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
    public class CombustiblesController : ApiController
    {
        private ApplicationDbContext _context;

        public CombustiblesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult ObtenerCombustibles()
        {
            var combustibles = _context.Combustibles.ToList().Select(Mapper.Map<Combustible, CombustibleDto>);

            return Ok(combustibles);
        }

        [HttpPost]
        public IHttpActionResult CrearCombustible(CombustibleDto combustibleDto)
        {
            var combustible = Mapper.Map<CombustibleDto, Combustible>(combustibleDto);

            _context.Combustibles.Add(combustible);
            _context.SaveChanges();

            var resultado = Mapper.Map<Combustible, CombustibleDto>(combustible);

            return Ok(resultado);
        }
    }
}
