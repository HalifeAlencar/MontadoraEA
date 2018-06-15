using MontadoraEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MontadoraEA.Repository
{
    public class VeiculoRepository
    {
        private readonly Contexto db = new Contexto();

        public void Adicionar(Veiculo veiculo)
        {
            db.Veiculo.Add(veiculo);
            db.SaveChanges();
        }
    }
}