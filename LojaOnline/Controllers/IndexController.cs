using LojaOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace LojaOnline.Controllers
{
    public class IndexController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        //https://stackoverflow.com/questions/13225315/pass-data-to-layout-that-are-common-to-all-pages
        //método que lista todas as categorias para serem usadas no menu
        [ChildActionOnly]
        public ActionResult Menu()
        {

            //Lista de categorias
            var model = from p in db.Categorias
                        select p;
                           
         //envia um model para ser usado na partial view
         return PartialView("~/Views/Shared/_Menu.cshtml", model);
        }


        //método que lista os produtos recentemente adicionados
        [ChildActionOnly]
        public ActionResult ProdutosRecentes()
        {

            //Lista os últimos 6 produtos adicionados na base de dados
            var model = (from p in db.Produtos                      
                        select p).Take(9).ToList(); ;

            //envia um model para ser usado na partial view
            return PartialView("~/Views/Shared/_ProdutosRecentes.cshtml", model);
        }
    }
}