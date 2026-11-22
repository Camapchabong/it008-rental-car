using System;
using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models
{
    // HANDOVER_PHOTOS (PhotoId, #HandoverId, FilePath, UploadedAt)
    public class HandoverPhoto
    {
        [Key]
        public int PhotoId { get; set; }
        public int HandoverId { get; set; }
        public string FilePath { get; set; } = string.Empty;   // chỉ lưu đường dẫn file ảnh
        public DateTime UploadedAt { get; set; } = DateTime.Now;

        // Quan hệ
        public Handover Handover { get; set; } = null!;
    }
}
