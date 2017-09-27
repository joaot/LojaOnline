using LojaOnline.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace LojaOnline.Controllers
{

    public class ComprasController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult AdicionarProduto(int id)
        {
                //seleciona o produto
                var produto = db.Produtos.Where(p => p.ProdutoID == id);

                //seleciona o ID do user autenticado
                var userID = User.Identity.GetUserId();

                //vai buscar o user associado ao id
                var user = db.Users.Find(userID);

                ////sleciona o id da ultima compra
                //var compraID = db.Compras.OrderByDescending(s => s.compraID).FirstOrDefault();

                //cria um novo objeto compra
                Compra c = new Compra();
                c.Cliente = user;
                c.Produtos = produto.ToList();
                c.dataCompra = DateTime.Now;
                c.StatusID = 1;

                //adiciona uma nova compra
                db.Compras.Add(c);
                db.SaveChanges();

            return View();
        }


        public ActionResult ListaCompras()
        {

            //seleciona o ID dos produtos em que o status = 1
            var produto = from p in db.Compras
                          where p.StatusID == 1
                          select p.Produtos.First();

            //seleciona o produto 
            //var prod = from p in db.Compras
            //            where p.Produtos.Any(c => c.ProdutoID == produtoID)
            //            select p;

            //var cenas = from p in db.Produtos
            //            where p.ProdutoID = produto
            //            select p;

            return View(produto);
        }

        //public ActionResult Delete(int id)
        //{
        //    //seleciona o produto
        //    var produto = db.Produtos.Where(p => p.ProdutoID == id);

        //    Compra c = new Compra();
        //    c.StatusID = 2;
               
        //    return View();
        //}



    }


}
