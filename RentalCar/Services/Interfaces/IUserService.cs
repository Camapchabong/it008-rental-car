using RentalCar.Enums;
using RentalCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task UpdateUserAsync(int userId, string fullName, UserRole role, bool isActive);
        Task AddUserAsync(User user);
        Task ChangePasswordAsync(int userId, string newPassword);
    }
}
