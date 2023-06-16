using Microsoft.AspNetCore.Identity;

namespace JWTAuthTemplate.Models.Identity
{
    public class ApplicationRole: IdentityRole<string>
    {
        public List<ApplicationUserRole> Users { get; set; } = new();
    }
}
