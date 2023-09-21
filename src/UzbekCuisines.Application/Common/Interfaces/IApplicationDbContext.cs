using Microsoft.EntityFrameworkCore;
using UzbekCuisines.Domain.Entities;

namespace UzbekCuisines.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Category> Categories { get; }
    DbSet<Food> Foods { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
