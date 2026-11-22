using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCar.Models
{
    // MAINTENANCES (MaintenanceId, #VehicleId, StartedAt, Content, #StartedBy, CompletedAt [?], ActualCost [?],
    //               OdometerAt [?], Result [?], #CompletedBy [?])
    public class Maintenance
    {
        public int MaintenanceId { get; set; }
        public int VehicleId { get; set; }
        public DateTime StartedAt { get; set; }
        public string Content { get; set; } = string.Empty;   // nội dung công việc + nơi làm
        public int StartedBy { get; set; }                    // nhân viên đưa xe đi

        // Hoàn tất (CompletedAt trống = xe đang bảo dưỡng)
        public DateTime? CompletedAt { get; set; }
        public decimal? ActualCost { get; set; }
        public int? OdometerAt { get; set; }
        public string? Result { get; set; }
        public int? CompletedBy { get; set; }                 // nhân viên nhận xe về

        // Quan hệ
        public Vehicle Vehicle { get; set; } = null!;

        [ForeignKey(nameof(StartedBy))]
        public User StartedByUser { get; set; } = null!;

        [ForeignKey(nameof(CompletedBy))]
        public User? CompletedByUser { get; set; }

        // Mã hiển thị BD001 (không lưu)
        [NotMapped]
        public string DisplayCode => $"BD{MaintenanceId:000}";
    }
}
