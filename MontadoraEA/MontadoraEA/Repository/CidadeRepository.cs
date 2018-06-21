using MontadoraEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MontadoraEA.Repository
{
    public class CidadeRepository
    {
        private readonly Contexto db = new Contexto();

        public void Adicionar(Cidade cidade)
        {
            db.Cidade.Add(cidade);
            db.SaveChanges();  
          
        }

        public IEnumerable<Cidade> ListaCidade()
        {
           return db.Cidade.ToList();
        }

        public Cidade BuscaCidade(int? id)
        {
            
            return db.Cidade.Find(id);
        }
    }
}