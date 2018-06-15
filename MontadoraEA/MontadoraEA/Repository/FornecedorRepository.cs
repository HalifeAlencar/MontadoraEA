using MontadoraEA.Models;
using System;
using System.Collections.Generic;
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
    }
}