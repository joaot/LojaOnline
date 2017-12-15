using LojaOnline.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaOnline.Controllers
{
   
    [Authorize]
    public class ComprasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Compras
        public ActionResult AdicionarProduto(int id)
        {

            //recebe o id do produto e pesquisa na bd ProdutoItems o id do produto correspondente
            var produtoID = (from p in db.ProdutoItems
                          where p.TipoProdutoFK == id
                          select p.produtoID).FirstOrDefault();


            //vai buscar o id da última compra e incrementa-o
            var novoID = (from i in db.Compras
                         orderby i.compraID descending
                           select i.compraID).FirstOrDefault() + 1;


            //vai buscar o utilizador autenticado
            var user = User.Identity.GetUserId();

        try
            {
                //cria um novo objeto compra
                Compra c = new Compra();

   
                c.compraID = novoID;
                c.produtoID = produtoID;
                c.userID = user;
              
                //adiciona à bd
                db.Compras.Add(c);

                //guarda os dados
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);               
            }

            return View();
        }

        public ActionResult GetItems()
        {
            //vai buscar o utilizador autenticado
            var user = User.Identity.GetUserId();

            //seleciona o id de todos os produtos da tabela Compras em que o user seja o user autenticado
            var productID = from c in db.Compras
                            where c.userID == user
                            select c.produtoID;


             //var itemList = from p in db.ProdutoItems
             //               where p.produtoID = productID;


            return View(/*itemList.ToList()*/);
        }

    }


}