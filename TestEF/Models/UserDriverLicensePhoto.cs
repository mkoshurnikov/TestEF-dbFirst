using System;
using System.Collections.Generic;

namespace TestEF.Models
{
    public partial class UserDriverLicensePhoto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public byte[] Photo { get; set; } = null!;
        public string? UserId { get; set; }

        public virtual AspNetUser? User { get; set; }
    }
}
