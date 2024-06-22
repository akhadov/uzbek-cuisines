using Application.Abstractions.Messaging;

namespace Application.Recipes.Update;
public sealed record UpdateRecipeCommand(
    Guid RecipeId,
    string Description,
    int PrepTime,
    int CookTime,
    int Servings,
    string ImagePath) : ICommand<Guid>;
