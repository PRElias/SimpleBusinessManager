using SimpleBusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SimpleBusinessManager.Controllers
{
    [Authorize]
    public class SaldoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private string query;

        // GET: Saldo
        public ActionResult Index()
        {
            query = "SELECT Vendas.PedidoId,Vendas.ClienteId,Clientes.Nome As Cliente,Vendas.VendedorId,Vendedores.Nome As Vendedor,Vendas.DataPedido,Vendas.Parcelas,Vendas.Pago,Vendas.ValorTotal,Recebimentos.Recebido as ValorRecebido,Recebimentos.UltimoPagto,(Vendas.ValorTotal - Recebimentos.Recebido) As ValorSaldo FROM[Vendas] Vendas INNER JOIN (SELECT PedidoId, SUM(Valor) AS Recebido, MAX(Data) AS UltimoPagto FROM [Recebimentos] GROUP BY PedidoId) AS Recebimentos ON Vendas.PedidoId = Recebimentos.PedidoId INNER JOIN[Clientes] Clientes on Vendas.ClienteId = Clientes.ClienteId INNER JOIN[Vendedors] Vendedores on Vendas.VendedorId = Vendedores.VendedorId";
            return View(db.Database.SqlQuery<SimpleBusinessManager.Relatorios.Saldo>(query));
        }
    }
}