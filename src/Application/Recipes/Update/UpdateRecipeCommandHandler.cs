using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Recipes;
using SharedKernel;
using Description = Domain.Recipes.Description;

namespace Application.Recipes.Update;
internal sealed class UpdateRecipeCommandHandler(
    IRecipeRepository recipeRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateRecipeCommand, Guid>
{
    public async Task<Result<Guid>> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
    {
        Recipe? recipe = await recipeRepository.GetByIdAsync(
            request.RecipeId,
            cancellationToken);

        if (recipe is null)
        {
            return Result.Failure<Guid>(RecipeErrors.NotFound(request.RecipeId));
        }

        recipe.Update(
            new Description(request.Description),
            request.PrepTime,
            request.CookTime,
            request.Servings,
            request.ImagePath);

        recipeRepository.Update(recipe);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return recipe.Id;
    }
}
