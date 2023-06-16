namespace JWTAuthTemplate.DTO.Identity
{
    public class RefreshDTO
    {
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
