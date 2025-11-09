using System.ComponentModel.DataAnnotations;

namespace HexagonalModular.API.Models.Auth
{
    public class RegisterResponseDto
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
