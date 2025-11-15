using HexagonalModular.Application.Identity.Authentication.Login;
using HexagonalModular.Application.Identity.Authentication.Register;
using HexagonalModular.Application.Identity.Common.Dtos;
using HexagonalModular.Core.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Application.Identity.Common.Ports
{
    public interface IAuthService
    {
        Task<AuthSessionDto> CreateAuthSessionAsync(UserDomain user);

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
