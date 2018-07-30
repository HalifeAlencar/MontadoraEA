using MontadoraEA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MontadoraEA.Repository
{
    public class PecaRepository
    {
        private readonly Contexto db = new Contexto();

        public void Adicionar(Peca peca)
        {
            db.Peca.Add(peca);
            db.SaveChanges();
        }

        public IEnumerable<Peca> ListaPeca()
        {
            return db.Peca.ToList();
        }

        public Peca BuscaPeca(int? id)
        {

            return db.Peca.Find(id);
        }

        public void Editar(Peca peca)
        {
            db.Entry(peca).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Excluir(Peca peca)
        {
            db.Peca.Remove(peca);
            db.SaveChanges();
        }

    }
}