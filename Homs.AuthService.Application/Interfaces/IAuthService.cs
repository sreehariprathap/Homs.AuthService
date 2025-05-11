using Homs.AuthService.Application.DTOs;

namespace Homs.AuthService.Application.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> CreateUserAsync(string username, string email, string password);
    }
}