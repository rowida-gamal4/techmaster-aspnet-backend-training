using TrainingCenter.Common;
using TrainingCenter.DTOs.Auth;

namespace TrainingCenter.Services.IServices
{
    public interface IAuthService
    {
        Task<GeneralResponseDto<AuthResponse>>LoginAsync(LoginRequest request );
        Task<GeneralResponseDto<RegisterResponse>>RegisterAsync(RegisterRequest request );
        Task<GeneralResponseDto<CurrentUserResponse>>GetCurrentUser(int userId );
        Task<GeneralResponseDto<string>>ChangePasswordAsync(int userId, ChangePasswordRequest request);
        Task<GeneralResponseDto<AuthResponse>> RefreshTokenAsync(RefreshTokenRequest request);

        Task LogoutAsync(int userId);
    }
}