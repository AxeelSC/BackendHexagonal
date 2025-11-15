using HexagonalModular.Application.Identity.Authentication.Register;
using HexagonalModular.Application.Identity.Common.Persistence;
using HexagonalModular.Application.Identity.Common.Ports;
using HexagonalModular.Application.Identity.Common.Security;
using HexagonalModular.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HexagonalModular.Application.Identity.Authentication.Login
{
    public class LoginHandler : ILoginHandler
    {
        private readonly IAuthService _authService;
        private readonly IIdentityUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        public LoginHandler(
             IIdentityUnitOfWork unitOfWork,
             IPasswordHasher passwordHasher,
             IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _authService = authService;
        }

        public async Task<Result<LoginResult>> HandleAsync(LoginCommand command)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(command.Email.Value);

            if (user is null || !_passwordHasher.Verify(command.Password, user.PasswordHash))
                return Result<LoginResult>.Failure(Errors.Authentication.InvalidCredentials);

            var session = await _authService.CreateAuthSessionAsync(user);

            await _unitOfWork.CommitAsync();

            return Result<LoginResult>.Success(new LoginResult(session));
        }
    }
}

