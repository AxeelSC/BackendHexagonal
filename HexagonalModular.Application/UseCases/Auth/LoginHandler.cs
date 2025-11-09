using HexagonalModular.Application.Interfaces;
using HexagonalModular.Core.Entities;
using HexagonalModular.Core.Interfaces;
using HexagonalModular.Core.Interfaces__Ports_;
using HexagonalModular.Core.ValueObjects;
using HexagonalModular.Infrastructure.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HexagonalModular.Application.UseCases.Auth
{
    public class LoginHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;

        public LoginHandler(
            IUnitOfWork unitOfWork,
            IPasswordHasher passwordHasher,
            IJwtTokenGenerator tokenGenerator,
            IRefreshTokenGenerator refreshTokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = tokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
        }

        public async Task<LoginResult> HandleAsync(LoginCommand command)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(command.Email)
                ?? throw new UnauthorizedAccessException("Invalid email or password");

            if (!_passwordHasher.Verify(command.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid email or password");

            var accessToken = _jwtTokenGenerator.GenerateToken(user); 

            var refreshToken = _refreshTokenGenerator.Generate(user.Id);
       
            await _unitOfWork.RefreshTokens.AddAsync(refreshToken);

            await _unitOfWork.CommitAsync();

            var loggedUser = new LoggedUserDto(user.Id, user.Email.Value, user.Name);

            return new LoginResult(accessToken, refreshToken.Token, loggedUser);
        }
    }
}
