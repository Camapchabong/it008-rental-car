using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCar.Models
{
    // HANDOVERS (HandoverId, #ContractId, Kind, HandoverAt, Odometer, Condition, Note [?], KeyStatus,
    //            #KeyDrawerId [?], LateFee, ExtraFee, ExtraReason [?], SettleAmount, #StaffId)
    // (ContractId + Kind) UNIQUE
    [Index(nameof(ContractId), nameof(Kind), IsUnique = true)]
    public class Handover
    {
        public int HandoverId { get; set; }
        public int ContractId { get; set; }

        [MaxLength(20)]
        public string Kind { get; set; } = string.Empty;        // Giao xe, Nhận trả
        public DateTime HandoverAt { get; set; }
        public int Odometer { get; set; }
        public string Condition { get; set; } = string.Empty;   // Bình thường, Cần vệ sinh, Hư hỏng
        public string? Note { get; set; }                       // hiện trạng + phụ kiện bàn giao

        // Chìa chính sau khi nhận trả: Tại quầy (kèm ngăn) hoặc Nhân viên giữ
        public string KeyStatus { get; set; } = string.Empty;
        public int? KeyDrawerId { get; set; }

        // Quyết toán (biên bản Giao xe để = 0)
        public decimal LateFee { get; set; }
        public decimal ExtraFee { get; set; }
        public string? ExtraReason { get; set; }                // bắt buộc khi ExtraFee > 0
        public decimal SettleAmount { get; set; }               // > 0 khách trả thêm, < 0 cửa hàng hoàn

        public int StaffId { get; set; }                        // người đang đăng nhập

        // Quan hệ
        public Contract Contract { get; set; } = null!;

        [ForeignKey(nameof(KeyDrawerId))]
        public KeyDrawer? KeyDrawer { get; set; }

        [ForeignKey(nameof(StaffId))]
        public User Staff { get; set; } = null!;

        public List<HandoverPhoto> Photos { get; set; } = new();  // tối đa 6 ảnh

        // Mã hiển thị GN001 (không lưu)
        [NotMapped]
        public string DisplayCode => $"GN{HandoverId:000}";
    }
}
