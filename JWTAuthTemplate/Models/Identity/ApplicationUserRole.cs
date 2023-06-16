using Microsoft.AspNetCore.Identity;

namespace JWTAuthTemplate.Models.Identity
{
    public class ApplicationUserRole: IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }

    public interface IApplicationUserRole
    {
        string UserId { get; set; }
        string RoleId { get; set; }
    }
}
