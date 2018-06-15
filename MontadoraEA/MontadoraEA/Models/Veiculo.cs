using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MontadoraEA.Models
{
    public class Veiculo
    {
        public Veiculo()
        {
            Cliente = new Cliente();
            Usuario = new Usuario();
            Montador = new Montador();
        }
        
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

        
        public Cliente Cliente { get; set; }

        
        public Usuario Usuario { get; set; }

        
        public Montador Montador { get; set; }

        
        public IList<PecaDoVeiculo> PecaDoVeiculos { get; set; }
    }
}