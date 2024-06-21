namespace Domain.Recipes;
public interface IRecipeRepository
{
    Task<Recipe?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Recipe recipe);

    void Remove(Recipe recipe);
}
