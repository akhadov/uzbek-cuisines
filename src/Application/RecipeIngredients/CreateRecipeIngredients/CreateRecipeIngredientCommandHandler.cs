using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.RecipeIngredients;
using Domain.Recipes;
using SharedKernel;

namespace Application.RecipeIngredients.CreateRecipeIngredients;
internal sealed class CreateRecipeIngredientCommandHandler(
    IRecipeRepository recipeRepository,
    IRecipeIngredientRepository recipeIngredientRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateRecipeIngredientCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateRecipeIngredientCommand request, CancellationToken cancellationToken)
    {
        Recipe? recipe = await recipeRepository.GetByIdAsync(request.RecipeId, cancellationToken);

        if (recipe is null)
        {
            return Result.Failure<Guid>(RecipeErrors.NotFound(request.RecipeId));
        }

        var unit = new Unit(request.Unit);

        var recipeIngredient = RecipeIngredient.Create(request.RecipeId, request.Amount, unit);

        recipeIngredientRepository.Insert(recipeIngredient);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return recipeIngredient.Id;
    }
}
