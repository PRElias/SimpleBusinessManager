using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBusinessManager.Models
{
    public class Venda
    {
        [Key]
        public int PedidoId { get; set; }

        public virtual Cliente Cliente { get; set; }

        [Required]
        public int ClienteId { get; set; }

        public virtual Vendedor Vendedor { get; set; }

        [Required(ErrorMessage = "Escolha um vendedor")]
        public int VendedorId { get; set; }

        [Required]
        [Display(Name = "Valor Total")]
        public Decimal? ValorTotal { get; set; }

        [Required]
        [Display(Name = "Data do Pedido")]
        public DateTime DataPedido { get; set; }

        [Display(Name = "Tipo do Pagamento")]
        public virtual TipoPagamento TipoPagamento { get; set; }

        [Required]
        public int TipoPagamentoId { get; set; }

        public int Parcelas { get; set; }

        public Boolean Pago { get; set; }

        [NotMapped]
        public string Apelido
        {
            get
            {
                return this.PedidoId + " - " + this.DataPedido + " - " + this.Cliente.Nome;
            }
        }

    }

    public enum TipoPagamento
    {
        Dinheiro = 1,
        [Display(Name = "Cartão de Crédito")]
        CartaoCredito = 2,
        [Display(Name = "Cartão de Crédito - Parcelado")]
        CartaoCreditoParcelado = 3,
        [Display(Name = "Promessa de pagamento em dinheiro")]
        Promissoria = 4
    }
}