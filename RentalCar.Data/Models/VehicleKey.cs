using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCar.Models
{
    // VEHICLE_KEYS (#VehicleId, MainKeyStatus, #MainDrawerId [?], #HolderStaffId [?], #HolderContractId [?], #SpareDrawerId [?])
    public class VehicleKey
    {
        [Key]
        public int VehicleId { get; set; }                       // vừa là PK vừa là FK (1-1 với xe)

        // Chưa cập nhật, Tại quầy, Nhân viên giữ, Đã giao khách, Tại xưởng
        public string MainKeyStatus { get; set; } = "Chưa cập nhật";

        public int? MainDrawerId { get; set; }                   // bắt buộc khi Tại quầy
        public int? HolderStaffId { get; set; }                  // bắt buộc khi Nhân viên giữ
        public int? HolderContractId { get; set; }               // bắt buộc khi Đã giao khách
        public int? SpareDrawerId { get; set; }                  // chìa dự phòng (mặc định Tủ 3)

        // Quan hệ
        public Vehicle Vehicle { get; set; } = null!;

        [ForeignKey(nameof(MainDrawerId))]
        public KeyDrawer? MainDrawer { get; set; }

        [ForeignKey(nameof(HolderStaffId))]
        public User? HolderStaff { get; set; }

        [ForeignKey(nameof(HolderContractId))]
        public Contract? HolderContract { get; set; }

        [ForeignKey(nameof(SpareDrawerId))]
        public KeyDrawer? SpareDrawer { get; set; }
    }
}
