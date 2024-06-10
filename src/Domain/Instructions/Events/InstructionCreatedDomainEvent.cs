using SharedKernel;

namespace Domain.Instructions.Events;
public sealed record InstructionCreatedDomainEvent(Guid InstructionId) : IDomainEvent;
