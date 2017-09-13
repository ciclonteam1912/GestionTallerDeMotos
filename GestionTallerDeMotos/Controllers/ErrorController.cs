using System.Web.Mvc;

namespace GestionTallerDeMotos.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult AccesoDenegado()
        {
            return View();
        }
    }
}