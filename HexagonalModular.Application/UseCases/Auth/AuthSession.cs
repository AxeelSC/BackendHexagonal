using HexagonalModular.Application.UseCases.Auth.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.UseCases.Auth
{
    public record AuthSession(string AccessToken, string RefreshToken, LoggedUserModel User);
}
