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

            return View(cidadeRepository.ListaCidade());
           
        }

        public ActionResult Novo()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                cidadeRepository.Adicionar(cidade);
            }
            
            return View(cidade);
        }

        public PartialViewResult ListaCidades()
        {
            List<Cidade> lista = new List<Cidade>();
            var ordenada = lista.OrderBy(p => p.Nome);
            foreach (var cidade in ordenada)
            {
                ViewBag.cidade = cidade.Nome;
            }
            return PartialView();
         
        }
    }
}