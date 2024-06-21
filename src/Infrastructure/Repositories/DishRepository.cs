using Domain.Dishes;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal sealed class DishRepository(ApplicationDbContext context) : IDishRepository
{
    public Task<Dish?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return context.Dishes.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
    }

    public void Insert(Dish dish)
    {
        context.Dishes.Add(dish);
    }

    public void Remove(Dish dish)
    {
        context.Dishes.Remove(dish);
    }

    public void Update(Dish dish)
    {
        context.Dishes.Update(dish);
    }
}
