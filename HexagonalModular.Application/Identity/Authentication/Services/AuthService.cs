using HexagonalModular.Application.Identity.Authentication.Login;
using HexagonalModular.Application.Identity.Authentication.Register;
using HexagonalModular.Application.Identity.Common.Dtos;
using HexagonalModular.Application.Identity.Common.Persistence;
using HexagonalModular.Application.Identity.Common.Ports;
using HexagonalModular.Application.Identity.Common.Security;
using HexagonalModular.Core.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.Identity.Authentication.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;
        private readonly IIdentityUnitOfWork _unitOfWork;

        public AuthService(
            IJwtTokenGenerator jwtTokenGenerator,
            IRefreshTokenGenerator refreshTokenGenerator,
            IIdentityUnitOfWork unitOfWork)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthSessionDto> CreateAuthSessionAsync(UserDomain userDomain)
        {
            var accessToken = _jwtTokenGenerator.GenerateToken(userDomain);

            var refreshToken = _refreshTokenGenerator.Generate(userDomain.Id);

            await _unitOfWork.RefreshTokens.AddAsync(refreshToken);

            var loggedUser = new LoggedUserDto(
                userDomain.Id,
                userDomain.Email.Value,
                userDomain.Name
            );

            return new AuthSessionDto(
                accessToken,
                refreshToken.Token,
                loggedUser
            );
        }
    }
}
