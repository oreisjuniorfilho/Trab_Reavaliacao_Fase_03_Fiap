using AutoMapper;
using AspnJwt_RefreshToken.Models;
using MvcBlogNoticias.Api.Data.Dto;
using MvcBlogNoticias.Models;


namespace MvcBlogNoticias.Api.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<CreateUserDto, RegisterModel>();
        }
    }
}
