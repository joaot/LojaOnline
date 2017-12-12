using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaOnline.Models
{
    public class ProdutoItem
    {
        [Key]
        public int produtoID { get; set; }

        [Required(ErrorMessage = "O número de série é de preenchimento obrigatório.")]
        [Display(Name = "Nº de Série")]
        [RegularExpression("[a-zA-Z0-9]*", ErrorMessage = "O nº de série só aceita digitos ou caracteres alfabéticos.")]
        [StringLength(9, ErrorMessage = "O nº de série tem de ter no máximo 9 digitos.")]
        public string numeroSerie { get; set; }

        //referência o objeto ProdutoItem com um objeto Produto
        public Produto Produto { get; set;}

        //atributo usado como chave estrangeira que relaciona com a tabela Produto
        [Display(Name = "Tipo de Produto")]
        [ForeignKey("Produto")]
        public int TipoProdutoFK { get; set; }


    }
}