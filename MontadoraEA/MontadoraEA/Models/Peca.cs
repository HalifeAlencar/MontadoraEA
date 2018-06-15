using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MontadoraEA.Models
{
    public class Peca
    {
        public Peca()
        {
            Fornecedor = new Fornecedor();
        }

        [Key]
        public int PecaId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFabricacao { get; set; }

        [StringLength(50, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        public string Descricao { get; set; }

        [StringLength(30, ErrorMessage = "O tamanho máximo são 30 caracteres.")]
        [Required]
        public string NumeroSerie { get; set; }        

        [Required]
        public decimal Valor { get; set; }
                
        public Fornecedor Fornecedor { get; set; }
    }
}