using Domain.Recipes.Events;
using SharedKernel;

namespace Domain.Recipes;
public sealed class Recipe : Entity
{
    private Recipe(
        Guid id,
        Guid userId,
        Guid dishId,
        Guid categoryId,
        Guid recipeIngredientId,
        Description description,
        TimeSpan prepTime,
        TimeSpan cookTime,
        int servings,
        string imagePath)
        : base(id)
    {
        UserId = userId;
        DishId = dishId;
        CategoryId = categoryId;
        RecipeIngredientId = recipeIngredientId;
        Description = description;
        PrepTime = prepTime;
        CookTime = cookTime;
        Servings = servings;
        ImagePath = imagePath;
    }

    private Recipe() { }

    public Guid UserId { get; private set; }

    public Guid DishId { get; private set; }

    public Guid CategoryId { get; private set; }

    public Guid RecipeIngredientId { get; private set; }

    public Description Description { get; private set; }

    public TimeSpan PrepTime { get; private set; }

    public TimeSpan CookTime { get; private set; }

    public int Servings { get; private set; }

    public string ImagePath { get; private set; }

    public static Recipe Create(
        Guid userId,
        Guid dishId,
        Guid categoryId,
        Guid recipeIngredientId,
        Description description,
        TimeSpan prepTime,
        TimeSpan cookTime,
        int servings,
        string imagePath)
    {
        var recipe = new Recipe(
            Guid.NewGuid(),
            userId,
            dishId,
            categoryId,
            recipeIngredientId,
            description,
            prepTime,
            cookTime,
            servings,
            imagePath);

        recipe.Raise(new RecipeCreatedDomainEvent(recipe.Id));

        return recipe;
    }
}
