using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.Identity.Authentication.Tokens
{
    public record RefreshTokenResult
    {
        public string AccessToken { get; }
        public string UserId { get; }

        public RefreshTokenResult(string accessToken, string userId)
        {
            AccessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        }
    }
}
