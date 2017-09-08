using AutoMapper;
using GestionTallerDeMotos.Dtos;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Linq;
using System.Web.Http;

namespace GestionTallerDeMotos.Controllers.APIs
{
    public class ServiciosBasicosController : ApiController
    {
        private ApplicationDbContext _context;

        public ServiciosBasicosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerServiciosBasicos()
        {
            var serviciosBasicos = _context.ServiciosBasicos
                .ToList()
                .Select(Mapper.Map<ServicioBasico, ServicioBasicoDto>);

            return Ok(serviciosBasicos);
        }

        [HttpPost]
        public IHttpActionResult CrearServicioBasico(ServicioBasicoDto servicioBasicoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var servicioBasico = Mapper.Map<ServicioBasicoDto, ServicioBasico>(servicioBasicoDto);

            _context.ServiciosBasicos.Add(servicioBasico);
            _context.SaveChanges();

            var resultado = Mapper.Map<ServicioBasico, ServicioBasicoDto>(servicioBasico);

            return Ok(resultado);
        }

        [HttpDelete]
        public IHttpActionResult EliminarServicioBasico(int id)
        {
            var servicioBasico = _context.ServiciosBasicos.Single(sb => sb.Id == id);

            _context.ServiciosBasicos.Remove(servicioBasico);
            _context.SaveChanges();

            return Ok();
        }
    }
}
