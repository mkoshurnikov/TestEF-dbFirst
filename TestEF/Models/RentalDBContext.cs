using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestEF.Models
{
    public partial class RentalDBContext : DbContext
    {
        public RentalDBContext()
        {
        }

        public RentalDBContext(DbContextOptions<RentalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdditionalService> AdditionalServices { get; set; } = null!;
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<FuelType> FuelTypes { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Rent> Rents { get; set; } = null!;
        public virtual DbSet<RentsHistory> RentsHistories { get; set; } = null!;
        public virtual DbSet<UserDriverLicensePhoto> UserDriverLicensePhotos { get; set; } = null!;
        public virtual DbSet<UserIdentificationCodePhoto> UserIdentificationCodePhotos { get; set; } = null!;
        public virtual DbSet<UserPassportPhoto> UserPassportPhotos { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;
        public virtual DbSet<VehicleBrand> VehicleBrands { get; set; } = null!;
        public virtual DbSet<VehicleClassification> VehicleClassifications { get; set; } = null!;
        public virtual DbSet<VehiclePhoto> VehiclePhotos { get; set; } = null!;
        public virtual DbSet<VehicleType> VehicleTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=RentalDB; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalService>(entity =>
            {
                entity.ToTable("AdditionalService");

                entity.HasIndex(e => e.RentId, "IX_AdditionalService_RentId");

                entity.HasIndex(e => e.RentsHistoryId, "IX_AdditionalService_RentsHistoryId");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Rent)
                    .WithMany(p => p.AdditionalServices)
                    .HasForeignKey(d => d.RentId);

                entity.HasOne(d => d.RentsHistory)
                    .WithMany(p => p.AdditionalServices)
                    .HasForeignKey(d => d.RentsHistoryId);
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<FuelType>(entity =>
            {
                entity.ToTable("FuelType");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");
            });

            modelBuilder.Entity<Rent>(entity =>
            {
                entity.ToTable("Rent");

                entity.HasIndex(e => e.CustomerId, "IX_Rent_CustomerId");

                entity.HasIndex(e => e.VehicleId, "IX_Rent_VehicleId");

                entity.Property(e => e.RentAmount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Rents)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Rents)
                    .HasForeignKey(d => d.VehicleId);
            });

            modelBuilder.Entity<RentsHistory>(entity =>
            {
                entity.ToTable("RentsHistory");

                entity.HasIndex(e => e.CustomerId, "IX_RentsHistory_CustomerId");

                entity.HasIndex(e => e.VehicleId, "IX_RentsHistory_VehicleId");

                entity.Property(e => e.RentAmount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RentsHistories)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.RentsHistories)
                    .HasForeignKey(d => d.VehicleId);
            });

            modelBuilder.Entity<UserDriverLicensePhoto>(entity =>
            {
                entity.ToTable("UserDriverLicensePhoto");

                entity.HasIndex(e => e.UserId, "IX_UserDriverLicensePhoto_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDriverLicensePhotos)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserIdentificationCodePhoto>(entity =>
            {
                entity.ToTable("UserIdentificationCodePhoto");

                entity.HasIndex(e => e.UserId, "IX_UserIdentificationCodePhoto_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserIdentificationCodePhotos)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserPassportPhoto>(entity =>
            {
                entity.ToTable("UserPassportPhoto");

                entity.HasIndex(e => e.UserId, "IX_UserPassportPhoto_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPassportPhotos)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.HasIndex(e => e.BrandId, "IX_Vehicle_BrandId");

                entity.HasIndex(e => e.FuelTypeId, "IX_Vehicle_FuelTypeId");

                entity.HasIndex(e => e.LocationId, "IX_Vehicle_LocationId");

                entity.HasIndex(e => e.VehicleClassId, "IX_Vehicle_VehicleClassId");

                entity.HasIndex(e => e.VehicleTypeId, "IX_Vehicle_VehicleTypeId");

                entity.Property(e => e.PricePerDay).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.BrandId);

                entity.HasOne(d => d.FuelType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.FuelTypeId);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.LocationId);

                entity.HasOne(d => d.VehicleClass)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleClassId);

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleTypeId);
            });

            modelBuilder.Entity<VehicleBrand>(entity =>
            {
                entity.ToTable("VehicleBrand");
            });

            modelBuilder.Entity<VehicleClassification>(entity =>
            {
                entity.ToTable("VehicleClassification");
            });

            modelBuilder.Entity<VehiclePhoto>(entity =>
            {
                entity.ToTable("VehiclePhoto");

                entity.HasIndex(e => e.VehicleId, "IX_VehiclePhoto_VehicleId");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.VehiclePhotos)
                    .HasForeignKey(d => d.VehicleId);
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.ToTable("VehicleType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
