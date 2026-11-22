using Microsoft.EntityFrameworkCore;
using RentalCar.Enums;
using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models
{
    // USERS (UserId, FullName, Account [U], PasswordHash, Role, IsActive)
    [Index(nameof(Account), IsUnique = true)]
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Account { get; set; } = string.Empty;       // UNIQUE
        public string PasswordHash { get; set; } = string.Empty;  // đã băm kèm salt
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;                // false = bị khóa
    }
}
