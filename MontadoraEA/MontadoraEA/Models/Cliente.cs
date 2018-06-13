using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MontadoraEA.Models
{
    public class Cliente: Pessoa
    {
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [StringLength(50, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        public string Endereco { get; set; }

        [StringLength(15, ErrorMessage = "O tamanho máximo são 15 caracteres.")]
        [Required]
        public string Numero { get; set; }

        [StringLength(50, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        public string OrgaoExpedidor { get; set; }

        [StringLength(20, ErrorMessage = "O tamanho máximo são 20 caracteres.")]
        [Required]
        public string Rg { get; set; }

        [StringLength(20, ErrorMessage = "O tamanho máximo são 20 caracteres.")]
        [Required]
        public Cidade Cidade { get; set; }

        [Required]
        public ESexo ESexo { get; set; }
    }
}