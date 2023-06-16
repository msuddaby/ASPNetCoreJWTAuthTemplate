using Microsoft.AspNetCore.Identity;

namespace JWTAuthTemplate.Models.Identity
{
    public class ApplicationUser: IdentityUser<string>
    {
        public DateTime CreateDate { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public List<ApplicationUserRole> Roles { get; set; } = new();
    }
}
