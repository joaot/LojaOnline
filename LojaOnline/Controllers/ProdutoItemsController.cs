using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LojaOnline.Models;
using LojaOnline.ViewModels;

namespace LojaOnline.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProdutoItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProdutoItems
        public ActionResult Index()
        {

            var produtoItems = db.ProdutoItems.Include(p => p.Produto);

            //ordena os produtos por ordem descendente em relação ao nome
            return View(produtoItems.OrderByDescending(r => r.Produto.Nome));
        }

        // GET: ProdutoItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoItem produtoItem = db.ProdutoItems.Find(id);
            if (produtoItem == null)
            {
                return HttpNotFound();
            }
            return View(produtoItem);
        }

        // GET: ProdutoItems/Create
        public ActionResult Create()
        {
            ViewBag.TipoProdutoFK = new SelectList(db.Produtos, "ProdutoID", "Nome");
            return View();
        }

        // POST: ProdutoItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "produtoID,numeroSerie,TipoProdutoFK")] ProdutoItem produtoItem)
        {
            if (ModelState.IsValid)
            {
                db.ProdutoItems.Add(produtoItem);
                db.SaveChanges();

                //Envia mensagem para a view
                TempData["Sucesso"] = "Produto adicionado com sucesso!";

                return RedirectToAction("Index");
            }

            ViewBag.TipoProdutoFK = new SelectList(db.Produtos, "ProdutoID", "Nome", produtoItem.TipoProdutoFK);
            return View(produtoItem);
        }

        // GET: ProdutoItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoItem produtoItem = db.ProdutoItems.Find(id);
            if (produtoItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoProdutoFK = new SelectList(db.Produtos, "ProdutoID", "Nome", produtoItem.TipoProdutoFK);
            return View(produtoItem);
        }

        // POST: ProdutoItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "produtoID,numeroSerie,TipoProdutoFK")] ProdutoItem produtoItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtoItem).State = EntityState.Modified;
                db.SaveChanges();

                //Envia mensagem para a view
                TempData["Sucesso"] = "Produto alterado com sucesso!";

                return RedirectToAction("Edit");
            }
            ViewBag.TipoProdutoFK = new SelectList(db.Produtos, "ProdutoID", "Nome", produtoItem.TipoProdutoFK);
            return View(produtoItem);
        }

        // GET: ProdutoItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoItem produtoItem = db.ProdutoItems.Find(id);
            if (produtoItem == null)
            {
                return HttpNotFound();
            }
            return View(produtoItem);
        }

        // POST: ProdutoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdutoItem produtoItem = db.ProdutoItems.Find(id);
            db.ProdutoItems.Remove(produtoItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //método que conta quantos items existem por produto
        public ActionResult Stock()
        {

            //agrupa os produtos pelo nome e faz a contagem dos mesmos
            var stock = from s in db.ProdutoItems
                        group s by s.Produto.Nome into produto
                        select new stock
                        {
                            //nome do produto
                            nome = produto.Key,
                            //número de produtos
                            stockCount = produto.Count()
                        };

            return View(stock.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
