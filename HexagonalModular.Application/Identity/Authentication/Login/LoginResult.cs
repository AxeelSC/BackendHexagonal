using HexagonalModular.Application.Identity.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.Identity.Authentication.Login
{
    public record LoginResult
    {
        public AuthSessionDto Session { get; }

        public LoginResult(AuthSessionDto session)
        {
            Session = session ?? throw new ArgumentNullException(nameof(session));
        }
    }
}
