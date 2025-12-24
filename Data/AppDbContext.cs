using Coffee_POS.Models;
using Microsoft.EntityFrameworkCore;

namespace Coffee_POS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<PaymentRecord> PaymentRecords { get; set; }
        public DbSet<OrderReject> OrderRejects { get; set; }
        public DbSet<TaxSetting> TaxSettings { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<AssetCategory> AssetCategorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // Product → Category
            // =========================
            modelBuilder.Entity<Product>()
                        .HasOne(p => p.Category)
                        .WithMany(c => c.Products)
                        .HasForeignKey(p => p.CategoryId);

            // =========================
            // Order → User
            // =========================
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId);

            // =========================
            // Order → Product  ⭐⭐⭐ (IMPORTANT)
            // =========================
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Product)
                .WithMany()
                .HasForeignKey(o => o.ProductId);

            // =========================
            // Review → User
            // =========================
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AssetCategory>().ToTable("asset_categories");

            modelBuilder.Entity<ProductSize>()
                        .HasOne(ps => ps.Product)
                        .WithMany(p => p.ProductSizes)
                        .HasForeignKey(ps => ps.ProductId);

        }
    }
}
