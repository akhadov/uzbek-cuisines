using Application.Abstractions.Messaging;

namespace Application.Dishes.Update;
public sealed record UpdateDishCommand(Guid DishId, string Name) : ICommand<Guid>;
