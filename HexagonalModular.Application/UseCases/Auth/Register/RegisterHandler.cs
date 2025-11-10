using HexagonalModular.Application.DTOs;
using HexagonalModular.Application.Interfaces.Auth;
using HexagonalModular.Application.Interfaces.Security;
using HexagonalModular.Application.Interfaces.User;
using HexagonalModular.Application.Interfaces.Users;
using HexagonalModular.Application.UseCases.Auth.Login;
using HexagonalModular.Core.Entities;
using HexagonalModular.Core.Interfaces__Ports_;
using HexagonalModular.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.UseCases.Auth.Register
{
    public class RegisterHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;

        public RegisterHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IUnitOfWork unitOfWork,
            IAuthService authService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<RegisterResult> HandleAsync(RegisterCommand command)
        {
            if (await _userRepository.ExistsByEmailAsync(command.Email.Value))
                throw new InvalidOperationException("Email already exists");


            var authSession = await _authService.RegisterAndLoginAsync(command);

            //Si en un futuro se necesitan mas campos, se anyadiran en RegisterResult.
            return new RegisterResult(authSession);
        }
    }
}
