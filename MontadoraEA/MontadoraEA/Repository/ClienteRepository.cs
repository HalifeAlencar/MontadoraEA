using MontadoraEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MontadoraEA.Repository
{
    public class ClienteRepository
    {
        private readonly Contexto db = new Contexto();

        public void Adicionar (Cliente cliente)
        {
            db.Cliente.Add(cliente);
            db.SaveChanges();
        }
    }
}