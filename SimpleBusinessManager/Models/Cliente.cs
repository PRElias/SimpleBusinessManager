using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SimpleBusinessManager.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} precisa ter ao menos {2} caracteres.", MinimumLength = 3)]
        public string Nome { get; set; }

        [StringLength(100)]
        [Display(Name ="Endereço")]
        public string Endereco { get; set; }

        [Phone]
        public string Telefone { get; set; }
        
        [Phone]
        public string Celular { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Url]
        public string Facebook { get; set; }

        [Display(Name ="Aniversário")]
        public DateTime? Aniversario { get; set; }

        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}