using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MontadoraEA.Models
{
    public class Pessoa
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(11)]
        [Required]
        [DisplayName("CPF")]
        public string Cpf { get; set; }
        
        [StringLength(50, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        public string Nome { get; set; }
    }
}