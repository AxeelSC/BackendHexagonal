using HexagonalModular.Application.Interfaces.Auth;
using HexagonalModular.Application.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Core.Interfaces__Ports_
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRefreshTokenRepository RefreshTokens { get; }
        Task CommitAsync();
    }
}
