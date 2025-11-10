using HexagonalModular.Application.Interfaces.Auth;
using HexagonalModular.Application.Interfaces.Security;
using HexagonalModular.Core.Entities;
using HexagonalModular.Core.Interfaces;
using HexagonalModular.Core.Interfaces__Ports_;
using HexagonalModular.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HexagonalModular.Application.UseCases.Auth.Login
{
    public class LoginHandler
    {
        private readonly IAuthService _authService;

        public LoginHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginResult> HandleAsync(LoginCommand command)
        {
            return await _authService.LoginAsync(command);
        }
    }
}
