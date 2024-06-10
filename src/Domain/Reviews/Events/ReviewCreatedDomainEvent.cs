using SharedKernel;

namespace Domain.Reviews.Events;
public sealed record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;
