using Application.Abstractions.Messaging;

namespace Application.Recipes.AddIngredients;
public sealed record AddIngredientsCommand(
    Guid RecipeId, List<IngredientRequest> Ingredients) : ICommand;
