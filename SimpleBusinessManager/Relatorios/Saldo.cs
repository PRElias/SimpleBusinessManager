using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBusinessManager.Relatorios
{
    public class Saldo
    {
        public int PedidoId { get; set; }

        public string Cliente { get; set; }

        public string Vendedor { get; set; }

        public DateTime DataPedido { get; set; }

        public int Parcelas { get; set; }

        public bool Pago { get; set; }

        public decimal ValorTotal { get; set; }

        public decimal ValorRecebido { get; set; }

        public DateTime UltimoPagto { get; set; }

        public decimal ValorSaldo { get; set; }
    }
}