using System.ComponentModel.DataAnnotations;

namespace JWTAuthTemplate.DTO.Identity
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required] public string Password { get; set; } = null!;
    }
}
