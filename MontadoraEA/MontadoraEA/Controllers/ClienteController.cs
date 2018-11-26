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
    public class ClienteController : Controller
    {
        private readonly ClienteRepository clienteRepository = new ClienteRepository();
        //private readonly CidadeRepository cidadeRepository = new CidadeRepository();
        // GET: Cliente
        public ActionResult Index()
        {
            TempData["ScriptIndexEssentials"] = "";
            return View(clienteRepository.ListaCliente());
        }

        public ActionResult Novo()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Cliente cliente)
        {
            

            if (ModelState.IsValid)
            {
                
                //cidade = cidadeRepository.BuscaCidade(cidade.CidadeId);
                //cliente.Cidade.CidadeId = cidade.CidadeId;             

                clienteRepository.Adicionar(cliente);
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

            Cliente cliente = clienteRepository.BuscaCliente(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        public PartialViewResult _TabelaClientes(Cliente cliente)
        {
            return PartialView(clienteRepository.ListaCliente().OrderBy(p => p.Nome));
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cliente cliente = clienteRepository.BuscaCliente(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteRepository.Editar(cliente);
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

            Cliente cliente = clienteRepository.BuscaCliente(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Excluir(Cliente cliente)
        {
            cliente = clienteRepository.BuscaCliente(cliente.Id);
            clienteRepository.Excluir(cliente);
            TempData["SuccessMessage"] = "Registro excluido com sucesso.";
            return RedirectToAction("index");
        }
    }
}