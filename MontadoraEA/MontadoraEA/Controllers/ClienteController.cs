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
        // GET: Cliente
        public ActionResult Index()
        {
            return View(clienteRepository.ListaCliente());
        }

        public ActionResult Novo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Novo(Cliente cliente)
        {

            if (ModelState.IsValid)//valida no lado do servidor
            {
                clienteRepository.Adicionar(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
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

        public PartialViewResult _ListaClientes(Cliente cliente)
        {
            return PartialView(clienteRepository.ListaCliente().OrderBy(p => p.Nome));
        }               
    }
}