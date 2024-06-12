namespace Domain.RecipeIngredients;
public interface IIngredientRepository
{
    Task<Ingredient?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Ingredient ingredient);
}
