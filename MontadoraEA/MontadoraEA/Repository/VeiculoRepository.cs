using MontadoraEA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IEnumerable<Veiculo> ListaVeiculo()
        {
            return db.Veiculo.ToList();
        }

        public Veiculo BuscaVeiculo(int? id)
        {

            return db.Veiculo.Find(id);
        }        

        public void Editar(Veiculo veiculo)
        {
            db.Entry(veiculo).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Excluir(Veiculo veiculo)
        {
            db.Veiculo.Remove(veiculo);
            db.SaveChanges();
        }

    }
}