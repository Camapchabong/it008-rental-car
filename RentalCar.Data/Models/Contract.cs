using RentalCar.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCar.Models
{
    // CONTRACTS (ContractId, #CustomerId, #VehicleId, StartAt, EndAt, DailyRate, Days, Deposit, PaymentMethod,
    //            Status, Note [?], CancelReason [?], #CreatedBy, #UpdatedBy [?], #CancelledBy [?], Version)
    public class Contract
    {
        public int ContractId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }

        // Lịch thuê (tối thiểu 24 giờ)
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

        // Tiền
        public decimal DailyRate { get; set; }        // đơn giá chốt lúc lập hợp đồng
        public int Days { get; set; }                 // làm tròn lên, tối thiểu 1
        public decimal Deposit { get; set; }          // tổng tiền cọc đã nhận
        public PaymentMethod PaymentMethod { get; set; }

        public ContractStatus Status { get; set; } = ContractStatus.New;
        public string? Note { get; set; }
        public string? CancelReason { get; set; }     // bắt buộc khi Đã hủy

        // Người thao tác
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? CancelledBy { get; set; }

        [ConcurrencyCheck]
        public int Version { get; set; }

        // Quan hệ
        public Customer Customer { get; set; } = null!;
        public Vehicle Vehicle { get; set; } = null!;

        [ForeignKey(nameof(CreatedBy))]
        public User CreatedByUser { get; set; } = null!;

        [ForeignKey(nameof(UpdatedBy))]
        public User? UpdatedByUser { get; set; }

        [ForeignKey(nameof(CancelledBy))]
        public User? CancelledByUser { get; set; }

        public List<Handover> Handovers { get; set; } = new();
        public List<Payment> Payments { get; set; } = new();

        // ===== Tính khi cần, không lưu =====
        [NotMapped]
        public decimal RentalAmount => DailyRate * Days;

        // HD260901 = HD + yyMM của StartAt + ContractId
        [NotMapped]
        public string DisplayCode => $"HD{StartAt:yyMM}{ContractId:00}";
    }
}
