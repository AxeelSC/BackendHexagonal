using System.ComponentModel.DataAnnotations;

namespace HexagonalModular.API.Identity.Auth.Request
{
    public class RefreshTokenRequestDto
    {
        [Required(ErrorMessage = "Refresh token is required")]
        public string RefreshToken { get; set; }
    }
}
