using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MontadoraEA.Models;
using MontadoraEA.Repository;

namespace MontadoraEA.Controllers
{
    public class CidadeController : Controller
    {
        private readonly CidadeRepository cidadeRepository = new CidadeRepository();

        
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
            if (ModelState.IsValid)//valida no lado do servidor
            {
                cidadeRepository.Adicionar(cidade);
            }

            return View(cidade);
        }

        public ActionResult Detalhar(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cidade cidade = cidadeRepository.BuscaCidade(id);

            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }






    }
}
