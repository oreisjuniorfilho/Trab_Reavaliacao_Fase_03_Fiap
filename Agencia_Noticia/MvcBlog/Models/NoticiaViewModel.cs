using System;
using System.ComponentModel.DataAnnotations;

namespace MvcBlogNoticias.Models
{
    public class NoticiaViewModel
    {
        [Key]
        public int ID { get; set; }
                
        public string Titulo { get; set; }
              
        public System.DateTime Lancamento { get; set; }
             
        public string Genero { get; set; }
         
        public decimal Preco { get; set; }
              
        public string Classificacao { get; set; }
    }
}
