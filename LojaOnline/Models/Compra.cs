using LojaOnline.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaOnline.Models
{
    public class Compra
    {
        public Compra()
        {
            this.Produtos = new HashSet<Produto>();
        }

        public int compraID { get; set; }


        //referencia a tabela produtos
        public virtual ICollection<Produto> Produtos { get; set; }


        [ForeignKey("Produtos")]
        public int produtoID { get; set; }

        //relaciona os users
        public virtual ApplicationUser Cliente { get; set; }

        [ForeignKey("Cliente")]
        public string userID { get; set; }
    }
}