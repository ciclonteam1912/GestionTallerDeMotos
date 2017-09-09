using AutoMapper;
using GestionTallerDeMotos.Dtos;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Linq;
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

        [Authorize(Roles = RoleName.Administrador)]
        [HttpPost]
        public IHttpActionResult CrearCombustible(CombustibleDto combustibleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var combustible = Mapper.Map<CombustibleDto, Combustible>(combustibleDto);

            _context.Combustibles.Add(combustible);
            _context.SaveChanges();

            var resultado = Mapper.Map<Combustible, CombustibleDto>(combustible);

            return Ok(resultado);
        }

        [Authorize(Roles = RoleName.Administrador)]
        [HttpDelete]
        public IHttpActionResult EliminarCombustibles(int id)
        {
            var combustible = _context.Combustibles.Single(p => p.Id == id);
            _context.Combustibles.Remove(combustible);
            _context.SaveChanges();

            return Ok();
        }
    }
}
