using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Recipes;
using SharedKernel;

namespace Application.Recipes.Remove;
internal sealed class RemoveRecipeCommandHandler(
    IRecipeRepository recipeRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<RemoveRecipeCommand>
{
    public async Task<Result> Handle(RemoveRecipeCommand request, CancellationToken cancellationToken)
    {
        Recipe? recipe = await recipeRepository.GetByIdAsync(
            request.RecipeId,
            cancellationToken);

        if (recipe is null)
        {
            return Result.Failure(RecipeErrors.NotFound(request.RecipeId));
        }

        recipeRepository.Remove(recipe);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
