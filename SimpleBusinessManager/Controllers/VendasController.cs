using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleBusinessManager.Models;
using System.Data.SqlClient;

namespace SimpleBusinessManager.Controllers
{
    [Authorize]
    public class VendasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vendas
        public ActionResult Index()
        {
            return View(db.Vendas.ToList());
        }

        // GET: Vendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // GET: Vendas/Create
        public ActionResult Create()
        {
            var model = new Venda();
            model.DataPedido = DateTime.Now;
            ViewBag.Clientes = new SelectList(db.ClienteModels.ToList().OrderBy(i => i.Nome), "ClienteId", "Nome");
            ViewBag.Vendedores = new SelectList(db.Vendedors.ToList().OrderBy(i => i.Nome), "VendedorId", "Nome");
            return View(model);
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Venda venda)
        {
            venda.ValorTotal = venda.ValorTotal / 100;
            if (ModelState.IsValid)
            {
                db.Vendas.Add(venda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(venda);
        }

        // GET: Vendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            ViewBag.Clientes = new SelectList(db.ClienteModels.ToList().OrderBy(i => i.Nome), "ClienteId", "Nome");
            ViewBag.Vendedores = new SelectList(db.Vendedors.ToList().OrderBy(i => i.Nome), "VendedorId", "Nome");
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Venda venda)
        {
            venda.ValorTotal = venda.ValorTotal / 100;
            if (ModelState.IsValid)
            {
                db.Entry(venda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venda venda = db.Vendas.Find(id);
            db.Vendas.Remove(venda);
            db.SaveChanges();
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

        public JsonResult GetVendas(string texto, string pago)
        {
            var vendas = db.Vendas.SqlQuery("Select * From Vendas v Inner Join Clientes c ON v.ClienteId = c.ClienteId AND c.Nome like '%' + @Texto + '%' AND v.Pago = @Pago",
                new SqlParameter("Texto", texto), new SqlParameter("Pago", pago)).ToList();
            return Json(vendas, JsonRequestBehavior.AllowGet);
        }
    }
}
