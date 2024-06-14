namespace Application.RecipeIngredients.CreateRecipeIngredients;
public sealed record CreateRecipeIngredientRequest(
        Guid RecipeId,
        decimal Amount,
        string Unit);
