using Microsoft.EntityFrameworkCore;

namespace WebApiNet.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        #region DbSet
        public DbSet<Merchandise> Products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Orders");
                e.HasKey(o => o.OrderId);
                e.Property(o => o.OrderDate).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.Receiver).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetails");
                e.HasKey(od => new { od.MerchandiseId, od.OrderId });
                e.HasOne(od => od.Merchandise)
                 .WithMany(m => m.OrderDetails)
                 .HasForeignKey(od => od.MerchandiseId)
                 .HasConstraintName("FK_OrderDetail_Merchandise");
                e.HasOne(od => od.Order)
                 .WithMany(o => o.OrderDetails)
                 .HasForeignKey(od => od.OrderId)
                 .HasConstraintName("FK_OrderDetai_Order");
            });
        }
    }
}
