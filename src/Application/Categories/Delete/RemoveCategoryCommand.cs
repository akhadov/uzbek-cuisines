using Application.Abstractions.Messaging;

namespace Application.Categories.Delete;
public sealed record RemoveCategoryCommand(Guid CategoryId) : ICommand;
