using Microsoft.EntityFrameworkCore;
using mywebapi.Models;

namespace mywebapi.Data;

public class MyDbContext : DbContext
{
    // Initilize Contructor
    public MyDbContext(DbContextOptions options) : base(options)
    {

    }
    /*
    DbSet
    */

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public DbSet<Order> Order { get; set; }

    public DbSet<OrderDetails> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(e =>
        {
            e.ToTable("Order");
            e.HasKey(row => row.OrderId);
            e.Property(row => row.OrderedDate).HasDefaultValueSql("getutcdate()");
        });

        modelBuilder.Entity<OrderDetails>(e =>
        {
            e.ToTable("OrderDetails");
            e.HasKey(row => new { row.OrderId, row.ProductId });
            e.HasOne(row => row.Order).WithMany(row => row._orderDetails).HasForeignKey(row => row.OrderId);
            e.HasOne(row => row.Product).WithMany(row => row._orderDetails).HasForeignKey(row => row.ProductId);
        });
    }
}