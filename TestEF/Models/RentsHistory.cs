using System;
using System.Collections.Generic;

namespace TestEF.Models
{
    public partial class RentsHistory
    {
        public RentsHistory()
        {
            AdditionalServices = new HashSet<AdditionalService>();
        }

        public int Id { get; set; }
        public string? CustomerId { get; set; }
        public int? VehicleId { get; set; }
        public DateTime RentStartDay { get; set; }
        public DateTime RentEndDay { get; set; }
        public decimal RentAmount { get; set; }

        public virtual AspNetUser? Customer { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
        public virtual ICollection<AdditionalService> AdditionalServices { get; set; }
    }
}
