using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexagonalModular.Application.Identity.Common.Dtos;

namespace HexagonalModular.Application.Identity.Authentication.Register
{
    public record RegisterResult
    {
        public AuthSessionDto Session { get; }

        public RegisterResult(AuthSessionDto session)
        {
            Session = session ?? throw new ArgumentNullException(nameof(session));
        }
    }
}
