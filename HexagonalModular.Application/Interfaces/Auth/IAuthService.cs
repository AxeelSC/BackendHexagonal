using HexagonalModular.Application.UseCases.Auth;
using HexagonalModular.Application.UseCases.Auth.Login;
using HexagonalModular.Application.UseCases.Auth.RefreshToken;
using HexagonalModular.Application.UseCases.Auth.Register;
using HexagonalModular.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<LoginResult> LoginAsync(LoginCommand command);

        Task<RegisterResult> RegisterAndLoginAsync(RegisterCommand command);

        //Task<ExternalLoginResult> ExternalLoginAsync(ExternalLoginCommand command);
        //
        //Task<MfaChallengeResult> StartMfaChallengeAsync(MfaChallengeCommand command);
        //
        //Task<MfaVerifyResult> VerifyMfaCodeAsync(MfaVerifyCommand command);
        //
        //Task RequestEmailVerificationAsync(RequestEmailVerificationCommand command);
        //
        //Task<EmailVerificationResult> VerifyEmailAsync(VerifyEmailCommand command);
        //
        //Task<AuthSession> RefreshTokenAsync(RefreshTokenCommand command);
        //
        //Task RequestPasswordResetAsync(PasswordResetRequestCommand command);
        //Task<PasswordResetResult> ResetPasswordAsync(PasswordResetCommand command);

    }
}
