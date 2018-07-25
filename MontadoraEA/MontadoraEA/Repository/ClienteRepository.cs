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

        public void Adicionar(Cliente cliente)
        {
            db.Cliente.Add(cliente);
            db.SaveChanges();
        }

        public IList<Cliente> ListaCliente()
        {
            return db.Cliente.Include(x => x.Cidade).ToList();// isso aqui que faz aparecer cidade 
        }

        public Cliente BuscaCliente(int? id)
        {
            return db.Cliente.Find(id);
        }

        public void Editar(Cliente cliente)
        {
            db.Entry(cliente).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Excluir(Cliente cliente)
        {
            db.Cliente.Remove(cliente);
            db.SaveChanges();
        }


    }
}