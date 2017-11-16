namespace LojaOnline.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LojaOnline.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LojaOnline.Models.ApplicationDbContext context)
        {
            //    string[] roles = new string[] { "Admin", "Cliente" };

            //    foreach (string role in roles)
            //    {
            //        var roleStore = new RoleStore<IdentityRole>(context);

            //        if (!context.Roles.Any(r => r.Name == role))
            //        {
            //            roleStore.CreateAsync(new IdentityRole(role));
            //        }
            //    }


            ////----------------------Adicionar administrador----------------------//
            //var passwordHash = new PasswordHasher();
            //var store = new UserStore<ApplicationUser>(context);
            //var manager = new UserManager<ApplicationUser>(store);

            //var userAdmin = new ApplicationUser {
            //    UserName = "admin@admin.com",
            //    PasswordHash = passwordHash.HashPassword("Admin123#"),
            //    SecurityStamp = Guid.NewGuid().ToString(),
            //    NomeProprio = "João",
            //    Apelido = "Teixeira",
            //    NIF = "123456789",
            //    Morada = "Rua do Pombal",
            //    CodPostal = "2080-111",
            //    Localidade = "Almeirim",
            //    Contacto = "123456789",
            //    Email = "admin@admin.com",
            //};

            //manager.Create(userAdmin);
            //manager.AddToRole(userAdmin.Id, "Admin");

            ////----------------------Adicionar um user cliente----------------------//
            //var userCliente = new ApplicationUser
            //{
            //    UserName = "jose@gmail.com",
            //    PasswordHash = passwordHash.HashPassword("Jose123#"),
            //    SecurityStamp = Guid.NewGuid().ToString(),
            //    NomeProprio = "José",
            //    Apelido = "Teixeira",
            //    NIF = "123456789",
            //    Morada = "Rua do Pombal",
            //    CodPostal = "2080-111",
            //    Localidade = "Almeirim",
            //    Contacto = "123456789",
            //    Email = "jose@gmail.com",
            //};

            //manager.Create(userCliente);
            //manager.AddToRole(userCliente.Id, "Cliente");

            //----------------------Adiciona categorias de produtos----------------------//

            var categorias = new List<Categoria>
            {
                new Categoria {Nome = "Processador" },
                new Categoria {Nome = "Caixas" },
                new Categoria {Nome = "Placas Gráficas" },
                new Categoria {Nome = "Ratos" }
                //new Categoria {Nome = "Teclados" }
            };

            categorias.ForEach(cc => context.Categorias.AddOrUpdate(c => c.Nome, cc));
            context.SaveChanges();



            //----------------------Adiciona produtos----------------------//

            var produtos = new List<Produto>
            {
                new Produto {Nome = "i3-6300", Preco = 162, Stock = 20, Imagem = "~/Imagens/i3.jpg", CategoriaFK = 1, descricao = "Este processador incorpora tecnologia Turbo Boost para um desempenho refinado para os mais recentes jogos e para uma multitarefa suave. Você pode jogar os mais recentes jogos assistir a filmes criar e editar conteúdo em vídeo partilhar fotografias e muito mais! Oferecendo mais poder quando você precisar dele e gráficos integrados de alta qualidade a 6ª geração de processador Intel Core i3 permite que você faça tudo ponto final!"  },
                new Produto {Nome = "i5-6600k", Preco = 230, Stock = 20, Imagem = "~/Imagens/i5.jpg", CategoriaFK = 1, descricao = "Este processador incorpora tecnologia Turbo Boost para um desempenho refinado para os mais recentes jogos e para uma multitarefa suave.Você pode jogar os mais recentes jogos assistir a filmes criar e editar conteúdo em vídeo partilhar fotografias e muito mais! Oferecendo mais poder quando você precisar dele e gráficos integrados de alta qualidade a 6ª geração de processador Intel Core i5 com tecnologia Intel Turbo Boost 2.0 permite que você faça tudo ponto final" },
                new Produto {Nome = "i7-7700k", Preco = 330, Stock = 20, Imagem = "~/Imagens/i7.jpg", CategoriaFK = 1, descricao = "Potência e responsividade sem precedentes, juntamente com a facilidade da segurança incorporada, significa que você pode trabalhar, jogar e criar com a rapidez que você deseja. Além disso, ao permitir resolução 4K, os processadores da 7ª geração Intel® Core™ farão com que você se sinta imerso em jogos e no entretenimento como nunca."  },
                new Produto {Nome = "Pentium G4400", Preco = 55, Stock = 20, Imagem = "~/Imagens/pentium.jpg", CategoriaFK = 1, descricao = "Este processador incorpora tecnologia Turbo Boost para um desempenho refinado para os mais recentes jogos e para uma multitarefa suave. Você pode jogar os mais recentes jogos assistir a filmes criar e editar conteúdo em vídeo partilhar fotografias e muito mais! Oferecendo mais poder quando você precisar dele e gráficos integrados de alta qualidade a 6ª geração de processador Intel Core i3 permite que você faça tudo ponto final!"  },
                new Produto {Nome = "Caixa ATX Nox Kore ", Preco = 23, Stock = 20, Imagem = "~/Imagens/caixa1.jpg", CategoriaFK = 2, descricao = "A Nox introduz a Kore: uma solução com amplas possibilidades num formato semi-tower. A sua versatilidade converte-a numa opção perfeita para aqueles que necessitam de uma caixa para hardware de alto desempenho num formato mais compacto. O design em preto com linhas angulares fornecem-lhe um aspecto implacável juntamente com o efeito de alumínio escovado do painel frontal."},
                new Produto {Nome = "Caixa ATX Nox Pax ", Preco = 25, Stock = 20, Imagem = "~/Imagens/caixa2.jpg", CategoriaFK = 2, descricao = "A Nox introduz a Kore: uma solução com amplas possibilidades num formato semi-tower. A sua versatilidade converte-a numa opção perfeita para aqueles que necessitam de uma caixa para hardware de alto desempenho num formato mais compacto. O design em preto com linhas angulares fornecem-lhe um aspecto implacável juntamente com o efeito de alumínio escovado do painel frontal."},
                new Produto {Nome = "Caixa ATX Nox Titan ", Preco = 28, Stock = 20, Imagem = "~/Imagens/caixa3.jpg", CategoriaFK = 2, descricao = "A Nox introduz a Kore: uma solução com amplas possibilidades num formato semi-tower. A sua versatilidade converte-a numa opção perfeita para aqueles que necessitam de uma caixa para hardware de alto desempenho num formato mais compacto. O design em preto com linhas angulares fornecem-lhe um aspecto implacável juntamente com o efeito de alumínio escovado do painel frontal."},
                new Produto {Nome = "MSI GeForce GTX 1050 ", Preco = 182, Stock = 20, Imagem = "~/Imagens/gtx1050.jpg", CategoriaFK = 3, descricao = "Assim como nos jogos, a tecnologia de ventoinha MSI TORX 2.0 usa o poder do trabalho em equipa para permitir que o TWIN FROZR VI alcance novos níveis de dissipação. O design de ventoinha TORX 2.0 gera 22% mais pressão de ar para um desempenho extremamente silencioso no calor da batalha." },
                new Produto {Nome = "MSI GeForce GTX 1060 ", Preco = 274, Stock = 20, Imagem = "~/Imagens/gtx1060.jpg", CategoriaFK = 3, descricao = "Assim como nos jogos, a tecnologia de ventoinha MSI TORX 2.0 usa o poder do trabalho em equipa para permitir que o TWIN FROZR VI alcance novos níveis de dissipação. O design de ventoinha TORX 2.0 gera 22% mais pressão de ar para um desempenho extremamente silencioso no calor da batalha." },
                new Produto {Nome = "MSI GeForce GTX 1070 ", Preco = 375, Stock = 20, Imagem = "~/Imagens/gtx1070.jpg", CategoriaFK = 3, descricao = "Assim como nos jogos, a tecnologia de ventoinha MSI TORX 2.0 usa o poder do trabalho em equipa para permitir que o TWIN FROZR VI alcance novos níveis de dissipação. O design de ventoinha TORX 2.0 gera 22% mais pressão de ar para um desempenho extremamente silencioso no calor da batalha." },
            };

            produtos.ForEach(pp => context.Produtos.AddOrUpdate(c => c.Nome, pp));
            context.SaveChanges();

            var estado = new List<Status>
            {
                new Status {StatusID = 1, nome = "Adicionado" },
                new Status {StatusID = 2, nome = "Removido" }
            };

            estado.ForEach(ee => context.Statuss.AddOrUpdate(c => c.nome, ee));
            context.SaveChanges();


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

        }
    }
}
