using Application.Abstractions.Messaging;

namespace Application.Recipes.Remove;
public sealed record RemoveRecipeCommand(Guid RecipeId) : ICommand;

