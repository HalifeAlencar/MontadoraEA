using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MontadoraEA.Controllers
{
    public class MontadorController : Controller
    {
        // GET: Montador
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }
    }
}