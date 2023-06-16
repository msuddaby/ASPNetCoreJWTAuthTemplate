namespace JWTAuthTemplate.DTO.Identity
{
    public class UserRoleDTO
    {
        public UserDTO User { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public RoleDTO Role { get; set; } = null!;
        public string RoleId { get; set; } = null!;
    }
}
