using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SimpleBusinessManager.Models
{
    public class Vendedor
    {
        [Key]
        public int VendedorId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} precisa ter ao menos {2} caracteres.", MinimumLength = 3)]
        public string Nome { get; set; }
    }
}