using Domain.RecipeIngredients.Events;
using SharedKernel;

namespace Domain.RecipeIngredients;
public sealed class RecipeIngredient : Entity
{
    private readonly List<Ingredient> _ingredients = new();
    private RecipeIngredient(Guid id, Guid recipeId, decimal amount, Unit unit) : base(id)
    {
        RecipeId = recipeId;
        Amount = amount;
        Unit = unit;
    }
    private RecipeIngredient() { }

    public Guid RecipeId { get; private set; }

    public List<Ingredient> Ingredients => _ingredients.ToList();

    public decimal Amount { get; private set; }

    public Unit Unit { get; private set; }

    public static RecipeIngredient Create(Guid recipeId, decimal amount, Unit unit)
    {
        var recipeIngredient = new RecipeIngredient(
            Guid.NewGuid(),
            recipeId,
            amount,
            unit);

        recipeIngredient.Raise(new RecipeIngredientCreatedDomainEvent(recipeIngredient.Id));

        return recipeIngredient;
    }

    public Result AddIngredient(
        Name name)
    {
        Result<Ingredient> result = Ingredient.Create(
            Id,
            name);

        if (result.IsFailure)
        {
            return result;
        }

        _ingredients.Add(result.Value);

        return Result.Success();
    }
}
