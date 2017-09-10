using GestionTallerDeMotos.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace GestionTallerDeMotos.Controllers.APIs
{
    public class UsuariosController : ApiController
    {
        private ApplicationDbContext _context;

        public UsuariosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerUsuarios()
        {
            var usuarios = _context.Users.ToList();

            return Ok(usuarios);
        }

        [HttpDelete]
        public IHttpActionResult EliminarUsuario(string id)
        {
            var usuario = _context.Users.Where(r => r.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            _context.Users.Remove(usuario);
            _context.SaveChanges();

            return Ok();
        }
    }
}
