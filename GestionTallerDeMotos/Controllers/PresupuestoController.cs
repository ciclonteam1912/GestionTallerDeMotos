using GestionTallerDeMotos.Models;
using System.Web.Mvc;

namespace GestionTallerDeMotos.Controllers
{
    public class PresupuestoController : Controller
    {
        // GET: Presupuesto
        [Authorize(Roles = RoleName.Administrador)]
        public ActionResult Index()
        {
            return View("PresupuestoDetalleFormulario");
        }
    }
}