using MontadoraEA.Models;
using MontadoraEA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Novo(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                fornecedorRepository.Adicionar(fornecedor);
            }
            
            return View(fornecedor);
        }
    }
}