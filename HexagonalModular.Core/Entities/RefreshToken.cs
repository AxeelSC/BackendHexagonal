using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Core.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid UserId { get; private set; }
        public string Token { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public bool IsRevoked { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public RefreshToken(Guid userId, string token, DateTime expirationDate)
        {
            UserId = userId;
            Token = token;
            ExpirationDate = expirationDate;
            IsRevoked = false;
        }

        public void Revoke() => IsRevoked = true;
    }

}
