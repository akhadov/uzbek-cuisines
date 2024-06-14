using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Categories;
using Domain.Dishes;
using Domain.RecipeIngredients;
using Domain.Recipes;
using Domain.Users;
using SharedKernel;

namespace Application.Recipes.Create;
internal sealed class CreateRecipeCommandHandler(
    IUserRepository userRepository,
    IDishRepository dishRepository,
    ICategoryRepository categoryRepository,
    IRecipeIngredientRepository recipeIngredientRepository,
    IRecipeRepository recipeRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateRecipeCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound(request.UserId));
        }

        Dish? dish = await dishRepository.GetByIdAsync(request.DishId, cancellationToken);
        if (dish is null)
        {
            return Result.Failure<Guid>(DishErrors.NotFound(request.DishId));
        }

        Category? category = await categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);
        if (category is null)
        {
            return Result.Failure<Guid>(CategoryErrors.NotFound(request.CategoryId));
        }

        RecipeIngredient? recipeIngredient = await recipeIngredientRepository.GetByIdAsync(request.RecipeIngredientId, cancellationToken);
        if (recipeIngredient is null)
        {
            return Result.Failure<Guid>(RecipeIngredientErrors.NotFound(request.RecipeIngredientId));
        }

        var description = new Description(request.Description);
        var recipe = Recipe.Create(
            request.UserId,
            request.DishId,
            request.CategoryId,
            request.RecipeIngredientId,
            description,
            request.PrepTime,
            request.CookTime,
            request.Servings,
            request.ImagePath);

        recipeRepository.Insert(recipe);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(recipe.Id);
    }
}
