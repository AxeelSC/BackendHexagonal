using HexagonalModular.API.DTOs.Auth;
using HexagonalModular.API.Models;
using HexagonalModular.API.Models.Auth;
using HexagonalModular.Application.UseCases.Auth;
using HexagonalModular.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HexagonalModular.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly LoginHandler _loginHandler;
        private readonly RegisterHandler _registerHandler;
        private readonly RefreshTokenHandler _refreshTokenHandler;

        public AuthController(
            LoginHandler loginHandler,
            RegisterHandler registerHandler,
            RefreshTokenHandler refreshTokenHandler)
        {
            _loginHandler = loginHandler;
            _registerHandler = registerHandler;
            _refreshTokenHandler = refreshTokenHandler;
        }

        // Login endpoint
        [HttpPost("login")]
        [ProducesResponseType(typeof(ApiResponse<LoginResponseDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        [ProducesResponseType(typeof(ApiResponse<object>), 401)]
        public async Task<ActionResult<ApiResponse<LoginResponseDto>>> Login([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse<LoginResponseDto>.ErrorResult("Invalid input data"));

            try
            {
                var command = new LoginCommand(request.Email, request.Password);
                var result = await _loginHandler.HandleAsync(command);

                var response = new LoginResponseDto
                {
                    AccessToken = result.AccessToken,
                    RefreshToken = result.RefreshToken,
                    User = new UserResponseDto
                    {
                        Id = result.User.Id.ToString(),
                        Email = result.User.Email,
                        Name = result.User.Name
                    }
                };

                return Ok(ApiResponse<LoginResponseDto>.SuccessResult(response, "Login successful"));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ApiResponse<LoginResponseDto>.ErrorResult(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<LoginResponseDto>.ErrorResult("Internal server error"));
            }
        }

        // Register endpoint
        [HttpPost("register")]
        [ProducesResponseType(typeof(ApiResponse<RegisterResponseDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        public async Task<ActionResult<ApiResponse<RegisterResponseDto>>> Register([FromBody] RegisterRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<RegisterResponseDto>.ErrorResult("Invalid input data"));
            }

            var response = await _registerHandler.HandleAsync(request.Username, request.Email, request.Password);
            return Ok(ApiResponse<RegisterResponseDto>.SuccessResult(response, "Registration successful"));
        }

        // Refresh Token endpoint
        [HttpPost("refresh-token")]
        [ProducesResponseType(typeof(ApiResponse<RefreshTokenResponseDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 400)]
        public async Task<ActionResult<ApiResponse<RefreshTokenResponseDto>>> RefreshToken([FromBody] RefreshTokenRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<RefreshTokenResponseDto>.ErrorResult("Invalid input data"));
            }

            var response = await _refreshTokenHandler.HandleAsync(request.RefreshToken);
            return Ok(ApiResponse<RefreshTokenResponseDto>.SuccessResult(response, "Token refreshed successfully"));
        }
    }
}
