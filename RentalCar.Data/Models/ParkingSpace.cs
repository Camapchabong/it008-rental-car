using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCar.Models
{
    // PARKING_SPACES (SpaceId, #RowId, Code, IsLocked, #CurrentVehicleId [U, ?])
    // (RowId + Code) UNIQUE
    [Index(nameof(RowId), nameof(Code), IsUnique = true)]
    [Index(nameof(CurrentVehicleId), IsUnique = true)]
    public class ParkingSpace
    {
        [Key]
        public int SpaceId { get; set; }
        public int RowId { get; set; }

        [MaxLength(10)]
        public string Code { get; set; } = string.Empty;   // A01, D1-05...
        public bool IsLocked { get; set; }                 // chỉ khóa được khi ô trống
        public int? CurrentVehicleId { get; set; }         // UNIQUE, null = ô trống

        // Quan hệ
        public ParkingRow Row { get; set; } = null!;

        [ForeignKey(nameof(CurrentVehicleId))]
        public Vehicle? CurrentVehicle { get; set; }
    }
}
