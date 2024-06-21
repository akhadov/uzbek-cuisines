using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Ingredients;
using Domain.Recipes;
using SharedKernel;

namespace Application.Recipes.RemoveIngredients;
internal sealed class RemoveIngredientCommandHandler(
    IRecipeRepository recipeRepository,
    IIngredientRepository ingredientRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<RemoveIngredientCommand>
{
    public async Task<Result> Handle(RemoveIngredientCommand request, CancellationToken cancellationToken)
    {
        Recipe? recipe = await recipeRepository.GetByIdAsync(
            request.RecipeId,
            cancellationToken);

        if (recipe is null)
        {
            return Result.Failure(RecipeErrors.NotFound(request.RecipeId));
        }

        Ingredient? ingredient = await ingredientRepository.GetByIdAsync(
            request.IngredientId,
            cancellationToken);

        if (ingredient is null)
        {
            return Result.Failure(IngredientErrors.NotFound(request.IngredientId));
        }

        Result result = recipe.RemoveIngredient(request.IngredientId);

        if (result.IsFailure)
        {
            return result;
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
