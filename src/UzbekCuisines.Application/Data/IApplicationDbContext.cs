using Microsoft.EntityFrameworkCore;
using UzbekCuisines.Domain.Entities.Customers;
using UzbekCuisines.Domain.Entities.Orders;

namespace UzbekCuisines.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get; set; }
    DbSet<Order> Orders { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
