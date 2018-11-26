using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MontadoraEA.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [StringLength(30, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        public string Nome { get; set; }

        [StringLength(30, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        public string Login { get; set; }
                
        [DataType(DataType.Password)]
        [StringLength(12, MinimumLength = 4)]
        [Required(ErrorMessage = "Senha deve ser preenchida")]
        public string Senha { get; set; }

        [DisplayName("Confirmar Senha")]
        [Compare ("Senha",ErrorMessage ="As senhas não correspondem")]
        [Required(ErrorMessage = "Senha deve ser Confirmada")]
        public string ConfirmaSenha { get; set; }
        
    }
}