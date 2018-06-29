using MontadoraEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

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

        public IList<Cliente> ListaCliente()
        {            
            return db.Cliente.Include(x => x.Cidade).ToList();
        }
    }
}