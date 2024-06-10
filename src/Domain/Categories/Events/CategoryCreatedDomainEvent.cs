using SharedKernel;

namespace Domain.Categories.Events;
public sealed record CategoryCreatedDomainEvent(Guid CategoryId) : IDomainEvent;
