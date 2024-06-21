using Domain.Recipes;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal sealed class RecipeRepository(ApplicationDbContext context) : IRecipeRepository
{
    public Task<Recipe?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return context.Recipes.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public void Insert(Recipe recipe)
    {
        context.Recipes.Add(recipe);
    }

    public void Remove(Recipe recipe)
    {
        context.Recipes.Remove(recipe);
    }

    public void Update(Recipe recipe)
    {
        context.Recipes.Update(recipe);
    }
}
