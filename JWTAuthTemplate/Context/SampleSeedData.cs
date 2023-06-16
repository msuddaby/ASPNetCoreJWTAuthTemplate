using JWTAuthTemplate.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthTemplate.Context
{
    public class SampleSeedData
    {
        public static void SeedData(ApplicationDbContext context)
        {
            var passwordHasher = new PasswordHasher<ApplicationUser>();

            ApplicationUser adminUser = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                Email = "admin@example.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                CreateDate = DateTime.UtcNow
            };

            var adminExists = context.Users.Any(u => u.NormalizedUserName == adminUser.NormalizedUserName);
            if (!adminExists)
            {
                var hashedPassword = passwordHasher.HashPassword(adminUser, "Admin123!");
                adminUser.PasswordHash = hashedPassword;

                context.Users.Add(adminUser); ;
            }

            ApplicationUser regularUser = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user",
                NormalizedUserName = "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                Email = "user@example.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                CreateDate = DateTime.UtcNow
            };

            var regularUserExists = context.Users.Any(u => u.NormalizedUserName == regularUser.NormalizedUserName);
            if (!regularUserExists)
            {
                var hashedPassword = passwordHasher.HashPassword(regularUser, "User123!");
                regularUser.PasswordHash = hashedPassword;

                context.Users.Add(regularUser);
            }

            ApplicationRole adminRole = new ApplicationRole()
           {
               ConcurrencyStamp = Guid.NewGuid().ToString(),
               Id = Guid.NewGuid().ToString(),
               Name = "Admin",
               NormalizedName = "ADMIN"
           };

            var adminRoleExists = context.Roles.Any(r => r.NormalizedName == adminRole.NormalizedName);
            if (!adminRoleExists)
            {
                context.Roles.Add(adminRole);

                ApplicationUserRole adminUserRole = new ApplicationUserRole()
                {
                    RoleId = adminRole.Id,
                    UserId = adminUser.Id
                };

                var adminUserRoleExists = context.UserRoles.Any(ur => ur.RoleId == adminUserRole.RoleId && ur.UserId == adminUserRole.UserId);
                if (!adminUserRoleExists)
                {
                    context.UserRoles.Add(adminUserRole);
                }
            }






            context.SaveChanges();

                
        }
    }
}
