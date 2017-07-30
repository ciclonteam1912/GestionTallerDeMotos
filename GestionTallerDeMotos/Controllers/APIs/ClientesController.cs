using GestionTallerDeMotos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionTallerDeMotos.Controllers.APIs
{
    public class ClientesController : ApiController
    {
        private ApplicationDbContext _context;

        public ClientesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult ObtenerClientes()
        {
            var clientes = _context.Clientes
                .Include(c => c.Personeria)
                .Include(c => c.TipoDocumento)
                .ToList();

            return Ok(clientes);
        }
    }
}
