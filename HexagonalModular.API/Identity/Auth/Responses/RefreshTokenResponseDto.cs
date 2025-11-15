namespace HexagonalModular.API.Identity.Auth.Responses
{
    public class RefreshTokenResponseDto
    {
        public string Token { get; set; } = default!;
        public string UserId { get; set; } = default!;
    }
}
