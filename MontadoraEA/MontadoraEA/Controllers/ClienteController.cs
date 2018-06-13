using MontadoraEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MontadoraEA.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Novo()
        {          

            return View();
        }

        [HttpPost]
        public ActionResult Novo (Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                return View("RevisarCadastro");
            }
            return View(cliente);
        }
    }
}