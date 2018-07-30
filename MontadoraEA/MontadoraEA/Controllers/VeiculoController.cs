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
    public class VeiculoController : Controller
    {
        private readonly VeiculoRepository veiculoRepository = new VeiculoRepository();

        public ActionResult Index()
        {
            TempData["ScriptIndexEssentials"] = "";
            return View(veiculoRepository.ListaVeiculo().OrderBy(p => p.Modelo));
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Veiculo veiculo)
        {
            if (ModelState.IsValid)//valida no lado do servidor
            {                
                veiculoRepository.Adicionar(veiculo);
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

            Veiculo veiculo = veiculoRepository.BuscaVeiculo(id);

            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        public PartialViewResult _TabelaVeiculos(Veiculo veiculo)
        {
            return PartialView(veiculoRepository.ListaVeiculo().OrderBy(p => p.Modelo));
        }       

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Veiculo veiculo = veiculoRepository.BuscaVeiculo(id);

            if (veiculo == null)
            {
                return HttpNotFound();
            }

            return View(veiculo);
        }

        [HttpPost]
        public ActionResult Editar(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {                
                veiculoRepository.Editar(veiculo);
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

            Veiculo veiculo = veiculoRepository.BuscaVeiculo(id);

            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        [HttpPost]
        public ActionResult Excluir(Veiculo veiculo)
        {
            veiculo = veiculoRepository.BuscaVeiculo(veiculo.VeiculoId);
            veiculoRepository.Excluir(veiculo);
            TempData["SuccessMessage"] = "Registro excluido com sucesso.";
            return RedirectToAction("index");
        }
    }

}