using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models
{
    // KEY_CABINETS (CabinetId, Name)
    public class KeyCabinet
    {
        [Key]
        public int CabinetId { get; set; }
        public string Name { get; set; } = string.Empty;   // Tủ 1 · Ô tô, Tủ 2 · Xe máy, Tủ 3 · Dự phòng

        // Quan hệ
        public List<KeyDrawer> Drawers { get; set; } = new();
    }
}
