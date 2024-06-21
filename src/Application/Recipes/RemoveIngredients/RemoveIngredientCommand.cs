using Application.Abstractions.Messaging;

namespace Application.Recipes.RemoveIngredients;
public sealed record RemoveIngredientCommand(Guid RecipeId, Guid IngredientId) : ICommand;
