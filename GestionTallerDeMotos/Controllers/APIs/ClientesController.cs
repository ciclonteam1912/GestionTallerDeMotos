using AutoMapper;
using GestionTallerDeMotos.Dtos;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Data.Entity;
using System.Linq;
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
                .ToList()
                .Select(Mapper.Map<Cliente, ClienteDto>);

            return Ok(clientes);
        }

        [HttpDelete]
        public IHttpActionResult EliminarCliente(int id)
        {
            var cliente = _context.Clientes.Single(c => c.Id == id);
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return Ok();
        }
    }
}
