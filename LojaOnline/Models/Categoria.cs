using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LojaOnline.Models
{
    public class Categoria 
    {
        [Key]
        public int CategoriaID { get; set; }

        [Required(ErrorMessage ="O nome da categoria é obrigatório.")]
        [RegularExpression("^[a-zA-ZçÇÁÀÃÂÉÍÓÕÔÚàáéíóõú.&', -]*$", ErrorMessage = "Permitido apenas caracteres de A a Z.")]
        [StringLength(20, ErrorMessage = "A categoria deve ter entre 2 a 20 caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

       //referencia a tabela produtos
        public ICollection<Produto> Produtos { get; set; }
    }
}