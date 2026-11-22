using RentalCar.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCar.Models
{
    // PAYMENTS (PaymentId, #ContractId, PaymentType, Amount, Method, PaidAt, #StaffId)
    // Đã ghi thì không sửa / xóa; sai thì ghi thêm giao dịch bù.
    public class Payment
    {
        public int PaymentId { get; set; }
        public int ContractId { get; set; }
        public PaymentType PaymentType { get; set; }   // Đặt cọc, Thu thêm, Hoàn tiền
        public decimal Amount { get; set; }            // luôn dương
        public PaymentMethod Method { get; set; }
        public DateTime PaidAt { get; set; } = DateTime.Now;
        public int StaffId { get; set; }

        // Quan hệ
        public Contract Contract { get; set; } = null!;

        [ForeignKey(nameof(StaffId))]
        public User Staff { get; set; } = null!;

        // Mã hiển thị GD001 (không lưu)
        [NotMapped]
        public string DisplayCode => $"GD{PaymentId:000}";
    }
}
