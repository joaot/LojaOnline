using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using LojaOnline.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LojaOnline
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            createRolesUser();
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
        }


        //método que cria os utilizadores sempre que a aplicação é iniciada
         private void createRolesUser()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            //Se não existir nenhum adminitrador, cria um novo
            if (!roleManager.RoleExists("Admin"))
            {
                //cria o role Admin
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Criação do utlizador Admin
                var user = new ApplicationUser
                {
                    UserName = "admin@admin.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    NomeProprio = "João",
                    Apelido = "Teixeira",
                    NIF = "123456789",
                    Morada = "Rua do Pombal",
                    CodPostal = "2080-111",
                    Localidade = "Almeirim",
                    Contacto = "123456789",
                    Email = "admin@admin.com",
                };

                string userPass = "Admin123#";
                var create = UserManager.Create(user, userPass);

                //Adicionar o user criado anteriormente à role Admin
                if (create.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            //Se não existir nenhum adminitrador, cria um novo
            if (!roleManager.RoleExists("Cliente"))
            {
                //cria o role Admin
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Cliente";
                roleManager.Create(role);

                //Criação do utlizador Admin
                var user = new ApplicationUser
                {
                    UserName = "jose@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    NomeProprio = "José",
                    Apelido = "Casinhas",
                    NIF = "123456789",
                    Morada = "Rua do Pombal",
                    CodPostal = "2080-111",
                    Localidade = "Almeirim",
                    Contacto = "123456789",
                    Email = "jose@gmail.com",
                };

                string userPass = "Jose123#";
                var create = UserManager.Create(user, userPass);

                //Adicionar o user criado anteriormente à role Cliente
                if (create.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Cliente");
                }
            }
        }

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }

