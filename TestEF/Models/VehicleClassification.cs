using System;
using System.Collections.Generic;

namespace TestEF.Models
{
    public partial class VehicleClassification
    {
        public VehicleClassification()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int VehicleTypeId { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
