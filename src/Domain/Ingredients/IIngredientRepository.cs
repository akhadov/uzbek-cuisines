namespace Domain.Ingredients;
public interface IIngredientRepository
{
    Task<Ingredient?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void InsertRange(IEnumerable<Ingredient> ingredients);
}
