using HexagonalModular.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.UseCases.Auth
{
    public record LoginResult(string AccessToken,string RefreshToken, LoggedUserDto User);
    public record LoggedUserDto(Guid Id, string Email, string? Name);
}
