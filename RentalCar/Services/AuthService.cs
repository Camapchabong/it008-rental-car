using Microsoft.EntityFrameworkCore;
using RentalCar.Data;
using RentalCar.Models;
using RentalCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Services
{
    public class AuthService : IAuthService
    {
        private readonly IDbContextFactory<AppDbContext> _factory;
        public AuthService(IDbContextFactory<AppDbContext> factory)
        {
            _factory = factory;
        }

        // Logic login user
        public async Task<User?> LoginAsync(string username, string password)
        {
            // Tạo DbContext mới từ DbContextFactory
            await using var dbContext = await _factory.CreateDbContextAsync();

            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Account == username && u.IsActive == true);

            // Check Account Exists?
            if (user == null || password != user.PasswordHash)
            {
                return null;
            }

            return user;
        }
    }
}
