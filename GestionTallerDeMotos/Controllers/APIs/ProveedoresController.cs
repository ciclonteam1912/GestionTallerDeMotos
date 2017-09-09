using AutoMapper;
using GestionTallerDeMotos.Dtos;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Linq;
using System.Web.Http;

namespace GestionTallerDeMotos.Controllers.APIs
{
    public class ProveedoresController : ApiController
    {
        private ApplicationDbContext _context;

        public ProveedoresController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult ObtenerProveedores()
        {
            var proveedores = _context.Proveedores.ToList().Select(Mapper.Map<Proveedor, ProveedorDto>);

            return Ok(proveedores);
        }

        [Authorize(Roles = RoleName.Administrador)]
        [HttpPost]
        public IHttpActionResult CrearProveedor(ProveedorDto proveedorDto)
        {
            var proveedor = Mapper.Map<ProveedorDto, Proveedor>(proveedorDto);

            _context.Proveedores.Add(proveedor);
            _context.SaveChanges();

            var resultado = Mapper.Map<Proveedor, ProveedorDto>(proveedor);

            return Ok(resultado);
        }

        [Authorize(Roles = RoleName.Administrador)]
        [HttpDelete]
        public IHttpActionResult EliminarProveedor(int id)
        {
            var proveedor = _context.Proveedores.Single(a => a.Id == id);
            _context.Proveedores.Remove(proveedor);
            _context.SaveChanges();

            return Ok();
        }
    }
}
