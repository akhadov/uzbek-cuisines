namespace Domain.Dishes;
public interface IDishRepository
{
    Task<Dish?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Dish dish);

    void Update(Dish dish);

    void Remove(Dish dish);
}
