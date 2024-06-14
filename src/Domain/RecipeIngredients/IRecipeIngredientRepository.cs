namespace Domain.RecipeIngredients;
public interface IRecipeIngredientRepository
{
    Task<RecipeIngredient?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(RecipeIngredient recipeIngredient);

    void Remove(RecipeIngredient recipeIngredient);
}
