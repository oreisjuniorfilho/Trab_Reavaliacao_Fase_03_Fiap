using MvcBlogNoticias.Models;
using MvcBlogNoticias.Api.Data.Dto;

namespace MvcBlogNoticias.Api.Data
{
    public interface INoticiaRepository
    {
        Task<List<LerNoticiaDto>> ObterNoticias();
        Task<LerNoticiaDto> ObterNoticiasPorId(int id);
        Task<LerNoticiaDto> CadastrarNoticia(CriarNoticiaDto noticiaDto);
    }
}
