using Microsoft.EntityFrameworkCore;
using RentalCar.Data;
using RentalCar.Enums;
using RentalCar.Models;
using RentalCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Services
{
    public class UserService : IUserService
    {
        private readonly IDbContextFactory<AppDbContext> _factory;

        public UserService(IDbContextFactory<AppDbContext> factory)
        {
            _factory = factory;
        }

        // Lấy toàn bộ tài khoản, chỉ đọc nên dùng AsNoTracking
        public async Task<List<User>> GetAllUsersAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Users.AsNoTracking()
                                 .OrderBy(u => u.UserId)
                                 .ToListAsync();
        }

        // Update information account
        public async Task UpdateUserAsync(int userId, string fullName, UserRole role, bool isActive)
        {
            await using var db = await _factory.CreateDbContextAsync();

            var user = await db.Users.FindAsync(userId);

            if (user == null)
                return;

            user.FullName = fullName;
            user.Role = role;
            user.IsActive = isActive;

            await db.SaveChangesAsync();
        }

        // Add new account
        public async Task AddUserAsync(User user)
        {
            await using var db = await _factory.CreateDbContextAsync();
            db.Users.Add(user);
            await db.SaveChangesAsync();
        }

        // Change password
        public async Task ChangePasswordAsync(int userId, string newPassword)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var user = await db.Users.FindAsync(userId);
            if (user == null)
                return;
            user.PasswordHash = newPassword;
            await db.SaveChangesAsync();
        }
    }
}
