using Domain.RecipeIngredients.Events;
using SharedKernel;

namespace Domain.RecipeIngredients;
public sealed class RecipeIngredient : Entity
{
    private RecipeIngredient(Guid id, Guid recipeId, List<Ingredient> ingredients, decimal amount, Unit unit) : base(id)
    {
        RecipeId = recipeId;
        Ingredients = ingredients;
        Amount = amount;
        Unit = unit;
    }
    private RecipeIngredient() { }

    public Guid RecipeId { get; private set; }

    public List<Ingredient> Ingredients { get; private set; } = new();

    public decimal Amount { get; private set; }

    public Unit Unit { get; private set; }

    public static RecipeIngredient Create(Guid recipeId, List<Ingredient> ingredients, decimal amount, Unit unit)
    {
        var recipeIngredient = new RecipeIngredient(
            Guid.NewGuid(),
            recipeId,
            ingredients,
            amount,
            unit);

        recipeIngredient.Raise(new RecipeIngredientCreatedDomainEvent(recipeIngredient.Id));

        return recipeIngredient;
    }
}
