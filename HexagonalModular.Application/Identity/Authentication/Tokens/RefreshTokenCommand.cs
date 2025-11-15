using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.Identity.Authentication.Tokens
{
    public record RefreshTokenCommand(string RefreshToken);
}
