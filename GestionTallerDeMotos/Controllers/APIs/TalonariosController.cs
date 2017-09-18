using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Linq;
using System.Web.Http;

namespace GestionTallerDeMotos.Controllers.APIs
{
    public class TalonariosController : ApiController
    {
        private ApplicationDbContext _context;

        public TalonariosController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpGet]
        public IHttpActionResult ObtenerTalonarios()
        {
            var talonarios = _context.Talonarios.ToList();
            return Ok(talonarios);
        }
        [HttpPost]
        public IHttpActionResult CrearTalonario(Talonario talonario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _context.Talonarios.Add(talonario);
            _context.SaveChanges();
            return Ok(talonario);
        }

        [HttpDelete]
        public IHttpActionResult EliminarTalonario(int id)
        {
            var talonario = _context.Talonarios.Single(t => t.Id == id);

            _context.Talonarios.Remove(talonario);
            _context.SaveChanges();

            return Ok();
        }
    }
}
