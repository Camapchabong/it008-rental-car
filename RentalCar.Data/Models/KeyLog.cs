using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCar.Models
{
    // KEY_LOGS (LogId, #VehicleId, Description, LoggedAt, #StaffId)
    public class KeyLog
    {
        [Key]
        public int LogId { get; set; }
        public int VehicleId { get; set; }
        public string Description { get; set; } = string.Empty;   // chìa chính đổi nơi giữ thế nào
        public DateTime LoggedAt { get; set; } = DateTime.Now;
        public int StaffId { get; set; }

        // Quan hệ
        public Vehicle Vehicle { get; set; } = null!;

        [ForeignKey(nameof(StaffId))]
        public User Staff { get; set; } = null!;
    }
}
