using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Ingredients;
using Domain.Recipes;
using SharedKernel;

namespace Application.Recipes.AddIngredients;
internal sealed class AddIngredientsCommandHandler(
    IIngredientRepository ingredientRepository,
    IRecipeRepository recipeRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<AddIngredientsCommand>
{
    public async Task<Result> Handle(AddIngredientsCommand request, CancellationToken cancellationToken)
    {
        Recipe? recipe = await recipeRepository.GetByIdAsync(request.RecipeId, cancellationToken);

        if (recipe is null)
        {
            return Result.Failure<Guid>(RecipeErrors.NotFound(request.RecipeId));
        }

        var results = request
            .Ingredients
            .Select(ingredientRequest =>
                recipe.AddIngredient(
                    ingredientRequest.Name,
                    ingredientRequest.Amount,
                    new Unit(ingredientRequest.Unit)))
            .ToList();

        if (results.Any(r => r.IsFailure))
        {
            return Result.Failure(ValidationError.FromResults(results));
        }

        ingredientRepository.InsertRange(recipe.Ingredients);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
