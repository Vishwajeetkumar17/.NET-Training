using LoginAndRoleBasedAccess.Models.DTOs;

namespace LoginAndRoleBasedAccess.Services
{
    public interface IAuthService
    {
        Task<AuthResponse?> SignupAsync(SignupRequest request);
        Task<AuthResponse?> LoginAsync(LoginRequest request);
    }
}
