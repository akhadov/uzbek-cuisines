using SharedKernel;

namespace Domain.Ingredients;
public static class IngredientErrors
{
    public static Error NotFound(Guid ingredientId) => Error.NotFound(
        "Ingredients.NotFound",
        $"Ingredient with id: {ingredientId} was not found.");
}
