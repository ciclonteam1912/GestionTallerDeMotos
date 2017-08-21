using GestionTallerDeMotos.Models;
using System.Linq;
using System.Web.Http;

namespace GestionTallerDeMotos.Controllers.APIs
{
    public class EstadosController : ApiController
    {
        private ApplicationDbContext _context;

        public EstadosController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult ObtenerEstados()
        {
            var estados = _context.Estados.ToList();

            return Ok(estados);
        }
    }
}
