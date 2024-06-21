using Application.Abstractions.Messaging;

namespace Application.Instructions.Remove;
public sealed record RemoveInstructionCommand(Guid InstructionId) : ICommand;
