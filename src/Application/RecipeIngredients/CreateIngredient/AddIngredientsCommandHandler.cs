using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.RecipeIngredients;
using SharedKernel;

namespace Application.RecipeIngredients.CreateIngredient;
internal sealed class AddIngredientsCommandHandler(
    IRecipeIngredientRepository recipeIngredientRepository,
    IIngredientRepository ingredientRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<AddIngredientsCommand>
{
    public async Task<Result> Handle(AddIngredientsCommand request, CancellationToken cancellationToken)
    {
        RecipeIngredient? recipeIngredient = await recipeIngredientRepository.GetByIdAsync(request.RecipeIngredientId, cancellationToken);
        if (recipeIngredient is null)
        {
            return Result.Failure<Guid>(RecipeIngredientErrors.NotFound(request.RecipeIngredientId));
        }

        var results = request
            .Ingredients
            .Select(ingredientRequest =>
                recipeIngredient.AddIngredient(
                    ingredientRequest.Name))
            .ToList();

        if (results.Any(r => r.IsFailure))
        {
            return Result.Failure(ValidationError.FromResults(results));
        }

        ingredientRepository.InsertRange(recipeIngredient.Ingredients);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
