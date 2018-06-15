using MontadoraEA.Models;
using MontadoraEA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MontadoraEA.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly VeiculoRepository veiculoRepository = new VeiculoRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Novo(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                veiculoRepository.Adicionar(veiculo);

                return View("Index","Veiculo");
            }
            return View(veiculo);
        }
    }
}