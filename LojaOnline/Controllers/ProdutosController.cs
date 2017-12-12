using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LojaOnline.Models;
using System.IO;
using PagedList;

namespace LojaOnline.Controllers
{
    public class ProdutosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Produtos
        public ViewResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.currentSort = sortOrder;
            ViewBag.Nome = sortOrder == "Nome";
            ViewBag.Preco = sortOrder == "Preco";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var produtos = from p in db.Produtos
                           select p;

            //pesquisa na base de dados todos os protudos de acordo com o que foi pesquisado
            if (!String.IsNullOrEmpty(searchString))
            {
                produtos = produtos.Where(p => p.Nome.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Nome":
                    produtos = produtos.OrderByDescending(p => p.Nome);
                    break;
                case "Preco":
                    produtos = produtos.OrderByDescending(p => p.Preco);
                    break;
                default:
                    produtos = produtos.OrderByDescending(p => p.Nome);
                    break;
            }

            //8 produtos por página
            int pageSize = 8;

            //página a ser mostrada
            int pageNumber = (page ?? 1);
            return View(produtos.ToPagedList(pageNumber, pageSize));
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produtos = db.Produtos.Find(id);

            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaFK = new SelectList(db.Categorias, "CategoriaID", "Nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoID,Nome,Preco,descricao,Imagem,CategoriaFK")] Produto produtos, HttpPostedFileBase ImageUpload)
        {
            if (ModelState.IsValid)
            {
                //se a imagem não for null
                if(ImageUpload != null && ImageUpload.ContentLength > 0)
                {
                    //define a directory da imagem
                    var uploadDir = "~/Imagens";

                    //combina a directory com o nome do ficheiro e forma o caminho da imagem
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), ImageUpload.FileName);

                    //url da imagem
                    var imageUrl = Path.Combine(uploadDir, ImageUpload.FileName);

                    ImageUpload.SaveAs(imagePath);

                    //guarda a url da imagem na base de dados
                    produtos.Imagem = imageUrl;
                }
                db.Produtos.Add(produtos);
                db.SaveChanges();
                //Envia mensagem para a view
                TempData["Sucesso"] = "O tipo de produto foi criado com sucesso!";

                return RedirectToAction("Index");
            }

            ViewBag.CategoriaFK = new SelectList(db.Categorias, "CategoriaID", "Nome", produtos.CategoriaFK);
            return View(produtos);
        }


        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaFK = new SelectList(db.Categorias, "CategoriaID", "Nome", produtos.CategoriaFK);
            return View(produtos);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoID,Nome,Preco,Imagem,descricao,CategoriaFK")] Produto produtos, HttpPostedFileBase ImageUploa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.CategoriaFK = new SelectList(db.Categorias, "CategoriaID", "Nome", produtos.CategoriaFK);
            return View(produtos);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produtos = db.Produtos.Find(id);
            db.Produtos.Remove(produtos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Descricao(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produtos = db.Produtos.Find(id);

            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        //recebe a categoria do menu e lista todos os produtos da mesma
        public ActionResult ListaProdutos(string name)
        {
            var ListaProdutos = db.Produtos.Where(c => c.Categoria.Nome == name);

            return View(ListaProdutos);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       public ActionResult ListarProdutos()
        {
            
            return View();
        }
    }
}
