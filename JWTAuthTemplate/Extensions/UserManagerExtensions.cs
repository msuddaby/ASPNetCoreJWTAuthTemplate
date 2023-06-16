using System.Security.Claims;
using JWTAuthTemplate.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthTemplate.Extensions
{
    public static class UserManagerExtensions
    {
        public static Task<ApplicationUser?> GetUserWithRolesAsync(this UserManager<ApplicationUser> userManager,
            ClaimsPrincipal user)
        {
            return userManager.Users.Include(u => u.Roles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(x => x.Id == user.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public static Task<ApplicationUser?> GetUserWithRolesAsync(this UserManager<ApplicationUser> userManager,
            string userId)
        {
            return userManager.Users.Include(u => u.Roles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(x => x.Id == userId);
        }

        public static IQueryable<T> IncludeUserRoles<T>(this IQueryable<T> queryable) where T : ApplicationUser
        {
            return queryable.Include(u => u.Roles)
                .ThenInclude(ur => ur.Role);
        }
    }
}
