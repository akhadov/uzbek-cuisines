using Domain.Ingredients;
using Domain.Recipes.Events;
using SharedKernel;

namespace Domain.Recipes;
public sealed class Recipe : Entity
{
    private readonly List<Ingredient> _ingredients = new();

    private Recipe(
        Guid id,
        Guid userId,
        Guid dishId,
        Guid categoryId,
        Description description,
        int prepTime,
        int cookTime,
        int servings,
        string imagePath)
        : base(id)
    {
        UserId = userId;
        DishId = dishId;
        CategoryId = categoryId;
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

    public Description Description { get; private set; }

    public int PrepTime { get; private set; }

    public int CookTime { get; private set; }

    public int Servings { get; private set; }

    public string ImagePath { get; private set; }

    public IReadOnlyList<Ingredient> Ingredients => _ingredients.ToList();

    public static Recipe Create(
        Guid userId,
        Guid dishId,
        Guid categoryId,
        Description description,
        int prepTime,
        int cookTime,
        int servings,
        string imagePath)
    {
        var recipe = new Recipe(
            Guid.NewGuid(),
            userId,
            dishId,
            categoryId,
            description,
            prepTime,
            cookTime,
            servings,
            imagePath);

        recipe.Raise(new RecipeCreatedDomainEvent(recipe.Id));

        return recipe;
    }

    public void Update(
        Description description,
        int prepTime,
        int cookTime,
        int servings,
        string imagePath)
    {
        Description = description;
        PrepTime = prepTime;
        CookTime = cookTime;
        Servings = servings;
        ImagePath = imagePath;
    }

    public Result AddIngredient(
        Name name,
        decimal amount,
        Unit unit)
    {
        Result<Ingredient> result = Ingredient.Create(
            Id,
            name,
            amount,
            unit);

        if (result.IsFailure)
        {
            return result;
        }

        _ingredients.Add(result.Value);

        return Result.Success();
    }

    public Result RemoveIngredient(Guid ingredientId)
    {
        Ingredient? ingredient = _ingredients.Find(i => i.Id == ingredientId);

        if (ingredient is null)
        {
            return Result.Failure(IngredientErrors.NotFound(ingredientId));
        }

        _ingredients.Remove(ingredient);

        return Result.Success();
    }
}
