using Domain.Dishes.Events;
using SharedKernel;

namespace Domain.Dishes;
public sealed class Dish : Entity
{
    private Dish(Guid id, Name name)
        : base(id)
    {
        Name = name;
    }

    private Dish() { }

    public Name Name { get; private set; }

    public static Dish Create(Name name)
    {
        var category = new Dish(Guid.NewGuid(), name);

        category.Raise(new DishCreatedDomainEvent(category.Id));

        return category;
    }
}
