using AutoMapper;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.AtributosDeAutorizacion;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Linq;
using System.Web.Mvc;

namespace GestionTallerDeMotos.Controllers
{
    public class AseguradoraController : Controller
    {
        private ApplicationDbContext _context;

        public AseguradoraController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Aseguradora
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Administrador) || User.IsInRole(RoleName.JefeDeTaller))
                return View("ListaDeAseguradoras");

            return View("ListaDeAseguradorasSoloLectura");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult NuevaAseguradora()
        {
            var aseguradora = new Aseguradora();

            return View("AseguradoraFormulario", aseguradora);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarAseguradora(Aseguradora aseguradora)
        {
            if (!ModelState.IsValid)
                return View("AseguradoraFormulario", aseguradora);

            if (aseguradora.Id == 0)
                _context.Aseguradoras.Add(aseguradora);
            else
            {
                var aseguradoraBD = _context.Aseguradoras.Single(a => a.Id == aseguradora.Id);
                Mapper.Map<Aseguradora, Aseguradora>(aseguradora, aseguradoraBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult EditarAseguradora(int id)
        {
            var aseguradoraBD = _context.Aseguradoras.SingleOrDefault(c => c.Id == id);

            if (aseguradoraBD == null)
                return HttpNotFound();

            var aseguradora = new Aseguradora(aseguradoraBD);

            return View("AseguradoraFormulario", aseguradora);
        }
    }
}