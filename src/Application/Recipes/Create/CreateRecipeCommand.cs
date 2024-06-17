using Application.Abstractions.Messaging;

namespace Application.Recipes.Create;
public sealed record CreateRecipeCommand(
    Guid UserId,
    Guid DishId,
    Guid CategoryId,
    string Description,
    int PrepTime,
    int CookTime,
    int Servings,
    string ImagePath) : ICommand<Guid>;
