using Domain.RecipeIngredients.Events;
using SharedKernel;

namespace Domain.RecipeIngredients;
public sealed class RecipeIngredient : Entity
{
    private RecipeIngredient(Guid id, Guid recipeId, Guid ingredientId, decimal amount, Unit unit) : base(id)
    {
        RecipeId = recipeId;
        IngredientId = ingredientId;
        Amount = amount;
        Unit = unit;
    }
    private RecipeIngredient() { }

    public Guid RecipeId { get; private set; }

    public Guid IngredientId { get; private set; }

    public decimal Amount { get; private set; }

    public Unit Unit { get; private set; }

    public static Ingredient Create(Ingredient ingredient, decimal amount, Unit unit)
    {
        var recipeIngredient = new RecipeIngredient(
            Guid.NewGuid(),
            ingredient.Id,
            amount,
            unit);

        recipeIngredient.Raise(new RecipeIngredientCreatedDomainEvent(ingredient.Id));

        return recipeIngredient;
    }
}
