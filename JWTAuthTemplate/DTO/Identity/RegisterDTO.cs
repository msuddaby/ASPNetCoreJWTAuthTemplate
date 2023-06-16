using System.ComponentModel.DataAnnotations;

namespace JWTAuthTemplate.DTO.Identity
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(16, MinimumLength = 4)]
        public string Password { get; set; } = null!;

        [Required]
        [StringLength(16, MinimumLength = 4)]
        public string ConfirmPassword { get; set; } = null!;

        [Required] [EmailAddress] public string Email { get; set; } = null!;

    }
}
