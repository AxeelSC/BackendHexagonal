using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.Identity.Common.Dtos
{
    public record LoggedUserDto
    {
        public Guid Id { get; }
        public string Email { get; }
        public string Name { get; }

        public LoggedUserDto(Guid id, string email, string name)
        {
            Id = id;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
