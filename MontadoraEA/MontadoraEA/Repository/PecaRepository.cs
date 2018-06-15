using MontadoraEA.Models;
using System;
using System.Collections.Generic;
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
    }
}