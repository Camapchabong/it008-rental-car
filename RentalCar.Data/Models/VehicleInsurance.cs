using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models
{
    // VEHICLE_INSURANCES (InsuranceId, #VehicleId, InsuranceKind, Provider, PolicyNo, StartDate [?], EndDate, Fee)
    // (VehicleId + InsuranceKind) UNIQUE
    [Index(nameof(VehicleId), nameof(InsuranceKind), IsUnique = true)]
    public class VehicleInsurance
    {
        [Key]
        public int InsuranceId { get; set; }
        public int VehicleId { get; set; }

        [MaxLength(20)]
        public string InsuranceKind { get; set; } = string.Empty;  // TNDS, Vật chất
        public string Provider { get; set; } = string.Empty;
        public string PolicyNo { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }                   // bắt buộc với TNDS
        public DateTime EndDate { get; set; }
        public decimal Fee { get; set; }                           // không âm

        // Quan hệ
        public Vehicle Vehicle { get; set; } = null!;
    }
}
