
using Microsoft.EntityFrameworkCore;
using UzbekCuisines.Application.Data;
using UzbekCuisines.Domain.Entities.Customers;
using UzbekCuisines.Domain.Entities.Orders;

namespace UzbekCuisines.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<Customer> Customers {  get; set; }

    public DbSet<Order> Orders {  get; set; }

}
