using GestionTallerDeMotos.Models;
using GestionTallerDeMotos.Models.AtributosDeAutorizacion;
using System.Web.Mvc;

namespace GestionTallerDeMotos.Controllers
{
    public class PresupuestoController : Controller
    {
        // GET: Presupuesto
        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller)]
        public ActionResult Index()
        {
            return View("PresupuestoDetalleFormulario");
        }
    }
}