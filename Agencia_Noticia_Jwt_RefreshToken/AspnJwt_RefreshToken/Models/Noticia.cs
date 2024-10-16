using System;
using System.ComponentModel.DataAnnotations;

namespace MvcBlogNoticias.Models
{
    public class Noticia
    {
        public int ID { get; set; }

        [Display(Name = "Gênero"), RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$"), Required, StringLength(30)]
        public string? Genero { get; set; }

        [Display(Name = "Data de Lançamento"), DataType(DataType.Date)]
        public DateTime Lancamento { get; set; }

        [Display(Name = "Preço"), Range(1, 100), DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string? Titulo { get; set; }
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$"), StringLength(5)]
        public string? Classificacao { get; set; }
    }
}
