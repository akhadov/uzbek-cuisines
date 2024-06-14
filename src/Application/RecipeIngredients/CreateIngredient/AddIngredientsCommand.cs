using Application.Abstractions.Messaging;

namespace Application.RecipeIngredients.CreateIngredient;
public sealed record AddIngredientsCommand(
    Guid RecipeIngredientId, List<IngredientRequest> Ingredients) : ICommand;
