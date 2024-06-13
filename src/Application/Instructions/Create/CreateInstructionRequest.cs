namespace Application.Instructions.Create;
public sealed record CreateInstructionRequest(Guid RecipeId, int StepNumber, string Description);
