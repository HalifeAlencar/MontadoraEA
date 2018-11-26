using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
            TempData["ScriptIndexEssentials"] = "";
            return View(cidadeRepository.ListaCidade().OrderBy(p => p.Nome));
        }

        //[HttpPost] método de pesquisa caso queira implementar algo do tipo
        //public ActionResult Index(FormCollection form)
        //{
        //    string query = form["txtBusca"];

        //    if (!string.IsNullOrWhiteSpace(query))
        //    {
        //        return View(cidadeRepository.Pesquisar(query));
        //    }
        //    else
        //    {
        //        return View(cidadeRepository.ListaCidade());
        //    }
        //}

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
                TempData["SuccessMessage"] = "Cadastro realizado com sucesso.";
                return RedirectToAction("Index");
                //return Json(new { RedirectUrl = Url.Action("Index") });
            }
            else
            {
                return View();
            }
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

        public PartialViewResult _TabelaCidades(Cidade cidade)
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
                TempData["SuccessMessage"] = "Registro editado com sucesso.";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

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
            TempData["SuccessMessage"] = "Registro excluido com sucesso.";
            return RedirectToAction("index");
        }


    }
}
