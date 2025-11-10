using HexagonalModular.Application.Interfaces.Auth;
using HexagonalModular.Application.Interfaces.Users;
using HexagonalModular.Core.Interfaces__Ports_;
using HexagonalModular.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public IUserRepository Users { get; }
        public IRefreshTokenRepository RefreshTokens { get; }

        public UnitOfWork(AppDbContext dbContext, IUserRepository users, IRefreshTokenRepository refreshTokens)
        {
            _dbContext = dbContext;
            Users = users;
            RefreshTokens = refreshTokens;
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
