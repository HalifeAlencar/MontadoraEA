using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MontadoraEA.Models
{
    public class Contexto : DbContext
    {
        public Contexto() : base("MontadoraEA")
        {

        }

        public DbSet<Veiculo> Veiculo { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
        
        public DbSet<PecaDoVeiculo> PecaDoVeiculo { get; set; }

        public DbSet<Peca> Peca { get; set; }

        public DbSet<Montador> Montador { get; set; }

        public DbSet<Fornecedor> Fornecedor { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Cidade> Cidade { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}