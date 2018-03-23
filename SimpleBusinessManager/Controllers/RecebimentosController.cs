using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleBusinessManager.Models;

namespace SimpleBusinessManager.Controllers
{
    [Authorize]
    public class RecebimentosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Recebimentos
        public ActionResult Index()
        {
            return View(db.Recebimentos.ToList());
        }

        // GET: Recebimentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recebimentos recebimentos = db.Recebimentos.Find(id);
            if (recebimentos == null)
            {
                return HttpNotFound();
            }
            return View(recebimentos);
        }

        // GET: Recebimentos/Create
        public ActionResult Create()
        {
            var model = new Recebimentos();
            model.Data = DateTime.Now;

            ViewBag.Vendas = new SelectList(db.Vendas.ToList().OrderBy(i => i.PedidoId), "PedidoId", "PedidoId");
            return View(model);
        }

        // POST: Recebimentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Recebimentos recebimentos)
        {
            recebimentos.Valor = recebimentos.Valor / 100;
            if (ModelState.IsValid)
            {
                db.Recebimentos.Add(recebimentos);
                db.SaveChanges();
                AlternarPago(recebimentos);
                return RedirectToAction("Index");
            }

            return View(recebimentos);
        }

        // GET: Recebimentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recebimentos recebimentos = db.Recebimentos.Find(id);
            ViewBag.Vendas = new SelectList(db.Vendas.ToList().OrderBy(i => i.PedidoId), "PedidoId", "PedidoId");
            if (recebimentos == null)
            {
                return HttpNotFound();
            }
            return View(recebimentos);
        }

        // POST: Recebimentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Recebimentos recebimentos)
        {
            recebimentos.Valor = recebimentos.Valor / 100;
            if (ModelState.IsValid)
            {
                db.Entry(recebimentos).State = EntityState.Modified;
                db.SaveChanges();
                AlternarPago(recebimentos);
                return RedirectToAction("Index");
            }
            return View(recebimentos);
        }

        // GET: Recebimentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recebimentos recebimentos = db.Recebimentos.Find(id);
            if (recebimentos == null)
            {
                return HttpNotFound();
            }
            return View(recebimentos);
        }

        // POST: Recebimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recebimentos recebimentos = db.Recebimentos.Find(id);
            db.Recebimentos.Remove(recebimentos);
            db.SaveChanges();
            AlternarPago(recebimentos);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult RecuperaSaldo(string PedidoId)
        {
            decimal valor = 0;
            if (PedidoId != null)
            {
                valor = db.Database.SqlQuery<decimal>("SELECT ValorTotal - ISNULL((SELECT CONVERT(varchar,SUM(Valor)) FROM dbo.Recebimentos WHERE PedidoId = " + PedidoId + " GROUP BY PedidoId),0) AS Saldo FROM Vendas WHERE PedidoId = " + PedidoId).SingleOrDefault();
            }
            return Json(valor.ToString(), JsonRequestBehavior.AllowGet);
        }

        public void AlternarPago(Recebimentos recebimento)
        {
            var venda = db.Vendas.Find(recebimento.PedidoId);
            var valor = db.Database.SqlQuery<decimal>("SELECT SUM(Valor) FROM dbo.Recebimentos WHERE PedidoId = " + venda.PedidoId + " GROUP BY PedidoId").SingleOrDefault();
            if (venda.ValorTotal <= valor)
            {
                venda.Pago = true;
                
            }
            else
            {
                venda.Pago = false;
            }
            db.Entry(venda).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
