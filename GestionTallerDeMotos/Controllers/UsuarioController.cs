using GestionTallerDeMotos.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GestionTallerDeMotos.Controllers
{
    [Authorize(Roles = RoleName.Administrador)]
    public class UsuarioController : Controller
    {
        private ApplicationDbContext _context;

        public UsuarioController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Usuario
        public ActionResult Index()
        {
            var usuarios = _context.Users.ToList();

            return View("ListaDeUsuarios", usuarios);
        }

    }
}