using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [DataType(DataType.Date)]
        [DisplayName("Data de Fabricação")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFabricacao { get; set; }

        [DisplayName("Descrição")]
        [StringLength(50, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        public string Descricao { get; set; }

        [DisplayName("Número de Série")]
        [StringLength(30, ErrorMessage = "O tamanho máximo são 30 caracteres.")]
        [Required]
        public string NumeroSerie { get; set; }        

        [Required]
        public decimal Valor { get; set; }


        public int FornecedorId { get; set; }

        [ForeignKey("FornecedorId")]
        public virtual Fornecedor Fornecedor { get; set; }
    }
}