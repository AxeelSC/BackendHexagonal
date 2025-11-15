using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using HexagonalModular.Core.Identity.Entities;

namespace HexagonalModular.Application.Identity.Common.Ports
{
    public interface IUserRepository
    {
        Task<UserDomain> GetByIdAsync(Guid id);
        Task<UserDomain> GetByEmailAsync(string email);
        Task AddAsync(UserDomain usuario);
        Task<bool> ExistsByEmailAsync(string email);

    }
}

