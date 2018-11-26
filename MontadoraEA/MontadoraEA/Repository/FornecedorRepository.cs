using MontadoraEA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MontadoraEA.Repository
{
    public class FornecedorRepository
    {
        private readonly Contexto db = new Contexto();
        
        public void Adicionar (Fornecedor fornecedor)
        {
            db.Fornecedor.Add(fornecedor);
            db.SaveChanges();
        }

        public IEnumerable<Fornecedor> ListaFornecedor()
        {
            return db.Fornecedor.ToList();
        }

        public Fornecedor BuscaFornecedor(int? id)
        {

            return db.Fornecedor.Find(id);
        }        

        public void Editar(Fornecedor fornecedor)
        {
            db.Entry(fornecedor).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Excluir(Fornecedor fornecedor)
        {
            db.Fornecedor.Remove(fornecedor);
            db.SaveChanges();
        }

    }
}