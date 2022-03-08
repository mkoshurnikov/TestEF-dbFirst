using System;
using System.Collections.Generic;

namespace TestEF.Models
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            Rents = new HashSet<Rent>();
            RentsHistories = new HashSet<RentsHistory>();
            UserDriverLicensePhotos = new HashSet<UserDriverLicensePhoto>();
            UserIdentificationCodePhotos = new HashSet<UserIdentificationCodePhoto>();
            UserPassportPhotos = new HashSet<UserPassportPhoto>();
            Roles = new HashSet<AspNetRole>();
        }

        public string Id { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Adress { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
        public virtual ICollection<RentsHistory> RentsHistories { get; set; }
        public virtual ICollection<UserDriverLicensePhoto> UserDriverLicensePhotos { get; set; }
        public virtual ICollection<UserIdentificationCodePhoto> UserIdentificationCodePhotos { get; set; }
        public virtual ICollection<UserPassportPhoto> UserPassportPhotos { get; set; }

        public virtual ICollection<AspNetRole> Roles { get; set; }
    }
}
