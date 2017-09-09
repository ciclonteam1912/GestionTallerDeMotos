using AutoMapper;
using GestionTallerDeMotos.Dtos;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Linq;
using System.Web.Http;

namespace GestionTallerDeMotos.Controllers.APIs
{
    public class FormaPagosController : ApiController
    {
        private ApplicationDbContext _context;

        public FormaPagosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerFormasDePago()
        {
            var formasDePago = _context.FormaPagos
                .ToList()
                .Select(Mapper.Map<FormaPago, FormaPagoDto>);

            return Ok(formasDePago);
        }

        [Authorize(Roles = RoleName.Administrador)]
        [HttpPost]
        public IHttpActionResult CrearFormasDePago(FormaPagoDto formasDePagoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var formasDePago = Mapper.Map<FormaPagoDto, FormaPago>(formasDePagoDto);

            _context.FormaPagos.Add(formasDePago);
            _context.SaveChanges();

            var resultado = Mapper.Map<FormaPago, FormaPagoDto>(formasDePago);

            return Ok(resultado);
        }

        [Authorize(Roles = RoleName.Administrador)]
        [HttpDelete]
        public IHttpActionResult EliminarFormasDePago(int id)
        {
            var formaDePago = _context.FormaPagos.Single(fp => fp.Id == id);

            _context.FormaPagos.Remove(formaDePago);
            _context.SaveChanges();

            return Ok();
        }
    }
}
