using System.ComponentModel.DataAnnotations;

namespace MvcBlogNoticias.Api.Data.Dto
{
    public class CriarNoticiaDto
    {

        public CriarNoticiaDto(string titulo, string modalidade, string perfil, decimal valor, DateTime dataPublicacao)
        {
            Titulo = titulo;
            Genero = modalidade;
            Classificacao = perfil;
            Preco = valor;
            Lancamento = dataPublicacao;            

            ValidateEntity();
        }

        public string? Genero { get; set; }
        public DateTime Lancamento { get; set; }        
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O campo de Titulo é obrigatório")]
        public string? Titulo { get; set; }
        public string? Classificacao { get; set; }


        public void ValidateEntity()
        {
            if (Titulo == null || Titulo.Trim().Length == 0)
            {
                throw new Exception("O título não pode estar vazio!");
            }
            else
            {
                if (Titulo.Trim().Length < 3)
                {
                    throw new Exception("O título não pode ter menos que [03] caracteres!");
                }
                else 
                {
                   if (Titulo.Trim().Length > 60)
                    {
                        throw new Exception("O título não pode conter mais que [60] caracteres!");
                    }
                }
            }

        }


        public decimal GenerateRandomDecimal( decimal min, decimal max)
        {
            Random random = new Random();

            double range = (double) (max - min);

            double value = random.NextDouble() * range + (double)min;

            return (decimal)value;

        }

    }
}
