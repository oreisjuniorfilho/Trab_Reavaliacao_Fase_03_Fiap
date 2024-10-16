using AutoMapper;
using MvcBlogNoticias.Models;
using MvcBlogNoticias.Api.Data.Dto;
using Microsoft.EntityFrameworkCore;

namespace MvcBlogNoticias.Api.Data.Repository
{
    public class NoticiaRepository : INoticiaRepository
    {

        private ApplicationDbContext _context;
        private IMapper _mapper;

        public NoticiaRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       
        public async Task<LerNoticiaDto> CadastrarNoticia(CriarNoticiaDto noticiaDto)
        {
            Noticia noticia = _mapper.Map<Noticia>(noticiaDto);

            _context.Filme.Add(noticia);
            _context.SaveChanges();

            return _mapper.Map<LerNoticiaDto>(noticia);
        }

        public async Task<List<LerNoticiaDto>> ObterNoticias()
        {
            var noticias = await _context.Filme.ToListAsync();

            if (noticias == null)
            {
                return null;
            }

            return _mapper.Map<List<LerNoticiaDto>>(noticias);
        }

        public async Task<LerNoticiaDto> ObterNoticiasPorId(int id)
        {
            var noticia = _context.Filme.FirstOrDefault(noticia => noticia.ID == id);

            if (noticia != null)
            {
                return _mapper.Map<LerNoticiaDto>(noticia);
            }

            return null;
        }
    }
}
