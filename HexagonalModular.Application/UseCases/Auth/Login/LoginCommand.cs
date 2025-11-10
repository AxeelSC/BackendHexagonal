using HexagonalModular.Core.Entities;
using HexagonalModular.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.UseCases.Auth.Login
{
    public record LoginCommand(Email Email, string Password);

}
