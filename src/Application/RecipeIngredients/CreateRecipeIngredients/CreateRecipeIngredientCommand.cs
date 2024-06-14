using Application.Abstractions.Messaging;

namespace Application.RecipeIngredients.CreateRecipeIngredients;
public sealed record CreateRecipeIngredientCommand(
        Guid RecipeId,
        decimal Amount,
        string Unit) : ICommand<Guid>;
