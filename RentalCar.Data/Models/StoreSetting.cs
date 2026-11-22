using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models
{
    // STORE_SETTINGS (SettingId, GraceMinutes, MaxLateHours, CarHourFee, BikeHourFee)
    public class StoreSetting
    {
        [Key]
        public int SettingId { get; set; }
        public int GraceMinutes { get; set; } = 60;        // phút ân hạn
        public int MaxLateHours { get; set; } = 6;         // trễ quá mức này thì tính theo ngày
        public decimal CarHourFee { get; set; } = 100000;  // phí trễ / giờ - ô tô
        public decimal BikeHourFee { get; set; } = 20000;  // phí trễ / giờ - xe máy
    }
}
