using System;
using System.Collections.Generic;

namespace TestEF.Models
{
    public partial class VehiclePhoto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public byte[] Photo { get; set; } = null!;
        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; } = null!;
    }
}
