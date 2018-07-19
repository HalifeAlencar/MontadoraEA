using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using MontadoraEA.Models;
using MontadoraEA.Repository;

namespace MontadoraEA.Controllers
{
    public class CidadeController : Controller
    {
        private readonly CidadeRepository cidadeRepository = new CidadeRepository();


        public ActionResult Index()
        {
            return View(cidadeRepository.ListaCidade().OrderBy(p => p.Nome));
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string query = form["txtBusca"];

            if (!string.IsNullOrWhiteSpace(query))
            {
                return View(cidadeRepository.Pesquisar(query));
            }
            else
            {
                return View(cidadeRepository.ListaCidade());
            }
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
                cidade.Nome = cidade.Nome.ToUpper();
                cidadeRepository.Adicionar(cidade);
                
                return Redirect("~/Cidade");
            }
            if(ModelState.IsValid == false)
            {
                return View();
            }
            return Redirect("~/Cidade");
        }

        public ActionResult Visualizar(int? id)
        {
            if (id == null)
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

        public PartialViewResult _ListaCidades(Cidade cidade)
        {
            return PartialView(cidadeRepository.ListaCidade().OrderBy(p => p.Nome));
        }

        public PartialViewResult ListarCidadePorEstado(Estado estado)
        {
            return PartialView(cidadeRepository.ListaCidadePorEstado(estado));
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
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

        [HttpPost]
        public ActionResult Editar(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                cidade.Nome = cidade.Nome.ToUpper();
                cidadeRepository.Editar(cidade);

                return RedirectToAction("Visualizar", new { id = cidade.CidadeId });
            }

            return View();
        }

        public ActionResult Excluir(int? id)
        {
            if (id == null)
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

        [HttpPost]
        public ActionResult Excluir(Cidade cidade)
        {
            cidade = cidadeRepository.BuscaCidade(cidade.CidadeId);
            cidadeRepository.Excluir(cidade);
            return RedirectToAction("index");
        }
    }
}
