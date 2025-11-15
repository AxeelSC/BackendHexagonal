using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.Identity.Common.Dtos
{
    public record AuthSessionDto
    {
        public string AccessToken { get; }
        public string RefreshToken { get; }
        public LoggedUserDto User { get; }

        public AuthSessionDto(string accessToken, string refreshToken, LoggedUserDto user)
        {
            AccessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
            RefreshToken = refreshToken ?? throw new ArgumentNullException(nameof(refreshToken));
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}
