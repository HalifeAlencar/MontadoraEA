using MontadoraEA.Models;
using System;
using System.Collections.Generic;
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
    }
}