using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MontadoraEA.Models
{
    public class Fornecedor: Pessoa
    {
        [StringLength(30, ErrorMessage = "O tamanho máximo são 30 caracteres.")]
        [Required]
        public string Endereco { get; set; }

        
    }
}