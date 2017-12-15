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


            //----------------------Adiciona categorias de produtos----------------------//

            var categorias = new List<Categoria>
            {
                new Categoria {Nome = "Processador" },
                new Categoria {Nome = "Caixas" },
                new Categoria {Nome = "Placas Gráficas" },
                new Categoria {Nome = "Ratos" },
                new Categoria {Nome = "Teclados" }
            };

            categorias.ForEach(cc => context.Categorias.AddOrUpdate(c => c.Nome, cc));
            context.SaveChanges();



            //----------------------Adiciona tipos de produto----------------------//

            var produtos = new List<Produto>
            {
                new Produto {Nome = "i3-6300", Preco = 162,  Imagem = "~/Imagens/i3.jpg", CategoriaFK = 1 },
                new Produto {Nome = "i5-6600k", Preco = 230,  Imagem = "~/Imagens/i5.jpg", CategoriaFK = 1},
                new Produto {Nome = "i7-7700k", Preco = 330,  Imagem = "~/Imagens/i7.jpg", CategoriaFK = 1 },
                new Produto {Nome = "Pentium G4400", Preco = 55,  Imagem = "~/Imagens/pentium.jpg", CategoriaFK = 1},
                new Produto {Nome = "Caixa ATX Nox Kore", Preco = 23,  Imagem = "~/Imagens/caixa1.jpg", CategoriaFK = 2},
                new Produto {Nome = "Caixa ATX Nox Pax", Preco = 25, Imagem = "~/Imagens/caixa2.jpg", CategoriaFK = 2},
                new Produto {Nome = "Caixa ATX Nox Titan", Preco = 28,  Imagem = "~/Imagens/caixa3.jpg", CategoriaFK = 2},
                new Produto {Nome = "MSI GeForce GTX 1050", Preco = 182,  Imagem = "~/Imagens/gtx1050.jpg", CategoriaFK = 3 },
                new Produto {Nome = "MSI GeForce GTX 1060", Preco = 274,  Imagem = "~/Imagens/gtx1060.jpg", CategoriaFK = 3 },
                new Produto {Nome = "MSI GeForce GTX 1070", Preco = 375,  Imagem = "~/Imagens/gtx1070.jpg", CategoriaFK = 3 },
                new Produto {Nome = "Rato Optico Preto", Preco = 5,  Imagem = "~/Imagens/rato1.jpg", CategoriaFK = 4 },
                new Produto {Nome = "1Life Rato Azul", Preco = 7,  Imagem = "~/Imagens/rato2.jpg", CategoriaFK = 4 },
                new Produto {Nome = "Rato Gembird G-laser", Preco = 9,  Imagem = "~/Imagens/rato3.jpg", CategoriaFK = 4 },
                new Produto {Nome = "Teclado 1Life", Preco = 22,  Imagem = "~/Imagens/teclado1.jpg", CategoriaFK = 5 },
                new Produto {Nome = "Teclado Nox Krom", Preco = 27,  Imagem = "~/Imagens/teclado2.jpg", CategoriaFK = 5 },
                new Produto {Nome = "Teclado Trust", Preco = 33,  Imagem = "~/Imagens/teclado3.jpg", CategoriaFK = 5 },

            };

            produtos.ForEach(pp => context.Produtos.AddOrUpdate(c => c.Nome, pp));
            context.SaveChanges();



            //----------------------Adiciona produto----------------------//
            var items = new List<ProdutoItem>
            {
                new ProdutoItem {numeroSerie = "123456789", TipoProdutoFK = 1 },
                new ProdutoItem {numeroSerie = "12sds67sa", TipoProdutoFK = 1 },
                new ProdutoItem {numeroSerie = "654654564", TipoProdutoFK = 2 },
                new ProdutoItem {numeroSerie = "65as4d65a", TipoProdutoFK = 2 },
                new ProdutoItem {numeroSerie = "asd230sda", TipoProdutoFK = 3 },
                new ProdutoItem {numeroSerie = "as1d56as4", TipoProdutoFK = 3 },
                new ProdutoItem {numeroSerie = "871sadsa1", TipoProdutoFK = 4 },
                new ProdutoItem {numeroSerie = "as97g9f8f", TipoProdutoFK = 4 },
                new ProdutoItem {numeroSerie = "asdas223z", TipoProdutoFK = 5 },
                new ProdutoItem {numeroSerie = "asdu92389", TipoProdutoFK = 5 },

            };

            items.ForEach(ii => context.ProdutoItems.AddOrUpdate(c => c.numeroSerie, ii));
            context.SaveChanges();

        }
    }
}
