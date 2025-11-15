using HexagonalModular.Core.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.Identity.Common.Ports
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(UserDomain user);
    }
}
