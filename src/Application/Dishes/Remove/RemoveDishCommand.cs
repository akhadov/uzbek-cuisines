using Application.Abstractions.Messaging;

namespace Application.Dishes.Remove;
public sealed record RemoveDishCommand(Guid DishId) : ICommand;
