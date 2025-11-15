using System.ComponentModel.DataAnnotations;

namespace HexagonalModular.API.Identity.Auth.Responses
{
    public class RegisterResponseDto
    {
        public string AccessToken { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;
        public UserResponseDto User { get; set; } = default!;
    }
}
