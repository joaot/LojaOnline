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

namespace LojaOnline.Controllers
{
    //[Authorize(Roles ="Administrador")]
    public class GerirUsersController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; private set; }
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: ListaUsers
        public ActionResult ListaUsers()
        {
            //retorna a lista de todos os utilizadores registados
            return View(db.Users.ToList());
        }

        // GET: GerirUsers/Editar/
        public ActionResult Editar()
        {
           
            var userID = User.Identity.GetUserId();

            var user = db.Users.Find(userID);
            return View(user);
   
        }

        //Post: GerirUser/Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Id,NomeProprio,Apelido,NIF,Morada,CodPostal,Localidade,Contacto,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,UserName")] ApplicationUser user)
        {           
            if (ModelState.IsValid)
            {              
                db.Entry(user).State = EntityState.Modified;             
                db.SaveChanges();             
                
                return RedirectToAction("ListaUsers");
            }
            return View(user);
        }
    }
}