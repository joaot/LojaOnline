using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LojaOnline.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        //atributos do utilizador
        [Required(ErrorMessage = "O nome próprio é de preenchimento obrigatório.")]
        [RegularExpression("([A-Z][a-zãéóáõ]*)", ErrorMessage = "O Nome próprio deve ter uma única palavra começada por letra maiúscula.")]
        [StringLength(20, ErrorMessage = "O Nome próprio deve ter entre 2 a 20 caracteres.", MinimumLength = 2)]
        [Display(Name = "Nome próprio")]
        public string NomeProprio { get; set; }

        [Required(ErrorMessage = "O apelido é de preenchimento obrigatório.")]
        [RegularExpression("([A-Z][a-zãéóáõ]*)", ErrorMessage = "O Apelido deve ter uma única palavra começada por letra maiúscula.")]
        [StringLength(20, ErrorMessage = "O Apelido deve ter entre 2 a 20 caracteres.", MinimumLength = 2)]
        public string Apelido { get; set; }

        [RegularExpression("[0-9]{9}", ErrorMessage = "O NIF só aceita valores numéricos e com nove números.")]
        [StringLength(9, ErrorMessage = "O NIF deve ter 9 caracteres.")]
        [Display(Name = "Nº Contribuinte")]
        public string NIF { get; set; }

        [RegularExpression("^[a-zA-Z0-9ºçÇÁÀÃÂÉÍÓÕÔÚàáéíóõú.&', -]*$", ErrorMessage = "Na Morada apenas são permitidos caracteres de A a Z e algarismos de 0 a 9.")]
        [StringLength(40, ErrorMessage = "A Morada não deve exceder os 30 caracteres.")]
        public string Morada { get; set; }

        [RegularExpression("[0-9]{4}-[0-9]{3} [a-zA-Z0-9ºçÇÁÀÂÃÉÈÍÌÓÒÔÕáàâãéèíìóòõ.&', -]*", ErrorMessage = "Código postal com formato incorrecto. ex: 0000-000 LOCALIDADE")]
        [StringLength(30, ErrorMessage = "O código postal não deve exceder os 30 caracteres.")]
        [Display(Name = "Código postal")]
        public string CodPostal { get; set; }

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
        public virtual DbSet<ProdutoItem> ProdutoItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}