using MvcBlogNoticias.Models;
using MvcBlogNoticias.Web.Data.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MvcBlogNoticias.Web.Services
{
    public class NoticiaService : INoticiaService
    {          
        private readonly HttpClient _httpClient;

        public NoticiaService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
               
        public async Task<LerNoticiaDto> CadastrarNoticia(CriarNoticiaDto noticiaDto)
        {                   
            try
            {                
                var content = new StringContent(JsonConvert.SerializeObject(noticiaDto), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("Noticias/Cadastrar", content);

                if (response.IsSuccessStatusCode)
                {
                    var noticias = await response.Content.ReadFromJsonAsync<LerNoticiaDto>();
                    return noticias;
                }

                return new LerNoticiaDto();
            }
            catch (System.Exception)
            {
                throw;
            }
            
        }
                
        public async Task<IEnumerable<LerNoticiaDto>> ObterNoticias()           
        {
            try
            {
                var response = await _httpClient.GetAsync("Noticias/Consultar");
                if (response.IsSuccessStatusCode)
                {
                    var noticias = await response.Content.ReadFromJsonAsync<IEnumerable<LerNoticiaDto>>();
                    return noticias;
                }
                return new List<LerNoticiaDto>();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<LerNoticiaDto> ObterNoticiasPorId(int id)
        {            
            try
            {
                var response = await _httpClient.GetAsync($"Noticias/Consultar/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var noticias = await response.Content.ReadFromJsonAsync<LerNoticiaDto>();
                    return noticias;
                }                
                return new LerNoticiaDto();
            }
            catch (System.Exception)
            {
                throw;
            }

        }
    }
}
