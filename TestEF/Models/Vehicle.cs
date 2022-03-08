using System;
using System.Collections.Generic;

namespace TestEF.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Rents = new HashSet<Rent>();
            RentsHistories = new HashSet<RentsHistory>();
            VehiclePhotos = new HashSet<VehiclePhoto>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int YearOfManufactured { get; set; }
        public int Mileage { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
        public int FuelTypeId { get; set; }
        public int VehicleTypeId { get; set; }
        public int NumberOfSeats { get; set; }
        public bool AutomaticTransmission { get; set; }
        public int LocationId { get; set; }
        public int VehicleClassId { get; set; }
        public int BrandId { get; set; }

        public virtual VehicleBrand Brand { get; set; } = null!;
        public virtual FuelType FuelType { get; set; } = null!;
        public virtual Location Location { get; set; } = null!;
        public virtual VehicleClassification VehicleClass { get; set; } = null!;
        public virtual VehicleType VehicleType { get; set; } = null!;
        public virtual ICollection<Rent> Rents { get; set; }
        public virtual ICollection<RentsHistory> RentsHistories { get; set; }
        public virtual ICollection<VehiclePhoto> VehiclePhotos { get; set; }
    }
}
