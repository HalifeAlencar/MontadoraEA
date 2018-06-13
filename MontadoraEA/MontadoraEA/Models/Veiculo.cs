using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MontadoraEA.Models
{
    public class Veiculo
    {
        [Key]
        [Required]
        public int VeiculoId { get; set; }

        
        [StringLength(50, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        public string Categoria { get; set; }

        
        [StringLength(50, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        public string Marca { get; set; }

        [StringLength(50, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        public string Modelo { get; set; }

        [StringLength(50, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        public Cliente Cliente { get; set; }

        [StringLength(50, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        public Usuario Usuario { get; set; }

        [StringLength(50, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        public Montador Montador { get; set; }

        [Required]
        public IList<PecaDoVeiculo> PecaDoVeiculos { get; set; }
    }
}