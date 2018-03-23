using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBusinessManager.Relatorios
{
    public class TotalMensalPorVendedor
    {
        public string Vendedor { get; set; }

        public int Mes { get; set; }

        public decimal Total { get; set; }
    }
}