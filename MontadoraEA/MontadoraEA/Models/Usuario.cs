using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MontadoraEA.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [StringLength(50, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        public string Nome { get; set; }

        [StringLength(50, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(06, MinimumLength = 4)]
        [Display(Name = "Password")]
        public string Senha { get; set; }

        [Compare ("Senha",ErrorMessage ="As senhas não correspondem")]
        [Required(ErrorMessage = "Senha deve ser preenchida")]
        public string ConfirmaSenha { get; set; }
        
    }
}