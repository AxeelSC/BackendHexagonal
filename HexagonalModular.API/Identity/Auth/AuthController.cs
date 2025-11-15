using HexagonalModular.API.Common;
using HexagonalModular.API.Identity.Auth.Request;
using HexagonalModular.API.Identity.Auth.Responses;
using HexagonalModular.Application.Identity.Authentication.Login;
using HexagonalModular.Application.Identity.Authentication.Register;
using HexagonalModular.Application.Identity.Authentication.Tokens;
using HexagonalModular.Application.Identity.Common.Ports;
using HexagonalModular.Core.Identity.ValueObjects;
using HexagonalModular.Core.Shared;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HexagonalModular.API.Identity.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILoginHandler _loginHandler;
        private readonly IRegisterHandler _registerHandler;
        private readonly IRefreshTokenHandler _refreshTokenHandler;

        public AuthController(
            ILoginHandler loginHandler,
            IRegisterHandler registerHandler,
            IRefreshTokenHandler refreshTokenHandler)
        {
            _loginHandler = loginHandler;
            _registerHandler = registerHandler;
            _refreshTokenHandler = refreshTokenHandler;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(ApiResponse<LoginResponseDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        [ProducesResponseType(typeof(ApiResponse<object>), 401)]
        public async Task<ActionResult<ApiResponse<LoginResponseDto>>> Login([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<LoginResponseDto>.ErrorResult(
                    "INVALID_INPUT",
                    "Invalid input data"
                ));
            }

            var emailVo = Email.Create(request.Email);
            var command = new LoginCommand(emailVo, request.Password);

            var result = await _loginHandler.HandleAsync(command);

            if (result.IsFailure)
            {
                var error = result.Error!;

                if (error.Code == Errors.Authentication.InvalidCredentials.Code)
                {
                    return Unauthorized(ApiResponse<LoginResponseDto>.ErrorResult(
                        error.Code,
                        "Invalid email or password"
                    ));
                }

                return BadRequest(ApiResponse<LoginResponseDto>.ErrorResult(
                    error.Code,
                    error.Message
                ));
            }

            var loginResult = result.Value!;

            var response = new LoginResponseDto
            {
                AccessToken = loginResult.Session.AccessToken,
                RefreshToken = loginResult.Session.RefreshToken,
                User = new UserResponseDto
                {
                    Id = loginResult.Session.User.Id.ToString(),
                    Email = loginResult.Session.User.Email,
                    Name = loginResult.Session.User.Name
                }
            };

            return Ok(ApiResponse<LoginResponseDto>.SuccessResult(
                response,
                "Login successful"
            ));
        }


        public async Task<ActionResult<ApiResponse<RegisterResponseDto>>> Register([FromBody] RegisterRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<RegisterResponseDto>.ErrorResult(
                    "INVALID_INPUT",
                    "Invalid input data"
                ));
            }

            var emailVo = Email.Create(request.Email);
            var registerCommand = new RegisterCommand(request.Username, emailVo, request.Password);

            var result = await _registerHandler.HandleAsync(registerCommand);

            if (result.IsFailure)
            {
                var error = result.Error!;

                if (error.Code == Errors.Users.EmailAlreadyInUse.Code)
                {
                    return BadRequest(ApiResponse<RegisterResponseDto>.ErrorResult(
                        error.Code,
                        error.Message 
                    ));
                }

                return BadRequest(ApiResponse<RegisterResponseDto>.ErrorResult(
                    error.Code,
                    error.Message
                ));
            }

            var registerResult = result.Value!;

            var response = new RegisterResponseDto
            {
                AccessToken = registerResult.Session.AccessToken,
                RefreshToken = registerResult.Session.RefreshToken,
                User = new UserResponseDto
                {
                    Id = registerResult.Session.User.Id.ToString(),
                    Email = registerResult.Session.User.Email,
                    Name = registerResult.Session.User.Name
                }
            };

            return Ok(ApiResponse<RegisterResponseDto>.SuccessResult(
                response,
                "Registration successful"
            ));
        }

        [HttpPost("refresh-token")]
        [ProducesResponseType(typeof(ApiResponse<RefreshTokenResponseDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        [ProducesResponseType(typeof(ApiResponse<object>), 401)]
        public async Task<ActionResult<ApiResponse<RefreshTokenResponseDto>>> RefreshToken(
            [FromBody] RefreshTokenRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<RefreshTokenResponseDto>.ErrorResult(
                    "INVALID_INPUT",
                    "Invalid input data"
                ));
            }

            var command = new RefreshTokenCommand(request.RefreshToken);

            var result = await _refreshTokenHandler.HandleAsync(command);

            if (result.IsFailure)
            {
                var error = result.Error!;

                if (error.Code == Errors.Authentication.InvalidRefreshToken.Code)
                {
                    return Unauthorized(ApiResponse<RefreshTokenResponseDto>.ErrorResult(
                        error.Code,
                        "Invalid or expired refresh token"
                    ));
                }

                return BadRequest(ApiResponse<RefreshTokenResponseDto>.ErrorResult(
                    error.Code,
                    error.Message
                ));
            }

            var refreshResult = result.Value!;

            var response = new RefreshTokenResponseDto
            {
                Token = refreshResult.AccessToken,
                UserId = refreshResult.UserId
            };

            return Ok(ApiResponse<RefreshTokenResponseDto>.SuccessResult(
                response,
                "Token refreshed successfully"
            ));
        }                 
    }
}
