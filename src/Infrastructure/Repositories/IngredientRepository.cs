using Domain.RecipeIngredients;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal sealed class IngredientRepository(ApplicationDbContext context) : IIngredientRepository
{
    public Task<Ingredient?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return context.Ingredients.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    public void InsertRange(IEnumerable<Ingredient> ingredients)
    {
        context.Ingredients.AddRange(ingredients);
    }
}
