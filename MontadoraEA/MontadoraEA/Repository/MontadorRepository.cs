using MontadoraEA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MontadoraEA.Repository
{
    public class MontadorRepository
    {
        private readonly Contexto db = new Contexto();

        public void Adicionar(Montador montador)
        {
            db.Montador.Add(montador);
            db.SaveChanges();
        }

        public IEnumerable<Montador> ListaMontador()
        {
            return db.Montador.ToList();
        }

        public Montador BuscaMontador(int? id)
        {

            return db.Montador.Find(id);
        }

        public void Editar(Montador montador)
        {
            db.Entry(montador).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Excluir(Montador montador)
        {
            db.Montador.Remove(montador);
            db.SaveChanges();
        }

    }
}