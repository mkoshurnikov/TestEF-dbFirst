using System;
using System.Collections.Generic;

namespace TestEF.Models
{
    public partial class Location
    {
        public Location()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Adress { get; set; } = null!;

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
