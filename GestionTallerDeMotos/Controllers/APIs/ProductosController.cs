using AutoMapper;
using GestionTallerDeMotos.Dtos;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace GestionTallerDeMotos.Controllers.APIs
{
    public class ProductosController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductosController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public async Task<IHttpActionResult> ObtenerProductos()
        {
            return await Task.Run(() =>
            {
                var productos = _context.Productos
                .ToList()
                .Select(Mapper.Map<Producto, ProductoDto>);

                return Ok(productos);
            });            
        }

        [HttpPost]
        public IHttpActionResult CrearProducto(ProductoDto productoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var producto = Mapper.Map<ProductoDto, Producto>(productoDto);

            _context.Productos.Add(producto);
            _context.SaveChanges();

            var resultado = Mapper.Map<Producto, ProductoDto>(producto);

            return Ok(resultado);
        }
    }
}
