using BookingManagement.Services.AuthService.Dtos;
using BookingManagement.Services.PersonService.Dtos;

namespace BookingManagement.Services.AuthService
{
    public interface IAuthService
    {
        Task<PersonDto> RegisterAsync(PersonDto input);
        Task<TokenResponseDto> LoginAsync(LoginDto input);
        Task LogoutAsync();
        Task<PersonDto> GetCurrentUserAsync();
        Task<bool> IsUserAuthenticatedAsync();
        Task<bool> IsUserInRoleAsync(string roleName);
        Task<bool> IsUserInAnyRoleAsync(string[] roleNames);
        Task<IEnumerable<string>> GetUserRolesAsync(Guid userId);
        Task<bool> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);
        Task<bool> ResetPasswordAsync(Guid userId, string newPassword);
        Task<bool> SendPasswordResetEmailAsync(string emailAddress);
        Task<bool> ConfirmEmailAsync(Guid userId, string token);
        Task<bool> ResendConfirmationEmailAsync(Guid userId);
        Task<TokenResponseDto> RefreshTokenAsync(RefreshTokenRequestDto requestDto);
    }
}
