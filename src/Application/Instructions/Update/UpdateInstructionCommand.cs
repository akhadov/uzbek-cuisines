using Application.Abstractions.Messaging;

namespace Application.Instructions.Update;
public sealed record UpdateInstructionCommand(
    Guid InstructionId,
    int StepNumber,
    string Description) : ICommand<Guid>;
