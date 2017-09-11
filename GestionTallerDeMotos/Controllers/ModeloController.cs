using AutoMapper;
using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.AtributosDeAutorizacion;
using GestionTallerDeMotos.Models.ModelosDeDominio;
using GestionTallerDeMotos.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace GestionTallerDeMotos.Controllers
{
    public class ModeloController : Controller
    {
        private ApplicationDbContext _context;

        public ModeloController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Modelo
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Administrador) || User.IsInRole(RoleName.JefeDeTaller))
                return View("ListaDeModelos");

            return View("ListaDeModelosSoloLectura");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult NuevoModelo()
        {
            var marcas = _context.Marcas.ToList();

            var viewModel = new ModeloViewModel
            {
                Marcas = marcas
            };

            return View("ModeloFormulario", viewModel);
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarModelo(Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ModeloViewModel(modelo)
                {
                    Marcas = _context.Marcas.ToList()
                };

                return View("ModeloFormulario", viewModel);
            }

            if (modelo.Id == 0)
                _context.Modelos.Add(modelo);
            else
            {
                var modeloBD = _context.Modelos.Single(m => m.Id == modelo.Id);
                Mapper.Map<Modelo, Modelo>(modelo, modeloBD);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult EditarModelo(int id)
        {
            var modeloBD = _context.Modelos.SingleOrDefault(c => c.Id == id);

            if (modeloBD == null)
                return HttpNotFound();

            var modelo = new ModeloViewModel(modeloBD)
            {
                Marcas = _context.Marcas.ToList()
            };

            return View("ModeloFormulario", modelo);
        }
    }
}