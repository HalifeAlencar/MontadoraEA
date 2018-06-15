using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MontadoraEA.Models
{
    public class PecaDoVeiculo
    {        
        public PecaDoVeiculo()
        {
            Peca = new Peca();
            Veiculo = new Veiculo();
        }

        [Key]
        public int PecaDoVeiculoId { get; set; }

        
        public decimal Desconto { get; set; }        


        public int Quantidade { get; set; }

        
        public Peca Peca { get; set; }

        
        public Veiculo Veiculo { get; set; }
        
    }
}