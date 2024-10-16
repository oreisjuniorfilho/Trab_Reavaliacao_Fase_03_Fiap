using Microsoft.AspNetCore.Identity;

namespace AspnJwt_RefreshToken.Models;

public class ApplicationUser : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}
