namespace Application.Recipes.Create;
public sealed record CreateRecipeRequest(
    Guid UserId,
    Guid DishId,
    Guid CategoryId,
    string Description,
    int PrepTime,
    int CookTime,
    int Servings,
    string ImagePath);
