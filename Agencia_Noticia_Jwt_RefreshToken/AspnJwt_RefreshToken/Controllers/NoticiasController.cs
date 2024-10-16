using AspnJwt_RefreshToken.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MvcBlogNoticias.Api.Data.Dto;
using MvcBlogNoticias.Api.Data;
using System.Text;


namespace MvcBlogNoticias.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
        public class NoticiasController : ControllerBase
        {
            private readonly INoticiaRepository _noticiaRepository;

            private readonly ILogger<NoticiasController> _logger;

        //public NoticiasController()
        //{
                
        //}
        //public NoticiasController(ILogger<NoticiasController> logger)
        //    {
        //        _logger = logger;
        //    }

            public NoticiasController(INoticiaRepository noticiaRepository)
            {
                _noticiaRepository = noticiaRepository;
            }

            [HttpGet]
            [Route("Consultar")]
            //[Authorize(Roles = UserRoles.Admin)]
            public async Task<IActionResult> ListarNoticias()
            {
                List<LerNoticiaDto> readDto = await _noticiaRepository.ObterNoticias();
                if (readDto == null) return NotFound();
                return Ok(readDto);
            }

            [HttpPost]
            [Route("Cadastrar")]
            //[Authorize(Roles = UserRoles.Admin)]
            public async Task<IActionResult> CadastrarNoticia(CriarNoticiaDto noticia)
            {
                LerNoticiaDto readDto = await _noticiaRepository.CadastrarNoticia(noticia);
                return CreatedAtAction(nameof(RecuperaNoticiaPorId), new { Id = readDto.ID }, readDto);
            }

            [HttpGet]
            [Route("Consultar/{id}")]
            //[Authorize(Roles = UserRoles.Admin)]
            public async Task<IActionResult> RecuperaNoticiaPorId(int id)
            {
                LerNoticiaDto readDto = await _noticiaRepository.ObterNoticiasPorId(id);
                if (readDto == null) return NotFound();
                return Ok(readDto);
            }
        
    }
}
