using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FaultyAssetTracker.Models;

namespace FaultyAssetTracker.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<FaultyAsset> FaultyAssets { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<InventoryAsset> InventoryAssets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // 👈 required for Identity tables

            modelBuilder.Entity<FaultyAsset>()
                .Property(f => f.RepairCost)
                .HasPrecision(18, 2);
            modelBuilder.Entity<FaultyAsset>()
                .HasIndex(a => a.AssetTag)
                .IsUnique();
            modelBuilder.Entity<InventoryAsset>()
               .HasIndex(a => a.AssetTag)
               .IsUnique();

            modelBuilder.Entity<InventoryAsset>()
                .HasIndex(a => a.SerialNo)
                .IsUnique();

            modelBuilder.Entity<InventoryAsset>()
                .Property(a => a.AssetTag)
                .HasMaxLength(100);

            modelBuilder.Entity<InventoryAsset>()
                .HasData(
                    new InventoryAsset
                    {
                        Id = 1,
                        Category = "Laptop",
                        AssetName = "Dell Latitude 5420",
                        SerialNo = "DL5420-0001",
                        AssetTag = "ASSET-LAP-0001",
                        Branch = "Head Office",
                        Vendor = "Chams Access",
                        CreatedAt = new DateTime(2026, 1, 10, 0, 0, 0, DateTimeKind.Utc)
                    },
                    new InventoryAsset
                    {
                        Id = 2,
                        Category = "POS Terminal",
                        AssetName = "Verifone V200c",
                        SerialNo = "VF200C-7781",
                        AssetTag = "ASSET-POS-0012",
                        Branch = "Ikeja Branch",
                        Vendor = "PFS",
                        CreatedAt = new DateTime(2026, 1, 12, 0, 0, 0, DateTimeKind.Utc)
                    }
                );

        }
    }
}
