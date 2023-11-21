using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using UzbekCuisines.Domain.Entities.Customers;
using UzbekCuisines.Domain.Entities.Orders;

namespace UzbekCuisines.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<OrderSummary> OrderSummaries { get; set; }

    DatabaseFacade Database { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
