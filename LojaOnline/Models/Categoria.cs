using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LojaOnline.Models
{
    public class Categoria 
    {
        [Key]
        public int CategoriaID { get; set; }

        public string Nome { get; set; }

       //referencia a tabela produtos
        public ICollection<Produto> Produtos { get; set; }
    }
}