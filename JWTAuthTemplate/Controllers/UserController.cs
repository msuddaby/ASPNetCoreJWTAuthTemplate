using JWTAuthTemplate.Context;
using JWTAuthTemplate.DTO.Identity;
using JWTAuthTemplate.Extensions;
using JWTAuthTemplate.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthTemplate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserDTO>> Get(string username)
        {
            var user = await _context.Users.Where(u => u.UserName == username)
                
                .Select(x => new UserDTO()
            {
                Id = x.Id,
                Username = x.UserName,
                CreateDate = x.CreateDate,
                Roles = new List<UserRoleDTO>(x.Roles.Select(r => new UserRoleDTO()
                {
                    Role = new RoleDTO()
                    {
                        Id = r.Role.Id,
                        Name = r.Role.Name,
                    }
                })),
            }).FirstOrDefaultAsync();
            
            if (user == null)
            {
                return NotFound("User was not found.");
            }

            return Ok(user);
        }

        [HttpPost("{username}/Roles")]
        public async Task<ActionResult> AddRole(string username, [FromBody] RoleDTO role)
        {
            var user = await _context.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound("The user was not found.");
            }

            var roleExists = await _context.Roles.Where(r => r.Name == role.Name).FirstOrDefaultAsync();
            if (roleExists == null)
            {
                return NotFound("The role was not found.");
            }

            var userRole = new ApplicationUserRole()
            {
                UserId = user.Id,
                RoleId = roleExists.Id,
            };

            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();

            return Ok($"Role {role.Name} was added to {user.UserName}");
        }

        [HttpDelete("{username}/Roles")]
        public async Task<ActionResult> RemoveRole(string username, [FromBody] RoleDTO role)
        {
            var user = await _context.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound("User not found");
            }

            var roleExists = await _context.Roles.Where(r => r.Name == role.Name).FirstOrDefaultAsync();
            if (roleExists == null)
            {
                return NotFound("Role not found");
            }

            var userRole = await _context.UserRoles.Where(ur => ur.UserId == user.Id && ur.RoleId == roleExists.Id).FirstOrDefaultAsync();
            if (userRole == null)
            {
                return NotFound("The specified user is not in the specified role");
            }

            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();

            return Ok($"Role {role.Name} was removed from {user.UserName}");
        }

    }
}
