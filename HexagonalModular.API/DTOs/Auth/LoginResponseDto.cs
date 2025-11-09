using HexagonalModular.API.DTOs.Auth;

namespace HexagonalModular.API.Models.Auth
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;
        public UserResponseDto User { get; set; } = default!;
    }
}
