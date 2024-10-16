using System.ComponentModel.DataAnnotations;

namespace MvcBlogNoticias.Api.Data.Dto
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "[User Name] >> Campo é obrigatório!")]
        public string? UserName { get; set; }

        //[Required(ErrorMessage = "[IsAdmin] >> Campo é obrigatório!")]
        //public bool IsAdmin { get; set; } = false;

        [EmailAddress]
        [Required(ErrorMessage = "[Email] >> Campo é obrigatório!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "[Password] >> Campo é obrigatório!")]
        public string? Password { get; set; }
    }
}
