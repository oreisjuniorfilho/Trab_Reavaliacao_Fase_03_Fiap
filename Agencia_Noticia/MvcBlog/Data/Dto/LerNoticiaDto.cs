using System.ComponentModel.DataAnnotations;

namespace MvcBlogNoticias.Web.Data.Dto
{
    public class LerNoticiaDto
    {
        [Required]
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "O campo de Titulo é obrigatório")]
        public string? Titulo { get; set; }
        public System.DateTime Lancamento { get; set; }
        public string? Genero { get; set; }        
        public decimal Preco { get; set; }         
        public string? Classificacao { get; set; }
    }
}
