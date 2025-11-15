using HexagonalModular.Core.Identity.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.Identity.Authentication.Login
{
    public record LoginCommand(Email Email, string Password);

}
