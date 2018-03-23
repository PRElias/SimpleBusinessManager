using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SimpleBusinessManager.Models
{
    public class Recebimentos
    {
        [Key]
        public int RecebimentoId { get; set; }

        public DateTime Data { get; set; }

        [Required]
        public decimal Valor { get; set; }

        public virtual Venda Venda { get; set; }

        public int PedidoId { get; set; }
    }
}