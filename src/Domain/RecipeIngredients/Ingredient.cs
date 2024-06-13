using Domain.RecipeIngredients.Events;
using SharedKernel;

namespace Domain.RecipeIngredients;
public sealed class Ingredient : Entity
{
    private Ingredient(Guid id, Guid recipeIngredientId, Name name)
        : base(id)
    {
        RecipeIngredientId = recipeIngredientId;
        Name = name;
    }
    private Ingredient() { }

    public Guid RecipeIngredientId { get; private set; }

    public Name Name { get; private set; }

    public static Ingredient Create(Guid recipeIngredientId, Name name)
    {
        var ingredient = new Ingredient(Guid.NewGuid(), recipeIngredientId, name);

        ingredient.Raise(new IngredientCreatedDomainEvent(ingredient.Id));

        return ingredient;
    }
}
