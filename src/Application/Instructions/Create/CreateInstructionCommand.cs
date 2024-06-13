using Application.Abstractions.Messaging;

namespace Application.Instructions.Create;
public sealed record CreateInstructionCommand(Guid RecipeId, int StepNumber, string Description)
    : ICommand<Guid>;
