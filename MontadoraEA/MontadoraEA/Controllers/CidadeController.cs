using MontadoraEA.Models;
using MontadoraEA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MontadoraEA.Controllers
{
    public class CidadeController : Controller
    {
        private readonly CidadeRepository cidadeRepository = new CidadeRepository();
        // GET: Cidade
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Novo()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Cidade cidade)
        {
            cidadeRepository.Adicionar(cidade);
            return View(cidade);
        }
    }
}