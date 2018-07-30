using MontadoraEA.Models;
using MontadoraEA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MontadoraEA.Controllers
{
    public class MontadorController : Controller
    {
        private readonly MontadorRepository montadorRepository = new MontadorRepository();

        public ActionResult Index()
        {
            TempData["ScriptIndexEssentials"] = "";
            return View(montadorRepository.ListaMontador().OrderBy(p => p.Nome));
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Montador montador)
        {
            if (ModelState.IsValid)//valida no lado do servidor
            {
                montadorRepository.Adicionar(montador);
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

            Montador montador = montadorRepository.BuscaMontador(id);

            if (montador == null)
            {
                return HttpNotFound();
            }
            return View(montador);
        }

        public PartialViewResult _TabelaPartial(Montador montador)
        {
            return PartialView(montadorRepository.ListaMontador().OrderBy(p => p.Nome));
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Montador montador = montadorRepository.BuscaMontador(id);

            if (montador == null)
            {
                return HttpNotFound();
            }

            return View(montador);
        }

        [HttpPost]
        public ActionResult Editar(Montador montador)
        {
            if (ModelState.IsValid)
            {                
                montadorRepository.Editar(montador);
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

            Montador montador = montadorRepository.BuscaMontador(id);

            if (montador == null)
            {
                return HttpNotFound();
            }
            return View(montador);
        }

        [HttpPost]
        public ActionResult Excluir(Montador montador)
        {
            montador = montadorRepository.BuscaMontador(montador.Id);
            montadorRepository.Excluir(montador);
            TempData["SuccessMessage"] = "Registro excluido com sucesso.";
            return RedirectToAction("index");
        }

    }

}
