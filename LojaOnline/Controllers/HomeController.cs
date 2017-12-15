using LojaOnline.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaOnline.ViewModels;
using System.Web.Mvc;

namespace LojaOnline.Controllers
{

    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var stock = from s in db.ProdutoItems
                        group s by s.Produto.Nome into produto
                        select new stock
                        {
                            nome = produto.Key,
                            stockCount = produto.Count()
                        };


            return View(stock.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //retorna uma lista de categorias
        public ActionResult Menu()
        {
            return View(db.Categorias.ToList());
        }

        public ActionResult Stock()
        {
            var stock = from s in db.ProdutoItems
                        group s by s.Produto.Nome into produto
                        select new stock
                        {
                            nome = produto.Key,
                            stockCount = produto.Count()
                        };


            return View(stock.ToList());
        }
    }
}