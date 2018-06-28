using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MontadoraEA.Models
{
    public class Cidade
    {
        [Key]
        [DisplayName("Código IBGE")]
        public int CidadeId { get; set; }

        [StringLength(50, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        [DisplayName("Cidade")]
        public string Nome { get; set; }

        
        [Required]
        [DisplayName("UF")]
        public Estado Estado { get; set; }
    }
}