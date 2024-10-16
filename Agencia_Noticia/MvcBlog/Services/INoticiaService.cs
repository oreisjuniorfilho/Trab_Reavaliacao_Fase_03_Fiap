using MvcBlogNoticias.Models;
using MvcBlogNoticias.Web.Data.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcBlogNoticias.Web.Services
{
    public interface INoticiaService
    {
        Task<IEnumerable<LerNoticiaDto>> ObterNoticias();
        Task<LerNoticiaDto> ObterNoticiasPorId(int id);
        Task<LerNoticiaDto> CadastrarNoticia(CriarNoticiaDto noticiaDto);
    }
}
