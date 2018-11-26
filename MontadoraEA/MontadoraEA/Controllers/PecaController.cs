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
    public class PecaController : Controller
    {
        private readonly PecaRepository pecaRepository = new PecaRepository();
        private readonly FornecedorRepository fornecedorRepository = new FornecedorRepository();

        public ActionResult Index()
        {
            
            TempData["ScriptIndexEssentials"] = "";
            return View(pecaRepository.ListaPeca().OrderBy(p => p.Descricao));
        }

        public ActionResult Novo()
        {
            ViewBag.fornecedores = new SelectList(fornecedorRepository.ListaFornecedor(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Peca peca)
        {
            if (ModelState.IsValid)
            {
                pecaRepository.Adicionar(peca);
                TempData["SuccessMessage"] = "Cadastro realizado com sucesso.";
                return RedirectToAction("Index");
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

            Peca peca = pecaRepository.BuscaPeca(id);

            if (peca == null)
            {
                return HttpNotFound();
            }
            return View(peca);
        }

        public PartialViewResult _TabelaPartial(Peca peca)
        {
            return PartialView(pecaRepository.ListaPeca().OrderBy(p => p.Descricao));
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Peca peca = pecaRepository.BuscaPeca(id);

            if (peca == null)
            {
                return HttpNotFound();
            }

            return View(peca);
        }

        [HttpPost]
        public ActionResult Editar(Peca peca)
        {
            if (ModelState.IsValid)
            {                
                pecaRepository.Editar(peca);
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

            Peca peca = pecaRepository.BuscaPeca(id);

            if (peca == null)
            {
                return HttpNotFound();
            }
            return View(peca);
        }

        [HttpPost]
        public ActionResult Excluir(Peca peca)
        {
            peca = pecaRepository.BuscaPeca(peca.PecaId);
            pecaRepository.Excluir(peca);
            TempData["SuccessMessage"] = "Registro excluido com sucesso.";
            return RedirectToAction("index");
        }


    }
}