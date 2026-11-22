using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCar.Models
{
    // CUSTOMERS (CustomerId, FullName, Phone, Email [?], BirthDate [?], IdentityNumber [U], Address [?],
    //            LicenseClass, LicenseNumber [?], LicenseExpiry [?], Note [?])
    [Index(nameof(IdentityNumber), IsUnique = true)]
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;           // 10 số, bắt đầu bằng 0
        public string? Email { get; set; }
        public DateTime? BirthDate { get; set; }

        [MaxLength(12)]
        public string IdentityNumber { get; set; } = string.Empty;  // CCCD 12 số, UNIQUE

        public string? Address { get; set; }
        public string LicenseClass { get; set; } = string.Empty;    // A1, A, B1, B, B2, C, Khác
        public string? LicenseNumber { get; set; }
        public DateTime? LicenseExpiry { get; set; }
        public string? Note { get; set; }

        // Quan hệ
        public List<Contract> Contracts { get; set; } = new();

        // Mã hiển thị KH001 (không lưu)
        [NotMapped]
        public string DisplayCode => $"KH{CustomerId:000}";
    }
}
