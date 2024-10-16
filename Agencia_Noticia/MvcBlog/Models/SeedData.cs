using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcBlogNoticias.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
           

            using (var context = new MvcBlogNoticiasContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcBlogNoticiasContext>>()))
            {
                // porcura por noticias
                if (context.Filme.Any())
                {
                    return;  //DB foi alimentado
                }

                context.Filme.AddRange(
                     new Noticia
                     {
                         Titulo = "A Bela e a Fera",
                         Classificacao="L",
                         Lancamento = DateTime.Parse("2017-3-16"),
                         Genero = "Fantasia/Romance",
                         Preco = 7.99M
                     },

                     new Noticia
                     {
                         Titulo = "Caça-Fantasmas",
                         Classificacao = "L",
                         Lancamento = DateTime.Parse("1984-3-13"),
                         Genero = "Comedia",
                         Preco = 8.99M
                     },

                     new Noticia
                     {
                         Titulo = "Kong - A ilha da Caveira",
                         Classificacao = "L",
                         Lancamento = DateTime.Parse("2017-3-09"),
                         Genero = "Ficção",
                         Preco = 9.99M
                     },

                   new Noticia
                   {
                       Titulo = "Rio Bravo",
                       Classificacao = "L",
                       Lancamento = DateTime.Parse("1959-4-15"),
                       Genero = "Western",
                       Preco = 3.99M
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
