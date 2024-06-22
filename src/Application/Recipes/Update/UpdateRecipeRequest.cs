namespace Application.Recipes.Update;
public sealed record UpdateRecipeRequest(
    string Description,
    int PrepTime,
    int CookTime,
    int Servings,
    string ImagePath);
