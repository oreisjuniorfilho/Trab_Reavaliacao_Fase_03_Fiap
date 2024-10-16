using AutoMapper;
using MvcBlogNoticias.Api.Data.Dto;
using MvcBlogNoticias.Models;

namespace MvcBlogNoticias.Api.Profiles
{
    public class NoticiaProfile : Profile
    {
        public NoticiaProfile()
        {
            CreateMap<CriarNoticiaDto, Noticia>();
            CreateMap<Noticia, LerNoticiaDto>();
        }
    }
}
