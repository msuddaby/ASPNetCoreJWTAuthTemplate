namespace JWTAuthTemplate.DTO.Identity
{
    public class AuthorizedDTO
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? TokenExpiration { get; set; }
    }
}
