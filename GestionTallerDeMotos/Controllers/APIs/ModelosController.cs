using AutoMapper;
using GestionTallerDeMotos.Dtos;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Data.Entity;
using System.Linq;
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

        [Authorize(Roles = RoleName.Administrador)]
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

        [Authorize(Roles = RoleName.Administrador)]
        [HttpDelete]
        public IHttpActionResult EliminarModelo(int id)
        {
            var modelo = _context.Modelos.Single(m => m.Id == id);

            _context.Modelos.Remove(modelo);
            _context.SaveChanges();

            return Ok();
        }
    }
}
