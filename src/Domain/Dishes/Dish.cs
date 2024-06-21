using Domain.Dishes.Events;
using SharedKernel;

namespace Domain.Dishes;
public sealed class Dish : Entity
{
    private Dish(Guid id, string name)
        : base(id)
    {
        Name = name;
    }

    private Dish() { }

    public string Name { get; private set; }

    public static Dish Create(string name)
    {
        var category = new Dish(Guid.NewGuid(), name);

        category.Raise(new DishCreatedDomainEvent(category.Id));

        return category;
    }

    public void Update(string name)
    {
        Name = name;
    }
}
