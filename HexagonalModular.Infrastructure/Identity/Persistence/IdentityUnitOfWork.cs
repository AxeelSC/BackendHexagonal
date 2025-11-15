using HexagonalModular.Application.Identity.Common.Persistence;
using HexagonalModular.Application.Identity.Common.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Infrastructure.Identity.Persistence
{
    public class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public IUserRepository Users { get; }
        public IRefreshTokenRepository RefreshTokens { get; }

        public IdentityUnitOfWork(AppDbContext dbContext, IUserRepository users, IRefreshTokenRepository refreshTokens)
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
