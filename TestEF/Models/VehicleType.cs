using System;
using System.Collections.Generic;

namespace TestEF.Models
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
