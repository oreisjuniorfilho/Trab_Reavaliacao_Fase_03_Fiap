using Moq;
using Bogus;
using Xunit;
using Bogus.DataSets;
using MvcBlogNoticias.Api.Data;
using MvcBlogNoticias.Api.Data.Dto;
using System.Reflection.Metadata;
using MvcBlogNoticias.Models;
using Assert = Xunit.Assert;

namespace BlogNoticias_Teste
{
    [TestClass]
    public class MvcBlogNoticiasTeste
    {
        private readonly Faker _faker;

        public MvcBlogNoticiasTeste()
        {
            _faker = new Faker();
        }

        [Fact(DisplayName = "Validando se o título esta vazio")]
        [Trait("Categoria", "Validando Noticias")]
        public void ValidateEntity_ShouldThrowException_WhenTitleIsEmpty()
        {
            // Arrange
            var titulodaObra = string.Empty;
            var generodaObra = _faker.Random.String2(30);
            var classificacaodaObra = _faker.Random.String2(5);
            var precodaObra = (decimal)_faker.Random.Int(1, 100);              
            var dataLancamentodaObra = DateTime.Now;


        //act
        var result = Assert.Throws<Exception>(() =>
                new CriarNoticiaDto(titulodaObra, generodaObra, classificacaodaObra, precodaObra, dataLancamentodaObra));

            //Assert
            Assert.Equal("O título não pode estar vazio!", result.Message);
        }


        [Fact(DisplayName = "Validando se a noticia foi obtida com sucesso")]
        [Trait("Categoria", "Consultando Noticias")]
        public void SelectNews_ShouldReturnSuccessMessage()
        {           
            // Arrange
            var titulodaObra = _faker.Random.String2(50);
            var generodaObra = _faker.Random.String2(30);
            var classificacaodaObra = _faker.Random.String2(5);
            var precodaObra = (decimal)_faker.Random.Int(1, 100);
            var dataLancamentodaObra = DateTime.Now;

            var noticias = new List<LerNoticiaDto>()
            {
                new ()
                {
                    Titulo = titulodaObra,
                    Genero = generodaObra,
                    Classificacao = classificacaodaObra,
                    Preco = precodaObra,
                    Lancamento = dataLancamentodaObra
                 }
            };

            var moqRepository = new Mock<INoticiaRepository>();

            moqRepository.Setup(service => service.ObterNoticias()).Returns(() =>
            Task.FromResult(new List<LerNoticiaDto>()
            {
                new ()
                {
                    Titulo = titulodaObra,
                    Genero = generodaObra,
                    Classificacao = classificacaodaObra,
                    Preco = precodaObra,
                    Lancamento = dataLancamentodaObra
                }
            }));

            var noticiaService = moqRepository.Object;

            // Act
            var resultado = noticiaService.ObterNoticias();

            // Assert
            Assert.Equal(noticias.FirstOrDefault().Titulo.ToString(),
                        resultado.Result.FirstOrDefault().Titulo.ToString());
        }

        [Fact(DisplayName = "Validando se a noticia foi criado com sucesso")]
        [Trait("Categoria", "Validando noticia")]
        public void CreateNews_ShouldReturnSuccessMessage()
        {
            // Arrange
            var titulodaObra = _faker.Random.String2(50);
            var generodaObra = _faker.Random.String2(30);
            var classificacaodaObra = _faker.Random.String2(5);
            var precodaObra = (decimal)_faker.Random.Int(1, 100);
            var dataLancamentodaObra = DateTime.Now;

            var noticiaDto = new CriarNoticiaDto(titulodaObra, generodaObra, classificacaodaObra, precodaObra, dataLancamentodaObra);

            var moqRepository = new Mock<INoticiaRepository>();

            moqRepository.Setup(service => service.CadastrarNoticia(It.IsAny<CriarNoticiaDto>()))
           .Returns(() =>
                       Task.FromResult(new LerNoticiaDto
                       {                           
                           Titulo = titulodaObra,
                           Genero = generodaObra,
                           Classificacao = classificacaodaObra,
                           Preco = precodaObra,
                           Lancamento = dataLancamentodaObra

                       }));

            var noticiaService = moqRepository.Object;

            // Act
            var resultado = noticiaService.CadastrarNoticia(noticiaDto);

            // Assert
            Assert.Equal(noticiaDto.Titulo, resultado.Result.Titulo);
        }

    }
}