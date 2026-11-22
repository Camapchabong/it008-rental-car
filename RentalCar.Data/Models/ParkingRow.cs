using RentalCar.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models
{
    // PARKING_ROWS (RowId, Name, VehicleType, IsLocked)
    public class ParkingRow
    {
        [Key]
        public int RowId { get; set; }
        public string Name { get; set; } = string.Empty;   // Dãy A, Dãy 1...
        public VehicleType VehicleType { get; set; }       // dãy chỉ dành cho 1 loại xe
        public bool IsLocked { get; set; }

        // Quan hệ
        public List<ParkingSpace> Spaces { get; set; } = new();
    }
}
