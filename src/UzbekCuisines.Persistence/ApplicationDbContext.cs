
using Microsoft.EntityFrameworkCore;
using UzbekCuisines.Application.Data;
using UzbekCuisines.Domain.Entities.Customers;
using UzbekCuisines.Domain.Entities.Orders;
using UzbekCuisines.Domain.Entities.Products;

namespace UzbekCuisines.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderSummary> OrderSummaries { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<LineItem> LineItems { get; set; }

}
