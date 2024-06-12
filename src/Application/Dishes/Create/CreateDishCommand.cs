using Application.Abstractions.Messaging;

namespace Application.Dishes.Create;
public sealed record CreateDishCommand(string Name) : ICommand<Guid>;
