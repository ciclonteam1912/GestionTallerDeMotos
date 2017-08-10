using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionTallerDeMotos.Controllers
{
    public class PresupuestoController : Controller
    {
        // GET: Presupuesto
        public ActionResult Index()
        {

            return View("PresupuestoDetalleFormulario");
        }
    }
}