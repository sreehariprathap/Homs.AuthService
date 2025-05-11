using Homs.AuthService.Application.DTOs;
using Homs.AuthService.Application.Interfaces;
using Homs.AuthService.Domain.Entities;
using Homs.AuthService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Homs.AuthService.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return null;

            return MapToDto(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users.Select(MapToDto);
        }

        public async Task<UserDto> CreateUserAsync(string username, string email, string password)
        {
            // In a real app, you would hash the password here
            var passwordHash = password; // Replace with proper hashing

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return MapToDto(user);
        }

        private static UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
        }
    }
}