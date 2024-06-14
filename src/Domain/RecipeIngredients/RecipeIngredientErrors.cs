using SharedKernel;

namespace Domain.RecipeIngredients;
public static class RecipeIngredientErrors
{
    public static Error NotFound(Guid recipeIngredientId) => Error.NotFound(
        "RecipeIngredients.NotFound",
        $"RecipeIngredient with id: {recipeIngredientId} was not found.");
}
