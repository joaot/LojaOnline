using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaOnline.Models
{
    public class Produto
    {

        [Key]
        public int ProdutoID { get; set; }


        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [RegularExpression("^[a-zA-Z0-9ºçÇÁÀÃÂÉÍÓÕÔÚàáéíóõú.&', -]*$", ErrorMessage = "O nome do produto apenas permite caracteres de A a Z e algarismos de 0 a 9.")]
        [StringLength(30, ErrorMessage = "O nome do produto não deve exceder os 30 caracteres.")]
        public string Nome { get; set; }



        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [Display(Name = "Preço")]
        public int Preco  { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [RegularExpression("^[a-zA-Z0-9ºçÇÁÀÃÂÉÍÓÕÔÚàáéíóõú.&', -]*$", ErrorMessage = "A descrição do produto apenas permite caracteres de A a Z e algarismos de 0 a 9.")]
        [StringLength(150, ErrorMessage = "A descrição do produto não deve exceder os 150 caracteres.")]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        public string Imagem { get; set; }

        //relaciona o objeto PRODUTO com um objeto CATEGORIA
        public Categoria Categoria { get; set; }

        //atributo usado como chave estrangeira que relaciona com a tabela Categorias
        [Display(Name = "Categoria")]
        [ForeignKey("Categoria")]
        public int CategoriaFK { get; set; }

        //referencia a tabela ProdutoItem
        public ICollection<ProdutoItem> Items { get; set; }

    }
}