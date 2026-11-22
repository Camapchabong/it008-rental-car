using Microsoft.EntityFrameworkCore;
using RentalCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        public DbSet<StoreSetting> StoreSettings => Set<StoreSetting>();
        public DbSet<VehicleInsurance> VehicleInsurances => Set<VehicleInsurance>();
        public DbSet<Maintenance> Maintenances => Set<Maintenance>();
        public DbSet<ParkingRow> ParkingRows => Set<ParkingRow>();
        public DbSet<ParkingSpace> ParkingSpaces => Set<ParkingSpace>();
        public DbSet<ParkingLog> ParkingLogs => Set<ParkingLog>();
        public DbSet<KeyCabinet> KeyCabinets => Set<KeyCabinet>();
        public DbSet<KeyDrawer> KeyDrawers => Set<KeyDrawer>();
        public DbSet<VehicleKey> VehicleKeys => Set<VehicleKey>();
        public DbSet<KeyLog> KeyLogs => Set<KeyLog>();
        public DbSet<Contract> Contracts => Set<Contract>();
        public DbSet<Handover> Handovers => Set<Handover>();
        public DbSet<HandoverPhoto> HandoverPhotos => Set<HandoverPhoto>();
        public DbSet<Payment> Payments => Set<Payment>();

    }
}
