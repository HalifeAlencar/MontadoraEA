using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MontadoraEA.Models
{
    public class PecaDoVeiculo
    {
        [Key]
        public int PecaDoVeiculoId { get; set; }

        
        public decimal Desconto { get; set; }        


        public int Quantidade { get; set; }

        [Required]
        public Peca Peca { get; set; }

        [Required]
        public Veiculo Veiculo { get; set; }

        public PecaDoVeiculo(Veiculo veiculo) //composição exemplo de implantação
        {
            Veiculo = veiculo;
        }
    }
}