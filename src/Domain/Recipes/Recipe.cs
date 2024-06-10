using Domain.Categories;
using Domain.Dishes;
using Domain.Users;
using SharedKernel;

namespace Domain.Recipes;
public sealed class Recipe : Entity
{
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

    public static Recipe Create(
        User user, 
        Dish dish,
        Category category, 
        Description description, 
        int prepTime, 
        int cookTime,
        int servings)
    {
        var recipe = new Recipe(
            Guid.NewGuid(),
            );
    }
}
