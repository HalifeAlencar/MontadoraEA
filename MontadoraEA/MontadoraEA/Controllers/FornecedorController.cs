using MontadoraEA.Models;
using MontadoraEA.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MontadoraEA.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly FornecedorRepository fornecedorRepository = new FornecedorRepository();
        // GET: Fornecedor
        public ActionResult Index()
        {
            TempData["ScriptIndexEssentials"] = "";
            return View(fornecedorRepository.ListaFornecedor().OrderBy(p => p.Nome));
        }

        public ActionResult Novo()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)//valida no lado do servidor
            {                
                fornecedorRepository.Adicionar(fornecedor);
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

            Fornecedor fornecedor = fornecedorRepository.BuscaFornecedor(id);

            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        public PartialViewResult _TabelaPartial(Fornecedor fornecedor)
        {
            return PartialView(fornecedorRepository.ListaFornecedor().OrderBy(p => p.Nome));
        }        

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Fornecedor fornecedor = fornecedorRepository.BuscaFornecedor(id);

            if (fornecedor == null)
            {
                return HttpNotFound();
            }

            return View(fornecedor);
        }

        [HttpPost]
        public ActionResult Editar(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {                
                fornecedorRepository.Editar(fornecedor);
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

            Fornecedor fornecedor = fornecedorRepository.BuscaFornecedor(id);

            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        [HttpPost]
        public ActionResult Excluir(Fornecedor fornecedor)
        {
            fornecedor = fornecedorRepository.BuscaFornecedor(fornecedor.Id);
            fornecedorRepository.Excluir(fornecedor);
            TempData["SuccessMessage"] = "Registro excluido com sucesso.";
            return RedirectToAction("index");
        }        

        //public PartialViewResult _PartialSelect()
        //{
        //    ViewBag.fornecedores = new SelectList(fornecedorRepository.ListaFornecedor(), "Id", "Nome");
        //    return ();
        //}
    }
}