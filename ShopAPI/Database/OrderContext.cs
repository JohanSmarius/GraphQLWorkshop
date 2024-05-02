using Microsoft.EntityFrameworkCore;
using ShopAPI.Model;

namespace ShopAPI.Database;

public class OrderContext : DbContext
{
    public DbSet<Order>? Orders { get; set; }
    
    public DbSet<OrderLine>? Orderlines { get; set; }
    public DbSet<Customer>? Customers { get; set; }
    
    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Customer>().HasData(
            new Customer() { Id = 1, Name = "Customer 1"},
            new Customer() { Id = 2, Name = "Customer 2"}
        );
        modelBuilder.Entity<Product>().HasData(
            new Product() { Id = 1, Name = "Product 1", EanCode = "123439900", Price = 100, Weight = 300 },
            new Product() { Id = 2, Name = "Product 2", EanCode = "37034034039", Price = 200, Weight = 700}
        );
        modelBuilder.Entity<Order>().HasData(
            new List<Order>()
            {
                new()
                {
                    Id = 1, CustomerId = 1, OrderTime = DateTime.Now
                },
                new()
                {
                    Id = 2, CustomerId = 2, OrderTime = DateTime.Now
                }
            }
        );
        modelBuilder.Entity<OrderLine>().HasData(
            new OrderLine() {Id = 2, OrderId = 1, ProductId = 1, Quantity = 2, DiscountPercentage = 0},
            new OrderLine() {Id = 1, OrderId = 1, ProductId = 2, Quantity = 5, DiscountPercentage = 5},
            new OrderLine() {Id = 3, OrderId = 2, ProductId = 1, Quantity = 7, DiscountPercentage = 0},
            new OrderLine() {Id = 4, OrderId = 2, ProductId = 2, Quantity = 10, DiscountPercentage = 20.0m}
        );
    }
}