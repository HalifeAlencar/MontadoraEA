using MontadoraEA.Models;
using MontadoraEA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MontadoraEA.Controllers
{
    public class PecaController : Controller
    {
        private readonly PecaRepository pecaRepository = new PecaRepository();
        // GET: Peca
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Peca peca)
        {
            if (ModelState.IsValid)
            {
                pecaRepository.Adicionar(peca);
                return View("Index", "Peca");
                
            }
            return View(peca);
        }
    }
}