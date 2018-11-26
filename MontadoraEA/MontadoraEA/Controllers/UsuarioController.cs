using MontadoraEA.Models;
using MontadoraEA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MontadoraEA.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepository usuarioRepository = new UsuarioRepository();

        
        public ActionResult CadastroUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroUsuario(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["SuccessMessage"] = "Cadastro realizado com sucesso. Seja bem vindo!";
                    usuarioRepository.Adicionar(usuario);
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                
                return View("CadastroUsuario");
            }
           
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Usuario usuario)
        {
            return View(usuario);
        }
    }
}