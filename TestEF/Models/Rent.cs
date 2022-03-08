using System;
using System.Collections.Generic;

namespace TestEF.Models
{
    public partial class Rent
    {
        public Rent()
        {
            AdditionalServices = new HashSet<AdditionalService>();
        }

        public int Id { get; set; }
        public string? CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime RentStartDay { get; set; }
        public DateTime RentEndDay { get; set; }
        public decimal RentAmount { get; set; }

        public virtual AspNetUser? Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; } = null!;
        public virtual ICollection<AdditionalService> AdditionalServices { get; set; }
    }
}
