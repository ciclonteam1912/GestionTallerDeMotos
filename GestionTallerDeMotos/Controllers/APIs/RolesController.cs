using GestionTallerDeMotos.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace GestionTallerDeMotos.Controllers.APIs
{
    public class RolesController : ApiController
    {
        private ApplicationDbContext _context;

        public RolesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerRoles()
        {
            var roles = _context.Roles.ToList();

            return Ok(roles);
        }

        [HttpDelete]
        public IHttpActionResult EliminarRol(string id)
        {
            var rol = _context.Roles.Where(r => r.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            _context.Roles.Remove(rol);
            _context.SaveChanges();

            return Ok();
        }
    }
}
