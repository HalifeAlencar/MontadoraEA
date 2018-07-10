using MontadoraEA.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IList<Cidade> ListaCidadePorEstado(Estado estado)
        {
            return db.Cidade.Where(e => e.Estado == estado).ToList();
        }

        public void Editar(Cidade cidade)
        {
            db.Entry(cidade).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Excluir (Cidade cidade)
        {
            db.Cidade.Remove(cidade);
            db.SaveChanges();
        }
        
        public IEnumerable<Cidade> Pesquisar(string texto)
        {
            return db.Cidade.Where(x => x.Nome.Contains(texto)).OrderBy(x => x.Nome);
        }
    }
}