using AutoMapper;
using GestionTallerDeMotos.Dtos;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Web.Http;

namespace GestionTallerDeMotos.Controllers.APIs
{
    public class PresupuestosController : ApiController
    {
        private ApplicationDbContext _context;

        public PresupuestosController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CrearPresupuesto(NuevoPresupuestoDto nuevoPresupuestoDto)
        {
            var presupuestoDto = new PresupuestoDto
            {
                FechaEmision = nuevoPresupuestoDto.Presupuesto.FechaEmision,
                VehiculoId = nuevoPresupuestoDto.Presupuesto.VehiculoId,
                PresupuestoAceptado = nuevoPresupuestoDto.Presupuesto.PresupuestoAceptado
            };

            var presupuesto = Mapper.Map<PresupuestoDto, Presupuesto>(presupuestoDto);
            _context.Presupuestos.Add(presupuesto);

            foreach (var detalle in nuevoPresupuestoDto.PresupuestoDetalles)
            {
                var presupuestoDetalleDto = new PresupuestoDetalleDto
                {
                    ProductoId = detalle.ProductoId,
                    Precio = detalle.Precio,
                    Cantidad = detalle.Cantidad,
                    Iva = detalle.Iva,
                    SubTotal = detalle.SubTotal
                };

                var presupuestoDetalle = Mapper.Map<PresupuestoDetalleDto, PresupuestoDetalle>(presupuestoDetalleDto);
                _context.PresupuestoDetalles.Add(presupuestoDetalle);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
