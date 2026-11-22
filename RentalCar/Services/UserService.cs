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
    public class UserService : IUserService
    {
        private readonly IDbContextFactory<AppDbContext> _factory;

        public UserService(IDbContextFactory<AppDbContext> factory)
        {
            _factory = factory;
        }

        // Lấy toàn bộ tài khoản, chỉ đọc nên dùng AsNoTracking
        public async Task<List<User>> GetAllAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Users.AsNoTracking()
                                 .OrderBy(u => u.UserId)
                                 .ToListAsync();
        }
    }
}
