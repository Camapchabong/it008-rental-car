using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCar.Models
{
    // PARKING_LOGS (LogId, #VehicleId, #SpaceId [?], Action, LoggedAt, #StaffId, Detail [?])
    public class ParkingLog
    {
        [Key]
        public int LogId { get; set; }
        public int VehicleId { get; set; }
        public int? SpaceId { get; set; }
        public string Action { get; set; } = string.Empty;   // Xếp vào ô, Chuyển ô, Lấy ra khỏi ô
        public DateTime LoggedAt { get; set; } = DateTime.Now;
        public int StaffId { get; set; }
        public string? Detail { get; set; }

        // Quan hệ
        public Vehicle Vehicle { get; set; } = null!;
        public ParkingSpace? Space { get; set; }

        [ForeignKey(nameof(StaffId))]
        public User Staff { get; set; } = null!;
    }
}
