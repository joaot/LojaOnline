using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using LojaOnline.Models;
using System.Data.Entity;
using System.Net;
using System.Data.Entity.Validation;
using System.Web.Security;
using PagedList;

namespace LojaOnline.Controllers
{
    [Authorize]
    public class GerirUsersController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; private set; }
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ListaUsers
        public ViewResult ListaUsers()
        {


            var user = from p in db.Users
                           select p;


           return View(user.OrderByDescending(r => r.NomeProprio));
            
        }

        // GET: GerirUsers/Editar/
        public ActionResult Editar(string id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //vai procurar o user pelo id recebido
            var user = db.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            //retorn a info do user
            return View(user);
   
        }

        //Post: GerirUser/Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Id,NomeProprio,Apelido,NIF,CodPostal,Morada,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,UserName")] ApplicationUser user)
        {           
            if (ModelState.IsValid)
            {              
                db.Entry(user).State = EntityState.Modified;             
                db.SaveChanges();

                //Envia mensagem de sucesso para a view
                TempData["Sucesso"] = "Os dados foram alterados com sucesso!";

                return RedirectToAction("ListaUsers");
            }
            return View(user);
        }


        // GET
        public ActionResult ApagaUser(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Apagar(string id)
        {
            ApplicationUser user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("ListaUsers");
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