using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.UseCases.Auth
{
    public record RegisterCommand(string Name, string Email, string Password);

}
