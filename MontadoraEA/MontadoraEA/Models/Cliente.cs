﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MontadoraEA.Models
{
    public class Cliente: Pessoa
    {
        public Cliente()
        {
            Cidade = new Cidade();

        }

        [DisplayName("Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [StringLength(50, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        public string Endereco { get; set; }

        [StringLength(15, ErrorMessage = "O tamanho máximo são 15 caracteres.")]
        [Required]
        public string Numero { get; set; }

        [DisplayName("Órgão Expedidor")]
        [StringLength(50, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Required]
        public string OrgaoExpedidor { get; set; }

        [StringLength(20, ErrorMessage = "O tamanho máximo são 20 caracteres.")]
        [Required]
        public string Rg { get; set; }


        public int CidadeId { get; set; }
        [ForeignKey("CidadeId")]
        public virtual Cidade Cidade { get; set; }

        [Required]
        [DisplayName("Sexo")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo Sexo é obrigatório.")]
        public ESexo ESexo { get; set; }
    }
}