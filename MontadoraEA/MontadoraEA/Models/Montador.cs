using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MontadoraEA.Models
{
    public class Montador: Pessoa
    {
        [Display(Name = "Salário")]        
        public decimal Salario { get; set; }
    }
}