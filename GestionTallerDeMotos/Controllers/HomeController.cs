using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionTallerDeMotos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Taller()
        {
            return View();
        }

        public ActionResult Ventas()
        {
            return View();
        }

        public ActionResult Compras()
        {
            return View();
        }

        public ActionResult Stock()
        {
            return View();
        }
    }
}