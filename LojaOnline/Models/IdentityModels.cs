﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace LojaOnline.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        //atributos do utilizador
        public string NomeProprio { get; set; }

        public string Apelido { get; set; }

        public string NIF { get; set; }

        public string Morada { get; set; }

        public string CodPostal { get; set; }

        public string Localidade { get; set; }

        public string Contacto { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //Criação das tabelas
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Status> Statuss { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}