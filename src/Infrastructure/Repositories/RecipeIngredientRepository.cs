using Domain.RecipeIngredients;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal sealed class RecipeIngredientRepository(ApplicationDbContext context) : IRecipeIngredientRepository
{
    public Task<RecipeIngredient?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return context.RecipeIngredients.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public void Insert(RecipeIngredient recipeIngredient)
    {
        context.RecipeIngredients.Add(recipeIngredient);
    }
}
