using Domain.Ingredients;

namespace Application.Recipes.AddIngredients;
public sealed record IngredientRequest(
        Name Name,
        decimal Amount,
        string Unit);
