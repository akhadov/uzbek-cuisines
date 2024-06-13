using SharedKernel;

namespace Domain.Recipes;
public static class RecipeErrors
{
    public static Error NotFound(Guid recipeId) => Error.NotFound(
        "Recipes.NotFound",
        $"Recipe with id: {recipeId} was not found.");
}
