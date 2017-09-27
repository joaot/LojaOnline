using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace LojaOnline.Models
{
    public class Produto
    {
        public Produto()
        {
            this.Compras = new HashSet<Compra>();
        }

        
        public int ProdutoID { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [Display(Name = "Preço")]
        public int Preco  { get; set; }

        public int Stock { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        public string Imagem { get; set; }

        //relaciona o objeto PRODUTO com um objeto CATEGORIA
        public Categoria Categoria { get; set; }

        //atributo usado como chave estrangeira que relaciona com a tabela Categorias
        [Display(Name = "Categoria")]
        [ForeignKey("Categoria")]
        public int CategoriaFK { get; set; }

        //referencia a tabela compras
        public virtual ICollection<Compra> Compras { get; set; }

    }
}