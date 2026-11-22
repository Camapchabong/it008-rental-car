using Microsoft.EntityFrameworkCore;
using RentalCar.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCar.Models
{
    // VEHICLES (VehicleId, Plate [U], VehicleType, BodyType [?], Brand, ModelName, Year, Color [?], Seats,
    //           Transmission, DailyRate, Odometer, Status, ImagePath [?], FuelType, EngineCc, PowerKw,
    //           DriveType, VIN [?], LastMaintenanceDate [?], NextMaintenanceDate [?], NextMaintenanceKm [?],
    //           MaintenanceNote [?], Version)
    [Index(nameof(Plate), IsUnique = true)]
    public class Vehicle
    {
        public int VehicleId { get; set; }

        [MaxLength(20)]
        public string Plate { get; set; } = string.Empty;          // UNIQUE (bỏ qua . - khoảng trắng khi so)
        public VehicleType VehicleType { get; set; }
        public string? BodyType { get; set; }                      // Sedan, SUV, MPV, Hatchback, Bán tải; xe máy để trống

        // Thông tin chung
        public string Brand { get; set; } = string.Empty;
        public string ModelName { get; set; } = string.Empty;
        public int Year { get; set; }
        public string? Color { get; set; }
        public int Seats { get; set; }                             // 1–50; xe máy là 2
        public string Transmission { get; set; } = string.Empty;   // hộp số

        // Giá, số km, trạng thái
        public decimal DailyRate { get; set; }                     // > 0
        public int Odometer { get; set; }                          // không bao giờ giảm
        public VehicleStatus Status { get; set; } = VehicleStatus.Available;
        public string? ImagePath { get; set; }                     // vd: images/vehicles/C01.jpg

        // Thông số kỹ thuật
        public string FuelType { get; set; } = string.Empty;       // Xăng, Điện
        public int EngineCc { get; set; }
        public decimal PowerKw { get; set; }
        public string DriveType { get; set; } = string.Empty;      // xe máy: Không áp dụng
        public string? VIN { get; set; }

        // Kế hoạch bảo dưỡng
        public DateTime? LastMaintenanceDate { get; set; }
        public DateTime? NextMaintenanceDate { get; set; }
        public int? NextMaintenanceKm { get; set; }
        public string? MaintenanceNote { get; set; }

        [ConcurrencyCheck]
        public int Version { get; set; }                           // tăng mỗi lần sửa

        // Quan hệ
        public VehicleKey? Key { get; set; }                       // mỗi xe đúng 1 hồ sơ chìa
        public List<VehicleInsurance> Insurances { get; set; } = new();
        public List<Maintenance> Maintenances { get; set; } = new();
        public List<Contract> Contracts { get; set; } = new();

        // Mã hiển thị C01 (không lưu)
        [NotMapped]
        public string DisplayCode => $"C{VehicleId:00}";
    }
}
