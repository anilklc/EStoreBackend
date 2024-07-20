using EStoreBackend.Application.DTOs.User;
using EStoreBackend.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser user);
        Task<bool> AddRole(string email,string UserRole);
        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime tokenDate, int refreshTokenTime);
        Task UpdatePasswordAsync(string userId, string newPassword);
        Task<List<ListUser>> GetAllUsersAsync();
        Task<ListUser> GetUserByUsernameAsync(string userName);
        Task<ListUser> GetUserByUserId(string Id);
        Task DeleteUserAsync(string Id);

    }
}
