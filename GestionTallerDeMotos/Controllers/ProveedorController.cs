using AutoMapper;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Linq;
using System.Web.Mvc;

namespace GestionTallerDeMotos.Controllers
{
    public class ProveedorController : Controller
    {
        private ApplicationDbContext _context;

        public ProveedorController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Proveedor
        public ActionResult Index()
        {
            if(User.IsInRole(RoleName.Administrador))
                return View("ListaDeProveedores");

            return View("ListaDeProveedoresSoloLectura");
        }

        [Authorize(Roles = RoleName.Administrador)]
        public ActionResult NuevoProveedor()
        {
            var proveedor = new Proveedor();

            return View("ProveedorFormulario", proveedor);
        }

        [Authorize(Roles = RoleName.Administrador)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarProveedor(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View("ProveedorFormulario", proveedor);

            if (proveedor.Id == 0)
                _context.Proveedores.Add(proveedor);
            else
            {
                var proveedorBD = _context.Proveedores.Single(p => p.Id == proveedor.Id);
                Mapper.Map<Proveedor, Proveedor>(proveedor, proveedorBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = RoleName.Administrador)]
        public ActionResult EditarProveedor(int id)
        {
            var proveedorBD = _context.Proveedores.SingleOrDefault(p => p.Id == id);

            if (proveedorBD == null)
                return HttpNotFound();

            var proveedor = new Proveedor(proveedorBD);

            return View("ProveedorFormulario", proveedor);
        }
    }
}