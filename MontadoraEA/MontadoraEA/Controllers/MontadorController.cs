using MontadoraEA.Models;
using MontadoraEA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MontadoraEA.Controllers
{
    public class MontadorController : Controller
    {
        private readonly MontadorRepository montadorRepository = new MontadorRepository();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Montador montador)
        {
            if (ModelState.IsValid)
            {
                montadorRepository.Adicionar(montador);
                return View("Index");
            }
            
            return View(montador);
        }
    }
}