using SharedKernel;

namespace Domain.Ingredients;
public sealed class Ingredient : Entity
{
    private Ingredient(Guid id, Guid recipeId, Name name, decimal amount, Unit unit)
    {
        Id = id;
        RecipeId = recipeId;
        Name = name;
        Amount = amount;
        Unit = unit;
    }

    private Ingredient() { }

    public Guid Id { get; private set; }

    public Guid RecipeId { get; private set; }

    public Name Name { get; private set; }

    public decimal Amount { get; private set; }

    public Unit Unit { get; private set; }

    internal static Result<Ingredient> Create(
        Guid recipeId,
        Name name,
        decimal amount,
        Unit unit)
    {
        var ingredient = new Ingredient(
            Guid.NewGuid(),
            recipeId,
            name,
            amount,
            unit);

        return ingredient;
    }
}
