using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Core.Shared
{
    public static class Errors
    {
        public static class Authentication
        {
            public static readonly Error InvalidCredentials =
                new("AUTH.INVALID_CREDENTIALS", "Invalid email or password");

            public static readonly Error InvalidRefreshToken =
                new("AUTH.INVALID_REFRESH_TOKEN", "Invalid or expired refresh token");
        }

        public static class Users
        {
            public static readonly Error EmailAlreadyInUse =
                new("USER.EMAIL_ALREADY_IN_USE", "Email already in use.");
        }
    }
}
