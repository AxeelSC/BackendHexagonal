using HexagonalModular.Application.Identity.Authentication.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.Identity.Common.Ports
{
    public interface IRegisterHandler
    {
        Task<Result<RegisterResult>> HandleAsync(RegisterCommand command);
    }
}
