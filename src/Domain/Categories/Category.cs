using Domain.Categories.Events;
using SharedKernel;

namespace Domain.Categories;
public sealed class Category : Entity
{
    private Category(Guid id, Name name)
        : base(id)
    {
        Name = name;
    }

    private Category() { }

    public Name Name { get; private set; }

    public static Category Create(Name name)
    {
        var category = new Category(Guid.NewGuid(), name);

        category.Raise(new CategoryCreatedDomainEvent(category.Id));

        return category;
    }

    public void Update(Name name)
    {
        Name = name;
    }
}
