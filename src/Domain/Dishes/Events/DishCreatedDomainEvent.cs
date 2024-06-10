using SharedKernel;

namespace Domain.Dishes.Events;
public sealed record DishCreatedDomainEvent(Guid DishId) : IDomainEvent;
