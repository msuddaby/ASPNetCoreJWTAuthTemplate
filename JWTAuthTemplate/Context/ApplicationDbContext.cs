using JWTAuthTemplate.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthTemplate.Context
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(e =>
            {
                e.HasMany(r => r.Roles)
                    .WithOne(u => u.User)
                    .HasForeignKey(u => u.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(e =>
            {
                e.HasMany(u => u.Users)
                    .WithOne(u => u.Role)
                    .HasForeignKey(u => u.RoleId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationUser>().Navigation(e => e.Roles).AutoInclude();
            modelBuilder.Entity<ApplicationUserRole>().Navigation(e => e.Role).AutoInclude();

            
        }
    }
}
