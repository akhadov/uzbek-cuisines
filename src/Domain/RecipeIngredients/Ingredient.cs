using Domain.RecipeIngredients.Events;
using SharedKernel;

namespace Domain.RecipeIngredients;
public sealed class Ingredient : Entity
{
    private Ingredient(Guid id, Name name)
        : base(id)
    {
        Name = name;
    }
    private Ingredient() { }

    public Name Name { get; private set; }

    public static Ingredient Create(Name name)
    {
        var ingredient = new Ingredient(Guid.NewGuid(), name);

        ingredient.Raise(new IngredientCreatedDomainEvent(ingredient.Id));

        return ingredient;
    }
}
