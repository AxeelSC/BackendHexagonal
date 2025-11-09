using HexagonalModular.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Infrastructure.Auth
{
    public interface IRefreshTokenGenerator
    {
        public RefreshToken Generate(Guid userId);
    }
}
