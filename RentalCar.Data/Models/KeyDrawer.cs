using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models
{
    // KEY_DRAWERS (DrawerId, #CabinetId, Code)
    // (CabinetId + Code) UNIQUE
    [Index(nameof(CabinetId), nameof(Code), IsUnique = true)]
    public class KeyDrawer
    {
        [Key]
        public int DrawerId { get; set; }
        public int CabinetId { get; set; }

        [MaxLength(10)]
        public string Code { get; set; } = string.Empty;   // 01–20

        // Quan hệ
        public KeyCabinet Cabinet { get; set; } = null!;
    }
}
