using System;
using System.Collections.Generic;

namespace TestEF.Models
{
    public partial class AdditionalService
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int? RentId { get; set; }
        public int? RentsHistoryId { get; set; }

        public virtual Rent? Rent { get; set; }
        public virtual RentsHistory? RentsHistory { get; set; }
    }
}
