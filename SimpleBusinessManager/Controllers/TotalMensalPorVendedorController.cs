using SimpleBusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBusinessManager.Controllers
{
    [Authorize]
    public class TotalMensalPorVendedorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private string query;

        // GET: TotalMensalPorVendedor
        public ActionResult Index()
        {
            query = "select V2.Nome As Vendedor,DATEPART(month, V1.DataPedido) As Mes,SUM(V1.ValorTotal) As Total from Vendas V1 inner join Vendedors V2 on V1.VendedorId = V2.VendedorId group by V2.Nome, DATEPART(month, V1.DataPedido)";
            return View(db.Database.SqlQuery<SimpleBusinessManager.Relatorios.TotalMensalPorVendedor>(query));
        }
    }
}