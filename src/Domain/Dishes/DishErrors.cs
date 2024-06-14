using SharedKernel;

namespace Domain.Dishes;
public static class DishErrors
{
    public static Error NotFound(Guid dishId) => Error.NotFound(
        "Dishes.NotFound",
        $"Dish with id: {dishId} was not found.");
}
