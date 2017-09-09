using AutoMapper;
using GestionTallerDeMotos.Dtos;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Linq;
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

        [Authorize(Roles = RoleName.Administrador)]
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

        [Authorize(Roles = RoleName.Administrador)]
        [HttpDelete]
        public IHttpActionResult EliminarAseguradora(int id)
        {
            var aseguradora = _context.Aseguradoras.Single(a => a.Id == id);
            _context.Aseguradoras.Remove(aseguradora);
            _context.SaveChanges();

            return Ok();
        }
    }
}
